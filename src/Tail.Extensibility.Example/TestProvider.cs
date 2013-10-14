using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tail.Extensibility.Example.ViewModels;

namespace Tail.Extensibility.Example
{
	public class TestProvider : TailProviderWithConfigurationAndSettings<TestStreamListener, TestStreamContext, TestConfigurationViewModel, TestSettingsViewModel>
	{
		private readonly ITailSettingService _settings;

		public TestProvider(ITailSettingService settings)
		{
			_settings = settings;
		}

		public override string GetDisplayName()
		{
			return "Test Provider";
		}

		public override ITailStreamContext CreateContext(TestConfigurationViewModel configuration)
		{
			var delay = TimeSpan.FromMilliseconds(configuration.Delay);
			var doMagic = _settings.Get("Example.DoMagic", false);
			return new TestStreamContext(delay, doMagic);
		}
	}
}
