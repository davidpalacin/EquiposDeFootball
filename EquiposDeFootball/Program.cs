using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquiposDeFootball
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\David\Desktop\esplai\ejercicios\programas\EquiposDeFootball\EquiposDeFootball\Equipos.txt";

            // Leer todo el archivo
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    if (line[0] == '*') // Si la línea empieza por *
                    {
                        Console.WriteLine(line);
                    }
                }
            }



        }
    }
}
