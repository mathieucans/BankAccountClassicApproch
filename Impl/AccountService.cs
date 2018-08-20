


using BankAcountAllTest;

namespace BankAcount
{
	public class AccountService
	{
		private readonly AccountServiceImpl _accountServiceImpl;
		private readonly IPrinter _printer;
		private readonly IDateProvider _dateProvider;

		public AccountService(AccountServiceImpl accountServiceImpl, IPrinter printer, IDateProvider dateProvider)
		{
			_accountServiceImpl = accountServiceImpl;
			_printer = printer;
			_dateProvider = dateProvider;
		}

		public void deposit(int p0)
		{
			_accountServiceImpl.deposit(_dateProvider.Now, p0);
		}

		public void withdraw(int i)
		{
			_accountServiceImpl.withdraw(_dateProvider.Now, i);
		}

		public void printStatement()
		{
			_printer.Write(_accountServiceImpl.printStatement());
		}
	}
}