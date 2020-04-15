using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace cw_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            try
            {
                path = @"C:\Users\kerki\Desktop\APBD\Zajęcia 2\dane.csv";
            }catch(ArgumentException a)
            {
                Console.WriteLine("Podana sciezka jest niepoprawna" + a.Message);
            }
            var result = new List<string[]>();
            var log = new List<string[]>();
            try
            {
                var fi = new FileInfo(path);
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] kolumny = line.Split(',');
                        if (Check(kolumny, result)) result.Add(kolumny);
                        else log.Add(kolumny);
                    }
                    Console.WriteLine(result.Count);
                    Console.WriteLine(log.Count);
                }
                FileStream writer = new FileStream(@"łog.txt", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<string[]>), new XmlRootAttribute());
                serializer.Serialize(writer, log);
            }
            catch(FileNotFoundException f)
            {
                Console.WriteLine("Plik " + path + " nie istnieje " + f.Message);
            }
        }
        public static bool Check(string[] arr, List<string[]> list)
        {
            if (arr.Length != 9) return false;
            for (int i = 0; i < 9; i++)
            {
                if (arr[i] == "")
                {
                    return false;
                }
            }
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i][0] == arr[0] &&
                    list[i][1] == arr[1] &&
                    list[i][5] == arr[5]) return false;
            }
            return true;
        }
        public static void RigthPath(string s)
        {
            if (s != @"C:\Users\kerki\Desktop\APBD\Zajęcia 2\dane.csv") throw new ArgumentException();
        }
    }
}
