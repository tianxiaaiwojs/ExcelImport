
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.HPaned hpaned2;

	private global::Gtk.VPaned vpaned1;

	private global::Gtk.Label excelPath;

	private global::Gtk.Button importBtn;

	private global::Gtk.FileChooserWidget fileBrowser;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.hpaned2 = new global::Gtk.HPaned();
		this.hpaned2.CanFocus = true;
		this.hpaned2.Name = "hpaned2";
		this.hpaned2.Position = 173;
		// Container child hpaned2.Gtk.Paned+PanedChild
		this.vpaned1 = new global::Gtk.VPaned();
		this.vpaned1.CanFocus = true;
		this.vpaned1.Name = "vpaned1";
		this.vpaned1.Position = 237;
		// Container child vpaned1.Gtk.Paned+PanedChild
		this.excelPath = new global::Gtk.Label();
		this.excelPath.Name = "excelPath";
		this.vpaned1.Add(this.excelPath);
		global::Gtk.Paned.PanedChild w1 = ((global::Gtk.Paned.PanedChild)(this.vpaned1[this.excelPath]));
		w1.Resize = false;
		// Container child vpaned1.Gtk.Paned+PanedChild
		this.importBtn = new global::Gtk.Button();
		this.importBtn.CanFocus = true;
		this.importBtn.Name = "importBtn";
		this.importBtn.UseUnderline = true;
		this.importBtn.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
		this.vpaned1.Add(this.importBtn);
		this.hpaned2.Add(this.vpaned1);
		global::Gtk.Paned.PanedChild w3 = ((global::Gtk.Paned.PanedChild)(this.hpaned2[this.vpaned1]));
		w3.Resize = false;
		// Container child hpaned2.Gtk.Paned+PanedChild
		this.fileBrowser = new global::Gtk.FileChooserWidget(((global::Gtk.FileChooserAction)(0)));
		this.fileBrowser.Name = "fileBrowser";
		this.hpaned2.Add(this.fileBrowser);
		this.Add(this.hpaned2);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 671;
		this.DefaultHeight = 477;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.importBtn.Clicked += new global::System.EventHandler(this.OnImportBtnClicked);
	}
}
