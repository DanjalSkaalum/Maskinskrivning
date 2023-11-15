using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Maskinskrivning
{
    internal class Io
    {
        public static int[] LoadHighscore()
        {

            int[] highscore = new int[10];
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (Stream reader = new FileStream(path + "/points.xml", FileMode.Open))
            {
                XmlSerializer seralizer = new(typeof(int[]));
                highscore = (int[])seralizer.Deserialize(reader);
                //string[] sa = highscore;
                //File.WriteAllLines("points.txt", highscore);
                //if ((!File.Exists("points.txt")) //Checking if points.txt exists or not
                //    {
                //    using (FileStream fs = File.Create("points.txt")) //Creates points.txt
                //    {
                //        fs.
                //    }
                //}
            }
            return highscore;
        }
        static void SaveHighScore(int[] highscore)
        {
            string url = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (FileStream stream = File.Create("points.txt"))
            {
                XmlSerializer seralizer = new(typeof(int[]));
                seralizer.Serialize(stream, highscore);
            }
        }
    }
}
