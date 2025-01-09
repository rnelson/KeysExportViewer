using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace KeysExportViewer;

internal static class Program
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	[SuppressMessage("ReSharper", "CA2000")]
	[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
	private static void Main()
	{
		if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
		    Environment.OSVersion.Version.Major >= 6 &&
		    Environment.OSVersion.Version.Minor >= 0)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
		else
		{
			Console.Error.WriteLine("error: this application only supports Windows 10 or newer");
		}
	}
}