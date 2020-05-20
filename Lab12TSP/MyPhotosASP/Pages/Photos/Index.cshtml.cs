using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReferenceMyPhotos;

namespace MyPhotosASP.Pages.Photos
{
    public class IndexModel : PageModel
    {
        private MyPhotosServiceClient service = new MyPhotosServiceClient();

        private readonly IWebHostEnvironment hostEnvironment;

        public List<MultimediaDTO> Multimedias { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(IWebHostEnvironment environment)
        {
            hostEnvironment = environment;

            Multimedias = new List<MultimediaDTO>();
        }

        public async Task OnGetAsync()
        {
            List<MultimediaDTO> everyMultimedia = await service.GetEveryMultimediaAsync();

            if (!string.IsNullOrEmpty(SearchString))
                everyMultimedia = everyMultimedia.Where(s => s.Path.Contains(SearchString)).ToList();

            foreach (MultimediaDTO multimedia in everyMultimedia)
            {
                var uploads = Path.Combine(hostEnvironment.WebRootPath, "uploads");
                var filePath = Path.ChangeExtension(Path.Combine(uploads, multimedia.Id.ToString()), Path.GetExtension(multimedia.Path));

                if (!System.IO.File.Exists(filePath))
                    System.IO.File.Copy(multimedia.Path, filePath);

                Multimedias.Add(multimedia);
            }
        }

        public string GetUploadPath(MultimediaDTO multimedia)
        {
            return "uploads/" + multimedia.Id + Path.GetExtension(multimedia.Path);
        }

        public string GetNameFromPath(MultimediaDTO multimedia)
        {
            return Path.GetFileName(multimedia.Path);
        }
    }
}