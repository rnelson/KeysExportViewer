using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace KeysExportViewer
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		[SuppressMessage("ReSharper", "CA2000")]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
	}
}
