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
using MySpace.Utilities;

namespace PasswordManager
{
    public partial class Home : Form
    {
        private readonly short MaxAppPasswordUseDay = 30;
        List<AppPassword> AppPasswords = null;

        public Home()
        {
            InitializeComponent();

            InitializeDgvAppPasswordStyle();
        }

        #region control event
        private async void Home_Load(object sender, EventArgs e)
        {
            await SqliteDbContextSeed();

            await LoadDatas();

            CheckExpiredPassword();

        }

        private void CheckExpiredPassword()
        {
            string message = string.Empty;
            var now = DateTimeOffset.UtcNow.DateTime;
            foreach (var appPassword in AppPasswords)
            {
                var usedTime = now - (DateTimeOffset)appPassword.ModifyTime;
                if (usedTime.Days >= MaxAppPasswordUseDay)
                {
                    message += $"{appPassword.AppName},";
                }
            }
            if (!message.IsNullOrEmpty())
            {
                message = message.Substring(0, message.Length - 1);
                message += $"等应用的密码已超过{MaxAppPasswordUseDay}天";

                notifyIconDefault.Visible = true;
                notifyIconDefault.ShowBalloonTip(3000, "同一密码使用时间过长提醒", message, ToolTipIcon.Warning);
            }
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

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            WindowState = FormWindowState.Minimized;
        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            // 如果点击了最小化
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;  // 隐藏任务栏区图标
                notifyIconDefault.Visible = true;   // 图标显示在托盘区
            }
        }

        /// <summary>
        /// 显示主窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMainWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void notifyIconDefault_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                ShowMainWindow();
            else
                HideMainWindow();
        }

        private void ShowMainWindow()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void HideMainWindow()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }
    }
}
