using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Tail.Extensibility.Example.ViewModels
{
	public class TestSettingsViewModel : Screen, ITailSettings
	{
		private bool _doMagic;
		private bool _isDirty;

		public bool IsDirty
		{
			get
			{
				return _isDirty;
			}
		}

		public bool DoMagic
		{
			get { return _doMagic; }
			set
			{
				_doMagic = value;
				_isDirty = true;
				this.NotifyOfPropertyChange(() => IsDirty);
				this.NotifyOfPropertyChange(() => DoMagic);
			}
		}

		public void Load(ITailSettingService service)
		{
			_doMagic = service.Get("Example.DoMagic", false);
		}

		public void Save(ITailSettingService service)
		{
			service.Set("Example.DoMagic", _doMagic);
		}

		public bool Validate(out string error)
		{
			error = string.Empty;
			return true;
		}
	}
}
