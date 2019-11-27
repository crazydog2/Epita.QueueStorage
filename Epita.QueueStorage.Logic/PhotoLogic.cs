using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Epita.QueueStorage.Logic.Contracts;
using Epita.QueueStorage.Model;
using Epita.QueueStorage.Services.Contracts;

namespace Epita.QueueStorage.Logic
{
    public class PhotoLogic : IPhotoLogic
    {
        private readonly IComputeService computeService;
        private readonly IPhotoService photoService;

        public PhotoLogic(
            IComputeService computeService,
            IPhotoService photoService)
        {
            this.computeService = computeService;
            this.photoService = photoService;
        }

        public async Task<string> UploadAsync(
            Stream file, 
            string userId, 
            string fileName)
        {
            string photoId = await photoService.UploadAsync(file, userId, fileName).ConfigureAwait(false);

            return string.IsNullOrEmpty(photoId) ? null : photoId;
        }

        public Task<Photo> GetByIdAsync(string userId, string photoId)
        {
            // TODO
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIdAsync(string userId, string photoId)
        {
            bool deleted = await photoService.DeleteByIdAsync(userId, photoId).ConfigureAwait(false);

            if (!deleted)
            {
                return false;
            }

            // TODO
            throw new NotImplementedException();
        }

        public async Task<bool> AddTagsAsync(string userId, string photoId, IEnumerable<string> tags)
        {
            Photo photo = await GetByIdAsync(userId, photoId).ConfigureAwait(false);

            if (photo == null)
            {
                return false;
            }

            // TODO
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTagsAsync(string userId, string photoId, IEnumerable<string> tags)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTagsAsync(string userId, string photoId, IEnumerable<string> tags)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}