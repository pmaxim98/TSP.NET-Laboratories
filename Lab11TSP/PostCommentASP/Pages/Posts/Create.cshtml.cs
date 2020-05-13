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
    public class CreateModel : PageModel
    {
        PostCommentClient pcc = new PostCommentClient();
        
        [BindProperty] 
        public PostDTO PostDTO { get; set; }

        public IActionResult OnGet() 
        { 
            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync() 
        { 
            if (!ModelState.IsValid) 
            { 
                return Page();
            } 
            
            Post post = new Post(); 
            post.Domain = PostDTO.Domain; 
            post.Description = PostDTO.Description; 
            post.Date = PostDTO.Date; 
            var result = await pcc.AddPostAsync(post); 
            
            if (!result) 
            { 
                return RedirectToAction("Error"); 
            } 
            
            return RedirectToPage("./Index"); 
        }
    }
}