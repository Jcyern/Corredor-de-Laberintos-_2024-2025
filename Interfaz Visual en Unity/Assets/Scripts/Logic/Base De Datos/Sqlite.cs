using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using FICHA;
using System.Collections.Generic;
using Mono.Data.Sqlite;

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
                        Faccion INTEGER
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

                string sql = " INSERT INTO MiTabla (Nombre,Velocidad,Enfriamiento,Faccion) VALUES (@Nombre,@Velocidad, @Enfriamiento, @Faccion)";

                using (var command = new SqliteCommand(sql, conection))
                {
                    foreach (var item in fichas)
                    {//Insertando los elementos , lo q hace q en el parametro nombre en la tabla asignale el valor q se le esta pasando
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Nombre", item.Name);
                        command.Parameters.AddWithValue("@Velocidad", item.Velocidad);
                        command.Parameters.AddWithValue("@Enfriamiento", item.Enfriamiento);
                        command.Parameters.AddWithValue("@Faccion", item.id);


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


                            fichas.Add(new Ficha(Convert.ToInt32(reader["Id"]), reader["Nombre"].ToString() ?? "", Convert.ToInt32(reader["Velocidad"]), Convert.ToInt32(reader["Enfriamiento"]), Convert.ToInt32(reader["Faccion"])));

                    
                        }
                    }
                }

                conection.Close();
            }

            Debug.Print(" se creo una lista de la faccion pasada");

            return fichas;
        }




        private void Insert_Elements()
        {


            //Lista de fichas 
            List<Ficha> fichas = new List<Ficha>
        {
            //Gryffindor
            new Ficha(1,"Albus Dumbledore",3,2,1),
            new Ficha(1,"Harry Potter",2,1,1),
            new Ficha(1,"Hermione",3,2,1),
            new Ficha(1,"Ron Weasley",4,1,1),
            new Ficha(1,"Sirius_Black",3,2,1),


             //Slytherin
            new Ficha(2,"Draco_Malfoy",4,2,2),     
            new Ficha(2,"Bellatrix_Lestrange",2,0,2),   
            new Ficha(2,"Estudiante_Astuto",2,1,2),
            new Ficha(2,"Bruja",2,1,2),
            new Ficha(2,"Baron_Sanguinario",4,2,2),


             //Ravenclaw
            new Ficha(3,"Borracho_de_Matalobos",3,1,3),
            new Ficha(3,"Glacius",3,1,3),
            new Ficha(3,"Kelpie",2,1,3),
            new Ficha(3,"Leo",2,0,3),
            new Ficha(4,"Gigante",3,1,4),

             //Hufflepuff
            new Ficha(4,"Boggart",3,2,4),
            new Ficha(4,"Caballero",3,1,4),
            new Ficha(4,"Elfo",2,1,4),
            new Ficha(4,"Fluffy",2,1,4),
            new Ficha(4,"Gytrash",2,0,4)

        };


            instancia.Insert(fichas);
            disponibles = fichas;
            System.Console.WriteLine("Fichas Agregadas ");
            int count = 0;
            foreach (var item in fichas)
            {
                System.Console.WriteLine($" ficha :  id: {count}  {item.Name}, {item.Faction},  {item.Velocidad} ");

                count++;
            }
        }

    }
}



