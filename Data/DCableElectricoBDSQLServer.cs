using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
/**
 * Creacion de tabla:
 * 
 *CREATE TABLE CableElectrico (
    numeroDeSerie INT PRIMARY KEY,
    cantidadDeConductores INT NOT NULL,
    marcaDelCable VARCHAR(100) NOT NULL,
    metros FLOAT NOT NULL,
    seccionDelCable CHAR(1) NOT NULL,
    libreDeHalogenos BIT NOT NULL,
    fachadaOVivienda BIT NOT NULL,
    fechaDeCompra DATETIME NOT NULL,
    fechaDeVencimiento DATETIME NOT NULL
);
 * 
 */
namespace Data
{
    public class DCableElectricoBDSQLServer : ICableElectricoFichero
    {

        private readonly string conexionBD = Data.Properties.Settings.Default.BDCablesElectricos;

        public bool AñadirCable(CableElectrico cableElectrico)
        {
            string query = "INSERT INTO CableElectrico (numeroDeSerie, cantidadDeConductores, marcaDelCable, metros, seccionDelCable, libreDeHalogenos, fachadaOVivienda, fechaDeCompra, fechaDeVencimiento)" +
                           "VALUES(@numeroDeSerie, @cantidadDeConductores, @marcaDelCable, @metros, @seccionDelCable, @libreDeHalogenos, @fachadaOVivienda, @fechaDeCompra, @fechaDeVencimiento)";

            int repuesta = 0;


            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@numeroDeSerie", cableElectrico.NumeroDeSerie);
                cmd.Parameters.AddWithValue("@cantidadDeConductores", cableElectrico.CantidadDeConductores);
                cmd.Parameters.AddWithValue("@marcaDelCable", cableElectrico.MarcaDelCable);
                cmd.Parameters.AddWithValue("@metros", cableElectrico.Metros);
                cmd.Parameters.AddWithValue("@seccionDelCable", cableElectrico.SeccionDelCable);
                cmd.Parameters.AddWithValue("@libreDeHalogenos", cableElectrico.LibreDeHalogenos);
                cmd.Parameters.AddWithValue("@fachadaOVivienda", cableElectrico.FachadaOVivienda);
                cmd.Parameters.AddWithValue("@fechaDeCompra", cableElectrico.FechaDeCompra);
                cmd.Parameters.AddWithValue("@fechaDeVencimiento", cableElectrico.FechaDeVencimiento);

                try
                {
                    repuesta = cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Este cable ya existe\n" + ex.Message);
                    return false;
                }

                con.Close();
            }

            return true;
        }

        public bool BorrarCable(int numeroDeSerie)
        {
            string query = "DELETE FROM CableElectrico WHERE numeroDeSerie = @numeroDeSerie";

            int repuesta = 0;


            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@numeroDeSerie", numeroDeSerie);


                repuesta = cmd.ExecuteNonQuery();

                con.Close();
            }

            return (repuesta >= 1) ? true : false;
        }

        public bool ModificarCable(CableElectrico cableElectrico)
        {
            string query = @"UPDATE CableElectrico
                     SET cantidadDeConductores = @cantidadDeConductores,
                         marcaDelCable = @marcaDelCable,
                         metros = @metros,
                         seccionDelCable = @seccionDelCable,
                         libreDeHalogenos = @libreDeHalogenos,
                         fachadaOVivienda = @fachadaOVivienda,
                         fechaDeCompra = @fechaDeCompra,
                         fechaDeVencimiento = @fechaDeVencimiento
                     WHERE numeroDeSerie = @numeroDeSerie";
            int repuesta = 0;


            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@numeroDeSerie", cableElectrico.NumeroDeSerie);
                cmd.Parameters.AddWithValue("@cantidadDeConductores", cableElectrico.CantidadDeConductores);
                cmd.Parameters.AddWithValue("@marcaDelCable", cableElectrico.MarcaDelCable);
                cmd.Parameters.AddWithValue("@metros", cableElectrico.Metros);
                cmd.Parameters.AddWithValue("@seccionDelCable", cableElectrico.SeccionDelCable);
                cmd.Parameters.AddWithValue("@libreDeHalogenos", cableElectrico.LibreDeHalogenos);
                cmd.Parameters.AddWithValue("@fachadaOVivienda", cableElectrico.FachadaOVivienda);
                cmd.Parameters.AddWithValue("@fechaDeCompra", cableElectrico.FechaDeCompra);
                cmd.Parameters.AddWithValue("@fechaDeVencimiento", cableElectrico.FechaDeVencimiento);

                repuesta = cmd.ExecuteNonQuery();

                con.Close();
            }

            return (repuesta >= 1) ? true : false;
        }

        public List<CableElectrico> MostrarCablePorFechaDeCompraAscendente(DateTime fecha)
        {
            string query = "Select * From CableElectrico WHERE fechaDeCompra >= @fechaDeCompra";

            List<CableElectrico> listaDeCables = new List<CableElectrico>();

            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@fechaDeCompra", fecha);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaDeCables.Add(
                                new CableElectrico(int.Parse(reader["numeroDeSerie"].ToString()),
                                                   int.Parse(reader["cantidadDeConductores"].ToString()),
                                                   reader["marcaDelCable"].ToString(), float.Parse(reader["metros"].ToString()),
                                                   char.Parse(reader["seccionDelCable"].ToString()),
                                                   bool.Parse(reader["libreDeHalogenos"].ToString()),
                                                   bool.Parse(reader["fachadaOVivienda"].ToString()),
                                                   DateTime.Parse(reader["fechaDeCompra"].ToString()),
                                                   DateTime.Parse(reader["fechaDeVencimiento"].ToString()))
                            );
                    }
                }
                con.Close();

            }

            return listaDeCables;
        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            string query = "Select * From CableElectrico WHERE metros >= @metros";

            List<CableElectrico> listaDeCables = new List<CableElectrico>();

            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@metros", metros);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaDeCables.Add(
                                new CableElectrico(int.Parse(reader["numeroDeSerie"].ToString()),
                                                   int.Parse(reader["cantidadDeConductores"].ToString()),
                                                   reader["marcaDelCable"].ToString(), float.Parse(reader["metros"].ToString()),
                                                   char.Parse(reader["seccionDelCable"].ToString()),
                                                   bool.Parse(reader["libreDeHalogenos"].ToString()),
                                                   bool.Parse(reader["fachadaOVivienda"].ToString()),
                                                   DateTime.Parse(reader["fechaDeCompra"].ToString()),
                                                   DateTime.Parse(reader["fechaDeVencimiento"].ToString()))
                            );
                    }
                }
                con.Close();

            }

            return listaDeCables;
        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            string query = "Select * From CableElectrico WHERE numeroDeSerie = @numeroDeSerie";

            CableElectrico cable = new CableElectrico();

            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();


                cmd.Parameters.AddWithValue("@numeroDeSerie", numeroDeSerie);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        cable = new CableElectrico(int.Parse(reader["numeroDeSerie"].ToString()),
                                                   int.Parse(reader["cantidadDeConductores"].ToString()),
                                                   reader["marcaDelCable"].ToString(), float.Parse(reader["metros"].ToString()),
                                                   char.Parse(reader["seccionDelCable"].ToString()),
                                                   bool.Parse(reader["libreDeHalogenos"].ToString()),
                                                   bool.Parse(reader["fachadaOVivienda"].ToString()),
                                                   DateTime.Parse(reader["fechaDeCompra"].ToString()),
                                                   DateTime.Parse(reader["fechaDeVencimiento"].ToString()));

                    }
                }
                con.Close();

            }

            return cable;
        }

        public List<CableElectrico> MostrarTodoElCable()
        {
            string query = "Select * From CableElectrico";

            List<CableElectrico> listaDeCables = new List<CableElectrico>();

            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaDeCables.Add(
                                new CableElectrico(int.Parse(reader["numeroDeSerie"].ToString()),
                                                   int.Parse(reader["cantidadDeConductores"].ToString()),
                                                   reader["marcaDelCable"].ToString(), float.Parse(reader["metros"].ToString()),
                                                   char.Parse(reader["seccionDelCable"].ToString()),
                                                   bool.Parse(reader["libreDeHalogenos"].ToString()),
                                                   bool.Parse(reader["fachadaOVivienda"].ToString()),
                                                   DateTime.Parse(reader["fechaDeCompra"].ToString()),
                                                   DateTime.Parse(reader["fechaDeVencimiento"].ToString()))
                            );
                    }
                }
                con.Close();

            }

            return listaDeCables;
        }

        public String procedimientoAlmacenado(string parametro)
        {
            string salida = "";
            string procedimiento = "PruebaProcedimientoAlmacenado";


            using (SqlConnection con = new SqlConnection(conexionBD))
            using (SqlCommand cmd = new SqlCommand(procedimiento, con))
            {
                con.Open();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Parámetro de entrada
                cmd.Parameters.AddWithValue("@param", parametro);
                cmd.Parameters.AddWithValue("@paramNombreTabla", "CableElectrico");

                // Parámetro de salida (IMPORTANTE: especificar tamaño)
                SqlParameter parametroDeSalida = new SqlParameter("@param_salida", System.Data.SqlDbType.VarChar, (200));
                parametroDeSalida.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametroDeSalida);

                // Parámetro RETURN (solo puede ser INT)
                SqlParameter parametroDeReTorno = new SqlParameter();
                parametroDeReTorno.Direction = System.Data.ParameterDirection.ReturnValue;
                parametroDeReTorno.ParameterName = "@retorno";
                parametroDeReTorno.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(parametroDeReTorno);

                cmd.ExecuteNonQuery();

                salida += cmd.Parameters["@retorno"].Value + "-";
                salida += cmd.Parameters["@param_salida"].Value;

                con.Close();
            }

            return salida.ToString();
        }

    }
}
