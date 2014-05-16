using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Symbol.RFID3;
using System.Windows.Forms;
using System.Collections;

namespace RFID_Manager
{
    class DefaultTagProcessor : ITagProcessor
    {
        private const string _DateFormat = "MMddyyyyHHmmss";
        private Hashtable _TagTable;
        private ICollection<string> _Tags;

        public DefaultTagProcessor()
        {
            _TagTable = new Hashtable(1023);
            _Tags = new List<string>();
        }

        public ICollection<string> Tags
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
                _Tags.Add(tagIDshort);

                lock (_TagTable.SyncRoot)
                {
                    _TagTable.Add(tagID, tag);
                }
            }
        }

        #endregion
    }
}
