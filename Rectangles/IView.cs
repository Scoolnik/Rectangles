namespace Rectangles
{
	public interface IView
	{
		void AddRectangle(RectangleWrapper rect);
		Size GetCanvasSize();
		void RemoveRectangle(RectangleWrapper rect);
	}
}