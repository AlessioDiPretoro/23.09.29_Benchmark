using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PoliziaDiStato.Models
{
    public class TipoViolazione
    {
        public int IDviolazione { get; set; }
        public string Descrizione { get; set; }

        public static void CreaTipoViolazione(TipoViolazione v)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tipoviolazione VALUES (@Descrizione)", conn);
                cmd.Parameters.AddWithValue("Descrizione", v.Descrizione);
                int affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

        public static List<TipoViolazione> GetAllViolazioni()
        {
            List<TipoViolazione> ListaViolazioni = new List<TipoViolazione>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tipoviolazione", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TipoViolazione v = new TipoViolazione
                    {
                        IDviolazione = Convert.ToInt16(reader["IDviolazione"].ToString()),
                        Descrizione = reader["Descrizione"].ToString(),
                    };

                    ListaViolazioni.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaViolazioni;
        }

        public static void DeleteTipoViolazione(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Tipoviolazione WHERE IDviolazione={id}", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

        public static void EditTipoViolazione(TipoViolazione v)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = $"UPDATE Tipoviolazione SET Descrizione=@Descrizione where IDviolazione = {v.IDviolazione}";
                conn.Open();
                cmd.Parameters.AddWithValue("Descrizione", v.Descrizione);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { conn.Close(); }
        }
    }
}