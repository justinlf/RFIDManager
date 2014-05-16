namespace RFID_Manager
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

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
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.exitBtn = new System.Windows.Forms.MenuItem();
            this.managerTC = new System.Windows.Forms.TabControl();
            this.linkTab = new System.Windows.Forms.TabPage();
            this.updateRTBtn = new System.Windows.Forms.Button();
            this.newRTBtn = new System.Windows.Forms.Button();
            this.updateCCBtn = new System.Windows.Forms.Button();
            this.newCCBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.syncTab = new System.Windows.Forms.TabPage();
            this.managerTC.SuspendLayout();
            this.linkTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.exitBtn);
            // 
            // exitBtn
            // 
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // managerTC
            // 
            this.managerTC.Controls.Add(this.linkTab);
            this.managerTC.Controls.Add(this.tabPage2);
            this.managerTC.Controls.Add(this.syncTab);
            this.managerTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerTC.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.managerTC.Location = new System.Drawing.Point(0, 0);
            this.managerTC.Name = "managerTC";
            this.managerTC.SelectedIndex = 0;
            this.managerTC.Size = new System.Drawing.Size(240, 188);
            this.managerTC.TabIndex = 0;
            // 
            // linkTab
            // 
            this.linkTab.Controls.Add(this.updateRTBtn);
            this.linkTab.Controls.Add(this.newRTBtn);
            this.linkTab.Controls.Add(this.updateCCBtn);
            this.linkTab.Controls.Add(this.newCCBtn);
            this.linkTab.Location = new System.Drawing.Point(0, 0);
            this.linkTab.Name = "linkTab";
            this.linkTab.Size = new System.Drawing.Size(240, 161);
            this.linkTab.Text = "Link";
            // 
            // updateRTBtn
            // 
            this.updateRTBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.updateRTBtn.Location = new System.Drawing.Point(50, 124);
            this.updateRTBtn.Name = "updateRTBtn";
            this.updateRTBtn.Size = new System.Drawing.Size(140, 27);
            this.updateRTBtn.TabIndex = 4;
            this.updateRTBtn.Text = "Update Room Tag";
            // 
            // newRTBtn
            // 
            this.newRTBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.newRTBtn.Location = new System.Drawing.Point(50, 87);
            this.newRTBtn.Name = "newRTBtn";
            this.newRTBtn.Size = new System.Drawing.Size(140, 27);
            this.newRTBtn.TabIndex = 3;
            this.newRTBtn.Text = "New Room Tag";
            // 
            // updateCCBtn
            // 
            this.updateCCBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.updateCCBtn.Location = new System.Drawing.Point(50, 50);
            this.updateCCBtn.Name = "updateCCBtn";
            this.updateCCBtn.Size = new System.Drawing.Size(140, 27);
            this.updateCCBtn.TabIndex = 2;
            this.updateCCBtn.Text = "Update Cage Card";
            // 
            // newCCBtn
            // 
            this.newCCBtn.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.newCCBtn.Location = new System.Drawing.Point(50, 13);
            this.newCCBtn.Name = "newCCBtn";
            this.newCCBtn.Size = new System.Drawing.Size(140, 27);
            this.newCCBtn.TabIndex = 1;
            this.newCCBtn.Text = "New Cage Card";
            this.newCCBtn.Click += new System.EventHandler(this.newCCBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 159);
            this.tabPage2.Text = "Deactivate";
            // 
            // syncTab
            // 
            this.syncTab.Location = new System.Drawing.Point(0, 0);
            this.syncTab.Name = "syncTab";
            this.syncTab.Size = new System.Drawing.Size(232, 159);
            this.syncTab.Text = "Sync";
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.ControlBox = false;
            this.Controls.Add(this.managerTC);
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "Manager";
            this.Text = "RFID Manager";
            this.managerTC.ResumeLayout(false);
            this.linkTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl managerTC;
        private System.Windows.Forms.TabPage linkTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage syncTab;
        private System.Windows.Forms.Button newCCBtn;
        private System.Windows.Forms.Button updateCCBtn;
        private System.Windows.Forms.Button updateRTBtn;
        private System.Windows.Forms.Button newRTBtn;
        private System.Windows.Forms.MenuItem exitBtn;
    }
}

