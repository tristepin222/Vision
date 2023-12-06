using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using VisionTest.Interfaces;

namespace VisionTest.Database
{
    public class DataSaver
    {
        public static void SaveImage(IImageData imageData)
        {
            SqlConnector.sqlConnection.Open();
        }
    }
}
