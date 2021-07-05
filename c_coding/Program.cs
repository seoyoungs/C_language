using System;
using static System.Console;

namespace 백준_2577_C샾
{
    class Program
    {
        static void Main(string[] args)
        {
            // c#은 여기서 부터 코드 쓰는것
            // 각각 자연수 a,b,c 정의
            int A = int.Parse(ReadLine()); //Console.ReadLine()문으로 숫자, 문자 입력받아 출력
            int B = int.Parse(ReadLine());
            int C = int.Parse(ReadLine());

            // 입력 받은 수를 곱함
            int muxNum = A * B * C;

            //0~9까지의 count를 나타낼 배열
            // 특정 길이로 초기화만 하는 경우 ----> int[] array = new int[10]
            int[] count = new int[10];

            // 무한 반복문
            while (true)
            {
                //muxNum의 값이 0이라면 반복문 탈출
                if (muxNum == 0) break;

                // count배열의 위치를 나타낼 a변수에
                // muxNum % 10 => 1개의 자릿수
                // 자릿수 자체가 숫자를 나타내므로
                int a = muxNum % 10;

                // 그 자릿수의 위치에 값을 1증가
                count[a]++;

                // muxNum / 10 =1자릿수 버려서
                // muxNum에 다시 넣어주기
                muxNum = muxNum / 10;
            }

            // count 배열 출력
            for(int i = 0; i < count.Length; i++) 
            {
                WriteLine(count[i]);
            }


            

        }
    }
}

//1.문제
//세 개의 자연수 A, B, C가 주어질 때 A×B×C를 계산한 결과에
//0부터 9까지 각각의 숫자가 몇 번씩 쓰였는지를 구하는 프로그램을 작성하시오.
//예를 들어 A = 150, B = 266, C = 427 이라면 
//A × B × C = 150 × 266 × 427 = 17037300 이 되고,
//계산한 결과 17037300 에는 0이 3번, 1이 1번, 3이 2번, 7이 2번 쓰였다.


//2.입력
//첫째 줄에 A, 둘째 줄에 B, 셋째 줄에 C가 주어진다. A, B, C는 모두 100보다 같거나 크고, 1,000보다 작은 자연수이다.

//3.출력
//첫째 줄에는 A×B×C의 결과에 0 이 몇 번 쓰였는지 출력한다. 마찬가지로 둘째 줄부터
//열 번째 줄까지 A×B×C의 결과에 1부터 9까지의 숫자가 각각 몇 번 쓰였는지 차례로 한 줄에 하나씩 출력한다.




