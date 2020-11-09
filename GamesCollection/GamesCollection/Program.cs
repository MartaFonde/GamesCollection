#define COLEC
using System;
using System.Collections.Generic;

namespace GamesCollection
    
{

    class Program
    {
#if COLEC
        public static List<Videojuego> ColecInicial()
        {
            List<Videojuego> colec = new List<Videojuego>();
            Videojuego j = new Videojuego("PINBALL", 1990, Estilo.ARCADE);
            colec.Add(j);
            j = new Videojuego("IMPERIVM CIVITAS", 2006, Estilo.ESTRATEGIA);
            colec.Add(j);
            j = new Videojuego("PORT ROYALE", 2002, Estilo.ESTRATEGIA);
            colec.Add(j);
            return colec;
        }
#endif
        public static void VisualizarLista(List<Videojuego> lista)
        {
            Console.WriteLine("-------------------------");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine("{0,10}\nTítulo: {1}\nAño: {2}\nGénero: {3}\n",
                    i, lista[i].Titulo.Length > 8 ? lista[i].Titulo.Substring(0, 10) + "..." : lista[i].Titulo, lista[i].Ano, lista[i].Estilo);
                Console.WriteLine("-------------------------");
            }            
        }
        public static bool ListaVacia(List<Videojuego> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("La colección no contiene ningún videojuego");
                return true;
            }
            return false;
        }

        public static void InfoJuego(List<Videojuego> lista, int pos)
        {
            Console.WriteLine("{0,4}\nTítulo: {1}\nAño: {2}\nGénero: {3}\n",
                pos, lista[pos].Titulo, lista[pos].Ano, lista[pos].Estilo);
        }


        static void Main(string[] args)
        {
#if COLEC
            List<Videojuego> colec = ColecInicial();
            ColeccionVideojuegos juegos = new ColeccionVideojuegos(colec);
#else
            ColeccionVideojuegos juegos = new ColeccionVideojuegos();
#endif
            int opcion = 0;
            int min = 0;
            int max = 0;
            int pos = 0;
            string resp;
            do
            {
                Console.WriteLine("--- COLECCIÓN DE VIDEOJUEGOS ---");
                Console.WriteLine("1. Insertar nuevo videojuego");
                Console.WriteLine("2. Eliminar videojuegos");
                Console.WriteLine("3. Visualizar lista de videojuegos");
                Console.WriteLine("4. Visualizar videojuegos de un estilo");
                Console.WriteLine("5. Modificar videojuego");
                Console.WriteLine("6. Salir");
                opcion = Videojuego.ValidacionNumero(1, 6);
                switch (opcion)
                {
                    case 1:
                        Videojuego v = new Videojuego();
                        juegos.Añadir(v);
                        Console.WriteLine(" *** Juego añadido a la lista ***");
                        break;
                    case 2:
                        if (!ListaVacia(juegos.lista))
                        {
                            do
                            {
                                Console.Write("Posición mínima: ");
                                min = Videojuego.ValidacionNumero(0, juegos.lista.Count - 1);
                                Console.Write("Posición máxima: ");
                                max = Videojuego.ValidacionNumero(0, juegos.lista.Count - 1);
                                if(min > max)
                                {
                                    Console.WriteLine("Error. La posición mínima no puede ser mayor que la máxima.");
                                }
                            } while (min > max);
                            
                            int i = min;
                            Console.WriteLine("¿Deseas eliminar siguientes juegos? S/N");
                            Console.WriteLine("-------------------------");
                            while (i <= max)
                            {
                                InfoJuego(juegos.lista, i);
                                Console.WriteLine("-------------------------");
                                i++;
                            }
                            do 
                            {
                                resp = Console.ReadLine().ToUpper();
                                if (resp.Equals("S"))
                                {
                                    if (juegos.Eliminar(max, min))
                                    {
                                        Console.WriteLine(" *** Juegos eliminados ***");
                                    }
                                    else
                                    {
                                        Console.WriteLine(" *** Error al eliminar los juegos ***");
                                    }

                                }
                                else if (resp.Equals("N"))
                                {
                                    Console.WriteLine(" *** Juegos no eliminados ***");
                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida");
                                }

                            } while (!resp.Equals("S") && !resp.Equals("N"));                                                                                                           
                        }
                        break;
                    case 3:
                        if (!ListaVacia(juegos.lista))
                        {
                            VisualizarLista(juegos.lista);
                        }
                        break;
                    case 4:
                        if (!ListaVacia(juegos.lista))
                        {
                            Console.Write("Estilo: ");
                            List<Videojuego> listEst = juegos.Busqueda(Videojuego.ValidacionEstilo());
                            if(listEst.Count > 0)
                            {
                                VisualizarLista(listEst);
                            }
                            else
                            {
                                Console.WriteLine("La colección no contiene ningún videojuego de ese estilo");
                            }
                        }
                        break;
                    case 5:
                        if (!ListaVacia(juegos.lista))
                        {
                            Console.Write("Posición del juego a modificar: ");
                            pos = Videojuego.ValidacionNumero(0, juegos.lista.Count - 1);
                            Console.Write("¿Deseas modificar el siguiente juego? S/N\n");
                            InfoJuego(juegos.lista, pos);
                            do
                            {
                                resp = Console.ReadLine().ToUpper();
                                if (resp.Equals("S"))
                                {
                                    juegos.lista.RemoveAt(pos);
                                    Videojuego j = new Videojuego();                                    
                                    pos = juegos.Posicion(j.Ano);
                                    juegos.lista.Insert(pos, j);                                    
                                    Console.WriteLine(" *** Juego modificado ***");
                                }
                                else if (resp.Equals("N"))
                                {
                                    Console.WriteLine(" *** Juego no modificado ***");
                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida");
                                }
                            } while (!resp.Equals("S") && !resp.Equals("N"));                            
                        }
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                Console.WriteLine();
            } while (opcion != 6);
        }
    }    
}
