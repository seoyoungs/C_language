﻿// 알고리즘7.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <string>
#include <vector>
#include <algorithm> // 여기에 sort가 들어있다.

using namespace std;

int N = 0; // n초기화

bool compare(string a, string b) {
    if (a[N] == b[N]) return a < b;
    else return a[N] < b[N];
}

vector<string> solution(vector<string> strings, int n) {
    N = n;
    sort(strings.begin(), strings.end(), compare);
    return strings;
}

//문제 설명
//문자열로 구성된 리스트 strings와, 정수 n이 주어졌을 때, 각 문자열의 인덱스 n번째 글자를 기준으로 오름차순 정렬하려 합니다.
// 예를 들어 strings가["sun", "bed", "car"]이고 n이 1이면 각 단어의 인덱스 1의 문자 "u", "e", "a"로 strings를 정렬합니다.

//제한 조건
//strings는 길이 1 이상, 50이하인 배열입니다.
//strings의 원소는 소문자 알파벳으로 이루어져 있습니다.
//strings의 원소는 길이 1 이상, 100이하인 문자열입니다.
//모든 strings의 원소의 길이는 n보다 큽니다.
//인덱스 1의 문자가 같은 문자열이 여럿 일 경우, 사전순으로 앞선 문자열이 앞쪽에 위치합니다.


