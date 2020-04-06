namespace Shop.UIForms.ViewModels
{
    
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Shop.UIForms.Views;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(this.Login);

        public LoginViewModel()
        {
            this.Email = "jose.arroyo@bismarck.com.pe";
            this.Password = "060285";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Advertencia", 
                    "Ingrese un e-mail válido", 
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Advertencia", 
                    "Ingrese un password",
                    "Aceptar");
                return;
            }

            if (!this.Email.Equals("jose.arroyo@bismarck.com.pe") || !this.Password.Equals("060285"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Advertencia", 
                    "Ingrese un e-mail o un password",
                    "Aceptar");
                return;
            }
            /*
            await Application.Current.MainPage.DisplayAlert(
                "Ok", 
                "Usuario correcto!!!",
                "Aceptar");
            */
            MainViewModel.GetInstance().Products = new ProductsViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());


        }
    }

}
