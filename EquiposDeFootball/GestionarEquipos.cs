using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquiposDeFootball
{
    internal class GestionarEquipos
    {
        public static void CrearEquipo()
        {
            Console.Clear();
            Console.WriteLine("Introduce el nombre del nuevo equipo: ");
            string nuevoEquipo = Console.ReadLine();

            Program.listaEquipos.Add(nuevoEquipo);

            string[] archivo = File.ReadAllLines(Program.path);
            archivo[0] = string.Join(",", Program.listaEquipos).Trim();

            File.WriteAllLines(Program.path, archivo);
            Console.WriteLine("Nuevo equipo agregado correctamente.");

            Program.CrearListaJugadores(); 
            Program.MostrarMenu();
        }

        public static void EliminarEquipo()
        {
            Console.Clear();
            Console.WriteLine("Selecciona el equipo que deseas eliminar:");

            for (int i = 0; i < Program.listaEquipos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Program.listaEquipos[i]}");
            }

            Console.Write("Ingrese el número del equipo a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= Program.listaEquipos.Count)
            {
                string equipoEliminado = Program.listaEquipos[indice - 1];

                Program.listaEquipos.RemoveAt(indice - 1);

                string[] archivo = File.ReadAllLines(Program.path);
                archivo[0] = string.Join(",", Program.listaEquipos);

                List<string> jugadoresFiltrados = new List<string>();
                for (int i = 1; i < archivo.Length; i++)
                {
                    string[] datosJugador = archivo[i].Split(',');

                    if (datosJugador.Length < 2 || datosJugador[1].Trim() != (indice - 1).ToString())
                    {
                        jugadoresFiltrados.Add(archivo[i]);
                    }
                }

                File.WriteAllLines(Program.path, new[] { archivo[0] }.Concat(jugadoresFiltrados));

                Console.WriteLine($"El equipo \"{equipoEliminado}\" ha sido eliminado correctamente.");

                Program.CrearListaEquipos();
                Program.CrearListaJugadores();
            }

            else
            {
                Console.WriteLine("Selección inválida. Inténtalo de nuevo.");
            }

            Program.MostrarMenu();
        }
    }
}
