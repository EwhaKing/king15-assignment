using System;
using System.Globalization;
using System.Net.Http.Headers;

namespace Classes_M1;

public class BankAccount
{
    private static int s_nextCustomerId = 1;
    public readonly int AccountNumber;
    public double Balance = 0;
    public static double InterestRate;
    public string AccountType = "Checking";
    public readonly string CustomerId;

    static BankAccount(){
        Random random = new Random();
        s_nextCustomerId = random.Next(10000000, 20000000);
        InterestRate = 0;
    }

    public BankAccount(string customerIdNumber){
        this.AccountNumber = s_nextCustomerId++;
        this.CustomerId = customerIdNumber;
    }

    public BankAccount(string customerIdNumber, double balance, string accountType){
        this.AccountNumber = s_nextCustomerId++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }
}
