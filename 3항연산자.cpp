﻿// 3항연산자.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#define AAA 5 // 배열 선언
#define BBB 4 //
int aa[AAA] = { 2, 3, 4, 4, 2 };
int bb[BBB] = { 1, 3, 2, 4 };

int main()
{
	int temp = aa[0];

	for (int i = 0; i < AAA - 1; i++)
	{

		int abc;
		abc = bb[i] == 1 ? temp += aa[i + 1] : bb[i] == 2 ? temp -= aa[i + 1] : bb[i] == 3 ? temp *= aa[i + 1] : temp /= aa[i + 1];
		//if (bb[i] == 1) {
		//	temp += aa[i + 1];
		//}
		//else if (bb[i] == 2) {
		//	temp -= aa[i + 1];
		//}
		//else if (bb[i] == 3) {
		//	temp *= aa[i + 1];
		//}
		//else if (bb[i] == 4) {
		//	temp /= aa[i + 1];
		//}

		
	}
	
	
	printf("%d", temp);

	return 0;
}


//1. N길이의 정수형 데이터가 담긴 배열이 존재

//2. N - 1 길이의 연산 정보가 담긴 배열이 존재

//- 연산정보는 숫자로 표기되고 각각 아래의 기능을 가지고있음.
//1 = 더하기
//2 = 빼기
//3 = 곱하기
//4 = 나누기

//3. 두 배열을 활용하여 사칙연산은 무시하고 앞에서부터 순서대로 연산을 진행.

//4. 결과를 출력


//ex : 예를 들면 배열이 아래와같이 구성되있다면
//정수 배열[2, 3, 4, 4, 2]
//연산 배열[1, 3, 2, 4]

//수식은 2 + 3 * 4 - 4 / 2 가 되며
//사칙연산은 무시되므로 최종 출력은
//8이 나오게 됨.

//사용 기능 = 반복문, 출력문, 조건문(if& else if), 지역변수의 활용