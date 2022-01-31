using OpenTK.Graphics.OpenGL4;
using OpenTK.WinForms;

namespace MF400_Winforms.Renderer
{
    internal class Renderer
    {
        private GLControl glControl;
        private System.Windows.Forms.Timer renderTimer;
        public Renderer(GLControl glControl)
        {
            this.glControl = glControl;
            renderTimer = new System.Windows.Forms.Timer();
            renderTimer.Interval = (int)(1000.0f / 20);
            renderTimer.Tick += RenderTick;
        }

        public float Fps
        {
            get { return 1000.0f/renderTimer.Interval; }
            set { renderTimer.Interval = (int)(1000.0f/value); }
        }
        public bool Rendering
        {
            get { return renderTimer.Enabled; }
            set 
            { 
                if (value)
                    renderTimer.Start();
                else
                    renderTimer.Stop();
            }
        }

        public void Initialize()
        {
            glControl.MakeCurrent();
            GL.ClearColor(1.0f, 1.0f, 0.0f, 1.0f);
        }

        private void RenderTick(object? sender, EventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            glControl.SwapBuffers();
        }
    }
}
