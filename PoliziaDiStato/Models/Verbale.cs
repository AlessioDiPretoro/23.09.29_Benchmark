using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace PoliziaDiStato.Models
{
    public class Verbale
    {
        public int IDVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public double Importo { get; set; }
        public int DecurtamentoPunti { get; set; }

        [Display(Name = "Anagrafica")]
        public int IDanagrafica { get; set; }

        public AnagraficaTrasgressore anagraficaTrasgressore { get; set; }

        [Display(Name = "Violazione")]
        public int IDviolazione { get; set; }

        public TipoViolazione tipoViolazione { get; set; }

        public bool Contestabile { get; set; }

        public static List<Verbale> GetAllVerbali()
        {
            List<Verbale> ListaVerbali = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, Contestabile, Nome, Cognome, Descrizione from verbale as v Inner JOIN TIPOVIOLAZIONE as tv ON v.IDviolazione = tv.IDviolazione Inner JOIN ANAGRAFICA as an ON v.IDanagrafica = an.IDanagrafica", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnagraficaTrasgressore a = new AnagraficaTrasgressore
                    {
                        Nome = reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                    };
                    TipoViolazione viol = new TipoViolazione
                    {
                        Descrizione = reader["Descrizione"].ToString()
                    };
                    Verbale v = new Verbale
                    {
                        //IDVerbale = Convert.ToInt16(reader["IDverbale"].ToString()),
                        DataViolazione = Convert.ToDateTime(reader["DataViolazione"].ToString()),
                        IndirizzoViolazione = reader["IndirizzoViolazione"].ToString(),
                        Nominativo_Agente = reader["Nominativo_Agente"].ToString(),
                        DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"].ToString()),
                        Importo = Convert.ToDouble(reader["Importo"].ToString()),
                        DecurtamentoPunti = Convert.ToInt16(reader["DecurtamentoPunti"].ToString()),
                        Contestabile = Convert.ToBoolean(reader["Contestabile"]),
                        anagraficaTrasgressore = a,
                        tipoViolazione = viol
                    };

                    ListaVerbali.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaVerbali;
        }
        public static List<Verbale> GetAllVerbaliContestabili()
        {
            List<Verbale> ListaVerbali = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, Contestabile, Nome, Cognome, Descrizione from verbale as v Inner JOIN TIPOVIOLAZIONE as tv ON v.IDviolazione = tv.IDviolazione Inner JOIN ANAGRAFICA as an ON v.IDanagrafica = an.IDanagrafica where Contestabile = 1", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnagraficaTrasgressore a = new AnagraficaTrasgressore
                    {
                        Nome = reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                    };
                    TipoViolazione viol = new TipoViolazione
                    {
                        Descrizione = reader["Descrizione"].ToString()
                    };
                    Verbale v = new Verbale
                    {
                        //IDVerbale = Convert.ToInt16(reader["IDverbale"].ToString()),
                        DataViolazione = Convert.ToDateTime(reader["DataViolazione"].ToString()),
                        IndirizzoViolazione = reader["IndirizzoViolazione"].ToString(),
                        Nominativo_Agente = reader["Nominativo_Agente"].ToString(),
                        DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"].ToString()),
                        Importo = Convert.ToDouble(reader["Importo"].ToString()),
                        DecurtamentoPunti = Convert.ToInt16(reader["DecurtamentoPunti"].ToString()),
                        Contestabile = Convert.ToBoolean(reader["Contestabile"]),
                        anagraficaTrasgressore = a,
                        tipoViolazione = viol
                    };

                    ListaVerbali.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaVerbali;
        }
        public static List<Verbale> GetVerbaliPunti(int punti)
        {
            List<Verbale> ListaVerbali = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand($"select DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, Contestabile, Nome, Cognome, Descrizione from verbale as v Inner JOIN TIPOVIOLAZIONE as tv ON v.IDviolazione = tv.IDviolazione Inner JOIN ANAGRAFICA as an ON v.IDanagrafica = an.IDanagrafica where DecurtamentoPunti >= {punti}", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnagraficaTrasgressore a = new AnagraficaTrasgressore
                    {
                        Nome = reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                    };
                    TipoViolazione viol = new TipoViolazione
                    {
                        Descrizione = reader["Descrizione"].ToString()
                    };
                    Verbale v = new Verbale
                    {
                        //IDVerbale = Convert.ToInt16(reader["IDverbale"].ToString()),
                        DataViolazione = Convert.ToDateTime(reader["DataViolazione"].ToString()),
                        IndirizzoViolazione = reader["IndirizzoViolazione"].ToString(),
                        Nominativo_Agente = reader["Nominativo_Agente"].ToString(),
                        DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"].ToString()),
                        Importo = Convert.ToDouble(reader["Importo"].ToString()),
                        DecurtamentoPunti = Convert.ToInt16(reader["DecurtamentoPunti"].ToString()),
                        Contestabile = Convert.ToBoolean(reader["Contestabile"]),
                        anagraficaTrasgressore = a,
                        tipoViolazione = viol
                    };

                    ListaVerbali.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaVerbali;
        }

        public static List<Verbale> GetVerbaliEuro(int euro)
        {
            List<Verbale> ListaVerbali = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand($"select DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, Contestabile, Nome, Cognome, Descrizione from verbale as v Inner JOIN TIPOVIOLAZIONE as tv ON v.IDviolazione = tv.IDviolazione Inner JOIN ANAGRAFICA as an ON v.IDanagrafica = an.IDanagrafica where Importo >= {euro}", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnagraficaTrasgressore a = new AnagraficaTrasgressore
                    {
                        Nome = reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                    };
                    TipoViolazione viol = new TipoViolazione
                    {
                        Descrizione = reader["Descrizione"].ToString()
                    };
                    Verbale v = new Verbale
                    {
                        //IDVerbale = Convert.ToInt16(reader["IDverbale"].ToString()),
                        DataViolazione = Convert.ToDateTime(reader["DataViolazione"].ToString()),
                        IndirizzoViolazione = reader["IndirizzoViolazione"].ToString(),
                        Nominativo_Agente = reader["Nominativo_Agente"].ToString(),
                        DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"].ToString()),
                        Importo = Convert.ToDouble(reader["Importo"].ToString()),
                        DecurtamentoPunti = Convert.ToInt16(reader["DecurtamentoPunti"].ToString()),
                        Contestabile = Convert.ToBoolean(reader["Contestabile"]),
                        anagraficaTrasgressore = a,
                        tipoViolazione = viol
                    };

                    ListaVerbali.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return ListaVerbali;
        }

        /*
        public static void TuttiVerbaliStoredProcedure()
        {
            List<Verbale> ListaVerbali = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("MostraVerbali", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.
                //BLOCCATO QUI...
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }
        */

        public static void CreaVerbale(Verbale v)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Verbale VALUES (@DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @IDanagrafica, @IDviolazione, @Contestabile)", conn);
                cmd.Parameters.AddWithValue("DataViolazione", v.DataViolazione);
                cmd.Parameters.AddWithValue("IndirizzoViolazione", v.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("Nominativo_Agente", v.Nominativo_Agente);
                cmd.Parameters.AddWithValue("DataTrascrizioneVerbale", v.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("Importo", v.Importo);
                cmd.Parameters.AddWithValue("DecurtamentoPunti", v.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("IDanagrafica", v.IDanagrafica);
                cmd.Parameters.AddWithValue("IDviolazione", v.IDviolazione);
                cmd.Parameters.AddWithValue("Contestabile", Convert.ToBoolean(v.Contestabile));

                int affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

        public static List<Verbale> TotalePuntiPerTrasgressore()
        {
            List<Verbale> TotalePunti = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select sum (DecurtamentoPunti) as TotPuntiDecurtati, Nome, Cognome from Verbale as V Inner Join ANAGRAFICA as A ON V.IDanagrafica = a.IDanagrafica GROUP BY a.IDanagrafica, Nome, Cognome", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnagraficaTrasgressore a = new AnagraficaTrasgressore
                    {
                        Nome = reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                    };
                    Verbale v = new Verbale
                    {
                        DecurtamentoPunti = Convert.ToInt16(reader["TotPuntiDecurtati"].ToString()),
                        anagraficaTrasgressore = a
                    };

                    TotalePunti.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return TotalePunti;
        }

        public static List<Verbale> TotaleVerbaliPerTrasgressore()
        {
            List<Verbale> TotalePunti = new List<Verbale>();
            string connectionString = ConfigurationManager.ConnectionStrings["PoliziaCoConnString"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select count (*) as TotVerbali, Nome, Cognome from Verbale as V Inner Join ANAGRAFICA as A ON V.IDanagrafica = a.IDanagrafica GROUP BY a.IDanagrafica, Nome, Cognome", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnagraficaTrasgressore a = new AnagraficaTrasgressore
                    {
                        Nome = reader["Nome"].ToString(),
                        Cognome = reader["Cognome"].ToString(),
                    };
                    Verbale v = new Verbale
                    {
                        DecurtamentoPunti = Convert.ToInt16(reader["TotVerbali"].ToString()),
                        anagraficaTrasgressore = a
                    };

                    TotalePunti.Add(v);
                }
            }
            catch (Exception ex) { }
            finally { conn.Close(); }

            return TotalePunti;
        }
    }
}