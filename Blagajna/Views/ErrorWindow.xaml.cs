using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ServisVozila.Views
{
    /// <summary>
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        string errorType;
        string errorCaption;
        string errorMessage;

        public ErrorWindow(string ErrorType, string ErrorCaption, string ErrorMessage)
        {
            InitializeComponent();

            errorType = ErrorType;
            errorCaption = ErrorCaption;
            errorMessage = ErrorMessage;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtErrorCaption.Text = errorCaption;
            txtErrorMessage.Text = errorMessage;
            txtErrorType.Text = errorType;
        }
    }
}
