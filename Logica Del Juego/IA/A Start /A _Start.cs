

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Mail;

namespace A_Start
{
    public class Nodo 
    {
        
        // las pos en el arra bidimensional 
        public int Fila ;
        public int Columna ;  

        public int G ;  // distancia con respecto a la casilla inicial

        public int H ; // distancia con respecto al final q se conoce como Heuristica 

        //la misma se calcula Con la Formula De Manhata si el objeto solo se puede mover   horizontal  y vertical

        // y si puede moverse tambiendiagonal se usa la formula de distancia de dos puntos de Euclides 


        public int F
        {
            get
            {
                return  G+H;
            }
        }  // es el costo que es la suma del C con el H 

        
        public Nodo? padre ;


        public Nodo (int x ,int y)
        {
            Fila = x;
            Columna = y ;
            G = int.MaxValue;
            H =0;
            padre = null;
        }



    }


    public class Algortim_A_Start
    {

        public static List<Nodo>? EncontrarCamino ( Nodo inicio , Nodo final ,bool [,] laberinto  )
        { 
            // la abierta las q no se han analizado 
            List<Nodo> lista_abierta = new List<Nodo>();

            //la cerrda las analizadas 
            List<Nodo> lista_cerrada = new List<Nodo>();

            inicio.G =0; // el distancia con respecto al nodo incio es 0 pq es el mismo
            inicio.H = CalcularHeuristica(inicio , final);

            lista_abierta.Add(inicio); // se agrega el elemento 

            while ( lista_abierta.Count >0)  // mientras q la lista tenga nodos por recorrer 
            {
                Nodo actual = lista_abierta[0];

                foreach( var nodo in lista_abierta)
                {
                    if ( nodo.F < actual.F || ( nodo.F == actual.F && nodo.H < actual.H))
                    {
                        actual = nodo;
                    }
                }

                lista_abierta.Remove(actual);
                lista_cerrada.Add(actual);



                //verifica si es la pos final 

                if(actual.Fila == final.Fila && actual.Columna == final.Columna)
                {
                    List<Nodo> camino = new List<Nodo>();

                    while( actual != null )
                    {
                        camino.Add(actual);
                        actual = actual.padre;
                    }

                    camino.Reverse();
                    return camino ;
                }



                foreach (var vecino in ObtenerVecinos(actual,laberinto))
                {
                    // si ya se reviso o es una pared pasa a la siguiente posicion 
                    if ( lista_cerrada.Contains(vecino) && laberinto [vecino.Fila,vecino.Columna])continue;
                    
                    //hallando la distancia del vecino con respecto al nodo actual 
                    int nuevoG = actual.G + (( vecino.Fila != actual.Fila && vecino.Columna != actual.Columna)?14 : 10);  // si ambas cosas son diferentes significa q es un mov diagonal y se le suma 14 y sino es vertical o horizontal 


                    //actualizando los valore del vecino 
                    if (nuevoG < vecino.G || !lista_abierta.Contains(vecino))
                    { 
                        //para actuaizar los valores correctos de distancias de los nodos ya q se incilizan en el Max Value
                        vecino.G = nuevoG; 
                        vecino.H = CalcularHeuristica(vecino, final); 
                        vecino.padre = actual; 

                        //Y si no esta en la lista , lo agregamos para q sea analizado 
                        if (!lista_abierta.Contains(vecino)) 
                        { 
                            lista_abierta.Add(vecino); 
                        } 
                    }
                }

            }

            return null;

        }







        private static List<Nodo> ObtenerVecinos(Nodo nodo, bool[,] laberinto) 
        { 
            List<Nodo> vecinos = new List<Nodo>(); 
            int[] dx = { -1, 1, 0, 0 }; // mov filas 
            int[] dy = { 0, 0, -1, 1 }; // mov columnas 
            
            for (int i = 0; i < dx.Length; i++) 
            { 
                int nuevoX = nodo.Fila + dx[i]; 
                int nuevoY = nodo.Columna + dy[i]; 
                
                if (nuevoX >= 0 && nuevoX < laberinto.GetLength(0) && nuevoY >= 0 && nuevoY < laberinto.GetLength(1) && !laberinto[nuevoX, nuevoY]) 
                {
                    vecinos.Add(new Nodo(nuevoX, nuevoY)); 
                } 
            }
            return vecinos; 
        }



        public static int CalcularHeuristica ( Nodo nodo , Nodo fin )
        {
            // se usa el algortimo de ManHattan ya q solo puede tener mov horizontales y verticales 

            // d = | x1-x2 | + | y1 -y2 |

            return Math.Abs(nodo.Fila - fin.Fila) + Math.Abs(nodo.Columna - nodo.Columna);
        }
    }




}