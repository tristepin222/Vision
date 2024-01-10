﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionTest.Interfaces;

namespace VisionTest.Datas
{
    public class SQLDumber
    {
        public static void Dumb(IImageData img)
        {

            MySqlConnection conn;

            conn = new MySqlConnection();
            conn.ConnectionString = Environment.GetEnvironmentVariable("DataBaseConnection");

            conn.Open();

            List<string> queries = new List<string>();
            string currentQuery = "";
            MySqlCommand command;
            string query = "INSERT into Image (Path) VALUES (@imageString)";

            command = new MySqlCommand(query);
            command.Connection = conn;

            command.Parameters.Add("@imageString", MySqlDbType.VarChar, 45).Value = img.ImageName;

            foreach (MySqlParameter p in command.Parameters)
            {
                currentQuery = query.Replace(p.ParameterName, p.Value.ToString());
            }
            queries.Add(currentQuery);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;

            query = "INSERT into Labels (Name, Confidence, Image_idImage) VALUES (@Name, @confidence, @idImage)";

            int index = 0;
            foreach (string image in img.Labels)
            {
                currentQuery = query;
                currentQuery = currentQuery.Replace("@Name", image);
                currentQuery = currentQuery.Replace("@confidence", img.Confidences[index].ToString());
                currentQuery = currentQuery.Replace("@idImage", id.ToString());
                queries.Add(currentQuery);
                command.ExecuteNonQuery();

                index++;
            }
            conn.Close();
            File.WriteAllLines("query", queries);
        }
    }
}
