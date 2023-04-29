using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace funcional
{
    class FileESHKERE
    {
        public struct dannie
        {
            public string fam;
            public string name;
            public string otch;
            public string data;
            public int ocenka;
        }
        public static dannie[] readforfile()
        {
            //string[] str = new string[Read]

            using (StreamReader sr = new StreamReader("journal.csv"))
            {
                string[] count = File.ReadAllLines("journal.csv");
                dannie[] arr = new dannie[count.Length];
                string line = sr.ReadLine();
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr1 = line.Split(';');
                    arr[i].fam = arr1[0];
                    arr[i].name = arr1[1];
                    arr[i].otch = arr1[2];
                    arr[i].data = arr1[3];
                    arr[i].ocenka = int.Parse(arr1[4]);
                    i++;
                }
                return arr;
            }
        }
        public static void vivod(dannie[] dani)
        {
            for (int i = 0; i < dani.Length; i++)
            {
                Console.WriteLine($"Фамилия: {dani[i].fam} Имя: {dani[i].name} Отчество: {dani[i].otch} Дата: {dani[i].data} Оценка: {dani[i].ocenka}");
            }
        }

        public static void rfidjkg()
        {
            dannie[] arr = new dannie[Ziseoffile()];
            int size = Ziseoffile();
            using (StreamReader sr = new StreamReader("journal.csv"))
            {
                string[] count = File.ReadAllLines("journal.csv");
                
                string line = sr.ReadLine();
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr1 = line.Split(';');
                    arr[i].fam = arr1[0];
                    arr[i].name = arr1[1];
                    arr[i].otch = arr1[2];
                    arr[i].data = arr1[3];
                    arr[i].ocenka = int.Parse(arr1[4]);
                    i++;
                }
                //return arr;
            }
            int count1 = 0;
            Console.WriteLine("введите фамилию");
            string f = Console.ReadLine();
            Console.WriteLine("введите имя");
            string im = Console.ReadLine();
            Console.WriteLine("введите отчество");
            string o = Console.ReadLine();
            Console.WriteLine("введите оценку от 1 до 5");
            string oc = Console.ReadLine();
            for (int i = 0; i < size; i++)
            {
                if (arr[i].fam == f)
                {
                    if (arr[i].name == im)
                    {
                        if (arr[i].otch == o)
                        {
                            count1 = i;
                            using (StreamWriter sr = new StreamWriter("journal.csv"))
                            {
                                sr.WriteLine();
                            }
                        }
                    }
                }
            }
            using (StreamWriter sr = new StreamWriter("journal.csv"))
            {
                for (int i = 0; i < size; i++)
                {
                    if (i == count1)
                    {
                        sr.WriteLine(arr[i].fam + ";" + arr[i].name + ";" + arr[i].otch + ";" + arr[i].data + ";" + arr[i].ocenka + ";" + oc);
                    }
                    else
                    {
                        sr.WriteLine(arr[i].fam + ";" + arr[i].name + ";" + arr[i].otch + ";" + arr[i].data + ";" + arr[i].ocenka);
                    }
                }
                
            }

        }
        static int Ziseoffile()// количество строк в файле
        {
            int count = 0;

            using (var sw = new StreamReader("journal.csv"))
            {

                for (int i = 0; sw.Peek() != -1; i++)
                {
                    sw.ReadLine();
                    count++;
                }
            }
            return count;
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Выберите режим работы программы:");
                Console.WriteLine("1 - для работы с программой в режиме ученика");
                Console.WriteLine("2 - для работы с программой в режиме учителя");
                Console.WriteLine("3 - для завершения работы с программой");

                int mode;

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out mode) || mode < 1 || mode > 3)
                    {
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите от 1 до 3.");
                    }
                    else
                    {
                        break;
                    }
                }


                // Обработка выбора режима работы программы
                if (mode == 1)
                {
                    FileESHKERE.vivod(FileESHKERE.readforfile());
                    Console.ReadKey();
                }
                if (mode == 2)
                {
                    FileESHKERE.rfidjkg();
                }
                if (mode == 3)
                {


                }
            }
        }
    }
}
