using System;
using System.IO;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;
using Epita.QueueStorage.Services.Configuration;
using Epita.QueueStorage.Services.Contracts;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Epita.QueueStorage.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly CloudBlobClient blobClient;

        public PhotoService(AzureConfiguration configuration)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(configuration.ConnectionString);

            blobClient = storageAccount.CreateCloudBlobClient();
        }

        public Task<string> UploadAsync(Stream file, string userId, string fileName)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<Photo> GetByIdAsync(string userId, string photoId)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<bool> UpdateByIdAsync(string userId, string photoId, Status status)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(string userId, string photoId)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}