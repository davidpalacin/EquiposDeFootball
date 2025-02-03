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
        public static string path = @"..\..\Equipos2.txt";
        public static List<string> listaEquipos = new List<string>();
        // Crear lista de jugadores como array de arrays
        public static List<string[]> listaJugadores = new List<string[]>();

        static void Main(string[] args)
        {
            CrearListaEquipos();
            CrearListaJugadores();
            MostrarMenu();
        }

        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al gestor de tu club de football");
            Console.WriteLine("Selecciona la acción que deseas realizar: ");
            Console.WriteLine("1.- Ver equipos");
            Console.WriteLine("2.- Ver jugadores");
            Console.WriteLine("3.- Alta jugador");
            Console.WriteLine("4.- Crear Equipo nuevo");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    MostrarEquipos();
                    break;
                case "2":
                    Console.Clear();
                    MostrarJugadores();
                    break;
                case "3":
                    AltaJugador();
                    Console.ReadLine();
                    break;

                case "4":
                    CrearEquipos.CrearEquipo();
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    MostrarMenu();
                    break;
            }
        }

        public static void CrearListaEquipos()
        {
            // Guardar nombre de equipos que están en la primera linea del archivo separados por comas
            string[] archivo = File.ReadAllLines(path);
            listaEquipos = archivo[0].Split(',').ToList();
        }

        public static void CrearListaJugadores()
        {
            string[] archivo = File.ReadAllLines(path);
            int i = 1;

            listaJugadores.Clear();

            while (i < archivo.Length)
            {
                // Crear array de jugadores
                string[] jugadores = archivo[i].Split(',');
                listaJugadores.Add(jugadores);
                i++;
            }
        }

        public static void MostrarEquipos()
        {
            int selector = 1;
            foreach (string equipo in listaEquipos)
            {
                Console.WriteLine(selector.ToString() + " - " + equipo);
                selector++;
            }

            Console.WriteLine("Selecciona un equipo para ver sus jugadores");
            int opcion = Convert.ToInt32(Console.ReadLine()) - 1;

            List<string[]> jugadoresEnEquipo = new List<string[]>();

            for (int i = 0; i < listaJugadores.Count(); i++)
            {
                if (listaJugadores[i][1] == opcion.ToString())
                {
                    jugadoresEnEquipo.Add(listaJugadores[i]);
                }
            }

            Console.Clear();
            Console.WriteLine("JUGADORES DEL EQUIPO:  " + listaEquipos[opcion]);
            selector = 1;
            foreach (string[] jugador in jugadoresEnEquipo)
            {
                Console.WriteLine(selector.ToString() + " - " + jugador[0]);
                selector++;
            }

            PreguntarSalirVolver();
        }

        public static void MostrarJugadores()
        {
            for (int i = 0; i < listaJugadores.Count(); i++)
            {
                // Cada jugador es un array
                Console.WriteLine(listaJugadores[i][0]);
            }
            PreguntarSalirVolver();
        }

        public static void PreguntarSalirVolver()
        {
            Console.WriteLine();
            Console.WriteLine("s. Salir");
            Console.WriteLine("v. Volver");
            string opcion = Console.ReadLine();
            if (opcion == "s")
                Environment.Exit(0);
            else
                MostrarMenu();
        }

        static void AltaJugador()
        {
            Console.Clear();
            Console.WriteLine("Introduce el nombre del jugador: ");
            string nombreNuevo = Console.ReadLine();

            Console.WriteLine("Introduce el equipo: ");
            int selector = 1;

            foreach (string equipo in listaEquipos)
            {
                Console.WriteLine(selector.ToString() + " - " + equipo);
                selector++;
            }

            int equipoNuevo = Convert.ToInt32(Console.ReadLine()) - 1;

            string nuevoJugador ="\n" + nombreNuevo + "," + equipoNuevo.ToString();

            // Agregar en nueva linea al archivo
            File.AppendAllText(path, nuevoJugador);

            listaJugadores.Add(new string[] { nombreNuevo, equipoNuevo.ToString() });

            Console.WriteLine("Jugador añadido correctamente.");
            PreguntarSalirVolver();
        }

    }
}