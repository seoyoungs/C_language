using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serial_program
{
    public partial class Portsetting_Popup : Form
    {
        
        

        public Portsetting_Popup()
        {
            InitializeComponent();
            LoadPortSetting();
            _portname = cb_PortNames.SelectedIndex;
            _baudrate = cb_BaudRate.SelectedIndex;
            _databits = cb_DataBits.SelectedIndex;
            _parity = cb_Parity.SelectedIndex;
            _stopbits = cb_StopBits.SelectedIndex;

        }

        private int _portname, _baudrate, _databits, _parity, _stopbits;

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            _portname = cb_PortNames.SelectedIndex; // 인자 지정할 때 _(언더바) 지정하기
            _baudrate = cb_BaudRate.SelectedIndex;
            _databits = cb_DataBits.SelectedIndex;
            _parity = cb_Parity.SelectedIndex;
            _stopbits = cb_StopBits.SelectedIndex;

            this.Close(); // 값 저장
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cb_PortNames.SelectedIndex = _portname;
            cb_BaudRate.SelectedIndex = _baudrate;
            cb_DataBits.SelectedIndex = _databits;
            cb_Parity.SelectedIndex = _parity;
            cb_StopBits.SelectedIndex = _stopbits;

            this.Close(); // 창 닫기 값 저장 안됨
        }


        // 밑에 부분 모두 함수만드는 영역
        private void LoadPortSetting() // void 반환형
        {           
            cb_BaudRate.SelectedIndex = 7; // 배열이므로 현재 위치 -1 (인덱스를 가져오는 것)
            cb_DataBits.SelectedIndex = 3;
            cb_Parity.SelectedIndex = 0;
            cb_StopBits.SelectedIndex = 0;
        }
        
        public void UpdatePortName()
        {
            cb_PortNames.Items.Clear();

            string[] ports = SerialPort.GetPortNames(); // alt + enter를 눌러서 SerialPort 검색해서 해결법 찾기(using System.IO.Ports;)
            foreach (string port in ports) // 배열의 길이 만큼 동작
            {
                cb_PortNames.Items.Add(port);
            }

            if (cb_PortNames.Items.Count >= 1) // port의 개수가 1 이상이면
            {
                cb_PortNames.SelectedIndex = 0; // 맨 처음꺼로 할당
            }
        }

        public bool GetPortSettings(out string portname, out int baudrate, out int databits, out Parity parity, out StopBits stopbits)
        {
           if (cb_PortNames.SelectedIndex == -1)
            {
                portname = "";
                baudrate = -1;
                databits = -1;
                parity = Parity.None;
                stopbits = StopBits.None;

                return false;
            }
            // out의 의미 인자 할당 값 직접 넣어주기(반대인 경우다)

            portname = cb_PortNames.SelectedItem.ToString(); // PortName 문자형은 ToString
            baudrate = int.Parse(cb_BaudRate.SelectedItem.ToString()); // BaudRate는 숫자형(int) parse
            databits = int.Parse(cb_DataBits.SelectedItem.ToString());

            // Parity, cb_StopBit 특수형이므로 따로 지정
            if (cb_Parity.SelectedIndex == 0) // 인덱스가 0일때, 젤 맨앞일때
            {
                parity = Parity.None;
            }
            else if (cb_Parity.SelectedIndex == 1)
            {
                parity = Parity.Odd;
            }
            else if (cb_Parity.SelectedIndex == 2)
            {
                parity = Parity.Even;
            }
            else
            {
                parity = Parity.None;
            }

            if (cb_StopBits.SelectedIndex == 0) //인덱스가 0이면 맨 처음꺼 소환
            {
                stopbits = StopBits.One;
            }
            else if (cb_StopBits.SelectedIndex == 1) // 선택되어 있는 값이 나온다
            {
                stopbits = StopBits.OnePointFive;
            }
            else if (cb_StopBits.SelectedIndex == 2)//마지막은 else로만 해도된다
            {
                stopbits = StopBits.Two;
            }
            else
            {
                stopbits = StopBits.None;
            }
            return true;

        }

    }
}
