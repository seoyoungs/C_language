// stack1.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;
#define MAX_STACK_COUNT 5

int stack[MAX_STACK_COUNT];
int a = 0;

int isFull() {
	if (a > MAX_STACK_COUNT - 1) {
		printf("스택이 가득찼습니다.\n");
		return 1; //참일때 1
	}
	else
		return -1;
}

int isEmpty() {
	if (a <= 0) {
		printf("스택이 비었습니다.\n");
		return 1; //끝맺음 - pop되고
	}
	else
		return -1;
}

void push(int num) {
	if (isFull() == 1)
		return;
	else {
		stack[a]=num;//최대값이 같아지면
		++a;
		printf("[%d]가 push되었습니다.\n", num);
	}
}

int pop() {
	if (isEmpty() == 1)
		return -1;
	else {
		int temp = stack[a - 1];
		stack[a - 1] = 0;
		--a;
		printf("[%d]가 pop 되었습니다.\n", temp);
		return temp;
	}

}

int main()
{
	for (int i = 0; i < MAX_STACK_COUNT; i++) {
		stack[i] = 0;
	}

	push(1);
	push(2);
	push(3);
	push(4);
	push(5);
	push(6);
	pop();
	pop();
	pop();
	pop();
	pop();
	pop();
	pop();

}

// 프로그램 실행: <Ctrl+F5> 또는 [디버그] > [디버깅하지 않고 시작] 메뉴
// 프로그램 디버그: <F5> 키 또는 [디버그] > [디버깅 시작] 메뉴

// 시작을 위한 팁: 
//   1. [솔루션 탐색기] 창을 사용하여 파일을 추가/관리합니다.
//   2. [팀 탐색기] 창을 사용하여 소스 제어에 연결합니다.
//   3. [출력] 창을 사용하여 빌드 출력 및 기타 메시지를 확인합니다.
//   4. [오류 목록] 창을 사용하여 오류를 봅니다.
//   5. [프로젝트] > [새 항목 추가]로 이동하여 새 코드 파일을 만들거나, [프로젝트] > [기존 항목 추가]로 이동하여 기존 코드 파일을 프로젝트에 추가합니다.
//   6. 나중에 이 프로젝트를 다시 열려면 [파일] > [열기] > [프로젝트]로 이동하고 .sln 파일을 선택합니다.
