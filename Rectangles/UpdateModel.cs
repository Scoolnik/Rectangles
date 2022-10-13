namespace Rectangles
{
	public class UpdateModel : IUpdateModel
	{
		public event Action<int> Update;
		public event Action<int> LateUpdate;

		public int TickNum => _tickNum;

		private int _tickNum = 0;
		private readonly System.Windows.Forms.Timer _timer;
		private const int UpdateIntervalMS = 1000;

		public UpdateModel()
		{
			_timer = new();
			_timer.Interval = UpdateIntervalMS;
			_timer.Tick += OnTimerTick;
		}

		public void Start() => _timer.Start();

		private void OnTimerTick(object? s, EventArgs e)
		{
			_tickNum++;
			Update?.Invoke(_tickNum);
			LateUpdate?.Invoke(_tickNum);
		}
	}
}
