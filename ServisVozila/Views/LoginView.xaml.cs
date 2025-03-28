﻿using ServisVozila.ViewModels;
using ServisVozila.Views;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;


namespace ServisVozila
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e) {
            string username = txtUser.Text;
            string password = txtPass.Password;

            btnLogin.IsEnabled = false;

            if (await DataAccess.TestConnectionAsync(username, password))
            {
                Settings1.Default.username = username;
                Settings1.Default.Save();

                // Open LoadingView.xaml
                try
                {
                    //bool imaOtvorenBD = DataAccess.hasOpenBlagajnickiDnevnik();

                    //if (imaOtvorenBD)
                    //{
                        LoadingView loadingView = new LoadingView();
                        loadingView.Show();
                    //}
                    //else
                    //{
                    //    //OtvaranjeBlagajneWindow ob = new OtvaranjeBlagajneWindow();
                    //    //ob.Show();
                    //}

                }
                catch (SqlException ex)
                {
                    ErrorWindow ew = new ErrorWindow(ex.GetType().ToString(), "GREŠKA", ex.Message);
                    ew.Show();
                }
                catch (Exception ex)
                {
                    ErrorWindow ew = new ErrorWindow(ex.GetType().ToString(), "GREŠKA", ex.Message);
                    ew.Show();
                }
                finally
                {
                    this.Close();
                }
            }
            else {
                txtGreska.Visibility = Visibility.Visible;
                txtGreska.Text = "Neuspješna konekcija";
                txtPass.Password = "";
                txtPass.Focus();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Text = Settings1.Default.username;

            // Check if txtUser is not empty
            if (!string.IsNullOrWhiteSpace(txtUser.Text))
            {
                // Set focus to txtPass
                txtPass.Focus();
            }
            else
            {
                // Set focus to txtUser by default
                txtUser.Focus();
            }
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = txtPass.Password;
            }

            if (txtPass.Password.Length > 0) { 
            btnLogin.IsEnabled = true;
                txtGreska.Text = "";
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            EnterClicked(e);
        }

        private void EnterClicked(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtUser.Text) &&
                    !string.IsNullOrWhiteSpace(txtPass.Password))
                {
                    btnLogin_Click(new object(), new RoutedEventArgs());
                }
           
            }
        }


        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            EnterClicked(e);
        }
    }
}
