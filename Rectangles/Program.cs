namespace Rectangles
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			var view = new MainForm();
			var updateModel = new UpdateModel();
			var actionsScheduler = new ActionsScheduler(updateModel);
			var rectsModel = new RectanglesModel(view);
			var rectsCreater = new RectanglesCreater(view, rectsModel, updateModel);
			updateModel.Start();
			Application.Run(view);
		}
	}
}