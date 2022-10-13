namespace Rectangles
{
	public interface IUpdateModel
	{
		int TickNum { get; }

		event Action<int> Update;
		event Action<int> LateUpdate;

		void Start();
	}
}