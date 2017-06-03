using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sprintz
{
    class Program
    {
        public static string pedirString(string pantallazo)
        {
            Console.Write(pantallazo);
            Console.WriteLine("");
            string regresa = Console.ReadLine();
            return regresa;
        }

        static void Main(string[] args)
        {
            /*string prueba = "al,g. o";
            Console.Write(prueba.Trim(',','.',' '));
            Console.ReadKey();
            */
            Console.WriteLine("Bienvenido al TextoLecto 4000 diseñado por Ecab =3");
            string rutaArchivo = pedirString("Dame la ruta absoluta de tu .txt: ");
            StreamReader leer = File.OpenText(rutaArchivo);
            byte velocidad = byte.Parse(pedirString("Escoja una velocidad del 1 (rapido) al 5 (lento) para leer el texto"));
            string cache = leer.ReadToEnd();
            string[] palabras = cache.Split(' ', ',', '.', '\n');
            bool esPar;
            for (int x = 0; x < palabras.Length; x++)
            {

                Console.SetCursorPosition((Console.WindowWidth - palabras[x].Length) / 2, (Console.WindowHeight / 2));

                //Console.Write(palabras[x]);

                if (palabras[x].Length % 2 == 0)
                {
                    esPar = true;
                }
                else
                {
                    esPar = false;
                }

                for (int a = 0; a < palabras[x].Length; a++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (palabras[x][a] == ',' || palabras[x][a] == '.' || palabras[x][a] == '\n')
                    { continue; }
                    if (esPar)
                    {
                        if (a + 1 == palabras[x].Length / 2 || a == palabras[x].Length / 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                        }
                        Console.Write(palabras[x][a]);

                    }
                    else if (esPar == false)
                    {
                        if (a == palabras[x].Length / 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.Write(palabras[x][a]);

                    }
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                }
                int timelapse = palabras[x].Length * (velocidad * 40);
                System.Threading.Thread.Sleep(timelapse);
                Console.Clear();
            }
            Console.Write("Texto terminado, presione cualquier tecla para cerrar");
            Console.ReadKey();
        }
    }
}
