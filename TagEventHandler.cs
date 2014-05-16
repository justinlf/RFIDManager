using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Symbol.RFID3;

namespace RFID_Manager
{
    public class TagEventHandler
    {
        private Hashtable _ExistingTable;
        private RFIDReader _ReaderAPI;
        private string _DeviceID;
        private ITagProcessor _Processor;


        public TagEventHandler(RFIDReader API, string ID)
        {            
            _ExistingTable = new Hashtable();
            _ReaderAPI = API;
            _DeviceID = ID;
            _Processor = new DefaultTagProcessor();
        }

        public RFIDReader ReaderAPI
        {
            get { return _ReaderAPI; }
        }

        public Hashtable ExistingTable
        {
            set { _ExistingTable = value; }
        }

        public ITagProcessor Processor
        {
            set { _Processor = value; }
        }

        public void newTagEvent(string stringData)
        {
            if (stringData == "BUFFER_FULL_WARNING_EVENT")
            {
                //userNotification.Text = "Buffer Full Warning";
                //userNotification.Visible = true;
            }
            else if (stringData == "DISCONNECTION_EVENT")
            {
                //userNotification.Text = "Radio Disconnected";
                //userNotification.Visible = true;
                _ReaderAPI.Reconnect();
            }
            else
            {
                TagData[] tagData = _ReaderAPI.Actions.GetReadTags(1000);

                if (tagData != null)
                {
                    for (int nIndex = 0; nIndex < tagData.Length; nIndex++)
                    {
                        TagData tag = tagData[nIndex];
                        string tagID = tag.TagID;
                        string tagIDshort = tagID.Substring(tag.TagID.Length - 8);

                        if (tag.TagID != _DeviceID )
                        {

                            if (tag.OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                            tag.OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS &&
                            _ExistingTable.ContainsKey(tagIDshort))
                            {
                                _Processor.updateTag(tag);
                            }

                            if (tag.OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE &&
                            !_ExistingTable.ContainsKey(tagIDshort))
                            {
                                _Processor.processTag(tag);
                            }
                        }
                    }//for
                }
            }
        }
    }
}
