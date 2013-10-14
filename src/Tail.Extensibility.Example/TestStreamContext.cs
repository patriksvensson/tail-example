using System;
namespace Tail.Extensibility.Example
{
	public class TestStreamContext : ITailStreamContext
	{
		private readonly TimeSpan _delay;
		private readonly bool _doMagic;

		public TimeSpan Delay
		{
			get { return _delay; }
		}

		public bool DoMagic
		{
			get { return _doMagic; }
		}

		public TestStreamContext(TimeSpan delay, bool doMagic)
		{
			_delay = delay;
			_doMagic = doMagic;
		}

		public string GetDescription()
		{
			return "Testing";
		}
	}
}