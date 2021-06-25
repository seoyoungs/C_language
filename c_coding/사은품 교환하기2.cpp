// 사은품 교환하기2.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;


int main() {
	int n = 32;
	int m = 20;
	int t;

	cin >> t; // 입력받을 변수
	while (t++) // 반복 수행 조건 (케이스 반복)
	{
		cin >> n >> m; // 입력받을 변수

		cout << min((n + m) / 12, n / 5) << "\n"; // 출력할 내용을 입력(제일 최솟값들로 추출)
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
