// 백준_1051.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <string>

using namespace std;

int n, m, result = 1;
int arr[51][51] = { 0 };
string input;

int main()
{
    cin >> n >> m;
    for (int i = 0; i < n; i++) {
        cin >> input;
        for (int j = 0; j < input.size(); j++)
            arr[i][j] = input[j] - '0';
    }

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            int cnt = 0;
            for (int k = 1;; k++) {
                if ((j + k) >= m || (i + k) >= n) break;
                if (arr[i][j] == arr[i][j + k] && arr[i][j] == arr[i + k][j] && arr[i][j] == arr[i + k][j + k])
                    if (cnt < k)
                        cnt = k;

            }
            if((cnt+1) > result)  result = cnt + 1;
        }
    }
    cout << result * result << endl;

}


// 문제
// N* M크기의 직사각형이 있다.각 칸은 한 자리 숫자가 적혀 있다.
// 이 직사각형에서 꼭짓점에 쓰여 있는 수가 모두 같은 가장 큰 정사각형을 
// 찾는 프로그램을 작성하시오.이때, 정사각형은 행 또는 열에 평행해야 한다.

// 입력
// 첫째 줄에 N과 M이 주어진다.N과 M은 50보다 작거나 같은 자연수이다.둘째 줄부터 N개의 줄에 수가 주어진다.

// 출력
// 첫째 줄에 정답 정사각형의 크기를 출력한다.


// 브루트포스 문제입니다. 모든 점에서 꼭짓점값들을 확인해서 가장크게 만들 수 있는 정사각형 넓이를 출력하는 문제




