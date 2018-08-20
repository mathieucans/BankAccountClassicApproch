using System;
using System.Collections.Generic;
using System.Linq;
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
			var accountService = new AccountService(new AccountServiceImpl(), testPrinter);
			
			accountService.deposit(1000);
			accountService.withdraw(100);
			accountService.deposit(500);
			accountService.printStatement();
			string print = testPrinter.Print;
			Assert.AreEqual(
				"Date      | AMOUNT  | BALANCE" +"\r\n" +
			    "10/04/2014| 500.00  | 1400.00"+ "\r\n" +
				"02/04/2014| -100.00 | 900.00" + "\r\n" +
				"01/04/2014| 1000.00 | 1000.00", 
				print);
		}
	}

	public interface ITestPrinter
	{
		void Write(string printStatement);
	}

	public class TestPrinter : ITestPrinter
	{
		public TestPrinter()
		{
			Print = "";
		}
		public string Print { get; private set; }

		public void Write(string printStatement)
		{
			Print += printStatement;
		}
	}

	[TestClass]
	public class AccountServiceShould
	{
		[TestMethod]
		public void print_deposeit_operation()
		{
			var accountService = new AccountServiceImpl();
			accountService.deposit(1000);
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
			accountService.deposit(1000);
			accountService.deposit(111);
			var print = accountService.printStatement();
			Assert.AreEqual(
				"Date      | AMOUNT  | BALANCE" + "\r\n" +
				"01/04/2014| 111.00 | 1111.00"+ "\r\n" +
				"01/04/2014| 1000.00 | 1000.00",
				print);
		}

		[TestMethod]
		public void print_withdraw_operation()
		{
			var accountService = new AccountServiceImpl();
			accountService.withdraw(100);
			var print = accountService.printStatement();
			Assert.AreEqual(
				"Date      | AMOUNT  | BALANCE" + "\r\n" +
				"01/04/2014| -100.00 | -100.00",
				print);
		}
	}

	public class AccountServiceImpl
	{
		private int account;
		private List<int> historyAccountOperation;

		public AccountServiceImpl()
		{
			this.account = 0;
			this.historyAccountOperation = new List<int>();
		}

		public void deposit(int i)
		{
			account += i;
			historyAccountOperation.Add(i);
		}

		public string printStatement()
		{
			
			int cumulator = 0;
			return "Date      | AMOUNT  | BALANCE" + "\r\n"
			 + String.Join( "\r\n", 
				historyAccountOperation.Select(a =>
				{
					cumulator += a;
					return string.Format("01/04/2014| {0}.00 | {1}.00", a, cumulator);				
				}).Reverse());
		}

		public void withdraw(int i)
		{
			account -= i;
			historyAccountOperation.Add(-i);
		}
	}

	public class AccountService
	{
		private readonly AccountServiceImpl _accountServiceImpl;
		private readonly ITestPrinter _printer;

		public AccountService(AccountServiceImpl accountServiceImpl, ITestPrinter printer)
		{
			_accountServiceImpl = accountServiceImpl;
			_printer = printer;
		}

		public void deposit(int p0)
		{
			_accountServiceImpl.deposit(p0);
		}

		public void withdraw(int i)
		{
			_accountServiceImpl.withdraw(i);
		}

		public void printStatement()
		{
			_printer.Write(_accountServiceImpl.printStatement());
		}
	}
}
