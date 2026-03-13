using System;
using System.Diagnostics;
namespace BankAccountNS
{
    ///  <summary>;
    /// Bank account demo class.
    ///  </summary>;
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        public string CustomerName
        {
            get { return m_customerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }
        /// <summary>;
        /// Этот метод списывает деньги с аккаунта
        /// </summary>;
        /// <param name="amount">Сумма списываемая со счета</param>;
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }
        /// <summary>;
        /// Этот метод начисляет деньги на счет
        /// </summary>;
        /// <param name="amount">Сумма начисляемая на счет</param>;
        public void Credit(double amount)
        {
            if (amount < 0)
{
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr.Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}