using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionTest.Interfaces
{
    public interface IDataObject
    {
        public Task<bool> DoesExists(string remoteFullPath);

        public Task Upload(string file, string remoteFullPath);

        public Task Download(string remoteFullPath, string localFullPath = "");

        public Task<string> Publish(string remoteFullPath, int expirationTime = 90);

        public Task Remove(string remoteFullPath, bool recursive = false);

    }
}
