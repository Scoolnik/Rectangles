using Ninject;

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
			var container = ConfigureContainer();
			var rectsCreater = container.Get<RectanglesCreater>();
			container.Get<IUpdateModel>().Start();
			Application.Run(container.Get<MainForm>());
		}

		public static StandardKernel ConfigureContainer()
		{
			var container = new StandardKernel();
			container.Bind<Canvas, IView>().To<Canvas>().InSingletonScope();
			container.Bind<MainForm>().ToSelf().InSingletonScope();
			container.Bind<IUpdateModel>().To<UpdateModel>().InSingletonScope();
			container.Bind<ActionsScheduler>().ToSelf().InSingletonScope();
			container.Bind<IRectanglesModel>().To<RectanglesModel>().InSingletonScope();
			container.Bind<RectanglesCreater>().ToSelf().InSingletonScope();
			return container;
		}
	}
}