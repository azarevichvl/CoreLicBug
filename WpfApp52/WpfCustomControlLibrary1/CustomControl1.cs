using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomControlLibrary1
{
	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary1"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary1;assembly=WpfCustomControlLibrary1"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:CustomControl1/>
	///
	/// </summary>
	[LicenseProvider(typeof(ChartLicenseProvider))]
	public class CustomControl1 : Control
	{
		static CustomControl1()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
		}

		public CustomControl1()
		{
			LicenseManager.Validate(typeof(CustomControl1));
		}
	}

	public class ChartLicenseProvider : LicenseProvider
	{
		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
		{
			if (context.UsageMode == LicenseUsageMode.Designtime) //Never called in .net 5, but works for .net framework
			{
				MessageBox.Show("Build time.", "title");
				context.SetSavedLicenseKey(type, "key");
				return new ChartLicense("test");
			}
			else
			{
				string key = context.GetSavedLicenseKey(type, null);
				if (key == "key") return new ChartLicense("test");
				throw new LicenseException(type, instance, "Custom license exception");
			}
		}
	}


	class ChartLicense : System.ComponentModel.License
	{
		public ChartLicense() { }

		public ChartLicense(string licenseKey)
		{
			LicenseKey = licenseKey;
		}

		public override string LicenseKey { get; }

		public override void Dispose() { }
	}
}
