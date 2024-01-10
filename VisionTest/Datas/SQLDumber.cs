using VisionTest.Interfaces;

namespace VisionTest.Datas
{
    public class SQLDumber
    {
        public static void Dumb(IImageData img)
        {
            List<string> queries = new List<string>();
            string currentQuery = "";
            string query = "INSERT into Image (Path) VALUES (@imageString)";

            currentQuery = query.Replace("imageString", img.ImageName.ToString());

            queries.Add(currentQuery);

            query = "INSERT into Labels (Name, Confidence, Image_idImage) VALUES (@Name, @confidence, @idImage)";

            int index = 0;
            foreach (string image in img.Labels)
            {
                currentQuery = query;
                currentQuery = currentQuery.Replace("@Name", image);
                currentQuery = currentQuery.Replace("@confidence", img.Confidences[index].ToString());
                currentQuery = currentQuery.Replace("@idImage", 21.ToString());
                queries.Add(currentQuery);

                index++;
            }
            File.WriteAllLines("query", queries);
        }
    }
}
