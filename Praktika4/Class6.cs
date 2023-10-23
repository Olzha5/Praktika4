using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    internal class Exemple6
    {
        class Client
        {
            public string Name { get; set; }
            public BankAccount BankAccount { get; set; }
            public CreditCard CreditCard { get; set; }

            public void MakePayment(decimal amount)
            {
                if (BankAccount != null && BankAccount.Balance >= amount)
                {
                    BankAccount.Balance -= amount;
                    Console.WriteLine($"{Name} совершил платеж в размере {amount}.");
                }
                else
                {
                    Console.WriteLine($"{Name} не может совершить платеж. Недостаточно средств.");
                }
            }

            public void TransferMoney(BankAccount targetAccount, decimal amount)
            {
                if (BankAccount != null && BankAccount.Balance >= amount && targetAccount != null)
                {
                    BankAccount.Balance -= amount;
                    targetAccount.Balance += amount;
                    Console.WriteLine($"{Name} перевел {amount} на счет {targetAccount.AccountNumber}.");
                }
                else
                {
                    Console.WriteLine($"{Name} не может совершить перевод. Недостаточно средств или целевой счет не указан.");
                }
            }

            public void CancelPayment(decimal amount)
            {
                if (BankAccount != null)
                {
                    BankAccount.Balance += amount;
                    Console.WriteLine($"{Name} аннулировал платеж в размере {amount}.");
                }
            }

            public void BlockCreditCard()
            {
                if (CreditCard != null)
                {
                    CreditCard.IsBlocked = true;
                    Console.WriteLine($"Кредитная карта клиента {Name} была заблокирована.");
                }
            }
        }

        class BankAccount
        {
            public string AccountNumber { get; set; }
            public decimal Balance { get; set; }
        }

        class CreditCard
        {
            public string CardNumber { get; set; }
            public decimal CreditLimit { get; set; }
            public bool IsBlocked { get; set; }
        }

        class Administrator
        {
            public void BlockCreditCard(CreditCard creditCard)
            {
                if (creditCard != null)
                {
                    creditCard.IsBlocked = true;
                    Console.WriteLine("Кредитная карта заблокирована администратором.");
                }
            }
        }

        class Program
        {
            static void Main()
            {
                Client client1 = new Client { Name = "Клиент 1" };
                BankAccount bankAccount1 = new BankAccount { AccountNumber = "123456", Balance = 1000.00M };
                CreditCard creditCard1 = new CreditCard { CardNumber = "1111-2222-3333-4444", CreditLimit = 5000.00M, IsBlocked = false };

                client1.BankAccount = bankAccount1;
                client1.CreditCard = creditCard1;

                client1.MakePayment(200.00M);
                client1.TransferMoney(bankAccount1, 300.00M);

                Administrator administrator = new Administrator();
                administrator.BlockCreditCard(creditCard1);

                client1.CancelPayment(50.00M);

                Console.WriteLine($"Имя клиента: {client1.Name}");
                Console.WriteLine($"Баланс банковского счета: {bankAccount1.Balance}");
                Console.WriteLine($"Лимит кредитной карты: {creditCard1.CreditLimit}");
                Console.WriteLine($"Кредитная карта заблокирована: {creditCard1.IsBlocked}");
            }
        }
    }
}