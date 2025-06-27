namespace Project1;

//클래스 생성자: 형식과 동일한 이름을 가진 메서드
// 인스턴스 생성자: 객체가 생성될 때 인스턴스 필드 변수를 생성.초기화하는데 사용
// 정적 생성자: 정적 데이터를 초기화하거나 한 번만 수행하면 되는 특정 작업을 수행하는데에 사용

public class Person
{
    //인스턴스 생성자: 클래스와 동일한 이름을 사용 + 반환 유형 포함X
    public Person()
    {
        
    }

    public Person(string fName, string lName)
    {
        string name = fName + " " + lName;
        Console.WriteLine($"Person created: {name}");
    }
    //클래스는 위에것처럼 두 개 이상의 생성자를 가질 수 있고, 일반적으로 다른 인수를 취함
}