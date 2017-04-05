using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 参照設定 : OpenTK System.Darwing
 */
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input; // キーボード入力





namespace WindowsOpenTk
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static int Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            using (Game window = new Game())
            {
                window.Run(30.0);
            }

            return 0;
        } // Main()

        /// <summary>
        /// Game Class
        /// </summary>
        class Game : GameWindow
        {
            /// <summary>
            /// コンストラクタ
            /// baseで継承元(GameWindow)を呼び出している
            /// </summary>
            public Game() : base(800, 600, GraphicsMode.Default, "Game Windows") { }
            
            /// <summary>
            /// OnLoad
            /// </summary>
            /// <param name="e"></param>
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                GL.ClearColor(Color4.Black);
                GL.Enable(EnableCap.DepthTest);
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);

                GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
                GL.MatrixMode(MatrixMode.Projection);
                Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, (float)this.Width/ (float)this.Height, 1.0f, 64.0f);
                GL.LoadMatrix(ref projection);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                base.OnUpdateFrame(e);

                // Excape キーで終了
                if (Keyboard[Key.Escape])
                {
                    this.Exit();
                }
            }

            protected override void OnRenderFrame(FrameEventArgs e)
            {
                base.OnRenderFrame(e);

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                GL.MatrixMode(MatrixMode.Modelview);
                Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
                GL.LoadMatrix(ref modelview);

                GL.Begin(BeginMode.Quads); // ?

                GL.Color4(Color4.White);
                GL.Vertex3(-1.0f, 1.0f, 4.0f);
                
                GL.Color4(new float[] {1.0f, 0.0f, 0.0f, 1.0f }); // 色を配列で指定
                GL.Vertex3(-1.0f, -1.0f, 4.0f);

                GL.Color4(0.0f, 1.0f, 0.0f, 1.0f); // 引数で指定
                GL.Vertex3(1.0f, -1.0f, 4.0f);

                GL.Color4((byte)0, (byte)0, (byte)255, (byte)255); // byte型で指定
                GL.Vertex3(1.0f, 1.0f, 4.0f);

                GL.End();


                SwapBuffers();
            }
        }
    } // Program
}
