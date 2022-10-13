namespace Rectangles
{
	public class ActionsScheduler
	{
		private static ActionsScheduler _instance;
		private readonly Dictionary<int, List<Action>> _scheduledActions = new();
		private readonly IUpdateModel _updateModel;

		public ActionsScheduler(IUpdateModel updateModel)
		{
			_updateModel = updateModel;
			_updateModel.Update += OnUpdate;
			_instance = this;
		}

		public static void ScheduleOnUpdate(Action task, int delayTicks)
		{
			if (delayTicks == 0)
			{
				task?.Invoke();
				return;
			}
			var tickNum = _instance._updateModel.TickNum + delayTicks;
			if (!_instance._scheduledActions.ContainsKey(tickNum))
				_instance._scheduledActions.Add(tickNum, new List<Action>());
			_instance._scheduledActions[tickNum].Add(task);
		}

		private void OnUpdate(int tick)
		{
			if (!_scheduledActions.ContainsKey(tick))
				return;
			foreach (var rect in _scheduledActions[tick])
				rect?.Invoke();
			_scheduledActions.Remove(tick);
		}
	}
}
