using OpenTK;
using OpenTK.Graphics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Maverick.Rendering
{
	public class Window : GameWindow
	{
		public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
			: base(gameWindowSettings, nativeWindowSettings)
		{
			
		}

		protected override void OnUpdateFrame(FrameEventArgs args)
		{
			base.OnUpdateFrame(args);
		}
	}
}
