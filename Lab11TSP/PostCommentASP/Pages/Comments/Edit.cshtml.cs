using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostCommentASP.Models;
using ServiceReferencePostComment;

namespace PostCommentASP.Pages.Comments
{
    public class EditModel : PageModel
    {
        PostCommentClient pcc = new PostCommentClient();

        [BindProperty]
        public CommentDTO CommentDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Comment comment = await pcc.GetCommentByIdAsync(id.Value);

            if (comment == null)
                return NotFound();

            CommentDTO = new CommentDTO();

            CommentDTO.CommentId = comment.Id;
            CommentDTO.Text = comment.Text;
            CommentDTO.PostPostId = comment.PostPostId;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Comment comment = new Comment();
            comment.Id = CommentDTO.CommentId;
            comment.Text = CommentDTO.Text;
            comment.PostPostId = CommentDTO.PostPostId;

            try
            {
                var result = await pcc.UpdateCommentAsync(comment);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

            return RedirectToPage("./List");
        }
    }
}