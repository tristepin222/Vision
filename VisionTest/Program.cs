// See https://aka.ms/new-console-template for more information
using VisionTest;



Vision vision = new Vision();


vision.Call();

await vision.Publish(Environment.GetEnvironmentVariable("Image"));

await vision.Analyze(Environment.GetEnvironmentVariable("Image"));

vision.Upload("query", "query");

