using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VisionTest.Interfaces;
using IDataObject = VisionTest.Interfaces.IDataObject;

namespace VisionTest
{
    internal class MySQLDataObjectImpl : IDataObject
    {
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
    }
}
