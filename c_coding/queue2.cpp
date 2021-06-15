// queue2.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;
#define MAX_QUEUE_COUNT 5 //MAX_QUEUE_COUNT 정의 후 배열 길이 지정
int queue[MAX_QUEUE_COUNT]; //정수형 배열 선언
int index = 0; // 값 들어갈 번지 정의

int isFull() {
    if (index > MAX_QUEUE_COUNT - 1) {
        printf("queue가 가득찼습니다.\n"); // index가 가득찬 후 에러
        return 1;
    }
    else
        return -1;
} // enqueue 함수화 하기

int isEmpty() {
    if (index <= 0) {
        printf("queue가 없습니다.\n");
        return 1;
    }
    else
        return -1;
} // dequeue 함수화 하기

void enqueue(int num) //삽입 명령을 ENQUEUE
{
    if (isFull() == 1)
        return;

    else {
        queue[index] = num;
        ++index; // 인덱스 넣을 때마다 1씩 증가
        printf("[%d]가 push\n", num);
    }
} // 반환 안함

int dequeue() //삭제 명령을 DEQUEUE
{
    if (isEmpty() == 1)
        return -1;
    else {
        int temp = queue[0];//지역 변수 설정-> 값 앞에서 한개 빼기
        for (int i = 1; i < index; i++) {
            queue[i - 1] = queue[i];

        } //index반환 -- 값 한 칸씩 땡기기(큐의 특징)
        --index; // 인덱스를 하나씩 빼준후 아예 없을 때 위에 에러나게 설정
        printf("[%d]가 delete\n", temp);
        return temp; // temp
    }
} // 반환



int main()
{
    for (int a = 0; a < MAX_QUEUE_COUNT; a++) {
        queue[a] = 0;
    } // 초기화 해주기

    enqueue(1);
    enqueue(2);
    enqueue(5);
    enqueue(4);
    enqueue(3);
    enqueue(6);
    dequeue();
    dequeue();
    dequeue();
    dequeue();
    dequeue();
    dequeue();
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
