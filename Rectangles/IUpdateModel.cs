namespace Rectangles
{
	public interface IUpdateModel
	{
		int TickNum { get; }

		event Action Update;

		event Action LateUpdate;

		void Start();
	}
}