using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Bor� tutar� bakiyeyi a��yor";
        public const string DebitAmountLessThanZeroMessage = "Bor� tutar� s�f�rdan k���k";
        private readonly string m_customerName;
        private double m_balance;
      //  public const string TaksitYillikMessage = "Y�ll�k Taksit kullan�ld�";
        //public const string AylikTaksitMessage = "Ayl�k Taksit kullan�ld�";
        public const string TaksitErrorMessage = "Ge�ersiz Taksit Se�ildi";
        public const double YilOran = 5.4;
        public const double AyOran = 7.3;
        //Readonly tan�ml� de�i�keni salt okunur moduna getirmektedir

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
        public void Taksit(double vade, double miktar)
        {
            if (vade==0)
            {
                throw new ArgumentOutOfRangeException("taksit", vade, TaksitErrorMessage);
            }
            if(vade>=12)
            {
                m_balance += (miktar - (vade * YilOran));
            }
            if (vade < 12)
            {
                m_balance += (miktar - (vade * AyOran));
            }
           
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally incorrect code
        }

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
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

           /* ba.Credit(5.77);
            ba.Debit(11.22);*/
           // ba.Taksit(8.5, 1500.65);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}