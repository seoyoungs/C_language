using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_Serial
{
    public class QueueBuffer
    {
        //멤버변수 선언
        private byte[] queue;
        private int head;
        private int tail;

        public QueueBuffer(int length)
        {
            //초기화
            queue = new byte[length];
            head = 0;
            tail = 0;

        }

        //프로퍼티 (속성)--- 이렇게 사용자 함수로 정의해 대입하는 것
        public int BytesToRead
        {
            get
            {
                if (head == tail)
                {
                    return 0;
                }
                else if (head > tail)
                {
                    return head - tail;
                }
                else
                {
                    return head + queue.Length - tail;
                }

            }
        }

        private int LastIndex
        {
            get
            {
                return queue.Length - 1;
            }
        }

        public bool Enqueue(byte[] datas, int offset, int count)
        {
            // 큐의 길이 한도 체크
            // if문
            //datas를 queue에 넣어주기
            // datas의 offset 인덱스 부터 카운트 개수 만큼 queue의 헤드 번지를 하나씩 올려가면서 큐에 그대로 값 넣기(for)
            // head가 queue의 마지막 index의 값과 같은때 0으로 돌리는 조건문 datas 포문안에

            if (offset <= 0)
            {
                return false;
            }

            if(count <= 0)
            {
                return false;
            }

            if(datas.Length < offset + count)
            {
                return false;
            }
            if(queue.Length < count) // 큐의 길이가 count보다 작은지
            {
                return false;
            }
            
            for (int i = offset; i < offset + count; i++)
            {
                queue[head] = datas[i]; //queue의 헤드 번지

                if (head == LastIndex) // head가 번지 수가 마지막을 가르키는지
                {
                    head = 0; // 헤드 처음 번지로
                }
                else
                {
                    head++; // 아니면 head를 +1씩 꽉 찰때까지 진행한다.
                }
            }

            return true;

        }

        public bool Dequeue(byte[] buffers, int count)
        {
            // head랑 tail 같은지(따로 함수로 구현할 예정)
            // byte[], 길이 를 인자로 추가하기
            // queue[tail] tail이랑 같아질때까지 , tail 0일때로 구현
            // 줄수 있는 길이보다 크면 안된다 1.
            // 길이만큼 for문 작성

            int bytestoread = BytesToRead; //head, tail값의 거리 --  보낼수 있는 데이터의 수

            if (count <= 0)
            {
                return false;
            }

            bytestoread = bytestoread < count ? bytestoread : count; // 둘 중에 작은값 (삼항연산자)


            for (int i = 0; i < bytestoread; i++)
            {
                buffers[i] = queue[tail]; // buffers의 i번지의 값을 queue의 tail번지에 있는 값으로 넣어준다
                
                if(tail == LastIndex) //queue.Length - 1 마지막 인덱스
                {
                    tail = 0;
                }
                else
                {
                    tail++;
                }
                

            }

            return true;
        }

    }





}








