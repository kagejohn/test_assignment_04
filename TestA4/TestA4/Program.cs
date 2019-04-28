using System;

namespace TestA4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region creditCardTest

            Customer customer = new Customer(false, false);

            CreditCard creditCard1 = new CreditCard
            {
                NewCustomer = true
            };//15%
            customer.CreditCards.Add(creditCard1);

            CreditCard creditCard2 = new CreditCard
            {
                NewCustomer = true,
                Coupon = true
            };//20%
            customer.CreditCards.Add(creditCard2);

            CreditCard creditCard3 = new CreditCard();//0%
            customer.CreditCards.Add(creditCard3);

            CreditCard creditCard4 = new CreditCard
            {
                Coupon = true
            };//20%
            customer.CreditCards.Add(creditCard4);

            CreditCard creditCard5 = new CreditCard
            {
                Coupon = true,
                LoyaltyCard = true
            };//30%
            customer.CreditCards.Add(creditCard5);

            CreditCard creditCard6 = new CreditCard
            {
                LoyaltyCard = true
            };//10%
            customer.CreditCards.Add(creditCard6);

            CreditCard creditCard7 = new CreditCard
            {
                NewCustomer = true,
                Coupon = true,
                LoyaltyCard = true
            };//20%
            customer.CreditCards.Add(creditCard7);

            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(creditCard1));
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(creditCard2));
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(creditCard3));
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(creditCard4));
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(creditCard5));
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(creditCard6));
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(creditCard7));

            #endregion

            Atm atm = new Atm();
            atm.InsertCreditCard(customer.CreditCards[0]);
            var test = atm.DepositAmount(1);
            var test1_1 = atm.ShowMonthlyInterestRate();
            var test1_2 = atm.ShowYearlyInterestRate();
            var test2 = atm.DepositAmount(100);
            var test2_1 = atm.ShowMonthlyInterestRate();
            var test2_2 = atm.ShowYearlyInterestRate();
            //var test3 = atm.PurchaseWithDiscount(2);
            var test4 = atm.DepositAmount(1000);
            var test4_1 = atm.ShowMonthlyInterestRate();
            var test4_2 = atm.ShowYearlyInterestRate();
        }
    }
}
