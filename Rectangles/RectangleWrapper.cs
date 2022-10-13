namespace Rectangles
{
	public class RectangleWrapper
	{
		public Rectangle Rectangle { get; }
		public Color Color { get; }

		private static List<RectangleWrapper> _wrappers = new List<RectangleWrapper>();

		public RectangleWrapper(IView _view)
		{
			Rectangle = RectangleHelper.GetRandom(_view.GetCanvasSize());
			Color = ColorHelper.GetRandom();
			_wrappers.Add(this);
		}

		public RectangleWrapper[] GetIntersections()
		{
			return _wrappers.Where(x => x != this && x.Rectangle.IntersectsWith(Rectangle)).ToArray();
		}

		internal void Remove() => _wrappers.Remove(this);
	}
}
