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

namespace serial_test
{
    public partial class Form1 : Form // 생성자 form1
    {
        public Form1()
        {
            InitializeComponent();
            LoadPortSetting(); //생성자 역할과 비슷
            PortSetting();
            Console.WriteLine(sp_Port.IsOpen.ToString());
            sp_Port.Open();
            Console.WriteLine(sp_Port.IsOpen.ToString());
            sp_Port.Write("가나"); //데이터 보내기
        }

        private void LoadPortSetting()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cb_PortNames.Items.Add(port);
            }

            if (cb_PortNames.Items.Count >= 1)
            {
                cb_PortNames.SelectedIndex = 0;
            }


            cb_BaudRate.SelectedIndex = 7;
            cb_DataBits.SelectedIndex = 3;
            cb_Parity.SelectedIndex = 0;
            cb_StopBit.SelectedIndex = 0;
        }

        private void PortSetting()
        {
            sp_Port.PortName = cb_PortNames.SelectedItem.ToString(); //문자형 -tostring
            sp_Port.BaudRate = int.Parse(cb_BaudRate.SelectedItem.ToString()); // 숫자형으로 -parse
            sp_Port.DataBits = int.Parse(cb_DataBits.SelectedItem.ToString());

            if (cb_Parity.SelectedIndex == 0)
            {
                sp_Port.Parity = Parity.None;
            }
            else if (cb_Parity.SelectedIndex == 1)
            {
                sp_Port.Parity = Parity.Odd;

            }
            else if (cb_Parity.SelectedIndex == 2)
            {
                sp_Port.Parity = Parity.Even;

            }

            if (cb_StopBit.SelectedIndex == 0)
            {
                sp_Port.StopBits =  StopBits.One;
            }
            else if (cb_StopBit.SelectedIndex == 1)
            {
                sp_Port.StopBits = StopBits.OnePointFive;


            }
            else if (cb_StopBit.SelectedIndex == 2)
            {
                sp_Port.StopBits = StopBits.Two;


            }

        }


    }
}

