using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using VisionTest.Interfaces;
using Object = Google.Apis.Storage.v1.Data.Object;

namespace VisionTest.Datas
{
    public class AwsDataObjectImpl : IDataObject
    {
        private string bucketName;

        public AwsDataObjectImpl(string bucketName)
        {
            this.bucketName = bucketName;
        }
        public bool DoesObjectExist()
        {
            throw new NotImplementedException();
        }

        public byte[] DownloadObject(string localFullPath)
        {
            var storage = StorageClient.Create();
            MemoryStream stream = new MemoryStream();
            Object file = storage.DownloadObject(bucketName, localFullPath, stream);
            return stream.ToArray();
        }

        public string PublishObject(string remoteFullPath, int expirationTime = 90)
        {
            throw new NotImplementedException();
        }

        public void RemoveObject(string remoteFullPath, bool recursive = false)
        {
            throw new NotImplementedException();
        }

        public void UploadObject(byte[] file, string remoteFullPath)
        {
            var storage = StorageClient.Create();
            MemoryStream stream = new MemoryStream(file);
            storage.UploadObject(bucketName, remoteFullPath, null, stream);
        }

        private bool DoesBucketExit()
        {
            var storage = StorageClient.Create();
            return storage.GetBucket(bucketName) != null;
        }

        private void CreateBucket()
        {
            throw new NotImplementedException();
        }

        private void RemoveBucket()
        {
            throw new NotImplementedException();
        }

        public void CreateObject(byte[] file, string remoteFullPath)
        {
            throw new NotImplementedException();
        }
    }
}
