using System;
using BankAcount;

namespace BankAcountAllTest
{
	public class TestDateProvider : IDateProvider
	{
		public DateTime Now { get; private set; }

		public void Configure(string s)
		{
			Now = DateTime.Parse(s);
		}
	}
}