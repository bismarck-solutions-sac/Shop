namespace Shop.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Data;
    using System.Threading.Tasks;
    public interface IMailHelper
    {
        void SendMail(string to, string subject, string body);

        Task PostSendMail(string to, string name, string subject, string body);

    }
}