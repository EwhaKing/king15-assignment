/* 3/20 언리얼vs유니티 교육세션 과제_C++ 스터디

Language support library
1)Basic memory management_Low level memory management (저수준 메모리 관리)
-new-expression: new 연산자는 heap에 동적으로 메모리를 할당할 때 사용된다.
-delete-expression: delete 연산자는 new로 할당한 메모리를 해제할 때 사용된다.
-new, delete 뿐만 아니라 이를 직접 구현하거나 예외 처리 등을 하고 싶을 때 밑의 요소들 활용

-functions
    1. operator new[]: 객체/배열을 위한 메모리 할당 함수
    2. operator delete[]: 메모리 해제 함수. new로 할당한 메모리 반환
    3. get_new_handler(): set_new_handler()로 설정된 핸들러 가져오기
    4. set_new_handler(): 메모리 할당 실패시 호출할 핸들러 함수 등록하기

-classes
    1. bad_alloc: 메모리 할당 실패 시 던져지는 예외 클래스 (std::bad_alloc)
    2. bad_array_new_length: 배열 크기가 유효하지 않을 때 발생
    3. align_val_t: 메모리 정렬이 필요한 할당 시 정렬 값 전달용 타입

-types
    new_handler: set_new_handler()에 사용할 수 있는 함수 포인터 타입 정의

-objects
    1. nothrow/nothrow_t: 메모리 할당 실패 시 예외를 던지지 않고 nullptr을 반환하도록 하는 태그 (new(nothrow) int[10])
    2. destroying_delete/destroying_delete_t: 객체 소멸자와 delete를 함께 처리하는 기능 선택용 태그

-object access
    launder(): 최적화된 포인터를 통해 안전하게 객체에 접근하도록 보장하는 함수. 주로 저수준 최적화에서 사용됨

요약)
1. 일반적인 메모리 할당 및 해제: new, delete, operator new/delete
2. 예외 핸들링: bad_alloc, set_new_handler
3. 정렬 제어: align_val_t
4. 예외 없이 할당: nothrow
5. 최신 표준 기능: launder, destroying_delete
*/

#include <iostream>
#include <new> //set_new_handler
using namespace std;

void newHandler(){
    cerr << "메모리 할당 실패\n";
    abort();
}

int main(){
    set_new_handler(newHandler); //핸들러 등록

    //짱 큰 메모리 할당 시도, 실패하면 핸들러 작용
    int* p = new int[1000000];
    delete[] p;
    return 0;
}