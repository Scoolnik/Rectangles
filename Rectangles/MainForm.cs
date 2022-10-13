namespace Rectangles
{
	public partial class MainForm : Form, IView
	{
		public MainForm()
		{
			InitializeComponent();
			Text = "";
			InitCanvas();
		}

		public Size GetCanvasSize() => canvas.Image.Size;

		public void AddRectangle(RectangleWrapper rect)
		{
			DrawRectangle(rect.Rectangle, rect.Color);
		}

		public void RemoveRectangle(RectangleWrapper rect)
		{
			DrawRectangle(rect.Rectangle, ColorHelper.BackgroundColor);
		}

		private void InitCanvas()
		{
			canvas.Image = new Bitmap(canvas.Width, canvas.Height);
			Graphics g = Graphics.FromImage(canvas.Image);
			g.FillRectangle(new SolidBrush(ColorHelper.BackgroundColor), 0, 0, canvas.Image.Width, canvas.Image.Height);
		}

		private void DrawRectangle(Rectangle rect, Color color)
		{
			using Graphics g = Graphics.FromImage(canvas.Image);
			g.DrawRectangle(new Pen(color), rect);
			canvas.Invalidate();
		}
	}
}