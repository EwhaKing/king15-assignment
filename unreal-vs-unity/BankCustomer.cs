using System;

namespace Classes_M1;

public class BankCustomer
{
    private static int s_nextCustomerId;
    public string FirstName = "Tim";
    public string LastName = "Shao";
    public readonly string CustomerId;

    public BankCustomer(){
        Random random = new Random();
        s_nextCustomerId = random.Next(10000000, 20000000);
    }

    public BankCustomer(String firstName, String lastName){
        FirstName = firstName;
        LastName = lastName;
        this.CustomerId = (s_nextCustomerId++).ToString("D10");
    }

}
