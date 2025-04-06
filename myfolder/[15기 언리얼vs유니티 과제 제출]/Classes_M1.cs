using System;

namespace Classes_M1;

public class BankCustomer
{
    public string First_name = "Tim";
    public string Last_name = "Shao";
    public readonly string customer_id;
    //readonly는 선언/생성자에서 값을 할당할 수 있는 필드를 선언하는데에 사용

    private static int s_next_customer_id;
    //고유한 ID 주소
   static BankCustomer() //public 필드는 외부에서 접근가능
    {
        Random rnd = new Random();
        s_next_customer_id = rnd.Next(100000,200000);
    }

    public BankCustomer()
    {
        this.customer_id = s_next_customer_id.ToString("D10");
        //이미 할당된 고객 id num으로 다음꺼를 할당해서 고유하게 만드는?작업?
    }

    
    public BankCustomer(string firstName, string lastName)
    {
        First_name= firstName;
        Last_name= lastName;
        this.customer_id = (s_next_customer_id++).ToString("D10");
    }

    
    public BankCustomer(string first_name, string last_name, string customer_idnum)
    {
        First_name = first_name;
        Last_name = last_name;
        customer_id = customer_idnum;
    }
}

