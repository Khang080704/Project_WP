using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.Services
{
    public class UserSessionService
    {
        private static UserSessionService _instance;
        public static UserSessionService Instance => _instance ??= new UserSessionService();

        public string UserEmail { get; private set; }

        private UserSessionService() { }

        public void SetUserEmail(string email)
        {
            UserEmail = email;
        }

        public void ClearSession()
        {
            UserEmail = null;
        }
    }
}
