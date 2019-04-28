using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestA4;
using Xunit;
using Xunit.Sdk;
using Assert = NHamcrest.XUnit.Assert;
// ReSharper disable AccessToStaticMemberViaDerivedType

namespace XUnitTestA4
{
    public class UnitTest1
    {
        

        [Theory]
        [InlineData(true, false, false, 15)]
        [InlineData(true, true, false, 20)]
        [InlineData(false, false, false, 0)]
        [InlineData(false, true, false, 20)]
        [InlineData(false, true, true, 30)]
        [InlineData(false, false, true, 10)]
        [InlineData(true, true, true, 20)]
        public void TestCreditCardDiscount(bool newCustomer, bool coupon, bool loyaltyCard, int discount)
        {
            CreditCard creditCard = new CreditCard
            {
                NewCustomer = newCustomer,
                Coupon = coupon,
                LoyaltyCard = loyaltyCard
            };

            Assert.Equal(discount, creditCard.Discount);
        }

        [Theory]
        [InlineData(-0.01, 0)]
        [InlineData(0.00, 3)]
        [InlineData(0.01, 3)]
        [InlineData(50, 3)]
        [InlineData(99.99, 3)]
        [InlineData(100, 3)]
        [InlineData(100.01, 5)]
        [InlineData(500, 5)]
        [InlineData(999.99, 5)]
        [InlineData(1000, 5)]
        [InlineData(1000.01, 7)]
        [InlineData(int.MaxValue, 7)]
        [InlineData(long.MaxValue, 7)]
        public void TestAccountInterestRate(decimal balance, int interestRate)
        {
            Account account = new Account
            {
                Balance = balance
            };

            Assert.Equal(interestRate, account.InterestRate);
        }

        [Theory]
        [Repeat(10)]
        public void TestRepeatedx10()
        {
            CreditCard creditCard = new CreditCard
            {
                NewCustomer = true,
                Coupon = false,
                LoyaltyCard = false
            };

            Assert.Equal(15, creditCard.Discount);
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void TestClassData(bool newCustomer, bool coupon, bool loyaltyCard, int discount)
        {
            CreditCard creditCard = new CreditCard
            {
                NewCustomer = newCustomer,
                Coupon = coupon,
                LoyaltyCard = loyaltyCard
            };

            Assert.Equal(discount, creditCard.Discount);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestMemberData(bool newCustomer, bool coupon, bool loyaltyCard, int discount)
        {
            CreditCard creditCard = new CreditCard
            {
                NewCustomer = newCustomer,
                Coupon = coupon,
                LoyaltyCard = loyaltyCard
            };

            Assert.Equal(discount, creditCard.Discount);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { true, false, false, 15 },
                new object[] { true, true, false, 20 },
                new object[] { false, false, false, 0 },
                new object[] { false, true, false, 20 },
                new object[] { false, true, true, 30 },
                new object[] { false, false, true, 10 },
                new object[] { true, true, true, 20 }
            };

        //@CSVSource and @CSVFileSource is not a thing.
    }

    public class RepeatAttribute : DataAttribute
    {
        private readonly int _count;

        public RepeatAttribute(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count),
                    "Repeat count must be greater than 0.");
            }
            _count = count;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return Enumerable.Repeat(new object[0], _count);
        }
    }

    public class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { true, false, false, 15 };
            yield return new object[] { true, true, false, 20 };
            yield return new object[] { false, false, false, 0 };
            yield return new object[] { false, true, false, 20 };
            yield return new object[] { false, true, true, 30 };
            yield return new object[] { false, false, true, 10 };
            yield return new object[] { true, true, true, 20 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
