using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestA4
{
    class Atm
    {
        private CreditCard _creditCard;

        public void InsertCreditCard(CreditCard creditCard)
        {
            _creditCard = creditCard;
        }

        public void ExtractCreditCard()
        {
            _creditCard = null;
        }

        public decimal DepositAmount(decimal amount, CreditCard creditCard = null)
        {
            if (creditCard != null)
            {
                _creditCard = creditCard;
            }

            else if (_creditCard == null)
            {
                throw new NullReferenceException("No credit card in the ATM.");
            }

            _creditCard.Account.Balance += amount;

            return _creditCard.Account.Balance;
        }

        public decimal WithdrawAmount(decimal amount, CreditCard creditCard = null)
        {
            if (creditCard != null)
            {
                _creditCard = creditCard;
            }

            else if (_creditCard == null)
            {
                throw new NullReferenceException("No credit card in the ATM.");
            }

            _creditCard.Account.Balance -= amount;

            return _creditCard.Account.Balance;
        }

        public decimal PurchaseWithDiscount(decimal amount, CreditCard creditCard = null)
        {
            if (creditCard != null)
            {
                _creditCard = creditCard;
            }

            else if (_creditCard == null)
            {
                throw new NullReferenceException("No credit card in the ATM.");
            }

            decimal amountWithDiscount = amount * (100 - _creditCard.Discount) / 100;

            if (_creditCard.Account.Balance >= amountWithDiscount)
            {
                _creditCard.Account.Balance -= amountWithDiscount;
            }
            else
            {
                throw new ConstraintException("Not enough funds, current balance: " + _creditCard.Account.Balance);
            }

            return _creditCard.Account.Balance;
        }

        public decimal ShowBalance(CreditCard creditCard = null)
        {
            if (creditCard != null)
            {
                _creditCard = creditCard;
            }

            else if (_creditCard == null)
            {
                throw new NullReferenceException("No credit card in the ATM.");
            }

            return _creditCard.Account.Balance;
        }

        public int ShowMonthlyInterestRate(CreditCard creditCard = null)
        {
            if (creditCard != null)
            {
                _creditCard = creditCard;
            }

            else if (_creditCard == null)
            {
                throw new NullReferenceException("No credit card in the ATM.");
            }

            return _creditCard.Account.InterestRate;
        }

        public decimal ShowYearlyInterestRate(CreditCard creditCard = null)
        {
            if (creditCard != null)
            {
                _creditCard = creditCard;
            }

            else if (_creditCard == null)
            {
                throw new NullReferenceException("No credit card in the ATM.");
            }

            double monthlyInterestRateFromInt = _creditCard.Account.InterestRate;

            double monthlyInterestRate = 1 + monthlyInterestRateFromInt / 100;

            double yearlyInterestRate = Math.Pow(monthlyInterestRate, 12);

            return Math.Round(Convert.ToDecimal((yearlyInterestRate - 1) * 100), 2);
        }
    }
}
