namespace Rectangles
{
	internal class RectangleHelper
	{
		private static readonly Random rand = new();

		internal static Rectangle GetRandom(Size canvasSize)
		{
			var x = rand.Next(canvasSize.Width);
			var y = rand.Next(canvasSize.Height);
			return new Rectangle(x, y, rand.Next(canvasSize.Width - x), rand.Next(canvasSize.Height - y));
		}
	}
}