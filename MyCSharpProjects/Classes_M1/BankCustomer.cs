
 using System;

 namespace Classes_M1;

 public class BankCustomer
 {
     // add public fields for FirstName, LastName, and CustomerId
     public string FirstName = "Tim";
     public string LastName = "Shao";
     public string CustomerId = "1010101010";
    
     public BankCustomer()
     {
    
     }
    
     public BankCustomer(string firstName, string lastName)
     {
         FirstName = firstName;
         LastName = lastName;
    
     }
    
     public BankCustomer(string firstName, string lastName, string customerIdNumber)
     {
         FirstName = firstName;
         LastName = lastName;
         CustomerId = customerIdNumber;
     }
 }
