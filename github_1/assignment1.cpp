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
    int* p = new int[1000000000];
    delete[] p;
    return 0;
}

/*
2)Variadic Functions(가변 인자 함수)
-인자의 개수가 정해지지 않은 함수
-함수 선언에서 ...(ellipsis)를 사용해서 정의함
-예시: printf(const char* fmt, ...)

-관련 헤더 및 매크로: 가변 인자를 처리하기 위해 <cstdarg> 헤더를 사용함
    1. va_list: 가변 인자들을 접근할 수 있는 타입 (핸들 역할)
    2. va_start: 가변 인자 시작점 지정
    3. va_arg: 다음 인자를 타입에 맞춰 하나씩 가져옴
    4. va_end: 인자 처리가 끝난 후 호출해서 정리
    5. va_copy: 인자 리스트를 복사할 때 사용
*/

#include <cstdarg> // 가변 인자 함수 처리에 필요한 헤더

void simple_printf(const char* fmt, ...) {
    va_list args;             // 인자 리스트 선언
    va_start(args, fmt);      // 인자 처리 시작

    while (*fmt != '\0') {
        if (*fmt == 'd') {    // 정수
            int i = va_arg(args, int);
            std::cout << i << '\n';
        } else if (*fmt == 'c') { // 문자
            int c = va_arg(args, int); // char도 int로 받아야 함
            std::cout << static_cast<char>(c) << '\n';
        } else if (*fmt == 'f') { // 실수
            double d = va_arg(args, double);
            std::cout << d << '\n';
        }
        ++fmt;
    }

    va_end(args);             // 인자 처리 종료
}

int main() {
    simple_printf("dcff", 3, 'a', 1.999, 42.5);
    return 0;
}

/*
3)std::source_location
-코드의 소스 정보(파일명, 함수명, 줄 번호 등)를 런타임에 캡처해서 확인할 수 있게 해주는 구조체
-이전에는 __FILE__, __LINE__, __func__ 같은 매크로를 사용
-더 깔끔하게 코드 위치 정보 찾을 수 있음
-소형 구조체라 복사해도 성능에 부담 적음(기본 생성 가능, 복사 가능, 이동 가능능)

-주요 멤버 함수
    1. source_location::current(): 현재 코드 위치 정보를 반환하는 정적 함수
    2. line(): 현재 줄 번호 반환
    3. column(): 현재 열 번호 반환
    4. file_name(): 현재 파일 이름 반환
    5. function_name(): 현재 함수 이름 반환

-생성 조건 
    1. noexcept move constructible
    2. noexcept move assignable
    3. noexcept swappable

-예제 코드드
#include <iostream>
#include <source_location>
#include <string_view>
 
void log(const std::string_view message,
         const std::source_location location =
               std::source_location::current())
{
    std::clog << "file: "
              << location.file_name() << '('
              << location.line() << ':'
              << location.column() << ") `"
              << location.function_name() << "`: "
              << message << '\n';
}
 
template<typename T>
void fun(T x)
{
    log(x); // line 20
}
 
int main(int, char*[])
{
    log("Hello world!"); // line 25
    fun("Hello C++20!");
}

**C++20 부터 도입된 기능 > 모든 컴파일러에 완전히 구현된 것은 아님
*/

/*
4)Type support (기본 타입 및 RTTI)
-추가적인 기본 타입과 매크로
    1. size_t: sizeof 연산 결과 반환용 부호 없는 정수 타입
    2. ptrdiff_t: 포인터 간 차이를 나타내는 부호 있는 정수 타입
    3. nullptr_t: nullptr의 타입 (null 포인터 리터럴)
    4. NULL: null 포인터 상수 (구현에 따라 다름)
    5. max_align_t: 가장 큰 정렬 요구 조건을 가지는 타입
    6. offsetof(type, member): 구조체 멤버의 오프셋을 반환하는 매크로
    7. byte: enum class로 정의된 바이트 단위 표현

-Fixed Width Integer Types (C++11~)
    <cstdint> 헤더에 정의된 고정 크기 정수 타입들
    예: int8_t, uint32_t, int64_t 등

-Numeric Limits
    <limits> 헤더에 정의됨
    std::numeric_limits<T>: 기본 타입들의 최소/최대값, 정밀도 등 조회 가능

-Runtime Type Identification (RTTI)
    <typeinfo> 헤더 필요
    1. type_info: typeid 연산자로 얻을 수 있는 타입 정보 객체
    2. bad_typeid: typeid 사용 시 null 인자를 주었을 때 발생하는 예외
    3. bad_cast: dynamic_cast 실패 시 발생하는 예외

- Type Index
    <typeindex> 헤더 필요
    type_index (C++11):	type_info 객체를 key로 사용 가능한 래퍼 (map, set 등에서 사용 가능)

요약)
1. size_t, ptrdiff_t 같은 타입은 포인터/배열 관련 연산에서 중요
2. nullptr_t, byte, max_align_t 등은 모던 C++에서 등장한 유틸리티 타입
3. RTTI는 런타임에 타입 정보를 얻을 수 있게 해주는 기능이며, typeid, dynamic_cast 관련
4. <typeindex>는 타입 정보를 맵의 키로 쓰고 싶을 때 사용
*/

