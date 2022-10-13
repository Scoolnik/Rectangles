namespace Rectangles
{
	public class RectangleWrapper
	{
		public Rectangle Rectangle { get; }
		public Color Color { get; }

		public RectangleWrapper(Rectangle rect, Color color)
		{
			Rectangle = rect;
			Color = color;
		}

		public RectangleWrapper[] GetIntersections(HashSet<RectangleWrapper> others)
		{
			return others.Where(x => x != this && x.Rectangle.IntersectsWith(Rectangle)).ToArray();
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Rectangle.GetHashCode(), Color.GetHashCode());
		}
	}
}
