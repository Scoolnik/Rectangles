namespace Rectangles
{
	public class Canvas : PictureBox, IView
	{
		private Graphics graphics;

		public void RecreateImage()
		{
			Image = new Bitmap(Width, Height);
			graphics = Graphics.FromImage(Image);
			using Brush brush = new SolidBrush(ColorHelper.BackgroundColor);
			graphics.FillRectangle(brush, 0, 0, Image.Width, Image.Height);
		}

		public Size GetSize() => Image.Size;

		public void AddRectangle(RectangleWrapper rect)
		{
			DrawRectangle(rect.Rectangle, rect.Color);
		}

		public void RemoveRectangle(RectangleWrapper rect)
		{
			DrawRectangle(rect.Rectangle, ColorHelper.BackgroundColor);
		}

		private void DrawRectangle(Rectangle rect, Color color)
		{
			using Pen pen = new(color);
			graphics.DrawRectangle(pen, rect);
			Invalidate();
		}
	}
}
