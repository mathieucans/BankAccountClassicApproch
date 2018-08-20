using System;
using System.Collections.Generic;
using System.Linq;
using BankAcountAllTest;

namespace BankAcount
{
	public class AccountServiceImpl
	{
		private List<Operation> historyAccountOperation;

		public AccountServiceImpl()
		{
			this.historyAccountOperation = new List<Operation>();
		}

		public void deposit(DateTime parse, int i)
		{
			historyAccountOperation.Add(new Operation(parse,i));
		}

		public string printStatement()
		{
			
			int cumulator = 0;
			return "Date      | AMOUNT  | BALANCE" + "\r\n"
			       + String.Join( "\r\n", 
				       historyAccountOperation.Select(a =>
				       {
					       cumulator += a.Amount;
					       return string.Format("{2:d}| {0}.00 | {1}.00", a.Amount, cumulator, a.DateTime);				
				       }).Reverse());
		}

		public void withdraw(DateTime now, int i)
		{
			historyAccountOperation.Add(new Operation(now, -i));
		}
	}
}