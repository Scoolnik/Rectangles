namespace Rectangles
{
	public class RectanglesModel : IRectanglesModel
	{
		public HashSet<RectangleWrapper> Rectangles => _rectangles;

		private readonly HashSet<RectangleWrapper> _rectangles = new();

		private readonly ActionsScheduler _actionsScheduler;

		private const int IntersectedRectLifetimeTicks = 1;

		public event Action Changed;

		public RectanglesModel(ActionsScheduler actionsScheduler)
		{
			_actionsScheduler = actionsScheduler;
		}

		public void AddRectangle(Rectangle rectangle, Color color)
		{
			var rectWrapper = new RectangleWrapper(rectangle, color);
			_rectangles.Add(rectWrapper);
			Changed?.Invoke();
			foreach (var intersection in rectWrapper.GetIntersections(_rectangles))
				ScheduleRectRemove(intersection, IntersectedRectLifetimeTicks);
		}

		private void ScheduleRectRemove(RectangleWrapper rect, int delayTicks)
		{
			_actionsScheduler.ScheduleOnUpdate(() => RemoveRectangle(rect), delayTicks);
		}

		private void RemoveRectangle(RectangleWrapper rect)
		{
			_rectangles.Remove(rect);
			Changed?.Invoke();
		}
	}
}
