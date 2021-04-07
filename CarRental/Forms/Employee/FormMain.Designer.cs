namespace CarRental
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BntRental = new System.Windows.Forms.Button();
            this.BtnCars = new System.Windows.Forms.Button();
            this.BtnClient = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.LblExit = new System.Windows.Forms.Label();
            this.PanelLeft.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.PanelLeft.Controls.Add(this.panel1);
            this.PanelLeft.Controls.Add(this.BntRental);
            this.PanelLeft.Controls.Add(this.BtnCars);
            this.PanelLeft.Controls.Add(this.BtnClient);
            this.PanelLeft.Controls.Add(this.menuStrip1);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(119, 300);
            this.PanelLeft.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(114, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 276);
            this.panel1.TabIndex = 0;
            // 
            // BntRental
            // 
            this.BntRental.FlatAppearance.BorderSize = 0;
            this.BntRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BntRental.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntRental.ForeColor = System.Drawing.Color.LightBlue;
            this.BntRental.Location = new System.Drawing.Point(0, 184);
            this.BntRental.Name = "BntRental";
            this.BntRental.Size = new System.Drawing.Size(118, 54);
            this.BntRental.TabIndex = 1;
            this.BntRental.Text = "Rental";
            this.BntRental.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntRental.UseVisualStyleBackColor = true;
            this.BntRental.Click += new System.EventHandler(this.BntRental_Click);
            // 
            // BtnCars
            // 
            this.BtnCars.FlatAppearance.BorderSize = 0;
            this.BtnCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCars.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCars.ForeColor = System.Drawing.Color.LightBlue;
            this.BtnCars.Location = new System.Drawing.Point(0, 78);
            this.BtnCars.Name = "BtnCars";
            this.BtnCars.Size = new System.Drawing.Size(118, 54);
            this.BtnCars.TabIndex = 0;
            this.BtnCars.Text = "Cars";
            this.BtnCars.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCars.UseVisualStyleBackColor = true;
            this.BtnCars.Click += new System.EventHandler(this.BtnCars_Click);
            // 
            // BtnClient
            // 
            this.BtnClient.FlatAppearance.BorderSize = 0;
            this.BtnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClient.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClient.ForeColor = System.Drawing.Color.LightBlue;
            this.BtnClient.Location = new System.Drawing.Point(0, 132);
            this.BtnClient.Name = "BtnClient";
            this.BtnClient.Size = new System.Drawing.Size(118, 54);
            this.BtnClient.TabIndex = 1;
            this.BtnClient.Text = "Client";
            this.BtnClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClient.UseVisualStyleBackColor = true;
            this.BtnClient.Click += new System.EventHandler(this.BtnClient_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(119, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Logut";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.PanelContainer.Location = new System.Drawing.Point(117, 23);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(596, 276);
            this.PanelContainer.TabIndex = 2;
            // 
            // LblExit
            // 
            this.LblExit.AutoSize = true;
            this.LblExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LblExit.ForeColor = System.Drawing.Color.Crimson;
            this.LblExit.Location = new System.Drawing.Point(696, 3);
            this.LblExit.Name = "LblExit";
            this.LblExit.Size = new System.Drawing.Size(17, 17);
            this.LblExit.TabIndex = 9;
            this.LblExit.Text = "X";
            this.LblExit.Click += new System.EventHandler(this.LblExit_Click_1);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(714, 300);
            this.Controls.Add(this.LblExit);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.PanelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.PanelLeft.ResumeLayout(false);
            this.PanelLeft.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Button BtnCars;
        private System.Windows.Forms.Button BntRental;
        private System.Windows.Forms.Button BtnClient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label LblExit;
    }
}

