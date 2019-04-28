using System;
using System.Collections.Generic;
using System.Text;

namespace TestA4
{
    public class Account
    {
        private int _interestRate;
        public decimal Balance { get; set; }
        public int InterestRate => SetInterestRate();

        private int SetInterestRate()
        {
            if (Balance >= 0 && Balance <= 100)
            {
                _interestRate = 3;
            }
            else if (Balance > 100 && Balance <= 1000)
            {
                _interestRate = 5;
            }
            else if (Balance > 1000 && Balance < decimal.MaxValue)
            {
                _interestRate = 7;
            }
            else
            {
                _interestRate = 0;
            }

            return _interestRate;
        }
    }
}
