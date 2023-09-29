using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PoliziaDiStato.Models
{
    public class AnagraficaTrasgressore
    {
        public int IDanagrafica { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Indirizzo { get; set; }

        [Required]
        public string Citta { get; set; }

        [Required]
        public string CAP { get; set; }

        [Required]
        public string Cod_Fisc { get; set; }

        public static void CreaAnagrafica(AnagraficaTrasgressore a)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO anagrafica VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @Cod_Fisc)", conn);
                cmd.Parameters.AddWithValue("Cognome", a.Cognome);
                cmd.Parameters.AddWithValue("Nome", a.Nome);
                cmd.Parameters.AddWithValue("Indirizzo", a.Indirizzo);
                cmd.Parameters.AddWithValue("Citta", a.Citta);
                cmd.Parameters.AddWithValue("CAP", a.CAP);
                cmd.Parameters.AddWithValue("Cod_Fisc", a.Cod_Fisc);

                int affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

        public static List<AnagraficaTrasgressore> GetAllAnagrafiche()
        {
            List<AnagraficaTrasgressore> ListaAnagrafiche = new List<AnagraficaTrasgressore>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Anagrafica", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnagraficaTrasgressore a = new AnagraficaTrasgressore
                    {
                        IDanagrafica = Convert.ToInt16(reader["IDanagrafica"].ToString()),
                        Cognome = reader["Cognome"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Indirizzo = reader["Indirizzo"].ToString(),
                        Citta = reader["Citta"].ToString(),
                        CAP = reader["CAP"].ToString(),
                        Cod_Fisc = reader["Cod_Fisc"].ToString(),
                    };

                    ListaAnagrafiche.Add(a);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaAnagrafiche;
        }
        public static void DeleteAnagrafica(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Anagrafica WHERE IDanagrafica={id}", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }
    }
}