using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace EquiposDeFootball
{
    internal class Program
    {
        static string path = @"C:\Users\David\Desktop\esplai\ejercicios\programas\EquiposDeFootball\EquiposDeFootball\Equipos.txt";
        static List<string> listaEquipos = new List<string>();

        static void Main(string[] args)
        {
            // TODO: Alta de equipo nuevo
            // TODO: Alta de jugador nuevo
            // TODO: Partido entre equipos
            CrearListaEquipos();
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al gestor de tu club de football");
            Console.WriteLine("Selecciona la acción que deseas realizar: ");
            Console.WriteLine("1.- Ver equipos");
            Console.WriteLine("2.- Ver jugadores");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarEquipos();
                    break;
                case "2":
                    MostrarJugadores();
                    break;
            }
        }

        static void CrearListaEquipos()
        {
            // Leer todo el archivo
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    if (line[0] == '*') // Si la línea empieza por * es un equipo
                    {
                        listaEquipos.Add(line);
                    }
                }
            }
        }

        static void MostrarEquipos()
        {
            Console.Clear();
            foreach (string equipo in listaEquipos)
            {
                Console.WriteLine("- " + equipo.Substring(2));
            }
            PreguntarSalirVolver();
        }

        static void MostrarJugadores()
        {
            Console.Clear();
            // Leer todo el archivo
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line != "")
                {
                    // Si empieza con un numero es un jugador
                    // Eliminar el numero para dejar solo su nombre
                    if (Char.IsDigit(line[0]))
                    {
                        // Eliminar el número del primer caracter
                        Console.WriteLine("- " + line.Substring(3));
                    }
                }
            }
            PreguntarSalirVolver();
        }

        static void PreguntarSalirVolver()
        {
            Console.WriteLine("s. Salir");
            Console.WriteLine("v. Volver");
            string opcion = Console.ReadLine();
            if (opcion == "s")
                Environment.Exit(0);
            else
                MostrarMenu();
        }

    }
}
