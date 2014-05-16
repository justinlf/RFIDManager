namespace RFID_Manager
{
    partial class TagListView
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
            this.okBtn = new System.Windows.Forms.MenuItem();
            this.cancelBtn = new System.Windows.Forms.MenuItem();
            this.item_LV = new System.Windows.Forms.ListView();
            this.item = new System.Windows.Forms.ColumnHeader();
            this.rfid = new System.Windows.Forms.ColumnHeader();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.remove_menuItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.okBtn);
            this.mainMenu.MenuItems.Add(this.cancelBtn);
            // 
            // okBtn
            // 
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // item_LV
            // 
            this.item_LV.CheckBoxes = true;
            this.item_LV.Columns.Add(this.item);
            this.item_LV.Columns.Add(this.rfid);
            this.item_LV.ContextMenu = this.contextMenu;
            this.item_LV.FullRowSelect = true;
            this.item_LV.Location = new System.Drawing.Point(0, 0);
            this.item_LV.Name = "item_LV";
            this.item_LV.Size = new System.Drawing.Size(240, 187);
            this.item_LV.TabIndex = 0;
            this.item_LV.View = System.Windows.Forms.View.Details;
            // 
            // item
            // 
            this.item.Text = "Item";
            this.item.Width = 100;
            // 
            // rfid
            // 
            this.rfid.Text = "RFID";
            this.rfid.Width = 100;
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.Add(this.remove_menuItem);
            // 
            // remove_menuItem
            // 
            this.remove_menuItem.Text = "Remove";
            this.remove_menuItem.Click += new System.EventHandler(this.remove_menuItem_Click);
            // 
            // TagListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.ControlBox = false;
            this.Controls.Add(this.item_LV);
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "TagListView";
            this.Text = "Tag Association";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem okBtn;
        private System.Windows.Forms.MenuItem cancelBtn;
        private System.Windows.Forms.ListView item_LV;
        private System.Windows.Forms.ColumnHeader item;
        private System.Windows.Forms.ColumnHeader rfid;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem remove_menuItem;
    }
}