using KeepItFit___Project_WinUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class AvatarViewModel
    {
        public byte[] imageBytes { get; set; }

        public AvatarViewModel() { }

        public async Task SaveAvatarAsync()
        {
            IDao sqlDao = new SQLDao();
            await sqlDao.SaveAvatarToDatabase(imageBytes);
        }

        public async Task<byte[]> GetAvatarAsync()
        {
            IDao sqlDao = new SQLDao();
            imageBytes = await sqlDao.GetAvatarFromDatabase();

            return imageBytes;
        }
    }
}
