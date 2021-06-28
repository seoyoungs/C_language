// 사은품 교환하기.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//
#include <stdio.h>
#include <iostream>


using namespace std;

int n = 100000000;
int m = 200000000;
int t;

int main()
{
	int ans = 0;
	
	while (1) {
		cin >> n >> m; // while안에 넣으면 반복된다

		while (1) {

			if (n >= 5 && n + m >= 12) {
				if (m >= 7) {
					n -= 5;
					m -= 7;
				}
				else {
					n -= 12 - m;
					m = 0;
				}
			}
			else
				break;
			ans++;

			printf("%d %d %d \n", n, m, ans);
		}
		// 
		cout << ans << endl; // printf랑 같은 역할
	}
	return 0;
}

// https://level.goorm.io/exam/47878/%EC%82%AC%EC%9D%80%ED%92%88-%EA%B5%90%ED%99%98%ED%95%98%EA%B8%B0/quiz/1
//문제:
//시즌 한정 쿠폰(s_copns)과 일반 쿠폰(n_copns)으로 사은품을 교환할 수 있다.
//총 12장의 쿠폰으로 교환할 수 있으며, 반드시 시즌 한정 쿠폰은 5장 이상이어야 한다.
// 
//Case 1 
//시즌 한정 : 32장
//일반 쿠폰 : 20장

//Case 2
//시즌한정 : 9장
//일반쿠폰 : 100장





