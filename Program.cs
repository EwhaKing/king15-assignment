using System;

//사용자 정의 유형 (class, struct, enum, interface 등 사용자 정의 형식 생성)

//struct 키워드를 사용해 사용자 정의 값 유형을 만듦
public struct Coords
{
    public int x, y;

    public Coords(int p1, int p2)
    {
        x = p1;
        y = p2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //System.Console.WriteLine이 아닌 이유는 가독성 개선을 위해
        //System이 네임스페이스, Console은 해당 네임스페이스의 클래스
        //이런 네임스페이스를 선언함녀 프로젝트에서 클래스/메서드 이름의 범위를 제어하는데에 도움이됨

        byte b = byte.MaxValue;
        Console.WriteLine(b);
        byte num = 0xA; //16진수
        Console.WriteLine(num);
        int a = 5;
        Console.WriteLine(a);
        char c = 'Z';
        Console.WriteLine(c);
        
        //배열 선언
        int[] numbers;
        numbers = new int[5];
        for (int i = 0; i < 5; i++)
        {
            numbers[i] = i;
            Console.WriteLine(numbers[i]);
        }

        Phone my_phone = new Phone(); //정의한 Phone() 클래스를 사용하려면, main()함수 안에서 객체(인스턴스)를 생성해야함
        my_phone.Call("010-1212-3434"); //클래스 내부 속성 설정 가능
        my_phone.Text("010-3456-7980", "Hi :)");

        Person person1 = new Person("Harry" , "Potter");
        
        //Person2는 생성자가 없는 클래스
        var person2 = new Person2();
        Console.WriteLine($"Name : {person2.name}, Age: {person2.age}");
        //이렇게 하면 Name: unknown, Age: 0으로 출력됨
    }
    
    //클래스는 데이터와 동작을 캡슐화함
    //캡슐화: 데이터와 동작을 단일 단위로 결합하는 프로세스로, 클래스는 속성을 활용해 데이터에 액세스, 메서드를 사용해 동작을 활성화함
    //C#코드의 클래스 정의
    public class Phone
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }

        public void Call(string phone_number)
        {
            Console.WriteLine($"Calling {phone_number}...");
        }

        public void Text(string phone_number, string message)
        {
            Console.WriteLine($"Texting {phone_number}: {message}...");
        }
    } 
    
    //클래스 생성자: 형식과 동일한 이름을 가진 메서드
    // ㄴ1. 인스턴스 생성자: 객체가 생성될 때 인스턴스 필드 변수를 생성.초기화하는데 사용
    // ㄴ2. 정적 생성자: 정적 데이터를 초기화하거나 한 번만 수행하면 되는 특정 작업을 수행하는데에 사용

    public class Person
    {
        //1. 인스턴스 생성자: 클래스와 동일한 이름을 사용 + 반환 유형 포함X
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
}

    //1-1. 생성자가 없는 클래스
    //명시적 인스턴스 생성자가 없는 경우, 인스턴스화하는데 사용 가능한 매개변수 없는 생성자를 제공

    public class Person2
    {
        public int age;
        public string name;
    }
    
    //2. 정적 
    //속성: 액세스 수정자를 사용하지 않고, 매개변수가 없음
    // 클래스는 정적 생성자를 하나만 가질 수 있고, 정적 생서자는 상속/오버로드 될 수 없음
    public class Person3
    {
        public string person_name;
        public string person_age;
        
        //정적인 필드
        public static string default_name;
        public static string default_age;

        static Person3()
        {
            default_name = "unknown";
            default_age = "unknown";
        }

        public Person3()
        {
            person_name = default_name;
            person_age = default_age;
        }
        
        public Person3(string name)
        {
            person_name = name;
            person_age = default_age;
        }
        
        public Person3(string name, int age)
        {
            person_name = name;
            person_age = age.ToString();
        }
    }