using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using KeepItFit___Project_WinUI.Services;
using System.Diagnostics;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class ChangePasswordPageViewModel : INotifyPropertyChanged
    {
        public string currentPassword { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }

        public ChangePasswordPageViewModel()
        {
            currentPassword = "";
            newPassword = "";
            confirmPassword = "";
        }

        public void ChangePassword()
        {
            // Check if the current password is correct
            if (!IsCurrentPasswordCorrect(currentPassword))
            {
                throw new Exception("Current password is incorrect");
            }

            // Check if the new password is valid
            if (!IsNewPasswordValid(newPassword))
            {
                throw new Exception("New password is invalid");
            }

            // Check if the new password matches the confirm password
            if (newPassword != confirmPassword)
            {
                throw new Exception("New password does not match confirm password");
            }

            // Update the password in the database
            UpdatePasswordInDatabase(currentPassword, newPassword);
        }

        private bool IsCurrentPasswordCorrect(string currentPassword)
        {
            string hashedCurrentPassword = HashPassword(currentPassword);

            IDao dao = new SQLDao();
            string storedHashedPassword = dao.GetStoredHashedPassword(UserSessionService.Instance.UserEmail);

            return hashedCurrentPassword == storedHashedPassword;
        }

        private bool IsNewPasswordValid(string newPassword)
        {
            return string.IsNullOrWhiteSpace(newPassword) ? false : true;
        }

        private void UpdatePasswordInDatabase(string currentPassword, string newPassword)
        {
            IDao dao = new SQLDao();

            dao.UpdateNewPasswordForUser(UserSessionService.Instance.UserEmail, HashPassword(newPassword));
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
