using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Visibility IsErrorMessageVisible { get; set; }
        public string ErrorMessage { get; set; }

        public UserInfo user {  get; set; }

        

        public SignInViewModel()
        {
            IsErrorMessageVisible = Visibility.Collapsed;
            user = new UserInfo();
        }

        public bool VerifyDataSignIn()
        {
            string hashedPassword = HashPassword(Password);
            try
            {
                IDao dao = new SQLDao();
                dao.VerifyDataSignIn(Email, hashedPassword);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }

            return true;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
