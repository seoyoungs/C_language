using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports; // serial port 연결해 주는 함수
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serial_program
{
    public partial class Form1 : Form // 상속 부분은 Form
    {
        #region 생성자영역
        public Form1() // 이부분이 생성자 부분, public 접근제한자
        {
            InitializeComponent(); // 컴포넌트(디자인의 컨트롤들 )초기화  
            // portsetting 따로 여기다 언급 안해도 된다.
        }

        #endregion

        #region 속성영역
        Portsetting_Popup _portsettingpopup = new Portsetting_Popup(); // 인자 지정시 _ 로 지정하기
        #endregion

        #region control 함수영역
        private void btn_PortOpen_Click(object sender, EventArgs e) //이벤트, 타입 - object
        {
            if (Portsetting() == false) //Portsetting은 bool 타입, 앞에 언급된 port setting 함수
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
            if (sp_Port.IsOpen == false) // IsOpen이 bool타입, 닫는 버튼이 닫혀있는 경우
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
            if (rdb_Preset.Checked  && cb_SendPreset.SelectedIndex == -1) // 선택된 항목없으면 -1로 반환
            {
                MessageBox.Show("보낼 데이터를 선택해주세요"); // 콤보박스 선택 안되있을 때 메세지
                return; // void, 형태이므로 false
            }
            else if(rdb_Write.Checked && tb_SendText.Text.Length == 0) //문자 수가 0이면
            {
                MessageBox.Show("보낼 데이터를 입력해주세요");
                return;
            }

            string data = ""; // 데이터 초기화

            if (rdb_Preset.Checked)
            {
                data = cb_SendPreset.SelectedItem.ToString(); // object 형태이므로 tosting해준다.
            }
            else if(rdb_Write.Checked)
            {
                data = tb_SendText.Text;
            }

            bool result = SendData(data); //SelectedItem 선택된 아이템 문자열로 보내기, 

            if (result)
            {
                MessageBox.Show("전송완료"); // 계속 진행
            }
            else
            {
                MessageBox.Show("전송실패"); // 콤보박스 선택 안되있을 때 메세지
            }
        }

        private void btn_PortSetting_Click(object sender, EventArgs e)
        {
            _portsettingpopup.UpdatePortName();
            _portsettingpopup.ShowDialog();
        }

        private void sp_Port_DataReceived(object sender, SerialDataReceivedEventArgs e) // 데이터를 받았을때만 실행
        {
            int count = sp_Port.BytesToRead; // 받을 수 있는 개수(개수 다르게 받는것 방지)

            if (count > 0)
            {
                byte[] buffer = new byte[count]; //현재 포트에서 읽을 수 있는 개수
                sp_Port.Read(buffer, 0, count); // 인자가 3개(buffer 저장할 공간, 데이터 어디서 부터 읽을지, 얼만큼 읽을지)

                rtb_RecvText.Text = Encoding.ASCII.GetString(buffer); //text받아서 실행(아스키 코드임)
            }
        }


        #endregion

        #region user함수영역
        private bool Portsetting() //포트 셋팅 함수
        {
            string portname; // 각 인자별 해당하면 타입 할당
            int baudrate;
            int databits;
            Parity parity;
            StopBits stopbits;

            if (!_portsettingpopup.GetPortSettings(out portname, out baudrate, out databits, out parity, out stopbits))
            {
                return false;
            } // !popup 역으로 할때
            sp_Port.PortName = portname;
            sp_Port.BaudRate = baudrate; 
            sp_Port.DataBits = databits;
            sp_Port.Parity = parity;
            sp_Port.StopBits = stopbits;
            return true;
        }

        private bool SendData(string data)
        {                
            if (sp_Port.IsOpen == false)
            {
                return false;
            }

            sp_Port.Write(data);
            return true;
        }
        #endregion
    }
}
