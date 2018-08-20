using System;

namespace BankAcount
{
	public class Operation
	{
		public DateTime DateTime { get; private set; }
		public int Amount { get; private set; }

		public Operation(DateTime dateTime, int amount)
		{
			DateTime = dateTime;
			Amount = amount;
		}
	}
}