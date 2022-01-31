namespace MF400_Winforms
{
    public partial class Form1 : Form
    {
        private Renderer.Renderer renderer;
        private Renderer.Cylinder cylinder;
        public Form1()
        {
            InitializeComponent();
            renderer = new Renderer.Renderer(glControl);
            cylinder = new Renderer.Cylinder(1.0f, 1.0f, 1.0f);
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            renderer.Initialize();
        }

        private void glControl_Click(object sender, EventArgs e)
        {
            renderer.Rendering = !renderer.Rendering;
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            cylinder.R1 = hScrollBar1.Value;
        }
    }
}