using System.Diagnostics;
using FICHA;
using EnumHab;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System;

// we agregate the package:   dotnet add package Microsoft.Data.Sqlite
namespace Base_Datos
{

    public class SQlite
    {

        public static SQlite instancia = new SQlite();

        public List<Ficha> disponibles = new();
        // string para conectar con la base dedatos ( Conexion simple , Data Source=<Name de la base>.db )
        public string conection_string = "Data Source=Fichas.db";




        public void CreateTable()
        {

            string sqlCheckTable = "SELECT name FROM sqlite_master WHERE type='table' AND name='MiTabla'";


            




            using (var conection = new SqliteConnection(conection_string))
            {
                conection.Open();
                using (var command = new SqliteCommand(sqlCheckTable, conection))
                {
                    var result = command.ExecuteScalar();
            
                    if (result != null)
                    {
                        Debug.Print("La tabla MiTabla ya existe.");
                        System.Console.WriteLine("La tabla MiTabla ya existe ");
                    }

                    else
                    {
                        
                        //crear una tabla sino existe 
                        string sql = @" CREATE TABLE IF NOT EXISTS MiTabla (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT,
                        Velocidad INTEGER,
                        Enfriamiento INTEGER,
                        Faccion INTEGER,
                        Seconds INTEGER,
                        Hability TEXT
                        )";

                        //comando coge la el comando q se ejecuara y la coneccion con la base de datos 
                        using (var createcommand = new SqliteCommand(sql, conection))
                        {
                            createcommand.ExecuteNonQuery();
                            Debug.Print(" se creo tabla correctamente ");
                            System.Console.WriteLine("Se creo la tabla corretamente ");
                            
                            
                        }

                        //Insertar los elementos en  la tabla 
                        Insert_Elements();
                    }
                }
                conection.Close();
            }

        }


        private void Insert(List<Ficha> fichas)
        {
            using (var conection = new SqliteConnection(conection_string))
            {
                conection.Open();

                string sql = " INSERT INTO MiTabla (Nombre,Velocidad,Enfriamiento,Faccion,Seconds,Hability) VALUES (@Nombre,@Velocidad, @Enfriamiento, @Faccion, @Seconds, @Hability)";

                using (var command = new SqliteCommand(sql, conection))
                {
                    foreach (var item in fichas)
                    {//Insertando los elementos , lo q hace q en el parametro nombre en la tabla asignale el valor q se le esta pasando
                    System.Console.WriteLine($"Insertirng _ {item.Name} __ Hab : {item.Hability.Nombre}");
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Nombre", item.Name);
                        command.Parameters.AddWithValue("@Velocidad", item.Velocidad);
                        command.Parameters.AddWithValue("@Enfriamiento", item.Enfriamiento);
                        command.Parameters.AddWithValue("@Faccion", item.Faction.id);
                        command.Parameters.AddWithValue("@Seconds",item.Seconds);
                        command.Parameters.AddWithValue("@Hability",item.Hability.Nombre);


                        command.ExecuteNonQuery();

                    }
                }
                Debug.Print("se agregaron a la tabla");
                conection.Close();
            }
        }



   //Se le pasa la Faction y te da las fichas disponibles a escoger 
        public List<Ficha> GetFichas(int faccion)
        {
            List<Ficha> fichas = new List<Ficha>();


            string sql = "SELECT * FROM MiTabla WHERE Faccion = " + faccion + "";


            using (var conection = new SqliteConnection(conection_string))
            {
                conection.Open();

                using (var command = new SqliteCommand(sql, conection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            fichas.Add(new Ficha(Convert.ToInt32(reader["Id"]), reader["Nombre"].ToString() ?? "", Convert.ToInt32(reader["Velocidad"]), Convert.ToInt32(reader["Enfriamiento"]), Convert.ToInt32(reader["Faccion"]), Convert.ToInt32(reader["Seconds"]), (EnumHability)Enum.Parse(typeof(EnumHability),reader["Hability"].ToString()?? "")));

                    
                        }
                    }
                }

                conection.Close();
            }

            Debug.Print(" se creo una lista de la faccion pasada");

            return fichas;
        }

        public Ficha GetFicha(int id)
        {
            Ficha ficha = null;


            string sql = "SELECT * FROM MiTabla WHERE Id = " + id + "";


            using (var conection = new SqliteConnection(conection_string))
            {
                conection.Open();

                using (var command = new SqliteCommand(sql, conection))
                {
                    
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ID = Convert.ToInt32(reader["Id"]);
                            var Name = reader["Nombre"].ToString() ?? "";
                            var Velocity = Convert.ToInt32(reader["Velocidad"]);
                            var Enfriamiento =  Convert.ToInt32(reader["Enfriamiento"]);
                            var Faccion =  Convert.ToInt32(reader["Faccion"]);
                            var Seconds = Convert.ToInt32(reader["Seconds"]);
                            string hab = reader["Hability"].ToString()?? " ";
                            EnumHability Hability = (EnumHability)Enum.Parse(typeof(EnumHability),hab);

                            ficha = new Ficha(ID,Name,Velocity,Enfriamiento,Faccion, Seconds,Hability);


                        }
                    }
                }

                conection.Close();
            }
            if(ficha != null)
            return ficha;
            else
            throw new Exception("No se cargaron los datos de la ficha");
        }




        private void Insert_Elements()
        {


            //Lista de fichas 
            List<Ficha> fichas = new List<Ficha>
            {
                //Gryffindor
                new(1,"Albus_Dumbledore",6,5,1,7, EnumHability.MoreTime),
                new(2,"Harry_Potter",4,7,1,8,EnumHability.AntiTramps),
                new(3,"Hermione",5,6,1,9,EnumHability.Aumentar_Velocity),
                new(4,"Ron_Weasley",5,5,1,6,EnumHability.Aumentar_Velocity),
                new(5,"Sirius_Black",7,2,1,7,EnumHability.MoreTime),


                //Slytherin
                new(6,"Draco_Malfoy",4,5,2,7, EnumHability.Aumentar_Velocity),     
                new(7,"Bellatrix_Lestrange",4,6,2,5,EnumHability.Aumentar_Velocity),   
                new(8,"Estudiante_Astuto",6,5,2,7,EnumHability.AntiTramps),
                new(9,"Bruja",7,4,2,8,EnumHability.MoreTime),
                new(10,"Baron_Sanguinario",5,3,2,7,EnumHability.AntiTramps),


                //Hufflepuff
                new(11,"Borracho_de_Matalobos",8,5,3,8,EnumHability.AntiTramps),
                new(12,"Glacius",5,5,3,6,EnumHability.AntiTramps),
                new(13,"Kelpie",5,4,3,6,EnumHability.MoreTime),
                new(14,"Leo",4,6,3,9,EnumHability.Aumentar_Velocity),
                new(15,"Gigante",6,7,3,10,EnumHability.AntiTramps),

                //Ravenclaw
                new(16,"Boggart",5,6,4,7,EnumHability.Aumentar_Velocity),
                new(17,"Caballero",5,1,4,9,EnumHability.Aumentar_Velocity),
                new(18,"Elfo",6,4,4,8,EnumHability.MoreTime),
                new(19,"Fluffy",8,6,4,5,EnumHability.AntiTramps),
                new(20,"Gytrash",5,9,4,7,EnumHability.AntiTramps)

            };


            instancia.Insert(fichas);
            disponibles = fichas;
            System.Console.WriteLine("Fichas Agregadas ");
            int count = 0;
            foreach (var item in fichas)
            {
                System.Console.WriteLine($" ficha :  id: {count}  Nombre {item.Name}, Facccion{item.Faction.name}, Velocidad j{item.Velocidad}, Seconds{item.Seconds} , Hability {item.Hability.Name}, Enfriamiento {item.Enfriamiento}");

                count++;
            }
        }

    }
}



