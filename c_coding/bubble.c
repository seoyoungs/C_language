#include <stdio.h>
 
#define AAA 20
int aa[AAA]={ 8, 4, 2, 5, 3, 7, 10, 1, 6, 9 }; // 정렬할 배열과 요소의 개수를 받음
 
 
int main()
{
 
	for (int j = 0; j < AAA; j++) //// 요소의 개수만큼 반복
	{
		for (int i = 0; i < AAA - 1; i++) // 요소의 개수 - 1만큼 반복
		{
			if (aa[i] > aa[i+1])  // 현재 요소의 값과 다음 요소의 값을 비교하여
			{
				int temp;
				temp = aa[i];
				aa[i] = aa[i+1]; 
				aa[i+1] = temp; // 큰값을 다음 요소로 보냄
			}	
		}	
	}
	for (int i = 0; i < AAA; i++) {
	printf("%d\n", aa[i]);
	}
	return 0;
}
