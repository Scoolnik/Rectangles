using Ninject;
using System.Runtime.Serialization;

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
			var view = container.Get<MainForm>();
			var rectsCreater = container.Get<RectanglesCreater>();
			container.Get<IUpdateModel>().Start();
			Application.Run(view);
		}

		public static StandardKernel ConfigureContainer()
		{
			var container = new StandardKernel();
			container.Bind<MainForm, IView>().To<MainForm>().InSingletonScope();
			container.Bind<IUpdateModel>().To<UpdateModel>().InSingletonScope();
			container.Bind<ActionsScheduler>().ToSelf().InSingletonScope();
			container.Bind<IRectanglesModel>().To<RectanglesModel>().InSingletonScope();
			container.Bind<RectanglesCreater>().ToSelf().InSingletonScope();
			return container;
		}
	}
}