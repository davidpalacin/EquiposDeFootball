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
        static string path = @"C:\Users\David\Desktop\esplai\ejercicios\programas\EquiposDeFootball\EquiposDeFootball\Equipos2.txt";
        static List<string> listaEquipos = new List<string>();
        // Crear lista de jugadores como array de arrays
        static List<string[]> listaJugadores = new List<string[]>();

        static void Main(string[] args)
        {
            CrearListaEquipos();
            CrearListaJugadores();
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al gestor de tu club de football");
            Console.WriteLine("Selecciona la acción que deseas realizar: ");
            Console.WriteLine("1.- Ver equipos");
            Console.WriteLine("2.- Ver jugadores");
            Console.WriteLine("3.- Alta jugador");
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
                default:
                    Console.WriteLine("Opción no válida");
                    MostrarMenu();
                    break;
            }
        }

        static void CrearListaEquipos()
        {
            // Guardar nombre de equipos que están en la primera linea del archivo separados por comas
            string[] archivo = File.ReadAllLines(path);
            listaEquipos = archivo[0].Split(',').ToList();
        }

        static void CrearListaJugadores()
        {
            string[] archivo = File.ReadAllLines(path);
            int i = 1;
            while (i < archivo.Length)
            {
                // Crear array de jugadores
                string[] jugadores = archivo[i].Split(',');
                listaJugadores.Add(jugadores);
                i++;
            }
        }

        static void MostrarEquipos()
        {
            int selector = 1;
            foreach (string equipo in listaEquipos)
            {
                Console.WriteLine(selector.ToString() + " - " + equipo);
                selector++;
            }
            PreguntarSalirVolver();
        }

        static void MostrarJugadores()
        {
            for (int i = 0; i < listaJugadores.Count(); i++)
            {
                // Cada jugador es un array
                Console.WriteLine(listaJugadores[i][0]);
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

        static void AltaJugador()
        {
            Console.Clear();
            Console.WriteLine("Introduce el nombre del jugador: ");
            string nombreNuevo = Console.ReadLine();

            Console.WriteLine("Selecciona el equipo del jugador: ");
            MostrarEquipos();
            int equipoSeleccionado = Convert.ToInt32(Console.ReadLine()) - 1;

            if (equipoSeleccionado < 0 || equipoSeleccionado >= listaEquipos.Count)
            {
                Console.WriteLine("Selección no válida. Inténtalo de nuevo.");
                return;
            }

            string nuevoJugador = nombreNuevo + "," + listaEquipos[equipoSeleccionado];

            // Agregar a la lista local
            listaJugadores.Add(new string[] { nombreNuevo, listaEquipos[equipoSeleccionado] });

            // Guardar en el archivo con salto de línea
            File.AppendAllText(path, "\n" + nuevoJugador);


            Console.WriteLine("Jugador añadido correctamente.");
        }

    }
}