using Google.Cloud.Storage.V1;
using VisionTest.Interfaces;
using Object = Google.Apis.Storage.v1.Data.Object;

using VisionTest.Exceptions;

namespace VisionTest.Datas
{
    public class GoogleDataObjectImpl : IDataObject
    {
        private string bucketName;

        public GoogleDataObjectImpl(string bucketName)
        {
            this.bucketName = bucketName;
        }
        public async Task<bool> DoesExists(string remoteFullPath)
        {
            var storage =  StorageClient.Create();
            try
            {
                if (remoteFullPath == bucketName)
                {
                    await storage.GetBucketAsync(remoteFullPath);
                    return true;
                }
                else
                {
                    await storage.GetObjectAsync(bucketName, remoteFullPath);
                    return true;
                }
            }
            catch
            { 
            return false;
            }
        }

        public async Task Download(string remoteFullPath,string localFullPath = "")
        {
            if (await DoesExists(remoteFullPath))
            {
                var storage = StorageClient.Create();
                MemoryStream stream = new MemoryStream();
                Object file = await storage.DownloadObjectAsync(bucketName, remoteFullPath, stream);
                File.WriteAllBytes(localFullPath, stream.GetBuffer());
            }
            throw new ObjectNotFoundException();
        }

        public Task<string> Publish(string remoteFullPath, int expirationTime = 90)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(string remoteFullPath, bool recursive = false)
        {
            var storage = StorageClient.Create();
            if (recursive) 
            {
                foreach (var storageObject in storage.ListObjects(bucketName))
                {
                    string fileName = remoteFullPath.Replace(bucketName + "/", "");
                    if (storageObject.Name.StartsWith(fileName, StringComparison.OrdinalIgnoreCase))
                    {
                        await storage.DeleteObjectAsync(bucketName, storageObject.Name);
                    }
                }
            }
            if (await DoesExists(remoteFullPath))
            {
                await storage.DeleteObjectAsync(bucketName, remoteFullPath);
            }
        }

        public async Task Upload(string file, string remoteFullPath)
        {
            var storage = StorageClient.Create();
            using var fileStream = File.OpenRead(file);
            await storage.UploadObjectAsync(bucketName, remoteFullPath, null, fileStream);
        }

    }
}
