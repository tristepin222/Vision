using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionTest.Interfaces;

namespace VisionTest
{
    internal class AwsDataObjectImpl : IDataObject
    {
        private string bucketName;

        public AwsDataObjectImpl(string bucketName)
        {

        }
        public bool DoesObjectExist()
        {
            throw new NotImplementedException();
        }

        public IImageData DownloadObject(IImageData image, string localFullPath)
        {
            throw new NotImplementedException();
        }

        public string PublishObject(string remoteFullPath, int expirationTime = 90)
        {
            throw new NotImplementedException();
        }

        public void RemoveObject(string remoteFullPath, bool recursive = false)
        {
            throw new NotImplementedException();
        }

        public void UploadObject(IImageData image, string remoteFullPath)
        {
            throw new NotImplementedException();
        }

        private bool DoesBucketExit()
        { 
            throw new NotImplementedException(); 
        }

        private void CreateBucket() 
        { 
            throw new NotImplementedException(); 
        }

        private void RemoveBucket()
        { 
            throw new NotImplementedException(); 
        }

        public void CreateObject(IImageData image, string remoteFullPath) 
        {
            throw new NotImplementedException(); 
        }
    }
}
