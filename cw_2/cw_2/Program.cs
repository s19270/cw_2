using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
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
                path = @"dane.csv";
            }catch(ArgumentException a)
            {
                Console.WriteLine("Podana sciezka jest niepoprawna" + a.Message);
            }
            var result = new List<Student>();
            var log = new List<Student>();
            try
            {
                var fi = new FileInfo(path);
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] kolumny = line.Split(',');
                        var student = new Student();
                        student.fname = kolumny[0];
                        student.lname = kolumny[1];
                        student.studiesname = kolumny[2];
                        student.studiesmode = kolumny[3];
                        student.indexNumber = "s" + kolumny[4];
                        student.birthdate = kolumny[5];
                        student.email = kolumny[6];
                        student.mothersName = kolumny[7];
                        student.fathersName = kolumny[8];


                        if (Check(kolumny, result)) result.Add(student);
                        else log.Add(student);
                    }
                    Console.WriteLine(result.Count);
                    Console.WriteLine(log.Count);
                }
                var jsonString = JsonSerializer.Serialize(result);
                File.WriteAllText("data.json", jsonString);
                FileStream writer = new FileStream(@"log.txt", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                           new XmlRootAttribute("uczelnia"));
                serializer.Serialize(writer, log);
            }
            catch(FileNotFoundException f)
            {
                Console.WriteLine("Plik " + path + " nie istnieje " + f.Message);
            }
        }
        public static bool Check(string[] arr, List<Student> list)
        {
            if (arr.Length != 9) return false;
            for (int i = 0; i < 9; i++)
            {
                if (arr[i] == "")
                {
                    return false;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].fname.Equals(arr[0]) &&
                    list[i].lname.Equals(arr[1]) &&
                    list[i].indexNumber.Equals("s" + arr[4])) return false; 
            }
            return true;
        }
        public static void RigthPath(string path)
        {
            if (path != @"dane.csv") throw new ArgumentException();
        }
    }
}
