namespace Shop.UIForms.Helpers
{
    using Interfaces;
    using Xamarin.Forms;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resources.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept => Resources.Accept;

        public static string Error => Resources.Error;

        public static string EmailError => Resources.EmailError;

        public static string PasswordError => Resources.PasswordError;

        public static string LoginError => Resources.LoginError;


        public static string Login => Resources.Login;

        public static string Email => Resources.Email;

        public static string EmailPlaceHolder => Resources.EmailPlaceHolder;

        public static string Password => Resources.Password;

        public static string PasswordPlaceHolder => Resources.PasswordPlaceHolder;

        public static string Remember => Resources.Remember;

        public static string RegisterNewUser => Resources.RegisterNewUser;

    }

}
