// 알고리즘2.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <string>
#include <vector>

using namespace std;

int solution(vector<int> a, vector<int> b) {
    int answer = 0; // long long 도 되는데 int도 가능//근데 왜 longlong?
    //long long 자료형은 int형 연산에서 초과되는 범위에서 사용
    int size = a.size();
    
    for (int i = 0; i < size; i++)
    {
        answer += a[i] * b[i]; //a[0]*b[0] 형식이다
    }

    return answer;
}




//문제 설명
//길이가 같은 두 1차원 정수 배열 a, b가 매개변수로 주어집니다.a와 b의 내적을 return 하도록 solution 함수를 완성해주세요.

//이때, a와 b의 내적은 a[0] * b[0] + a[1] * b[1] + ... + a[n - 1] * b[n - 1] 입니다. (n은 a, b의 길이)

//제한사항
//a, b의 길이는 1 이상 1, 000 이하입니다.
//a, b의 모든 수는 - 1, 000 이상 1, 000 이하입니다.

//출력 예
//a           	b	        result
//[1, 2, 3, 4] [-3, -1, 0, 2]	3
//[-1, 0, 1]   [1, 0, -1]     - 2

//https://programmers.co.kr/learn/courses/30/lessons/70128?language=cpp