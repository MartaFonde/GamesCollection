using System;
using System.Collections.Generic;
using System.Text;

namespace GamesCollection
{
    enum Estilo
    {
        ARCADE,
        VIDEOAVENTURA,
        SHOOTEMUP,
        ESTRATEGIA,
        DEPORTIVO
    }
    class Videojuego
    {
        private string titulo;
        private int ano;
        private Estilo estilo;
        public string Titulo
        {
            set
            {
                titulo = value.Trim().ToUpper();
            }
            get
            {
                return titulo;
            }
        }

        public int Ano
        {
            set
            {
                ano = value;
            }
            get
            {
                return ano;
            }
        }

        public Estilo Estilo
        {
            set
            {
                estilo = value;
            }
            get
            {
                return estilo;
            }
        }

        public Videojuego(string titulo, int ano, Estilo estilo)
        {
            Titulo = titulo.Trim().ToUpper();
            Ano = ano;
            Estilo = estilo;
        }

        public Videojuego()
        {
            Console.Write("Título: ");
            Titulo = Console.ReadLine().Trim().ToUpper();
            Console.Write("Año: ");
            Ano = ValidacionNumero(max: DateTime.Now.Year);
            Console.Write("Estilo: ");
            Estilo = ValidacionEstilo();
        }

        public static int ValidacionNumero(int min = 1960, int max = 2020)
        {
            int num = 0;
            bool valido = false;
            while (!valido)
            {
                try
                {
                    valido = true;
                    num = Convert.ToInt32(Console.ReadLine().Trim());
                    if (num < min || num > max)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("El dato introducido no es un número");
                    valido = false;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Valor no válido, no cumple con el rango permitido (" + min + "-" + max + ")");
                    valido = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Dato no válido");
                    valido = false;
                }
            }
            return num;
        }

        public static Estilo ValidacionEstilo()
        {
            Estilo e = Estilo.ARCADE;
            string[] estilos = Enum.GetNames(typeof(Estilo));

            bool valido = false;
            while (!valido)
            {
                string est = Console.ReadLine().Trim().ToUpper();
                for (int i = 0; i < estilos.Length; i++)
                {
                    if (estilos[i].Equals(est))
                    {
                        return (Estilo)i;
                    }
                }
                Console.WriteLine("Error. Estilo no válido. Los posibles estilos de la colección son:\n" + string.Join(',', estilos));
            }
            return e;
        }
    }
}

