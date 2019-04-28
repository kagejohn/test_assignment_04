using System;
using System.Collections.Generic;
using System.Text;

namespace TestA4
{
    class Customer
    {
        private readonly bool _newCustomer;
        public bool LoyaltyCard { get; set; }
        public bool Coupon { get; set; }
        public List<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

        public Customer(bool loyaltyCard, bool coupon)
        {
            _newCustomer = true;
            LoyaltyCard = loyaltyCard;
            Coupon = coupon;
            NewCreditCard(loyaltyCard, coupon);
        }

        public void NewCreditCard(bool loyaltyCard, bool coupon)
        {
            CreditCards.Add(new CreditCard { Coupon = coupon, LoyaltyCard = loyaltyCard, NewCustomer = _newCustomer });
        }
    }
}
