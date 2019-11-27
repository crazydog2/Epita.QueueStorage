using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Epita.QueueStorage.Logic.Contracts;
using Epita.QueueStorage.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epita.QueueStorage.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoLogic photoLogic;

        public PhotosController(IPhotoLogic photoLogic)
        {
            this.photoLogic = photoLogic;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] IFormFile file)
        {
            string userId = HttpContext.User.Identity.Name;

            await using Stream stream = file.OpenReadStream();

            string filename = file.FileName;

            string photoId = await photoLogic.UploadAsync(stream, userId, filename).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(photoId))
            {
                return CreatedAtAction(nameof(GetByIdAsync), new { photoId }, photoId);
            }

            return BadRequest();
        }

        [HttpGet("{photoId}")]
        public async Task<IActionResult> GetByIdAsync(string photoId)
        {
            string userId = HttpContext.User.Identity.Name;

            Photo photo = await photoLogic.GetByIdAsync(userId, photoId);

            if (photo == null)
            {
                return NotFound();
            }

            return Ok(photo);
        }

        [HttpDelete("{photoId}")]
        public async Task<IActionResult> DeleteByIdAsync(string photoId)
        {
            string userId = HttpContext.User.Identity.Name;

            bool success = await photoLogic.DeleteByIdAsync(userId, photoId);

            if (!success)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost("{photoId}/tags")]
        public async Task<IActionResult> AddTagsIdAsync(string photoId, [FromBody] IEnumerable<string> tags)
        {
            string userId = HttpContext.User.Identity.Name;

            bool success = await photoLogic.AddTagsAsync(userId, photoId, tags);

            if (!success)
            {
                return BadRequest();
            }

            return NoContent();
        }
        
        [HttpPut("{photoId}/tags")]
        public async Task<IActionResult> UpdateTagsIdAsync(string photoId, [FromBody] IEnumerable<string> tags)
        {
            string userId = HttpContext.User.Identity.Name;

            bool success = await photoLogic.UpdateTagsAsync(userId, photoId, tags);

            if (!success)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{photoId}/tags")]
        public async Task<IActionResult> DeleteTagsIdAsync(string photoId, [FromBody] IEnumerable<string> tags)
        {
            string userId = HttpContext.User.Identity.Name;

            bool success = await photoLogic.DeleteTagsAsync(userId, photoId, tags);

            if (!success)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}