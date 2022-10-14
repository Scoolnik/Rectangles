namespace Rectangles
{
	public class ActionsScheduler
	{
		private readonly Dictionary<int, List<Action>> _scheduledActions = new();
		private readonly IUpdateModel _updateModel;

		public ActionsScheduler(IUpdateModel updateModel)
		{
			_updateModel = updateModel;
			_updateModel.Update += OnUpdate;
		}

		public void ScheduleOnUpdate(Action task, int delayTicks)
		{
			if (delayTicks == 0)
			{
				task?.Invoke();
				return;
			}
			var tickNum = _updateModel.TickNum + delayTicks;
			if (!_scheduledActions.ContainsKey(tickNum))
				_scheduledActions.Add(tickNum, new List<Action>());
			_scheduledActions[tickNum].Add(task);
		}

		private void OnUpdate()
		{
			var tick = _updateModel.TickNum;
			if (!_scheduledActions.ContainsKey(tick))
				return;
			foreach (var rect in _scheduledActions[tick])
				rect?.Invoke();
			_scheduledActions.Remove(tick);
		}
	}
}
