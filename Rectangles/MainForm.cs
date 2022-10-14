namespace Rectangles
{
	public partial class MainForm : Form
	{
		public MainForm(Canvas canvas)
		{
			InitializeComponent();
			Text = "";
			InitCanvas(canvas);
		}

		private void InitCanvas(Canvas canvas)
		{
			Controls.Add(canvas);
			canvas.Dock = DockStyle.Fill;
			canvas.RecreateImage();
		}
	}
}