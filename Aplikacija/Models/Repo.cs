using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Aplikacija.Models
{
    public class Repo
    {
        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        internal static dynamic GetKatCount() => (int)SqlHelper.ExecuteScalar(cs, "GetKatCount");
        

        internal static int GetPotkCount() => (int)SqlHelper.ExecuteScalar(cs, "GetPotkCount");


        public static IEnumerable<Kupac> GetKupci()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetKupci");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKupacFromDataRow(row);
            }

        }

        public static IEnumerable<Proizvod> GetProizvodi()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetProizvodi");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetProizvodFromDataRow(row);
            }
        }

        public static IEnumerable<Potkategorija> GetPotkategorije()
        {
            
            ds = SqlHelper.ExecuteDataset(cs, "GetPotkategorije");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetPotkFromDataRow(row);
            }
        }

        public static IEnumerable<Kategorija> GetKategorije()
        {

            ds = SqlHelper.ExecuteDataset(cs, "GetKategorije");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKategorijaFromDataRow(row);
            }
        }

        //public static List<Grad> GetGradovi()
        //{
        //    List<Grad> gradovi = new List<Grad>();
        //    ds = SqlHelper.ExecuteDataset(cs, "GetGradovi");
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        gradovi.Add(GetGradFromDataRow(row));
        //    }
        //    return gradovi;
        //}

        public static List<Potkategorija> GetPotks()
        {
            List<Potkategorija> potkategorije = new List<Potkategorija>();
            ds = SqlHelper.ExecuteDataset(cs, "GetPotks");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                potkategorije.Add(GetPotkFromDataRow(row));
            }
            return potkategorije;
        }

        private static Grad GetGradFromDataRow(DataRow row)
        {
            return new Grad
            {
                IDGrad = (int)row["IDGrad"],
                Naziv = row["Naziv"].ToString()
            };
        }

        internal static void CreateKategorija(Kategorija k) => SqlHelper.ExecuteNonQuery(cs, "CreateKat", k.Naziv);
        internal static void CreatePotkategorija(Potkategorija p) => SqlHelper.ExecuteNonQuery(cs, "CreatePotkat", p.Naziv, p.KategorijaID);
        internal static void CreateProizvod(Proizvod p) => SqlHelper.ExecuteNonQuery(cs, "CreateProizvod", p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPDV, p.PotkategorijaID);


        private static Proizvod GetProizvodFromDataRow(DataRow row)
        {
            return new Proizvod
            {
                IDProizvod = (int)row["IDProizvod"],
                Naziv = row["Naziv"].ToString(),
                BrojProizvoda = row["BrojProizvoda"].ToString(),
                Boja = row["Boja"] != DBNull.Value ? row["Boja"].ToString() : default,
                MinimalnaKolicinaNaSkladistu = (short)row["MinimalnaKolicinaNaSkladistu"],
                CijenaBezPDV = (decimal)row["CijenaBezPDV"],
                PotkategorijaID = row["PotkategorijaID"] != DBNull.Value ? (int)row["PotkategorijaID"] : default,
                Potk = GetPotkategorija((int)row["PotkategorijaID"])
            };
        }

        internal static int UpdateProizvod(Proizvod p) => SqlHelper.ExecuteNonQuery(cs, "UpdateProizvod", p.IDProizvod, p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPDV, p.PotkategorijaID);

        internal static int UpdatePotkategorija(Potkategorija p) => SqlHelper.ExecuteNonQuery(cs, "UpdatePotk", p.IDPotkategorija, p.Naziv, p.KategorijaID);
        internal static int UpdateKategorija(Kategorija k) => SqlHelper.ExecuteNonQuery(cs, "UpdateKat", k.IDKategorija, k.Naziv);

        public static Kupac GetKupac(int IDKupac)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKupac", IDKupac).Tables[0].Rows[0];
            return GetKupacFromDataRow(row);
        }

        public static Proizvod GetProizvod(int IDProizvod)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetProizvod", IDProizvod).Tables[0].Rows[0];
            return GetProizvodFromDataRow(row);
        }

        public static Potkategorija GetPotkategorija(int IDProizvod)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetPotk", IDProizvod).Tables[0].Rows[0];
            return GetPotkFromDataRow(row);
        }

        

        private static Potkategorija GetPotkFromDataRow(DataRow row)
        {
            return new Potkategorija
            {
                IDPotkategorija = (int)row["IDPotkategorija"],
                KategorijaID = (int)row["KategorijaID"],
                Naziv = row["Naziv"].ToString(),
                Kat = GetKategorija((int)row["KategorijaID"])
            };
        }

        public static Kategorija GetKategorija(int IDKategorija)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKat", IDKategorija).Tables[0].Rows[0];
            return GetKategorijaFromDataRow(row);
        }

        private static Kategorija GetKategorijaFromDataRow(DataRow row)
        {
            return new Kategorija
            {
                IDKategorija = (int)row["IDKategorija"],
                Naziv = row["Naziv"].ToString()
            };
        }

        public static int DeleteKupac(int kupacId) => SqlHelper.ExecuteNonQuery(cs, "DeleteKupac", kupacId);
        public static int DeletePotkategorija(int IDPotkategorija) => SqlHelper.ExecuteNonQuery(cs, "DeletePotk", IDPotkategorija);
        public static int DeleteProizvod(int IDProizvod) => SqlHelper.ExecuteNonQuery(cs, "DeleteProizvod", IDProizvod);
        public static int DeleteKategorija(int IDKategorija) => SqlHelper.ExecuteNonQuery(cs, "DeleteKategorija", IDKategorija);

        public static int UpdateKupac(Kupac kupac) => SqlHelper.ExecuteNonQuery(cs, "UpdateKupac", kupac.IDKupac, kupac.Ime, kupac.Prezime, kupac.Email, kupac.Telefon, kupac.GradID);

        

        private static Kupac GetKupacFromDataRow(DataRow row)
        {
            return new Kupac
            {
                IDKupac = (int)row["IDKupac"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
                GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1
            };
        }

        public static Grad GetGrad(int gradId)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetGrad", gradId).Tables[0].Rows[0];
            return GetGradFromDataRow(row);
        }
        public static IEnumerable<Racun> GetRacuniKupca(int kupacId)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetRacuniKupca", kupacId);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new Racun
                {
                    IDRacun = (int)row["IDRacun"],
                    DatumIzdavanja = DateTime.Parse(row["DatumIzdavanja"].ToString()),
                    BrojRacuna = row["BrojRacuna"].ToString(),
                    Komentar = row["Komentar"] != DBNull.Value ? row["Komentar"].ToString() : "-"
                };
            }
        }


        public static int GetProductsCount() => (int)SqlHelper.ExecuteScalar(cs, "GetProductsCount");
    }
}