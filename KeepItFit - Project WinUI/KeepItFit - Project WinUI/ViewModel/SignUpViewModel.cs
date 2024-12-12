using KeepItFit___Project_WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        public SignUpViewModel()
        {

        }

        public void SaveDataSignUp()
        {
            string hashedPassword = HashPassword(Password);
            string formattedDateOfBirth = DateOfBirth?.ToString("yyyy-MM-dd");
            IDao dao = new SQLDao();
            dao.SaveDataSignUp(Email, hashedPassword, FirstName, LastName, formattedDateOfBirth);
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
