using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace dump_to_asphyxia_core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Asphyxia ID:");
            string refid = Console.ReadLine();
            XElement score_dump = XElement.Load("dump.xml");
            var infos = score_dump.Element("game").Element("music").Elements("info");
            List<string> scores = new List<string>();
            foreach (var info in infos)
            {
                string[] record = info.Element("param").Value.Split(" ");
                AsyLine line = new AsyLine();
                line.Collection = "music";
                line.Mid = long.Parse(record[0]);
                line.Type = long.Parse(record[1]);
                line.Score = long.Parse(record[2]);
                line.Exscore = 0;
                line.Clear = long.Parse(record[3]);
                line.Grade = long.Parse(record[4]);
                line.ButtonRate = long.Parse(record[7]) / 200;
                line.LongRate = long.Parse(record[8]) / 200;
                line.VolRate = long.Parse(record[9]) / 200;
                line.S = "plugins_profile";
                line.Refid = refid;
                line.Id = GetRandomString(16);
                AtedAt atedAt = new AtedAt();
                atedAt.Date = System.DateTime.Now.Ticks;
                line.CreatedAt = atedAt;
                line.UpdatedAt = atedAt;
                scores.Add(JsonConvert.SerializeObject(line));
            }
            File.WriteAllLines("out.db", scores);
        }
        public static string GetRandomString(int length)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = "";
            str += "0123456789"; 
            str += "abcdefghijklmnopqrstuvwxyz"; 
            str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
    }
}
