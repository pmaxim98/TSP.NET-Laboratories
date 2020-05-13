using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostCommentASP.Models;
using ServiceReferencePostComment;

namespace PostCommentASP.Pages.Posts
{
    public class EditModel : PageModel
    {
        PostCommentClient pcc = new PostCommentClient();

        [BindProperty]
        public PostDTO PostDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Post post = await pcc.GetPostByIdAsync(id.Value);

            if (post == null)
                return NotFound();

            PostDTO = new PostDTO();

            PostDTO.PostId = post.PostId;
            PostDTO.Domain = post.Domain;
            PostDTO.Description = post.Description;
            PostDTO.Date = post.Date;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Post post = new Post();
            post.PostId = PostDTO.PostId;
            post.Domain = PostDTO.Domain;
            post.Description = PostDTO.Description;
            post.Date = PostDTO.Date;

            var result = await pcc.UpdatePostAsync(post);

            if (result == null)
                return RedirectToAction("Error");

            return RedirectToPage("./Index");
        }
    }
}