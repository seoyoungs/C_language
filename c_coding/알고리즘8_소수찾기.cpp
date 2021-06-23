// 알고리즘8_소수찾기.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
// 애라토스테네스 체 활용하기

#include <string>
#include <vector>

using namespace std;

int solution(int n) {
    int answer = 0;
    int i, j;

    vector<int> prime(n + 1, 0);

    for (i = 2; i <= n; i++) {
        if (prime[i] == 1)
            continue;
        answer++;
        for (j = i; j <= n; j += i) {
            prime[j] = -1;
        }
    }
    return answer;
}

// 문제 설명
// 1부터 입력받은 숫자 n 사이에 있는 소수의 개수를 반환하는 함수, solution을 만들어 보세요.

// 소수는 1과 자기 자신으로만 나누어지는 수를 의미합니다.
// (1은 소수가 아닙니다.)

// 제한 조건
// n은 2이상 1000000이하의 자연수입니다.
// 입출력 예
// n   result
// 10	4
// 5  	3


