using System;
using System.Collections.Generic;
using System.Text;

namespace GamesCollection
{
    class ColeccionVideojuegos
    {
        public List<Videojuego> lista = new List<Videojuego>();
        public ColeccionVideojuegos(List<Videojuego> colec)
        {
            for (int i = 0; i < colec.Count; i++)
            {
                lista.Insert(Posicion(colec[i].Ano), colec[i]);
            }
        }

        public ColeccionVideojuegos()
        {

        }

        public void Añadir(Videojuego v)
        {
            lista.Insert(Posicion(v.Ano), v);
        }

        public int Posicion(int ano)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Ano > ano)
                {
                    return i;
                }
            }
            return lista.Count;
        }

        public bool Eliminar(int max, int min = 0)
        {
            if (min >= 0 && max <= lista.Count - 1 && min <= max)
            {
                while (min <= max)
                {
                    lista.RemoveAt(max);
                    max--;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Videojuego> Busqueda(Estilo e)
        {
            List<Videojuego> listaEstilo = new List<Videojuego>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Estilo.Equals(e))
                {
                    listaEstilo.Add(lista[i]);
                }
            }
            return listaEstilo;
        }
    }
}

