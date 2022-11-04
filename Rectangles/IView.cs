namespace Rectangles
{
	public interface IView
	{
		void Update(IEnumerable<RectangleWrapper> rects);
		Size GetSize();
	}
}