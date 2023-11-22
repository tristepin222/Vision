// See https://aka.ms/new-console-template for more information
using Google.Api;
using Google.Cloud.Vision.V1;


Console.WriteLine("Hello, World!");

Image image1 = Image.FromFile("Nigiri_Sushi_(26478725732).jpg");

ImageAnnotatorClient client = ImageAnnotatorClient.Create();

IReadOnlyList<EntityAnnotation> result = client.DetectLabels(image1);

foreach (EntityAnnotation face in result)
{
    Console.WriteLine($"Confidence: {(int)(face.Score * 100)}%");
}