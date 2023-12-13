﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisionTest.Datas;

namespace TestRiaApiEvaluationModel
{
    /// <summary>
    /// This test class is designed to confirm the AwsBucketManager class's behavior
    /// </summary>
    [TestClass]
    public class TestAwsBucketManagerImpl
    {

        #region private attributes
        private AwsDataObjectImpl bucketManager;
        private string domain;
        private string bucketName;
        private string bucketUrl;
        private string imageName;
        private string pathToTestFolder;
        private string fullPathToImage;
        private string prefixObjectDownloaded;
        #endregion private attributes

        /// <summary>
        /// This test method initializes the context before each test method run.
        /// </summary>
        [TestInitialize()]
        public void Init()
        {
            this.pathToTestFolder = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "testData");
            this.bucketName = "testbucket";
            this.domain = "aws.dev.actualit.info";
            this.bucketUrl = bucketName + "." + this.domain;
            this.imageName = "emiratesa380.jpg";
            this.fullPathToImage = pathToTestFolder + "\\" + imageName;
            this.prefixObjectDownloaded = "downloaded";
            this.bucketManager = new AwsDataObjectImpl(this.bucketUrl);
        }

        /// <summary>
        /// This test method checks the method in charge of creating a new data object
        /// Note: the bucket exists
        /// </summary>
        [TestMethod]
        public async Task CreateObject_CreateObjectWithExistingBucket_Success()
        {
            //given
            string fileName = this.imageName;
            string objectUrl = this.bucketUrl + "/" + this.imageName;
            await this.bucketManager.CreateObject(this.bucketUrl);
            Assert.IsTrue(await this.bucketManager.Exists(this.bucketUrl));
            Assert.IsFalse(await this.bucketManager.Exists(objectUrl));

            //when
            await this.bucketManager.CreateObject(objectUrl, this.pathToTestFolder + "//" + fileName);

            //then
            Assert.IsTrue(await this.bucketManager.Exists(objectUrl));
        }

        /// <summary>
        /// This test method checks the method in charge of download item in an existing bucket
        /// </summary>
        [TestMethod]
        public async Task DownloadObject_NominalCase_Success()
        {
            //given
            string objectUrl = bucketUrl + "//" + this.imageName;
            string destinationFullPath = this.pathToTestFolder + "//" + this.prefixObjectDownloaded + this.imageName;
            await this.bucketManager.CreateObject(objectUrl, this.pathToTestFolder + "//" + this.imageName);

            Assert.IsTrue(await this.bucketManager.Exists(bucketUrl));

            //when
            await this.bucketManager.DownloadObject(objectUrl, destinationFullPath);

            //then
            Assert.IsTrue(File.Exists(destinationFullPath));
        }

        /// <summary>
        /// This test method checks the method in charge of testing the existence of an object
        /// </summary>
        [TestMethod]
        public async Task Exists_NominalCase_Success()
        {
            //given
            Task t = this.bucketManager.CreateObject(this.bucketUrl);
            await t;
            bool actualResult;

            //when
            actualResult = await this.bucketManager.Exists(bucketUrl);

            //then
            Assert.IsTrue(actualResult);
        }

        /// <summary>
        /// This test method checks the method in charge of testing the existence of an object
        /// When the object doesn't exist (object is the file in an existing bucket)
        /// </summary>
        [TestMethod]
        public async Task Exists_ObjectNotExistFile_Success()
        {
            //given
            await this.bucketManager.CreateObject(this.bucketUrl);
            string notExistingFile = bucketUrl + "//" + "notExistingFile.jpg";
            Assert.IsTrue(await this.bucketManager.Exists(bucketUrl));
            bool actualResult;

            //when
            actualResult = await this.bucketManager.Exists(notExistingFile);

            //then
            Assert.IsFalse(actualResult);
        }

        /// <summary>
        /// This test method checks the method in charge of removing an existing object
        /// Case: bucket with content
        /// </summary>
        [Test]
        public async Task RemoveObject_NotEmptyBucket_Success()
        {
            //given
            string fileName = this.imageName;
            string objectUrl = this.bucketUrl + "/" + this.imageName;
            await this.bucketManager.CreateObject(this.bucketUrl);
            await this.bucketManager.CreateObject(objectUrl, this.pathToTestFolder + "//" + fileName);

            Assert.IsTrue(await this.bucketManager.Exists(bucketUrl));
            Assert.IsTrue(await this.bucketManager.Exists(objectUrl));

            //when
            await this.bucketManager.RemoveObject(this.bucketUrl);

            //then
            Assert.IsFalse(await this.bucketManager.Exists(bucketUrl));
        }

        /// <summary>
        /// This test method cleans up the context after each test method run.
        /// </summary>
        [TearDown]
        public async Task Cleanup()
        {
            string destinationFullPath = this.pathToTestFolder + "\\" + this.prefixObjectDownloaded + this.imageName;

            if (File.Exists(destinationFullPath))
            {
                File.Delete(destinationFullPath);
            }
        }
    }
}