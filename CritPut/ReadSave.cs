using System;
using System.Collections.Generic;
using System.IO;

namespace CritPut
{
    struct Activity
    {
        public int eventStart, eventEnd, time;
    }
    struct Path
    {
        public string path;
        public int lastTochk, lenght;
    }
    static class ReadSave
    {
        public static void Read(string path, ref List<Activity> activities)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("file not found");
                Console.ReadKey();
                Environment.Exit(0);
            }
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                string[] str = line.Split(';');
                activities.Add(new Activity { eventStart = Convert.ToInt32(str[0]), eventEnd = Convert.ToInt32(str[1]), time = Convert.ToInt32(str[2]) });
            }
        }
        public static void Write(string path, Path savingP)
        { 
        if (!File.Exists(path)) File.Create(path).Close();
        try
        {
            using (StreamWriter STW = new StreamWriter(path, false))
            {
               STW.WriteLine("Найденный путь :");
               STW.WriteLine(savingP.path);
               STW.WriteLine("Длина :" + savingP.lenght);


            }
        }
        catch
        {
                Console.WriteLine("Ошибка");
                Console.ReadKey();
                
        }

        }
    }
}
