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
    public partial class Manager : Form
    {
        //Device
        private RFIDReader _ReaderAPI;
        private bool _IsConnected;
        private DeviceSettings _Device;
        private TagEventHandler _TagEventHandler;
        
        private delegate void TagEventDelegate(string stringData);
        private TagEventDelegate _TagEvent;

        public Manager()
        {
            InitializeComponent();

            uint port = 5084;
            _ReaderAPI = new RFIDReader("127.0.0.1", port, 0);

            _Device = new DeviceSettings(_ReaderAPI);
            _TagEventHandler = new TagEventHandler(_ReaderAPI, _Device.DeviceID);
            _TagEvent = new TagEventDelegate(_TagEventHandler.newTagEvent);

            Connect();
        }

        private void Connect()
        {    
            try
            {
                _ReaderAPI.Connect();
                _Device.configureAntenna();
                /*
                 * Setup Events
                 */
                _ReaderAPI.Events.AttachTagDataWithReadEvent = false;
                _ReaderAPI.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
                _ReaderAPI.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
                _ReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                _ReaderAPI.Events.NotifyReaderDisconnectEvent = true;

                _IsConnected = _ReaderAPI.IsConnected;

            }
            catch (OperationFailureException ofe)
            {
                //userNotification.Text = ofe.Result.ToString();
                //userNotification.Visible = true;
            }
        }

        private void Events_ReadNotify(object sender, Events.ReadEventArgs args)
        {
            this.Invoke(_TagEvent, new object[] { args.ReadEventData.TagData.TagID });
        }

        public void Events_StatusNotify(object sender, Events.StatusEventArgs args)
        {
            this.Invoke(_TagEvent, new object[] { args.StatusEventData.StatusEventType.ToString() });
        }

        

        private void Exit()
        {
            YesNo exitDialog = new YesNo("Are you sure you want to exit?");
            if (exitDialog.ShowDialog() == DialogResult.Yes)
            {
                //this.Refresh();
                //this.Visible = false;
                if (_IsConnected)
                    _ReaderAPI.Disconnect();
                //userNotification.Visible = false;
                //userNotification.Dispose();
                Application.Exit();
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void newCCBtn_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            for (int i = 1; i<=25; i++)
                items.Add(i.ToString());
            TagListView tagview = new TagListView(_TagEventHandler, "Cage Card", items);
            tagview.startScan();
            tagview.ShowDialog();
            tagview.stopScan();
        }
    }
}