using FICHA;
namespace Page
{

    //para pasar pagina en la interfaz visual a la hora de elegir jugador 
    public class Paginas 
    {   
        public List<Ficha> actual = new List<Ficha>();

        private int count = 3 ; //cantidad de fichas a mostrar 

    
        public  Stack<Ficha> adelante = new ();
        public  Stack<Ficha> atras = new ();



        public Paginas (List<Ficha> fichas)
        {


            fichas.Reverse();

            foreach ( var item in fichas )
            {   //agregando los elementos de la lista a la pila 
                adelante.Push(item);
            }

            
        }


        public void Back()
        {
            if(actual.Count>0)
            {   
                int i = 0 ;
                while ( i != count)
                {  
                    if(actual.Count==0)break;
                    adelante.Push(actual[actual.Count-1]);
                    actual.RemoveAt(actual.Count-1);

                    i++;
                }


                actual.Clear();
            }

            for ( int j = 0 ; j< count ;j++)
            {
                if(atras.Count == 0)
                {
                    System.Console.WriteLine("Se acabaron los elementos de la pila de adelante ");
                    break ;
                    
                }

                actual.Add(atras.Pop());
            }
        }

        public void Next()
        {
            if(actual.Count>0)
            {
                    int i = 0 ;
                while ( i != count)
                {    
                    atras.Push(actual[actual.Count-1]);
                    actual.RemoveAt(actual.Count-1);

                    i++;
                }
                actual.Clear();
            }
            for ( int j = 0 ; j< count ;j++)
            {
                if(adelante.Count == 0)
                {
                    System.Console.WriteLine("Se acabaron los elementos de la pila de adelante ");
                    break ;
                    
                }

                actual.Add(adelante.Pop());
            }
        }
}
};
