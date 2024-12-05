using System;
using System.Diagnostics;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using FICHA;

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
            using (var conection = new SqliteConnection(conection_string))
            {
                conection.Open();

                //crear una tabla sino existe 
                string sql = @" CREATE TABLE IF NOT EXISTS MiTabla (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT,
                Velocidad INTEGER,
                Enfriamiento INTEGER,
                Faccion INTEGER
                )";

                //comando coge la el comando q se ejecuara y la coneccion con la base de datos 
                using (var command = new SqliteCommand(sql, conection))
                {
                    command.ExecuteNonQuery();
                }
                Debug.Print(" se creo tabla correctamente ");
                conection.Close();
            }

        }


        public void Insert(List<Ficha> fichas)
        {
            using (var conection = new SqliteConnection(conection_string))
            {
                conection.Open();

                string sql = " INSERT INTO MiTabla (Nombre,Velocidad,Enfriamiento,Faccion) VALUES (@Nombre,@Velocidad, @Enfriamiento, @Faccion)";

                using (var command = new SqliteCommand(sql, conection))
                {
                    foreach (var item in fichas)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@Nombre", item.Name);
                        command.Parameters.AddWithValue("@Velocidad", item.Velocidad);
                        command.Parameters.AddWithValue("@Enfriamiento", item.Enfriamiennto);
                        command.Parameters.AddWithValue("@Faccion", item.id);


                        command.ExecuteNonQuery();

                    }
                }
                Debug.Print("se agregaron a la tabla");
                conection.Close();
            }
        }




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

#pragma warning disable CS8604 // Possible null reference argument.
                            fichas.Add(new Ficha(Convert.ToInt32(reader["Id"]), reader["Nombre"].ToString(), Convert.ToInt32(reader["Velocidad"]), Convert.ToInt32(reader["Enfriamiento"]), Convert.ToInt32(reader["Faccion"])));
#pragma warning restore CS8604 // Possible null reference argument.
                            Console.WriteLine($"Id: {reader["Id"]}, Nombre: {reader["Nombre"]}, Velocidad: {reader["Velocidad"]}");
                        }
                    }
                }

                conection.Close();
            }

            Debug.Print(" se creo una lista de la faccion pasada");

            return fichas;
        }




        public void AgregateFichasToBase()
        {
            List<Ficha> fichas = new List<Ficha>
        {
            //Gryffindor
            new Ficha(1,"Albus_Dumbledore",3,2,1),
            new Ficha(1,"Animago",2,1,1),
            new Ficha(1,"Auror",1,0,1),
            new Ficha(1,"Espada_de_GG",4,1,1),
            new Ficha(1,"Fenix",2,0,1),
            new Ficha(1,"Minerva_McGonagall",5,2,1),
            new Ficha(1,"Ron_Weasley",2,0,1),
            new Ficha(1,"Rubeus_Hagrid",3,1,1),
            new Ficha(1,"Sirius_Black",3,2,1),
             //Slytherin
            new Ficha(2,"Acromantula",3,1,2),
            new Ficha(2,"Baron_Sanguinario",4,2,2),
            new Ficha(2,"Basilisco",3,1,2),
            new Ficha(2,"Bellatrix_Lestrange",2,0,2),
            new Ficha(2,"Bruja",2,1,2),
            new Ficha(2,"Dementor",3,1,2),
            new Ficha(2,"Draco_Malfoy",4,2,2),
            new Ficha(2,"Tom_Riddle_Diarie",3,1,2),
            new Ficha(2,"Estudiante_Astuto",2,1,2),
            new Ficha(2,"Merodeador",4,2,2),
            new Ficha(2,"Mortifago",3,1,2),
            new Ficha(2,"Tom_Riddle",2,1,2),
            new Ficha(2,"Uniforme_de_Slytherin",3,1,2),
             //Ravenclaw
            new Ficha(3,"Borracho_de_Matalobos",3,1,3),
            new Ficha(3,"Giratiempo",4,2,3),
            new Ficha(3,"Glacius",3,1,3),
            new Ficha(3,"Kelpie",2,1,3),
            new Ficha(3,"Leon",2,0,3),
            new Ficha(3,"Vendedor_de_Varitas",3,1,3),

             //Hufflepuff
            new Ficha(4,"Boggart",3,2,4),
            new Ficha(4,"Caballero_de_Raven",3,1,4),
            new Ficha(4,"Colacuerno_Hungaro",3,1,4),
            new Ficha(4,"Elfo_Domestico",2,1,4),
            new Ficha(4,"Fluffy",2,1,4),
            new Ficha(4,"Gigante",3,1,4),
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



