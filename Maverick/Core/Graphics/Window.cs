using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL4;

namespace Maverick.Core.Graphics
{
	public class Window : GameWindow
	{
		private readonly float[] _vertices =
		{
			-0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };

		private int _vertexBufferObject;
		private int _vertexArrayObject;

		private Shader? _shader;

		public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
			: base(gameWindowSettings, nativeWindowSettings)
		{

		}

		protected override void OnLoad()
		{
			base.OnLoad();

			GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

			_vertexBufferObject = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
			GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

			_vertexArrayObject = GL.GenVertexArray();
			GL.BindVertexArray(_vertexArrayObject);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
			GL.EnableVertexAttribArray(0);

			_shader = new Shader(
			   @"C:\Users\joshu\source\repos\MaverickSolution\Maverick\Core\Graphics\TempShaders\shader.vert",
			   @"C:\Users\joshu\source\repos\MaverickSolution\Maverick\Core\Graphics\TempShaders\shader.frag");

			_shader.Use();
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			base.OnRenderFrame(e);

			GL.Clear(ClearBufferMask.ColorBufferBit);

			_shader!.Use();

			GL.BindVertexArray(_vertexArrayObject);
			
			GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

			SwapBuffers();
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			base.OnUpdateFrame(e);

			if (KeyboardState.IsKeyDown(Keys.Escape))
				Close();
		}
	}
}
