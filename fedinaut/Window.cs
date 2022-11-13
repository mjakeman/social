using System.Reflection;
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
        Title = "Fedinaut (Mastodon Client)";
        DefaultHeight = 600;
        DefaultWidth = 800;
        
        var builder = new Builder("window.ui");
        var root = (Widget) builder.GetObject("root");
        SetChild(root);
    }
}