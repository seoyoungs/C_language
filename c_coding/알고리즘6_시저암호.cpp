// 알고리즘6_시저암호.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <string>
#include <vector>

using namespace std;

string solution(string s, int n) {
    string answer = "";
    int alpha = 'z' - 'a' + 1;
    for (auto c : s) {
        if (c >= 'a' && c <= 'z') {
            c = c + n > 'z' ? c + n - alpha : c + n;
        }
        else if (c >= 'A' && c <= 'Z') {
            c = c + n > 'Z' ? c + n - alpha : c + n;
        }
        answer.push_back(c);
    }


    return answer;
}

// 문제 설명
// 어떤 문장의 각 알파벳을 일정한 거리만큼 밀어서 다른 알파벳으로 바꾸는 암호화 방식을 시저 암호라고 합니다.
// 예를 들어 "AB"는 1만큼 밀면 "BC"가 되고, 3만큼 밀면 "DE"가 됩니다. "z"는 1만큼 밀면 "a"가 됩니다.문자열 s와 거리 n을 입력받아 s를 n만큼 민 암호문을 만드는 함수, solution을 완성해 보세요.

//제한 조건
//공백은 아무리 밀어도 공백입니다.
//s는 알파벳 소문자, 대문자, 공백으로만 이루어져 있습니다.
//s의 길이는 8000이하입니다.
//n은 1 이상, 25이하인 자연수입니다.
//입출력 예
// s	   n	result
//"AB"	   1	"BC"
//"z"	   1	"a"
//"a B z"	4	"e F d"


//https://programmers.co.kr/learn/courses/30/lessons/12926
// 아스키 코드 공부하기 시저암호랑 연관있음


