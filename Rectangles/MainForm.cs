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
			using Graphics g = Graphics.FromImage(canvas.Image);
			using Brush brush = new SolidBrush(ColorHelper.BackgroundColor);
			g.FillRectangle(brush, 0, 0, canvas.Image.Width, canvas.Image.Height);
		}

		private void DrawRectangle(Rectangle rect, Color color)
		{
			using Graphics g = Graphics.FromImage(canvas.Image);
			using Pen pen = new(color);
			g.DrawRectangle(pen, rect);
			canvas.Invalidate();
		}
	}
}