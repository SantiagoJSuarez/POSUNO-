using POSUNO.Components;
using POSUNO.Helpers;
using POSUNO.Models;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace POSUNO.Pages
{

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            EmailTextBox.Text = "juan@yopmail.com";
            PasswordPasswordBox.Password = "123456";
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = await ValidForm();
            if(!isValid)
            {
                return;
            }

            Loader loader = new Loader("Por favor Espere ...");
            loader.Show();

            Response response = await ApiService.LoginAsync(new LoginRequest
            {
                Email = EmailTextBox.Text,
                Password = PasswordPasswordBox.Password
            });

            loader.Close();

            MessageDialog messageDialog;

            if (!response.IsSuccess)
            {
                 messageDialog = new MessageDialog(response.Message,"Ok");
                await messageDialog.ShowAsync();
                return;


            }

            User user = (User)response.Result; //Devuelve el Usuario 
            if(user == null )
            {
                messageDialog = new MessageDialog("Usuario o contraseña Incorrectos", "Error");
                await messageDialog.ShowAsync();
                return;
            }

            Frame.Navigate(typeof(MainPage), user);

        }

        private async Task<bool> ValidForm()
        {
            MessageDialog messageDialog;

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                messageDialog = new MessageDialog("Debes Ingresar tu email.", "Error");
                await messageDialog.ShowAsync();
                return false;
            }

            if (!RegexUtilities.IsValidEmail(EmailTextBox.Text))
            {
                messageDialog = new MessageDialog("Debes Ingresar un email Valido ", "Error");
                await messageDialog.ShowAsync();
                return false;
            }

            if (PasswordPasswordBox.Password.Length < 6)
            {
                messageDialog = new MessageDialog("Debes Ingresar tu contraseña de almenos 6 caracteres .", "Error");
                await messageDialog.ShowAsync();
                return false;
            }

            return true;
        }
    }
}