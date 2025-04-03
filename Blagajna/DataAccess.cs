using ServisVozila.Models;
using ServisVozila.Views;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServisVozila
{
    public class DataAccess
    {
        SecureString connection = new SecureString();
        public static bool TestConnection(string user, string pass) {

            string connString = string.Format(Configuration.ConnectionStringTemplate, user, pass);


            try
            {
                using (IDbConnection conn = new SqlConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    bool output = conn.ExecuteScalar<bool>("SELECT 1");


                    App.ConnectionString = connString;
                    return output;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Nemate dozvolu za selekciju poreske kartice. Molimo obratite se administratoru sistema.",
                                    "UPOZORENJE");
                    return false;
                }
                else
                {
                    MessageBox.Show($"SQL Server greška: {ex.Number}. ({ex.Message})");
                    return false;
                    // Handle other SQL errors
                }
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.ToString());
                MessageBox.Show($"Greška: DataAccess.TestConnection. {ex}");
                return false;
            }


        }

        public static async Task<ObservableCollection<Potrosac>> GetPotrosaciAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<Potrosac>("SELECT * FROM Potrosaci_View")).ToList();

                return new ObservableCollection<Potrosac>(output);
            }
        }
        public static async Task<ObservableCollection<KontoDT>> GetKontaAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<KontoDT>("SELECT * FROM KontaDT_View")).ToList();

                return new ObservableCollection<KontoDT>(output);
            }
        }
        public static async Task<ObservableCollection<VrstePrometaBlagajna>> GetVrstaPrometaAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<VrstePrometaBlagajna>("SELECT * FROM VrstePrometaBlagajna")).ToList();

                return new ObservableCollection<VrstePrometaBlagajna>(output);
            }
        }
        public static async Task<ObservableCollection<Vozila>> GetVozilaAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<Vozila>("SELECT * FROM Vozila_View ORDER BY BrojAlarma desc, Naziv asc")).ToList();

                return new ObservableCollection<Vozila>(output);
            }
        }
        public static async Task<ObservableCollection<AlarmiVozila>> GetAlarmiAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<AlarmiVozila>("SELECT * FROM AlarmiVozila")).ToList();

                return new ObservableCollection<AlarmiVozila>(output);
            }
        }
        public static async Task<ObservableCollection<KilometrazaVozila>> GetKilometrazeAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<KilometrazaVozila>("SELECT * FROM KilometrazaVozila")).ToList();

                return new ObservableCollection<KilometrazaVozila>(output);
            }
        }
        public static async Task<ObservableCollection<Materijal>> GetMaterijalAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<Materijal>("SELECT * FROM Materijal")).ToList();

                return new ObservableCollection<Materijal>(output);
            }
        }
        public static async Task<ObservableCollection<RegistracijaVozila>> GetRegistracijaAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<RegistracijaVozila>("SELECT * FROM RegistracijaVozila")).ToList();

                return new ObservableCollection<RegistracijaVozila>(output);
            }
        }
        public static async Task<ObservableCollection<VrstaGoriva>> GetVrsteGorivaAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<VrstaGoriva>("SELECT * FROM VrstaGoriva")).ToList();

                return new ObservableCollection<VrstaGoriva>(output);
            }
        }
        public static async Task<ObservableCollection<Servisi>> GetServisiAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<Servisi>("SELECT * FROM Servisi")).ToList();

                return new ObservableCollection<Servisi>(output);
            }
        }
        public static async Task<ObservableCollection<VrstaServisa>> GetVrsteServisaAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<VrstaServisa>("SELECT * FROM VrstaServisa")).ToList();

                return new ObservableCollection<VrstaServisa>(output);
            }
        }
        public static async Task<ObservableCollection<MaterijalSkladiste>> GetMaterijalSkladisteAsync()
        {
            string connString = App.ConnectionString;

            using (IDbConnection conn = new SqlConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Use Dapper to query the database and convert to ObservableCollection
                var output = (await conn.QueryAsync<MaterijalSkladiste>("SELECT * FROM MaterijalSkladiste ORDER BY Naziv asc")).ToList();

                return new ObservableCollection<MaterijalSkladiste>(output);
            }
        }
        public static int ExecuteStoredProcedure(string stored_proc_name, DynamicParameters parameters)
        {

            using (IDbConnection conn = new SqlConnection(App.ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                int rows_affected = conn.Execute(stored_proc_name, parameters, commandType: CommandType.StoredProcedure);
                return rows_affected;
            }


        }
        public static bool hasOpenBlagajnickiDnevnik()
        {
            using (IDbConnection conn = new SqlConnection(App.ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                int output = conn.ExecuteScalar<int>("SELECT Count(*) FROM BlagajnickiDnevnici WHERE DatumZatvaranja IS NULL");
                return output > 0;
            }
        }
    }
}
