using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquiposDeFootball
{
    internal class CrearEquipos
    {
        public static void CrearEquipo()
        {
            Console.Clear();
            Console.WriteLine("Introduce el nombre del nuevo equipo: ");
            string nuevoEquipo = Console.ReadLine();

            // Agregar el nuevo equipo a la lista global de equipos
            Program.listaEquipos.Add(nuevoEquipo);

            // Leer todo el contenido del archivo
            string[] archivo = File.ReadAllLines(Program.path);

            // Modificar solo la primera línea con la lista actualizada de equipos
            // Eliminamos cualquier espacio extra al final de la lista
            archivo[0] = string.Join(",", Program.listaEquipos).Trim();

            // Escribir todo el archivo de nuevo, asegurándonos de no borrar a los jugadores
            File.WriteAllLines(Program.path, archivo);

            Console.WriteLine("Nuevo equipo agregado correctamente.");

            // Recargar los jugadores y equipos para actualizar los datos
            Program.CrearListaJugadores();  // Recargamos los jugadores
            Program.MostrarMenu();
        }
    }
}
