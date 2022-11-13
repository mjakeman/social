using System.Reflection;
using GObject;
using Gtk;
using Mastonet;

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
        
        SetupMastodon();
    }

    async void SetupMastodon()
    {
        // var authClient = new AuthenticationClient("instanceUrl");
        // var appRegistration = await authClient.CreateApp("Fedinaut", Scope.Read | Scope.Write | Scope.Follow);

        // var assistant = Assistant.New();
        // assistant.Present();
    }
}