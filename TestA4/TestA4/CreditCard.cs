using System;
using System.Collections.Generic;
using System.Text;

namespace TestA4
{
    public class CreditCard
    {
        private int _discount;

        public int Discount => SetDiscount();

        public bool NewCustomer { get; set; }
        public bool LoyaltyCard { get; set; }
        public bool Coupon { get; set; }

        private int SetDiscount()
        {
            if (NewCustomer && !Coupon)
            {
                _discount = 15;
            }
            else if (NewCustomer && Coupon)
            {
                _discount = 20;
            }
            else if (LoyaltyCard && !Coupon)
            {
                _discount = 10;
            }
            else if (Coupon && !LoyaltyCard)
            {
                _discount = 20;
            }
            else if (LoyaltyCard && Coupon)
            {
                _discount = 30;
            }
            else
            {
                _discount = 0;
            }

            return _discount;
        }

        public Account Account { get; set; } = new Account();
    }
}
