using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // sp_port사용

namespace Queue_Serial
{

    public partial class SerialProgram : Form
    {
        #region 생성자
        public SerialProgram() // public 접근제한자,
        {
            InitializeComponent();
            _time = new Timer();

            _time.Interval = 50;// Tick
            _time.Tick += _time_Tick; //이벤트 추가 - 50마다 데이터가 있는지 확인
        }

        private void _time_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            // dequeue
        }


        #endregion

        #region 속성
        SettingPopup _settingPopup = new SettingPopup();
        Timer _time;
        QueueBuffer _queueBuffer;

        #endregion

        #region 함수
        private void btn_PortOpen_Click(object sender, EventArgs e)
        {
            if (Portsetting() == false) // portsetting이 함수이므로 ___() 표시를 해줘야한다.
            {
                MessageBox.Show("연결된 포트가 없습니다.");
                return;
            }
            Console.WriteLine(sp_Port.IsOpen.ToString()); // 객체가 열려있는지 닫혀있는지 확인
            sp_Port.Open();
            Console.WriteLine(sp_Port.IsOpen.ToString());

            btn_PortClose.Enabled = true;
            btn_PortOpen.Enabled = false;
            btn_Send.Enabled = true;

        }
        
        private void btn_PortClose_Click(object sender, EventArgs e)
        {
            if (sp_Port.IsOpen == false)
            {
                return;
            }

            Console.WriteLine(sp_Port.IsOpen.ToString());
            sp_Port.Close();
            Console.WriteLine(sp_Port.IsOpen.ToString());

            btn_PortOpen.Enabled = true;
            btn_PortClose.Enabled = false;
            btn_Send.Enabled = false;
        }

        private void btn_Send_Click(object sender, EventArgs e) // 여기서 && 쓴다
        {
            if(rdb_Preset.Checked && cb_SendPreset.SelectedIndex == -1) // 콤보 박스 이므로 선택하게 조건으로
            {
                MessageBox.Show("보낼 데이터를 선택해주세요");
                return;
            }

            if(rdb_Write.Checked && tb_SendText.Text.Length== 0) // 글이 있는 박스로 그냥 통과
            {
                MessageBox.Show("보낼데이터를 입력해주세요");
                return;
            }

            string data = ""; // 데이터 초기화

            if (rdb_Preset.Checked)
            {
                data = cb_SendPreset.SelectedIndex.ToString();
            }
            else if (rdb_Write.Checked)
            {
                data = tb_SendText.Text;
            }

            bool result = SendData(data);

            if (result) // 위에 bool타입인데 true일 경우에 if를 타므로
            {
                MessageBox.Show("전송완료");
            }
            else
            {
                MessageBox.Show("전송실패");
            }

        }

        private void btn_PortSetting_Click(object sender, EventArgs e)
        {
            int count = sp_Port.BytesToRead; // 받을 수 있는 개수(개수 다르게 받는것 방지)

            if (count > 0)
            {
                byte[] buffer = new byte[count]; //현재 포트에서 읽을 수 있는 개수
                sp_Port.Read(buffer, 0, count); // 인자가 3개(buffer 저장할 공간, 데이터 어디서 부터 읽을지, 얼만큼 읽을지)

                rtb_RecvText.Text = Encoding.ASCII.GetString(buffer); //text받아서 실행(아스키 코드임)
            }
            //내가 설정한 popup이랑 연결될 수 있게 설정
        }


        private void sp_Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = sp_Port.BytesToRead;


            if(count > 0)
            {
                byte[] buffer = new byte[count];
                int readCount = sp_Port.Read(buffer, 0, count); // 무조건 int로 반환 (read가 하는 일)
                                                                //Read: 실제로 읽은 바이트의 수


                bool enq = _queueBuffer.Enqueue(buffer, 0, readCount); // 무조건 bool타입으로 반환

                //if (_queueBuffer.Enqueue(buffer, 0, readCount))
                //{ 
                //}
                // Read (int 실제로 받은 수) -- 그럼 count가 5인데 실제로 받은 수가 3일 수도 있다.
                //큐에 저장 인큐 함수
                //read반환값 저장 변수 만들기
                //받은데이터를 큐에다가 저장만 하도록
                //rtb_RecvText.Text = Encoding.ASCII.GetString(buffer); //buffer에 저장을 해뒀으니 그것을 소환
            }
        }

        #endregion

        private bool Portsetting() //포트 셋팅 함수
        {
            string portname; // 각 인자별 해당하면 타입 할당
            int baudrate;
            int databits;
            Parity parity;
            StopBits stopbits;

            if (!_settingPopup.GetPortSettings(out portname, out baudrate, out databits, out parity, out stopbits))
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
            if(sp_Port.IsOpen == false)
            {
                return false;
            }

            sp_Port.Write(data); // send와 비슷한 개념(송신버퍼에 데이터를 보낼 때)
            return true;
        }

    }
}
