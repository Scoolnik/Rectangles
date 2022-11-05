namespace Rectangles
{
	public interface IRectanglesModel
	{
		HashSet<RectangleWrapper> Rectangles { get; }

		event Action Changed;

		void AddRectangle(Rectangle rectangle, Color color);
	}
}