using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinario
{
    class Conexion
    {
         private MySqlConnection conexion;
        private static MySqlCommand comando;
        private MySqlDataReader resultado;
        private DataTable datos = new DataTable();

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = veterinario; Uid = root; Pwd =; Port = 3306");
            
        }

       
        // MASCOTAS

        public void eliminarMascota(int id)
        {
            conexion.Open();
            comando = new MySqlCommand("DELETE FROM t_mascotas WHERE id_mascota = " + id, conexion);
            comando.ExecuteReader();
            conexion.Close();
        }

        public DataTable obtenerMascotas()
        {
            conexion.Open();
            comando = new MySqlCommand("Select * from t_mascotas", conexion);
            resultado = comando.ExecuteReader();
             datos.Load(resultado);
            conexion.Close();
            return datos;
        }

        public void anadirMascota(String nombre, string sexo, string raza, string especie, Int32 chip, string fecha, Int32 propietario, string imagen)
        {
            conexion.Open();
            comando = new MySqlCommand("INSERT INTO  t_mascotas (nombre, sexo, raza, especie, chip, fech_nac, propietario, imagen)" +
                "VALUES ('" + nombre + "', '" + sexo + "', '" + raza + "', '" + especie + "', '" + chip + "', '" +
                 fecha + "', '" + propietario + "', '" + imagen + "')", conexion);
            comando.ExecuteReader();
            conexion.Close();

           // Console.WriteLine(fecha);
        }

        public void modificarMascota(int idMascota, String nombre, string sexo, string raza, string especie, Int32 chip, string fecha, Int32 propietario)
        {
            conexion.Open();
            comando = new MySqlCommand("UPDATE  t_mascotas SET nombre ='" + nombre + "', sexo = '" + sexo + "', raza = '" + raza + "', especie = '" + especie
                + "', chip = '" + chip + "', fech_nac = '" + fecha + "', propietario = '" + propietario + "' WHERE id_mascota ='" + idMascota + "'", conexion);
            comando.ExecuteReader();
            conexion.Close();
        }

        public  DataTable buscarMascota( string nombre)
        {
            resultado = null;
            DataTable buscado = new DataTable();

            conexion.Open();
            comando = new MySqlCommand("Select * from t_mascotas WHERE nombre LIKE '%"+ nombre+"%'", conexion);
            resultado = comando.ExecuteReader();
            buscado.Load(resultado);
            conexion.Close();
            return buscado;
        }

         // VISITAS

        public DataTable obtenerVisitas(int id)
        {
            conexion.Open();
            comando = new MySqlCommand("SELECT * FROM t_visitas  WHERE mascota = '"+ id +"'", conexion);
            resultado = comando.ExecuteReader();
            datos.Load(resultado);
            conexion.Close();
            return datos;
        }

        public void eliminarVisita(int id)
        {
            conexion.Open();
            comando = new MySqlCommand("DELETE FROM t_visitas WHERE id_visita = " + id, conexion);
            comando.ExecuteReader();
            conexion.Close();
        }

        public void modificarVisita(int idVisita, int mascota, string descripcion, int empleado, string fecha)
        {
            conexion.Open();
            comando = new MySqlCommand("UPDATE  t_visitas SET mascota ='"+ mascota +"', descripcion ='" +descripcion 
                + "', empleado ='" +empleado +"', fecha ='"+fecha+"' WHERE id_visita =" + idVisita, conexion);
            comando.ExecuteReader();
            conexion.Close();
        }

        public void anadirVisita(int mascota, int empleado, string descripcion, string fecha)
        {
            conexion.Open();
            comando = new MySqlCommand("INSERT INTO  t_visitas (mascota, descripcion, empleado, fecha)" +
                "VALUES ('"+mascota+"', '"+descripcion+"', '"+empleado+"', '"+fecha+"')", conexion);
            comando.ExecuteReader();
            conexion.Close();
        }
    }
}
