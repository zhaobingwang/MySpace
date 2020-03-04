using Microsoft.EntityFrameworkCore;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            InitializeDgvAppPasswordStyle();
        }

        List<AppPassword> AppPasswords = null;

        #region control event
        private async void Home_Load(object sender, EventArgs e)
        {
            await SqliteDbContextSeed();

            await LoadDatas();
        }

        /// <summary>
        /// 创建应用密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemCreatePassword_Click(object sender, EventArgs e)
        {
            CreateOrEditAppPassword formCreate = new CreateOrEditAppPassword();
            formCreate.StartPosition = FormStartPosition.CenterParent;
            formCreate.ShowDialog(this);
        }
        #endregion

        internal async Task LoadDatas()
        {
            using (var db = new SqliteDbContext())
            {
                AppPasswords = await db.AppPasswords.ToListAsync();
            }
            dgvAppPassword.DataSource = AppPasswords;
        }

        private async Task SqliteDbContextSeed()
        {
            using (var db = new SqliteDbContext())
            {
                if (db.AppPasswords.Count() < 1)
                {
                    db.AppPasswords.AddRange(new AppPassword
                    {
                        AppName = "APP1",
                        Password = "123",
                        CreateTime = DateTime.UtcNow,
                        ModifyTime = DateTime.UtcNow
                    },
                    new AppPassword
                    {
                        AppName = "APP2",
                        Password = "456",
                        CreateTime = DateTime.UtcNow,
                        ModifyTime = DateTime.UtcNow
                    });
                    await db.SaveChangesAsync();
                }
            }
        }

        private void InitializeDgvAppPasswordStyle()
        {

            dgvAppPassword.ReadOnly = true;
            dgvAppPassword.Columns["ID"].FillWeight = 10;
            dgvAppPassword.Columns["AppName"].FillWeight = 20;
            dgvAppPassword.Columns["Password"].FillWeight = 30;
            dgvAppPassword.Columns["CreateTime"].FillWeight = 20;
            dgvAppPassword.Columns["ModifyTime"].FillWeight = 20;
            dgvAppPassword.Columns["Edit"].FillWeight = 20;
            dgvAppPassword.AutoGenerateColumns = false;
        }

        private void dgvAppPassword_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var current = dgvAppPassword[0, e.RowIndex];

            CreateOrEditAppPassword formCreate = new CreateOrEditAppPassword((int)current.Value);
            formCreate.StartPosition = FormStartPosition.CenterParent;
            formCreate.ShowDialog(this);
        }
    }
}
