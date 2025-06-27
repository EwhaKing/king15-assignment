using Classes_M1;
// 이를 통해 Program.cs 파일 내에서 클래스에 액세스 가능

BankCustomer customer1 = new BankCustomer();
string first_name = "Tim";
string last_name = "Shao";
//string customer_idnum = "10101010";

first_name = "Lisa";
BankCustomer customer2 = new BankCustomer(first_name, last_name);

first_name = "Sandy";
last_name = "Zoeng";
//customer_idnum = "20202020";
BankCustomer customer3 = new BankCustomer(first_name, last_name);


Console.WriteLine($"BankCustomer 1: {customer1.First_name} {customer1.Last_name} {customer1.customer_id}");
Console.WriteLine($"BankCustomer 2: {customer2.First_name} {customer2.Last_name} {customer2.customer_id}");
Console.WriteLine($"BankCustomer 3: {customer3.First_name} {customer3.Last_name} {customer3.customer_id}");
