// 알고리즘1.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <string>
#include <vector>
#include <algorithm>

using namespace std;

//vector를 이용하여 N*N의 이중 배열만들 수 있다.
vector<int> solution(vector<int> arr, int divisor) //vector<vector<int>> arr 이중 벡터 만들기 
{
    vector<int> answer;
    sort(arr.begin(), arr.end()); // 처음 끝 정렬해주기 왜??

    for (int i = arr.size() - 1; i >= 0; --i) {
        if (arr[i] < divisor) //자연수보다 작을때
        {
            break;///멈추기
        }
        if (arr[i] % divisor == 0) {
            answer.insert(answer.begin(), arr[i]);
        }
    }
    if (answer.size() == 0)
    {
        answer.push_back(-1); //divisor로 나누어 떨어지는 element가 없다면 -1 반환
    }

    return answer;
}


//문제 설명
//array의 각 element 중 divisor로 나누어 떨어지는 값을 오름차순으로 정렬한 배열을 반환하는 함수, solution을 작성해주세요.
//divisor로 나누어 떨어지는 element가 하나도 없다면 배열에 - 1을 담아 반환하세요.

//제한사항
//arr은 자연수를 담은 배열입니다.
//정수 i, j에 대해 i ≠ j 이면 arr[i] ≠ arr[j] 입니다.
//divisor는 자연수입니다.
//array는 길이 1 이상인 배열입니다.

//https://programmers.co.kr/learn/courses/30/lessons/12910
