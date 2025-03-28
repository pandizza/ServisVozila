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
        public static async Task<bool> TestConnectionAsync(string user, string pass)
        {
            string connString = string.Format(Configuration.ConnectionStringTemplate, user, pass);

            try
            {
                await using (var conn = new SqlConnection(connString))
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync(); // Use async Open method

                    var output = await conn.ExecuteScalarAsync<int>("SELECT 1"); // Await the result

                    App.ConnectionString = connString;
                    return output == 1; // Ensure conversion to bool
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Nemate dozvolu za selekciju tabele. Molimo obratite se administratoru sistema.", "UPOZORENJE");
                    return false;
                }
                else
                {
                    MessageBox.Show($"SQL Server greška: {ex.Number}. ({ex.Message})", "GREŠKA");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.ToString());
                MessageBox.Show($"Greška: DataAccess.TestConnection. {ex.Message}", "GREŠKA");
                return false;
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
                var output = (await conn.QueryAsync<Vozila>("SELECT * FROM Vozila_View")).ToList();

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

        public static int ExecuteStoredProcedure(string stored_proc_name, DynamicParameters parameters)
        {

            try
            {
                using (IDbConnection conn = new SqlConnection(App.ConnectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    int rows_affected = conn.Execute(stored_proc_name, parameters, commandType: CommandType.StoredProcedure);
                    return rows_affected;
                }
            }
            catch (SqlException ex)
            {

                ErrorWindow ew = new ErrorWindow("SqlException", "GREŠKA", ex.Message);
                ew.Show();
                return 0;
                
            }
            catch (Exception ex)
            {
                ErrorWindow ew = new ErrorWindow(ex.GetType().ToString(), "GREŠKA", ex.Message);
                ew.Show();
                return 0;
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
