namespace CarRental
{
    partial class MainAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAdmin));
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PanelDropdown = new System.Windows.Forms.Panel();
            this.BtnReport = new System.Windows.Forms.Button();
            this.BtnTransaction = new System.Windows.Forms.Button();
            this.BtnCarReport = new System.Windows.Forms.Button();
            this.BtnClientReport = new System.Windows.Forms.Button();
            this.BtnCarReg = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LblExit = new System.Windows.Forms.Label();
            this.PanelLeft.SuspendLayout();
            this.PanelDropdown.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.PanelLeft.Controls.Add(this.panel3);
            this.PanelLeft.Controls.Add(this.button1);
            this.PanelLeft.Controls.Add(this.button2);
            this.PanelLeft.Controls.Add(this.PanelDropdown);
            this.PanelLeft.Controls.Add(this.BtnCarReg);
            this.PanelLeft.Controls.Add(this.button3);
            this.PanelLeft.Controls.Add(this.menuStrip1);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(125, 300);
            this.PanelLeft.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(3, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Rent Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnTransaction_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.LightBlue;
            this.button2.Location = new System.Drawing.Point(3, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Car Report";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnCarReport_Click);
            // 
            // PanelDropdown
            // 
            this.PanelDropdown.Controls.Add(this.BtnReport);
            this.PanelDropdown.Controls.Add(this.BtnTransaction);
            this.PanelDropdown.Controls.Add(this.BtnCarReport);
            this.PanelDropdown.Controls.Add(this.BtnClientReport);
            this.PanelDropdown.Location = new System.Drawing.Point(0, 112);
            this.PanelDropdown.MaximumSize = new System.Drawing.Size(122, 160);
            this.PanelDropdown.MinimumSize = new System.Drawing.Size(122, 52);
            this.PanelDropdown.Name = "PanelDropdown";
            this.PanelDropdown.Size = new System.Drawing.Size(122, 52);
            this.PanelDropdown.TabIndex = 5;
            // 
            // BtnReport
            // 
            this.BtnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReport.ForeColor = System.Drawing.Color.LightBlue;
            this.BtnReport.Location = new System.Drawing.Point(0, 0);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(122, 52);
            this.BtnReport.TabIndex = 4;
            this.BtnReport.Text = "Reports";
            this.BtnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReport.UseVisualStyleBackColor = true;
            // 
            // BtnTransaction
            // 
            this.BtnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTransaction.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTransaction.ForeColor = System.Drawing.Color.Black;
            this.BtnTransaction.Location = new System.Drawing.Point(0, 124);
            this.BtnTransaction.Name = "BtnTransaction";
            this.BtnTransaction.Size = new System.Drawing.Size(119, 36);
            this.BtnTransaction.TabIndex = 4;
            this.BtnTransaction.Text = "Rent Report";
            this.BtnTransaction.UseVisualStyleBackColor = true;
            // 
            // BtnCarReport
            // 
            this.BtnCarReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCarReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCarReport.ForeColor = System.Drawing.Color.Black;
            this.BtnCarReport.Location = new System.Drawing.Point(0, 89);
            this.BtnCarReport.Name = "BtnCarReport";
            this.BtnCarReport.Size = new System.Drawing.Size(122, 35);
            this.BtnCarReport.TabIndex = 5;
            this.BtnCarReport.Text = "Car Report";
            this.BtnCarReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCarReport.UseVisualStyleBackColor = true;
            // 
            // BtnClientReport
            // 
            this.BtnClientReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClientReport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClientReport.ForeColor = System.Drawing.Color.Black;
            this.BtnClientReport.Location = new System.Drawing.Point(0, 54);
            this.BtnClientReport.Name = "BtnClientReport";
            this.BtnClientReport.Size = new System.Drawing.Size(119, 35);
            this.BtnClientReport.TabIndex = 4;
            this.BtnClientReport.Text = "Client Report";
            this.BtnClientReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClientReport.UseVisualStyleBackColor = true;
            // 
            // BtnCarReg
            // 
            this.BtnCarReg.FlatAppearance.BorderSize = 0;
            this.BtnCarReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCarReg.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCarReg.ForeColor = System.Drawing.Color.LightBlue;
            this.BtnCarReg.Location = new System.Drawing.Point(3, 52);
            this.BtnCarReg.Name = "BtnCarReg";
            this.BtnCarReg.Size = new System.Drawing.Size(116, 54);
            this.BtnCarReg.TabIndex = 1;
            this.BtnCarReg.Text = "Cars";
            this.BtnCarReg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCarReg.UseVisualStyleBackColor = true;
            this.BtnCarReg.Click += new System.EventHandler(this.BtnCarReg_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.LightBlue;
            this.button3.Location = new System.Drawing.Point(3, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 35);
            this.button3.TabIndex = 7;
            this.button3.Text = "Client Report";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BtnClientReport_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(125, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.menuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(120, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 276);
            this.panel3.TabIndex = 2;
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.PanelContainer.Location = new System.Drawing.Point(125, 24);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(592, 276);
            this.PanelContainer.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LblExit
            // 
            this.LblExit.AutoSize = true;
            this.LblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LblExit.ForeColor = System.Drawing.Color.Crimson;
            this.LblExit.Location = new System.Drawing.Point(696, 3);
            this.LblExit.Name = "LblExit";
            this.LblExit.Size = new System.Drawing.Size(17, 17);
            this.LblExit.TabIndex = 8;
            this.LblExit.Text = "X";
            this.LblExit.Click += new System.EventHandler(this.LblExit_Click);
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(717, 300);
            this.Controls.Add(this.LblExit);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.PanelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.MainAdmin_Load);
            this.PanelLeft.ResumeLayout(false);
            this.PanelLeft.PerformLayout();
            this.PanelDropdown.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Button BtnCarReg;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel PanelDropdown;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Button BtnTransaction;
        private System.Windows.Forms.Button BtnCarReport;
        private System.Windows.Forms.Button BtnClientReport;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblExit;
    }
}