// See https://aka.ms/new-console-template for more information

using Fedinaut;
using Gio;

Adw.Module.Initialize();

void OnActivate(Application app, EventArgs e)
{
    Console.WriteLine("Hello!");
    
    var window = new Window(app);
    window.Present();
}

var app = Adw.Application.New("com.mattjakeman.fedinaut", ApplicationFlags.FlagsNone);
app.OnActivate += OnActivate;
app.Run();

Console.WriteLine("Hello, World!");