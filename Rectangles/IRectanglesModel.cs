namespace Rectangles
{
	public interface IRectanglesModel
	{
		HashSet<RectangleWrapper> Rectangles { get; }

		void AddRectangle(Rectangle rectangle, Color color);
	}
}