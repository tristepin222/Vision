// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using VisionTest;
using VisionTest.Analysers;
using VisionTest.Datas;
using VisionTest.Interfaces;



Vision vision = new Vision();


vision.Call();

await vision.Publish(Environment.GetEnvironmentVariable("Image"));

await vision.Analyze(Environment.GetEnvironmentVariable("Image"));

vision.Upload("query", "query");

