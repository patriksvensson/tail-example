using System;
using System.Threading;

namespace Tail.Extensibility.Example
{
	public class TestStreamListener : TailStreamListener<TestStreamContext>
	{
		public override void Listen(TestStreamContext context, ITailCallback callback, WaitHandle abortSignal)
		{
			while (!abortSignal.WaitOne(context.Delay))
			{
				// Create the message.
				var message = string.Format("{0}: Hello World", DateTime.Now.ToString("HH:mm:ss.fff"));
				message = context.DoMagic ? string.Concat(message, " [MAGIC]") : message;
				message = string.Concat(message, Environment.NewLine);

				// Publish the message.
				callback.Publish(message);
			}
		}
	}
}