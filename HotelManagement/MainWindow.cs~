using System;
using Gtk;
using HotelManagement;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnImportBtnClicked(object sender, EventArgs e)
	{
		//this.excelPathLabel.Text = XmlHelper.Instance.ExcelPath;
		var path = this.fileBrowser.Filename;
		var controller = new HotelBookDetailController();
		controller.ImportExcelToDatabase(path);
		MessageDialog md = new MessageDialog(this, DialogFlags.DestroyWithParent,
		MessageType.Info,
		ButtonsType.Ok, "Import Success!");
		md.Run();
		md.Destroy();
	}
}
