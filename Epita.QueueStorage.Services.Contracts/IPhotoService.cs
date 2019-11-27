using System.IO;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;

namespace Epita.QueueStorage.Services.Contracts
{
    public interface IPhotoService
    {
        /// <summary>
        /// Upload a photo represented as a Stream
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
        /// Get the Information of the photo
        /// Only the owner of the photo can access the photo
        /// </summary>
        /// <param name="userId">The owner of the photo</param>
        /// <param name="photoId">The identifier of the photo</param>
        /// <param name="status"></param>
        /// <returns>true if success, false otherwise</returns>
        Task<bool> UpdateByIdAsync(string userId, string photoId, Status status);

        /// <summary>
        /// Delete the photo of the user
        /// </summary>
        /// <param name="userId">The owner of the photo</param>
        /// <param name="photoId">The identifier of the photo</param>
        /// <returns>true if success, false otherwise</returns>
        Task<bool> DeleteByIdAsync(string userId, string photoId);
    }
}