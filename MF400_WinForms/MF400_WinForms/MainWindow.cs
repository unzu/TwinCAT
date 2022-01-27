using OpenTK.Graphics.OpenGL4;

namespace MF400_WinForms
{
    public partial class MainWindow : Form
    {
        private System.Windows.Forms.Timer timer_;

        public MainWindow()
        {
            InitializeComponent();

            timer_ = new System.Windows.Forms.Timer();
            timer_.Interval = 50;
            timer_.Tick += (s, e) =>
            {
                GlControlPaintEvt(null, null);
            };
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void GLControlLoad(object? sender, EventArgs? args)
        {
            glControl.Resize += GLControlResizeEvt;
            glControl.Paint += GlControlPaintEvt;

            timer_.Start();
        }

        private void GLControlResizeEvt(object? sender, EventArgs? args)
        {
            glControl.MakeCurrent();
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
        }

        private void GlControlPaintEvt(object? sender, EventArgs? args)
        {
            glControl.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit);
            glControl.SwapBuffers();
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            glControl.MakeCurrent();
            GL.ClearColor(rnd.NextSingle(), rnd.NextSingle(), rnd.NextSingle(), 1.0f);
        }
    }
}