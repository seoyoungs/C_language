using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Queue_Serial
{
    public partial class SettingPopup : Form
    {

        #region 속성
        private PortNames _portNames;
        private bool _isSet = false; // _isSet 팝업에서 한번이라도 설정했는지

        #endregion

        #region 생성자
        public SettingPopup()
        {
            InitializeComponent();
            LoadPortSetting();
        }
        #endregion

        #region public 함수

        public bool GetSerialProperties(ref PortNames properties)
        {
            if (!_isSet)
            {
                return false; // 설정했으면 false반환, 설정되었으면 true이고, 그렇지 않으면 false
            }
            else
            {
                properties = this._portNames;
                return true;
            }
        }

        public void UpdatePortName()
        {
            foreach (string portName in SerialPort.GetPortNames())
            {
                this.cb_PortNames.Items.Add(portName); // 각각 portname추가해 준다.
            }
        }

        public bool GetPortSettings()
        {
            if (!_isSet)
            {
                LoadPortSetting();
                return false;
            }
            else
            {
                GetPortSettings();
                for (int i = 0; i < this.cb_PortNames.Items.Count; ++i)
                {
                    if (this.cb_PortNames.Items[i].ToString().Equals(this._portNames.portName))
                    {
                        this.cb_PortNames.SelectedIndex = i;
                        break;
                    }
                }

                this.cb_BaudRate.SelectedItem = this._portNames.baudRate.ToString();
                this.cb_DataBits.SelectedItem = this._portNames.dataBits.ToString();
                this.cb_Parity.SelectedItem = this._portNames.parity.ToString();
                this.cb_StopBits.SelectedItem = this._portNames.stopBits.ToString();
            }
            return true;
        }

        #endregion

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (cb_PortNames.SelectedIndex == -1)
            {
                MessageBox.Show("포트를 선택해주세요");
                return;
            }

            _portNames = new PortNames
            {
                portName = cb_PortNames.SelectedItem.ToString(),
                baudRate = int.Parse(cb_BaudRate.SelectedItem.ToString()),
                dataBits = int.Parse(cb_DataBits.SelectedItem.ToString()),
                parity = (Parity)Enum.Parse(typeof(Parity), cb_Parity.SelectedItem.ToString()),
                stopBits = (StopBits)Enum.Parse(typeof(StopBits), cb_StopBits.SelectedItem.ToString()) // typeof 형식 선언시 사용, Enum 상수값
            };
            _isSet = true;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // _portname에는 아무것도 없으므로 저장이 안된다 위에꺼랑 반대(확인 필요)
            this.Close();
        }

        private void LoadPortSetting()
        {
            UpdatePortName();
            if (cb_PortNames.Items.Count > 0)
            {
                cb_PortNames.SelectedIndex = 0; //처음꺼 할당하는 것으로 설정해야하므로 인덱스 0할당
            }

            cb_BaudRate.SelectedIndex = 7;
            cb_DataBits.SelectedIndex = 3;
            cb_Parity.SelectedIndex = 0;
            cb_StopBits.SelectedIndex = 0;
        }  

    }
}
