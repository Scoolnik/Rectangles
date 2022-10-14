namespace Rectangles
{
	public interface IView
	{
		void AddRectangle(RectangleWrapper rect);
		Size GetSize();
		void RemoveRectangle(RectangleWrapper rect);
	}
}