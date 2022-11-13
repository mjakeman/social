using GObject;
using Gtk;

namespace Fedinaut;

/// <summary>
/// The main window showing a user's home feed
/// </summary>
public class Window : ApplicationWindow
{
    public Window(Gio.Application app) : base(ConstructArgument.With("application", app))
    {
        var label = Label.New("Text");
        SetChild(label);
    }
}