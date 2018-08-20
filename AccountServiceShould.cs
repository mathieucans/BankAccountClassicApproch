using System;
using BankAcount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAcountAllTest
{
	[TestClass]
	public class AccountServiceShould
	{
		[TestMethod]
		public void print_deposeit_operation()
		{
			var accountService = new AccountServiceImpl();
			accountService.deposit(DateTime.Parse("01/04/2014 05:30"), 1000);
			var print = accountService.printStatement();
			Assert.AreEqual(
				"Date      | AMOUNT  | BALANCE" + "\r\n" +
				"01/04/2014| 1000.00 | 1000.00",
				print);
		}

		[TestMethod]
		public void print_deposeit_history_operation()
		{
			var accountService = new AccountServiceImpl();
			accountService.deposit(DateTime.Parse("01/04/2014 05:30"), 1000);
			accountService.deposit(DateTime.Parse("02/04/2014 22:30"), 111);
			var print = accountService.printStatement();
			Assert.AreEqual(
				"Date      | AMOUNT  | BALANCE" + "\r\n" +
				"02/04/2014| 111.00 | 1111.00"+ "\r\n" +
				"01/04/2014| 1000.00 | 1000.00",
				print);
		}

		[TestMethod]
		public void print_withdraw_operation()
		{
			var accountService = new AccountServiceImpl();
			accountService.withdraw(DateTime.Parse("01/04/2014 05:30"), 100);
			var print = accountService.printStatement();
			Assert.AreEqual(
				"Date      | AMOUNT  | BALANCE" + "\r\n" +
				"01/04/2014| -100.00 | -100.00",
				print);
		}
	}
}