using Maverick.Core.Graphics;

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Maverick.Core
{
	public abstract class Game
	{
		readonly Window window;
		public Game(string title)
		{
			var nativeWindowSettings = new NativeWindowSettings()
			{
				Size = new Vector2i(
					 Monitors.GetPrimaryMonitor().HorizontalResolution,
					 Monitors.GetPrimaryMonitor().VerticalResolution),
				Title = title ?? this.GetType().Name,
				Flags = ContextFlags.ForwardCompatible,
				WindowState = WindowState.Fullscreen
			};
			
			window = new Window(GameWindowSettings.Default, nativeWindowSettings);
		}
		public void Run()
		{
			Initialize();
			
			using (window)
			{
				Update();
				window.Run();
			}
		}

		protected abstract void Initialize();
		protected abstract void Update();
	}
}
