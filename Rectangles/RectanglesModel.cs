namespace Rectangles
{
	public class RectanglesModel : IRectanglesModel
	{
		private readonly HashSet<RectangleWrapper> _rectangles = new();

		private readonly ActionsScheduler _actionsScheduler;
		private readonly IView _view;

		private const int IntersectedRectLifetimeTicks = 1;

		public RectanglesModel(IView view, ActionsScheduler actionsScheduler)
		{
			_view = view;
			_actionsScheduler = actionsScheduler;
		}

		public void AddRectangle(Rectangle rectangle, Color color)
		{
			var rectWrapper = new RectangleWrapper(rectangle, color);
			_rectangles.Add(rectWrapper);
			_view.AddRectangle(rectWrapper);
			foreach (var intersection in rectWrapper.GetIntersections(_rectangles))
				ScheduleRectRemove(intersection, IntersectedRectLifetimeTicks);
		}

		private void ScheduleRectRemove(RectangleWrapper rect, int delayTicks)
		{
			_actionsScheduler.ScheduleOnUpdate(() => RemoveRectangle(rect), delayTicks);
		}

		private void RemoveRectangle(RectangleWrapper rect)
		{
			_view.RemoveRectangle(rect);
			_rectangles.Remove(rect);
		}
	}
}
