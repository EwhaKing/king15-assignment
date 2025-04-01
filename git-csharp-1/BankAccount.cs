using System;

namespace Classes_M1;

public class BankAccount{

    public int AccountNumber;
    public double Balance = 0;
    public static double Interestrate;
    public string AccountType = "Checking";
    public readonly string CustomerId;
    private static int s_nextAccountNumber = 1;

    static BankAccount(){
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        Interestrate = 0;
    }

    public BankAccount(string customerIdNumber){
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    public BankAccount(string customerIdNumber, double balance, string AccountType){
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = AccountType;
    }
}