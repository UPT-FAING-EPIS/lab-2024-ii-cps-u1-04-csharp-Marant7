namespace Bank.WebApi.Models
{
    public class BankAccount
    {
       private readonly string m_customerName;
        private double m_balance;

        public BankAccount(string customerName, double balance)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or empty.", nameof(customerName));

            if (balance < 0)
                throw new ArgumentOutOfRangeException(nameof(balance), "Initial balance cannot be negative.");

            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName => m_customerName;
        public double Balance => m_balance;

        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException(nameof(amount), "Debit amount exceeds balance.");
            
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Debit amount cannot be negative.");
            
            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Credit amount cannot be negative.");
            
            m_balance += amount;
        }
    }
}