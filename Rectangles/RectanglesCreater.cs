namespace Rectangles
{
	public class RectanglesCreater
	{
		private readonly IView _view;
		private readonly IUpdateModel _updateModel;
		private readonly RectanglesModel _rectanglesModel;

		public RectanglesCreater(IView view, RectanglesModel rectanglesModel, IUpdateModel updateModel)
		{
			_view = view;
			_rectanglesModel = rectanglesModel;
			_updateModel = updateModel;
			_updateModel.LateUpdate += OnLateUpdate;
		}

		private void OnLateUpdate(int tickNum)
		{
			CreateRandomRect();
		}

		private void CreateRandomRect()
		{
			_rectanglesModel.AddRectangle(RectangleHelper.GetRandom(_view.GetCanvasSize()), ColorHelper.GetRandom());
		}
	}
}
