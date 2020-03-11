namespace PasswordManager
{
    partial class Home
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.dgvAppPassword = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCreatePassword = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppPassword)).BeginInit();
            this.panel1.SuspendLayout();
            this.mnsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAppPassword
            // 
            this.dgvAppPassword.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppPassword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppPassword.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AppName,
            this.Password,
            this.CreateTime,
            this.ModifyTime,
            this.Edit});
            this.dgvAppPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppPassword.Location = new System.Drawing.Point(0, 0);
            this.dgvAppPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvAppPassword.Name = "dgvAppPassword";
            this.dgvAppPassword.RowHeadersWidth = 72;
            this.dgvAppPassword.RowTemplate.Height = 23;
            this.dgvAppPassword.Size = new System.Drawing.Size(863, 428);
            this.dgvAppPassword.TabIndex = 0;
            this.dgvAppPassword.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAppPassword_CellMouseDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 28.72777F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 9;
            this.ID.Name = "ID";
            // 
            // AppName
            // 
            this.AppName.DataPropertyName = "AppName";
            this.AppName.FillWeight = 43.74945F;
            this.AppName.HeaderText = "应用";
            this.AppName.MinimumWidth = 9;
            this.AppName.Name = "AppName";
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.FillWeight = 149.9032F;
            this.Password.HeaderText = "密码";
            this.Password.MinimumWidth = 9;
            this.Password.Name = "Password";
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.FillWeight = 142.8302F;
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.MinimumWidth = 9;
            this.CreateTime.Name = "CreateTime";
            // 
            // ModifyTime
            // 
            this.ModifyTime.DataPropertyName = "ModifyTime";
            this.ModifyTime.FillWeight = 134.7894F;
            this.ModifyTime.HeaderText = "最后更新时间";
            this.ModifyTime.MinimumWidth = 9;
            this.ModifyTime.Name = "ModifyTime";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "编辑";
            this.Edit.MinimumWidth = 9;
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvAppPassword);
            this.panel1.Location = new System.Drawing.Point(14, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 430);
            this.panel1.TabIndex = 1;
            // 
            // mnsMain
            // 
            this.mnsMain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mnsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.mnsMain.Size = new System.Drawing.Size(893, 27);
            this.mnsMain.TabIndex = 2;
            this.mnsMain.Text = "主菜单";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCreatePassword});
            this.编辑ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // menuItemCreatePassword
            // 
            this.menuItemCreatePassword.Name = "menuItemCreatePassword";
            this.menuItemCreatePassword.Size = new System.Drawing.Size(100, 22);
            this.menuItemCreatePassword.Text = "新增";
            this.menuItemCreatePassword.Click += new System.EventHandler(this.menuItemCreatePassword_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 484);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnsMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnsMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Home";
            this.Text = "PasswordManager";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppPassword)).EndInit();
            this.panel1.ResumeLayout(false);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreatePassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyTime;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}

