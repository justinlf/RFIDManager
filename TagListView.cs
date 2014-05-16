using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;

namespace RFID_Manager
{
    public partial class TagListView : Form
    {
        private RFIDReader _ReaderAPI;
        //private TagEventHandler _Handler;

        public TagListView(TagEventHandler handler, string header, List<string> items)
        {
            InitializeComponent();
            _ReaderAPI = handler.ReaderAPI;
            handler.Processor = new TagListViewProcessor(item_LV);
            item_LV.Columns[0].Text = header;
            item_LV.BeginUpdate();
            ListViewItem lvItem;
            foreach (string item in items)
            {
                lvItem = new ListViewItem(item);
                lvItem.Checked = true;
                item_LV.Items.Add(lvItem);
            }
            item_LV.EndUpdate();
        }

        public void startScan()
        {
            _ReaderAPI.Actions.Inventory.Perform();
        }

        public void stopScan()
        {
            _ReaderAPI.Actions.Inventory.Stop();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //this.Hide();
            //stopScan();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void remove_menuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = item_LV.SelectedIndices;
            foreach (int index in item_LV.SelectedIndices)
            {
                if (item_LV.Items[index].SubItems.Count == 2)
                    item_LV.Items[index].SubItems.RemoveAt(1);
            }
        }
    }
}