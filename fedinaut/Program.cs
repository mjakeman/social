// See https://aka.ms/new-console-template for more information

using Gtk;
using Gio;

void OnActivate(Gio.Application app, EventArgs e)
{
    Console.WriteLine("Hello!");
}

var app = Gtk.Application.New("com.mattjakeman.fedinaut", ApplicationFlags.FlagsNone);
app.OnActivate += OnActivate;
app.Run();

Console.WriteLine("Hello, World!");