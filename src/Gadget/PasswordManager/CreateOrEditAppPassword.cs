﻿using PasswordManager.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySpace.Utilities.Security;
using System.Configuration;

namespace PasswordManager
{
    public partial class CreateOrEditAppPassword : Form
    {
        private int _appPwdId;
        private AppPassword CurrentSelectAppPwd;
        private string _publicKey = string.Empty;
        private string _privateKey = string.Empty;
        public CreateOrEditAppPassword()
        {
            InitializeComponent();
        }

        public CreateOrEditAppPassword(int appPwdId) : this()
        {
            _appPwdId = appPwdId;
            _publicKey = ConfigurationManager.AppSettings["publicKey"];
            _privateKey = ConfigurationManager.AppSettings["privateKey"];
        }

        private void CreateOrEditAppPassword_Load(object sender, EventArgs e)
        {
            if (_appPwdId > 0)
            {
                using (var db = new SqliteDbContext())
                {
                    CurrentSelectAppPwd = db.AppPasswords.FirstOrDefault(p => p.ID == _appPwdId);
                    txtAppName.Text = CurrentSelectAppPwd.AppName;
                    txtAppPassword.Text = RSAUtil.Decrypt(CurrentSelectAppPwd.Password, _privateKey);
                }
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            await Save();
            Home home = (Home)Owner;
            await home.LoadDatas();
            Close();
        }

        private async Task<bool> Save()
        {
            var appName = txtAppName.Text.Trim();
            var appPassword = RSAUtil.Encrypt(txtAppPassword.Text.Trim(), _publicKey);

            using (var db = new SqliteDbContext())
            {
                if (_appPwdId > 0)
                {
                    CurrentSelectAppPwd.AppName = appName;
                    CurrentSelectAppPwd.Password = appPassword;
                    CurrentSelectAppPwd.ModifyTime = DateTime.UtcNow;
                    db.AppPasswords.Update(CurrentSelectAppPwd);
                }
                else
                {
                    db.AppPasswords.Add(new AppPassword
                    {
                        AppName = appName,
                        Password = appPassword,
                        CreateTime = DateTime.UtcNow,
                        ModifyTime = DateTime.UtcNow
                    });
                }

                return await db.SaveChangesAsync() > 0;
            }
        }

        private void btnRndPassword_Click(object sender, EventArgs e)
        {
            txtAppPassword.Text = Password.Generate(10, 2);
        }
    }
}
