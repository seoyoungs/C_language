using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace _06_ADC_TEST_WND
{
    public partial class Form1 : Form
    {
        /*-----------------------------------------------------------------------------
        *  시리얼 통신 변수
        *---------------------------------------------------------------------------*/
        SerialPort my_serial = new SerialPort();        // 시리얼 포트 변수 생성
        delegate void SetTextCallBack(string str);      // Callback 함수

        public Form1()
        {
            InitializeComponent();
            my_serial.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
        }

        private void comboBox_comdev_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox_comdev.Items.Clear();
            foreach (string comport in SerialPort.GetPortNames())
            {
                comboBox_comdev.Items.Add(comport);
            }
        }

        private void comboBox_comdev_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] serial_send_data = new byte[8];
            string comport_str = "";

            my_serial.PortName = comboBox_comdev.Text;
            comport_str = comboBox_comdev.Text;
            my_serial.BaudRate = 115200;

            if (!my_serial.IsOpen)
            {
                try
                {
                    my_serial.Open();
                    comport_str += "  " + "is Open !!";
                    listBox_msg.Items.Add(comport_str);
                }
                catch
                {
                    MessageBox.Show("SEIRAL PORT CONNECTION FAIL |!");
                }
            }
        }

        private void button_cmd_Click(object sender, EventArgs e)
        {

        }

        /*-----------------------------------------------------------------------------
        *  시리얼 통신 인터럽트 처리 함수
        *---------------------------------------------------------------------------*/
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int i_recv_size = my_serial.BytesToRead;
            byte[] b_tmp_buf = new byte[i_recv_size];
            string recv_str = "";

            my_serial.Read(b_tmp_buf, 0, i_recv_size);
            recv_str = Encoding.Default.GetString(b_tmp_buf);
            this.BeginInvoke(new SetTextCallBack(display_data), new object[] { recv_str });
        }
        /*-----------------------------------------------------------------------------
        *  디스플레이 함수
        *---------------------------------------------------------------------------*/
        private void display_data(string str)
        {
            this.listBox_msg.Items.Add(str);
        }
    }
}
