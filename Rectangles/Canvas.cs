namespace Rectangles
{
	public class Canvas : PictureBox, IView
	{
		private Graphics _graphics;

		public void RecreateImage()
		{
			Image = new Bitmap(Width, Height);
			_graphics = Graphics.FromImage(Image);
			Clear();
		}

		public Size GetSize() => Image.Size;

		public void Update(IEnumerable<RectangleWrapper> rects)
		{
			Clear();
			foreach (var rect in rects)
				DrawRectangle(rect.Rectangle, rect.Color);
		}

		private void DrawRectangle(Rectangle rect, Color color)
		{
			using Pen pen = new(color);
			_graphics.DrawRectangle(pen, rect);
			Invalidate();
		}

		private void Clear()
		{
			_graphics.Clear(ColorHelper.BackgroundColor);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_graphics?.Dispose();
			base.Dispose(disposing);
		}
	}
}
