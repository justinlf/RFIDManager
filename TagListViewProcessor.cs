using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Symbol.RFID3;

namespace RFID_Manager
{
    class TagListViewProcessor : ITagProcessor
    {
        private Hashtable _TagTable;
        private Stack<string> _Tags;
        private ListView _Item_LV;

        public TagListViewProcessor(ListView listview)
        {
            _TagTable = new Hashtable(1023);
            _Tags = new Stack<string>();
            _Item_LV = listview;
            _Item_LV.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._Item_LV_ItemCheck);
        }

        public Stack<string> Tags
        {
            get { return _Tags; }
        }

        #region ITagProcessor Members

        public void updateTag(TagData tag)
        {
            bool isFound = false;
            string tagID = tag.TagID;

            lock (_TagTable.SyncRoot)
            {
                isFound = _TagTable.ContainsKey(tagID);
            }

            if (!isFound)
            {
                lock (_TagTable.SyncRoot)
                {
                    _TagTable.Add(tagID, tag);
                }
            }
        }

        public void processTag(TagData tag)
        {
            bool isFound = false;
            string tagID = tag.TagID;
            string tagIDshort = tagID.Substring(tag.TagID.Length - 8);


            lock (_TagTable.SyncRoot)
            {
                isFound = _TagTable.ContainsKey(tagID);
            }

            if (!isFound)
            {
                lock (_TagTable.SyncRoot)
                {
                    _TagTable.Add(tagID, tag);
                }

                _Tags.Push(tagIDshort);

                updateListView();
            }

        }

        #endregion

        private void updateListView()
        {
            ListViewItem.ListViewSubItem subItem;
            //_Item_LV.BeginUpdate();
            foreach (ListViewItem item in _Item_LV.Items)
            {
                if (item.Checked && item.SubItems.Count == 1 && _Tags.Count > 0)
                {
                    subItem = new ListViewItem.ListViewSubItem();
                    subItem.Text = _Tags.Pop();
                    item.SubItems.Add(subItem);
                }
                else if (!item.Checked && item.SubItems.Count == 2 && item.SubItems[1] != null)
                {
                    _Tags.Push(item.SubItems[1].Text);
                    item.SubItems.RemoveAt(1);
                }
            }
            //_Item_LV.EndUpdate();
        }

        private void _Item_LV_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem item = _Item_LV.Items[e.Index];
            if (e.NewValue == CheckState.Unchecked && item.SubItems.Count == 2 && item.SubItems[1] != null)
            {
                _Tags.Push(item.SubItems[1].Text);
                item.SubItems.RemoveAt(1);
            }

            ListViewItem.ListViewSubItem subItem;

            for (int i = 0; i < _Item_LV.Items.Count; i++)
            {
                item = _Item_LV.Items[i];
                if (item.SubItems.Count == 1 && _Tags.Count > 0 &&
                ((e.Index == i && e.NewValue == CheckState.Checked) || (item.Checked && e.Index != i)))
                {
                    subItem = new ListViewItem.ListViewSubItem();
                    subItem.Text = _Tags.Pop();
                    item.SubItems.Add(subItem);
                }
                else if (item.SubItems.Count == 2 && item.SubItems[1] != null && !item.Checked)
                {
                    _Tags.Push(item.SubItems[1].Text);
                    item.SubItems.RemoveAt(1);
                }
            }
        }
    }
}
