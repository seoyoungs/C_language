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
    public partial class Form1 : Form
    {
        public Form1() // 이부분이 생성자 부분
        {
            InitializeComponent();
            LoadPortSetting();
            
        }

        // 밑에 부분 모두 함수만드는 영역
        private void LoadPortSetting()
        {
            string[] ports = SerialPort.GetPortNames(); // alt + enter를 눌러서 SerialPort 검색해서 해결법 찾기(using System.IO.Ports;)
            foreach (string port in ports)
            {
                cb_PortNames.Items.Add(port);
            }

            if (cb_PortNames.Items.Count >= 1) // port의 개수가 1 이상이면
            {
                cb_PortNames.SelectedIndex = 0; // 맨 처음꺼로 할당
            }

            cb_BaudRate.SelectedIndex = 7; // 배열이므로 현재 위치 -1 (인덱스를 가져오는 것)
            cb_DataBits.SelectedIndex = 3;
            cb_Parity.SelectedIndex = 0;
            cb_StopBit.SelectedIndex = 0;
        }

        private bool Portsetting()
        {
            if(cb_PortNames.SelectedIndex ==  -1)
            {
                return false;
            }

            sp_Port.PortName = cb_PortNames.SelectedItem.ToString(); // PortName 문자형은 ToString
            sp_Port.BaudRate = int.Parse(cb_BaudRate.SelectedItem.ToString()); // BaudRate는 숫자형(int) parse
            sp_Port.DataBits = int.Parse(cb_DataBits.SelectedItem.ToString());

            // Parity, cb_StopBit 특수형이므로 따로 지정
            if (cb_Parity.SelectedIndex == 0) // 인덱스가 0일때, 젤 맨앞일때
            {
                sp_Port.Parity = Parity.None;
            }
            else if (cb_Parity.SelectedIndex == 1)
            {
                sp_Port.Parity = Parity.Odd;
            }
            else if (cb_Parity.SelectedIndex ==2)
            {
                sp_Port.Parity = Parity.Even;
            }

            if (cb_StopBit.SelectedIndex == 0) //인덱스가 0이면 맨 처음꺼 소환
            {
                sp_Port.StopBits = StopBits.One;
            } 
            else if (cb_StopBit.SelectedIndex == 1)
            {
                sp_Port.StopBits = StopBits.OnePointFive;
            }
            else if (cb_StopBit.SelectedIndex == 2)
            {
                sp_Port.StopBits = StopBits.Two;
            }

            return true;         
        }

        private void btn_PortOpen_Click(object sender, EventArgs e) //이벤트
        {
            if (Portsetting() == false) // 앞에 언급된 port setting 함수
            {
                MessageBox.Show("연결된 포트가 없습니다.");
                return;
            }
            Console.WriteLine(sp_Port.IsOpen.ToString()); // 객체가 열려있는지 닫혀 있는지 확인
            sp_Port.Open();
            Console.WriteLine(sp_Port.IsOpen.ToString());
            //sp_Port.Write("ab"); //데이터를 내보내는 것 

            btn_PortClose.Enabled = true; //버튼 사용가능으로 바꿔준다
            btn_PortOpen.Enabled = false; // 오픈 기능 닫아주기
            btn_Send.Enabled = true; // send기능 열어주기
        }

        private void btn_PortClose_Click(object sender, EventArgs e) // 닫는 버튼
        {
            if (sp_Port.IsOpen == false) // 닫는 버튼이 닫혀있는 경우
            {
                return;
            }
            

            Console.WriteLine(sp_Port.IsOpen.ToString()); // 객체가 열려있는지 닫혀 있는지 확인
            sp_Port.Close();
            Console.WriteLine(sp_Port.IsOpen.ToString());

            btn_PortOpen.Enabled = true; // 버튼 닫으므로 다시 포트 열기
            btn_PortClose.Enabled = false;
            btn_Send.Enabled = false;

        }

        private void btn_Send_Click(object sender, EventArgs e) // 데이터 내보낼 때 클릭
        {
            sp_Port.Write(tb_SendText.Text); //데이터를 내보내는 것 

        }

        private void sp_Port_DataReceived(object sender, SerialDataReceivedEventArgs e) // 데이터를 받았을때만 실행
        {
            int count = sp_Port.BytesToRead; // 받을 수 있는 개수(개수 다르게 받는것 방지)

            if(count > 0)
            {
                byte[] buffer = new byte [count]; //현재 포트에서 읽을 수 있는 개수
                sp_Port.Read(buffer, 0, count); // 인자가 3개(buffer 저장할 공간, 데이터 어디서 부터 읽을지, 얼만큼 읽을지)

                rtb_RecvText.Text = Encoding.ASCII.GetString(buffer); //text받아서 실행
            }
        }
    }
}
