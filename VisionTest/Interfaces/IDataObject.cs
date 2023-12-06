using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionTest.Interfaces
{
    public interface IDataObject
    {
        public bool DoesObjectExist();

        public void UploadObject(IImageData file, string remoteFullPath);

        public IImageData DownloadObject(IImageData file, string localFullPath);

        public string PublishObject(string remoteFullPath, int expirationTime = 90);

        public void RemoveObject(string remoteFullPath, bool recursive = false);

    }
}
