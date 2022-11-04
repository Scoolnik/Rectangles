namespace Rectangles
{
	public class RectanglesPresenter
	{
		public RectanglesPresenter(IUpdateModel updateModel, IRectanglesModel model, IView view)
		{
			updateModel.LateUpdate += () => view.Update(model.Rectangles);
		}
	}
}
