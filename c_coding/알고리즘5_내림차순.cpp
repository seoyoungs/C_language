// 알고리즘5_내림차순.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <string>
#include <vector>
#include <algorithm>

using namespace std;

string solution(string s) //문제에 정렬이란 말이 있으면 sort를 꼭 해주자
{
    sort(s.begin(), s.end()); // 먼저 정렬을 한 다음
    reverse(s.begin(), s.end()); // 거꾸로 정렬을 해준다 -- 큰것부터 작은 순
    return s;
}


// 문자열 내림차순으로 배치하기
//문제 설명
//문자열 s에 나타나는 문자를 큰것부터 작은 순으로 정렬해 새로운 문자열을 리턴하는 함수, solution을 완성해주세요.
//s는 영문 대소문자로만 구성되어 있으며, 대문자는 소문자보다 작은 것으로 간주합니다.

//제한 사항
//str은 길이 1 이상인 문자열입니다.
//입출력 예
//     s	  return
//"Zbcdefg"	"gfedcbZ"
// 
//https://programmers.co.kr/learn/courses/30/lessons/12917
