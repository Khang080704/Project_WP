using KeepItFit___Project_WinUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class DeleteAccountViewModel
    {
        public DeleteAccountViewModel() { }

        public void DeleteAccount()
        {
            // Delete the account from the database
            IDao dao = new SQLDao();
            dao.DeleteAccount(UserSessionService.Instance.UserEmail);
        }
    }
}
