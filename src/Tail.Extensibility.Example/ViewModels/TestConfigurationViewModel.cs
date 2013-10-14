using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Tail.Extensibility.Example.ViewModels
{
	public class TestConfigurationViewModel : Screen, ITailConfiguration, IDataErrorInfo
	{
		private int _delay;

		public int Delay
		{
			get { return _delay; }
			set
			{
				_delay = value;
				this.NotifyOfPropertyChange(() => this.Delay);
			}
		}

		public TestConfigurationViewModel()
		{
			_delay = 1000;
		}

		public bool Validate()
		{
			return this["Delay"] == null;
		}

		public string Error
		{
			get { return null; }
		}

		public string this[string columnName]
		{
			get
			{
				if (columnName == "Delay")
				{
					if (this.Delay < 100)
					{
						return "Delay must be greater than 100 ms.";
					}
				}
				return null;
			}
		}
	}
}
