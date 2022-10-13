using System.Windows.Forms;

namespace Rectangles
{
	public class RectangleWrapper
	{
		public Rectangle Rectangle { get; }
		public Color Color { get; }

		private IView _view;

		private static HashSet<RectangleWrapper> _wrappers = new();

		public RectangleWrapper(IView view, Rectangle rect, Color color)
		{
			_view = view;
			Rectangle = rect;
			Color = color;
			_view.AddRectangle(this);
			_wrappers.Add(this);
		}

		public static RectangleWrapper GetRandomRect(IView view)
		{
			var rect = RectangleHelper.GetRandom(view.GetCanvasSize());
			var color = ColorHelper.GetRandom();
			return new RectangleWrapper(view, rect, color);
		}

		public RectangleWrapper[] GetIntersections()
		{
			return _wrappers.Where(x => x != this && x.Rectangle.IntersectsWith(Rectangle)).ToArray();
		}

		public void Remove()
		{
			_view.RemoveRectangle(this);
			_wrappers.Remove(this);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Rectangle.GetHashCode(), Color.GetHashCode());
		}
	}
}
