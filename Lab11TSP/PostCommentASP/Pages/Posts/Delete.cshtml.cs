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
    public class DeleteModel : PageModel
    {
        PostCommentClient pcc = new PostCommentClient();
        
        [BindProperty] 
        public PostDTO PostDTO { get; set; }

        public DeleteModel() { }

        public async Task<IActionResult> OnGetAsync(int? id) 
        { 
            if (id == null) 
                return NotFound(); 
            
            var post = await pcc.GetPostByIdAsync(id.Value); 
            
            if (post != null) 
            { 
                PostDTO = new PostDTO(); 
                PostDTO.PostId = post.PostId; 
                PostDTO.Domain = post.Domain; 
                PostDTO.Description = post.Description; 
                PostDTO.Date = post.Date; 

                return Page();
            } 
            else 
                return NotFound(); 
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) 
                return NotFound();

            try 
            { 
                await pcc.DeletePostAsync(id.Value); 
            } 
            catch (Exception) 
            { 
                return RedirectToPage("/Error"); 
            } 
            
            return RedirectToPage("./Index"); 
        }
    }
}