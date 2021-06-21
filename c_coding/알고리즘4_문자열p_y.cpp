// 알고리즘4_문자열p_y.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <string>
#include <iostream>
using namespace std;

bool solution(string s)
{
    int p = 0;
    int y = 0;
    for (auto c : s) {
        if (c == 'p' || c == 'P') ++p; // 소대문자 p일 때
        if (c == 'y' || c == 'Y')++y; // 소대문자 y일 때

    }

    return p == y;
}

//문제 설명
//대문자와 소문자가 섞여있는 문자열 s가 주어집니다.s에 'p'의 개수와 'y'의 개수를 비교해 같으면 True, 다르면 False를 return 하는 solution를 완성하세요. 
//'p', 'y' 모두 하나도 없는 경우는 항상 True를 리턴합니다.단, 개수를 비교할 때 대문자와 소문자는 구별하지 않습니다.

//예를 들어 s가 "pPoooyY"면 true를 return하고 "Pyy"라면 false를 return합니다.

//제한사항
//문자열 s의 길이 : 50 이하의 자연수
//문자열 s는 알파벳으로만 이루어져 있습니다.
//입출력 예
//    s	        answer
// "pPoooyY"	true
// "Pyy"	    false
