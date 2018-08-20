using System;

namespace BankAcount
{
	public interface IDateProvider
	{
		DateTime Now	{ get;  }
	}
}
