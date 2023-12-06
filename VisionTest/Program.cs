// See https://aka.ms/new-console-template for more information
using Google.Api;
using Google.Cloud.Vision.V1;
using Microsoft.Data.SqlClient;
using VisionTest.Analysers;
using VisionTest.Database;
using VisionTest.Interfaces;

new SqlConnector("Data Source=SC-C333-PC01;Initial Catalog=Vision;Integrated Security=True;Trust Server Certificate=True");

SqlConnector.sqlConnection.Open();

string imageName = "20230727_140005.jpg";
GoogleAnalyser analyser = new GoogleAnalyser();
IImageData img = analyser.Analyse(imageName, 3, 50);

SqlCommand command;
string query = "INSERT into vision (ImageData,labels,confidences) VALUES (@ImageData,@labels,@confidences)";
command = new SqlCommand(query);
command.Connection = SqlConnector.sqlConnection;

command.Parameters.Add("@ImageData", System.Data.SqlDbType.VarChar, 500).Value = img.ImageName;
command.Parameters.Add("@labels", System.Data.SqlDbType.VarChar, 1000).Value = img.Labels.ToString();
command.Parameters.Add("@confidences", System.Data.SqlDbType.VarChar, 1000).Value = img.Confidences.ToString();

command.ExecuteNonQuery();
SqlConnector.sqlConnection.Close();


