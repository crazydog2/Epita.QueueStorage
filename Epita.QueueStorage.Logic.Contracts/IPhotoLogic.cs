using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;

namespace Epita.QueueStorage.Logic.Contracts
{
    public interface IPhotoLogic
    {
        /// <summary>
        /// Upload a photo represented as a Stream
        /// The status of the Photo after upload should be uploaded
        /// If the photo already exists, the return value should be null
        /// </summary>
        /// <param name="file">The photo Stream</param>
        /// <param name="userId">The userId of the Owner of the photo</param>
        /// <param name="fileName">The original name of the file</param>
        /// <returns>The unique identifier of teh newly created photo</returns>
        Task<string> UploadAsync(
            Stream file,
            string userId,
            string fileName);

        /// <summary>
        /// Get the Information of the photo
        /// Only the owner of the photo can access the photo
        /// </summary>
        /// <param name="userId">The owner of the photo</param>
        /// <param name="photoId">The identifier of the photo</param>
        /// <returns>The photo information matching the photoId</returns>
        Task<Photo> GetByIdAsync(string userId, string photoId);

        /// <summary>
        /// Delete the photo of the user
        /// If the photo does not exist return false;
        /// </summary>
        /// <param name="userId">The owner of the photo</param>
        /// <param name="photoId">The identifier of the photo</param>
        /// <returns>true if success, false otherwise</returns>
        Task<bool> DeleteByIdAsync(string userId, string photoId);

        /// <summary>
        /// Append tags to the current photo
        /// </summary>
        /// <param name="userId">The owner of the photo</param>
        /// <param name="photoId">The identifier of the photo</param>
        /// <param name="tags">The list of the tags to append to the current tags of the photo</param>
        /// <returns>true if success, false otherwise</returns>
        Task<bool> AddTagsAsync(string userId, string photoId, IEnumerable<string> tags);

        /// <summary>
        /// Delete the selected tags onto the current photo
        /// If the tag does not exist onto the photo, therefore ignore the tag
        /// </summary>
        /// <param name="userId">The owner of the photo</param>
        /// <param name="photoId">The identifier of the photo</param>
        /// <param name="tags">The list of the tags to delete from the current tags of the photo</param>
        /// <returns>true if success, false otherwise</returns>
        Task<bool> DeleteTagsAsync(string userId, string photoId, IEnumerable<string> tags);

        /// <summary>
        /// Update the list of the tags associated with the current photo
        /// If some tags already existed onto the photo, replace all the tags with the new tags
        /// </summary>
        /// <param name="userId">The owner of the photo</param>
        /// <param name="photoId">The identifier of the photo</param>
        /// <param name="tags">The list of the tags to Update from the current tags of the photo</param>
        /// <returns>true if success, false otherwise</returns>
        Task<bool> UpdateTagsAsync(string userId, string photoId, IEnumerable<string> tags);
    }
}