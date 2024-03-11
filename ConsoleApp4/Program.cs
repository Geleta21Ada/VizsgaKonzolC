using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> list = new List<Book>();
            string[] line = File.ReadAllLines("books.txt");

            foreach (string line2 in line)
            {
                string[] value = line2.Split(',');
                Book obj = new Book(value[0], value[1], value[2], value[3], value[4]);
                list.Add(obj);
            }
            Console.WriteLine("4.feladat");
            foreach (var item in list) 
            {
                Console.WriteLine($"{item.id}, {item.kateg}, {item.cim}, {item.ar}, {item.db}");
            }
            Console.WriteLine("\n 5.feladat");
            int osszdb = 0;
            foreach(var item in list)
            {
                osszdb += item.db;
            }
            Console.WriteLine($"Az össz darabszám: {osszdb}db");
            Console.WriteLine("\n 6.feladat");
            
            foreach(var item in list)
            {
                if (item.kateg == "Regény")
                {
                    Console.WriteLine($"Az könyv ára és címe: {item.ar}, {item.cim}");
                }
            }
            Console.WriteLine("\n 7.feladat");
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach(var item in list)
            {
                if (dic.ContainsKey(item.kateg))
                {
                    dic[item.kateg]++;
                }
                else
                {
                    dic[item.kateg] = 1;
                }
            }
            foreach(var item in dic)
            {
                Console.WriteLine($"{item.Key}, {item.Value}");

            }
            Console.WriteLine("\n 8.feladat");
            List<Book> books = new List<Book>();
            Book legolcsobb = list[0];
            books.Add(legolcsobb);

            foreach(var item in list)
            {
                if (item.ar < legolcsobb.ar)
                {
                    legolcsobb = item;
                    books.Clear();
                    books.Add(legolcsobb);
                }
                else if (item.ar == legolcsobb.ar)
                {
                    books.Add(item);
                }
            }

            foreach (var item in books)
            {
                Console.WriteLine($"{item.kateg}, {item.cim}, {item.ar}");
            }
        }
    }
}
