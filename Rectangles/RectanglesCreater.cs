namespace Rectangles
{
	public class RectanglesCreater
	{
		private readonly IView _view;
		private readonly IUpdateModel _updateModel;
		private readonly IRectanglesModel _rectanglesModel;

		public RectanglesCreater(IView view, IRectanglesModel rectanglesModel, IUpdateModel updateModel)
		{
			_view = view;
			_rectanglesModel = rectanglesModel;
			_updateModel = updateModel;
			_updateModel.LateUpdate += OnLateUpdate;
		}

		private void OnLateUpdate()
		{
			CreateRandomRect();
		}

		private void CreateRandomRect()
		{
			_rectanglesModel.AddRectangle(RectangleHelper.GetRandom(_view.GetSize()), ColorHelper.GetRandom());
		}
	}
}
