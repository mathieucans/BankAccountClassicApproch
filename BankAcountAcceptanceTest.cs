using BankAcount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAcountAllTest
{
	[TestClass]
	public class BankAcountAcceptanceTest
	{
		[TestMethod]
		public void TestAccountOperation()
		{
			var testPrinter = new TestPrinter();
			var testDateProvider = new TestDateProvider();
			var accountService = new AccountService(new AccountServiceImpl(), testPrinter, testDateProvider);

			testDateProvider.Configure("01/04/2014");
			accountService.deposit(1000);
			testDateProvider.Configure("02/04/2014");
			accountService.withdraw(100);
			testDateProvider.Configure("10/04/2014");
			accountService.deposit(500);
			accountService.printStatement();
			string print = testPrinter.Print;
			var expected = "Date      | AMOUNT  | BALANCE" +"\r\n" +				
			               "10/04/2014| 500.00 | 1400.00"+ "\r\n" +
			               "02/04/2014| -100.00 | 900.00" + "\r\n" +
			               "01/04/2014| 1000.00 | 1000.00";
			Assert.AreEqual(
				expected, 
				print);
		}
	}
}