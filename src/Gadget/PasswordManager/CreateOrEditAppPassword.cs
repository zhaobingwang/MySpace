using PasswordManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class CreateOrEditAppPassword : Form
    {
        public CreateOrEditAppPassword()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await Save();

            Home home = (Home)Owner;
            home.pan
            Close();
        }

        private async Task<bool> Save()
        {
            var appName = txtAppName.Text.Trim();
            var appPassword = txtAppPassword.Text.Trim();

            using (var db = new SqliteDbContext())
            {
                db.AppPasswords.Add(new AppPassword
                {
                    AppName = appName,
                    Password = appPassword,
                    CreateTime = DateTime.UtcNow,
                    ModifyTime = DateTime.UtcNow
                });
                return await db.SaveChangesAsync() > 0;
            }
        }
    }
}
