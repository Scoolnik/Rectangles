using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles
{
	public class RectangleWrapper
	{
		public Rectangle Rectangle { get; }
		public Color Color { get; }
		//public RectangleWrapper[] Intersections
		//{
		//	get
		//	{
		//		_intersections ??= GetIntersections();
		//		return _intersections;
		//	}
		//}

		//private RectangleWrapper[] _intersections;
		private static List<RectangleWrapper> wrappers = new List<RectangleWrapper>();

		public RectangleWrapper(IView _view)
		{
			Rectangle = RectangleHelper.GetRandom(_view.GetCanvasSize());
			Color = ColorHelper.GetRandom();
			wrappers.Add(this);
		}

		public RectangleWrapper[] GetIntersections()
		{
			return wrappers.Where(x => x != this && x.Rectangle.IntersectsWith(Rectangle)).ToArray();
		}

		internal void Remove()
		{
			wrappers.Remove(this);
		}
	}
}
