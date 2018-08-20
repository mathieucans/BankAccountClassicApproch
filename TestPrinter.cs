using BankAcount;

namespace BankAcountAllTest
{
	public class TestPrinter : IPrinter
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
}