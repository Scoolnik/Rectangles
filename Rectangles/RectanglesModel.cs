namespace Rectangles
{
	internal class RectanglesModel
	{
		private readonly Dictionary<int, List<RectangleWrapper>> rectsToDelete = new();

		private readonly IView _view;

		private int _tickNum = 0;
		private System.Windows.Forms.Timer _timer;
		private const int UpdateIntervalMS = 1000;
		private const int IntersectedRectLifetimeTicks = 1;

		public RectanglesModel(IView view)
		{
			_view = view;
			InitTimer();
		}

		private void InitTimer()
		{
			_timer = new();
			_timer.Interval = UpdateIntervalMS;
			_timer.Tick += (s, e) => OnTick(++_tickNum);
			_timer.Start();
		}

		private void OnTick(int tickNum)
		{
			RemoveRectsIfNeeded();
			CreateRect();
			RemoveRectsIfNeeded();
		}

		private void CreateRect()
		{
			var rect = RectangleWrapper.GetRandomRect(_view);
			foreach (var intersection in rect.GetIntersections())
				ScheduleRectRemove(intersection, IntersectedRectLifetimeTicks);
			_view.AddRectangle(rect);
		}

		private void RemoveRectsIfNeeded()
		{
			if (!rectsToDelete.ContainsKey(_tickNum))
				return;
			foreach (var rect in rectsToDelete[_tickNum])
				rect.Remove();
			rectsToDelete.Remove(_tickNum);
		}

		private void ScheduleRectRemove(RectangleWrapper rect, int delayTicks)
		{
			var stepIndex = _tickNum + delayTicks;
			if (!rectsToDelete.ContainsKey(stepIndex))
				rectsToDelete.Add(stepIndex, new List<RectangleWrapper>());
			rectsToDelete[stepIndex].Add(rect);
		}
	}
}
