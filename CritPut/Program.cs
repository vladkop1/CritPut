using System;

namespace CritPut
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Метод нахождения критичексого пути");
            var cr = new Critical("file1.csv", "reshfile1.txt");
            cr.RaschetCritPut();
            Console.WriteLine("Выполнено!");
            Console.ReadKey();
           
        }
    }
}
