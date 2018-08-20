using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAcountAllTest
{
	[TestClass]
	public class BankAcountAcceptanceTest
	{
		[TestMethod]
		public void TestAccountOperation()
		{
			var accountService = new AccountService();
			accountService.deposit(1000);
			accountService.withdraw(100);
			accountService.deposit(500);
			accountService.printStatement();
			string print = "";
			Assert.AreEqual(
				"Date      | AMOUNT  | BALANCE" + "r\n" +
			    "10/04/2014| 500.00  | 1400.00"+ "r\n" +
				"02/04/2014| -100.00 | 900.00" + "r\n" +
				"01/04/2014| 1000.00 | 1000.00", 
				print);
		}
	}

	public class AccountService
	{
		public void deposit(int p0)
		{
			throw new NotImplementedException();
		}

		public void withdraw(int i)
		{
			throw new NotImplementedException();
		}

		public void printStatement()
		{
			throw new NotImplementedException();
		}
	}
}
