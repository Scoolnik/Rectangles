namespace Rectangles
{
	internal class ColorHelper
	{
		public static Color BackgroundColor = Color.White;

		private static readonly Random rand = new Random();
		private const int MaxColorIndex = 255;
		
		internal static Color GetRandom()
		{
			return Color.FromArgb(rand.Next(MaxColorIndex), rand.Next(MaxColorIndex), rand.Next(MaxColorIndex));
		}
	}
}