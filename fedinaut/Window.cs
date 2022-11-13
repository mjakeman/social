using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using GObject;
using Gtk;
using Mastonet;
using Mastonet.Entities;

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

    record Account(Auth token, AppRegistration app);

    void SetupMastodon()
    {
        if (File.Exists("app.json"))
        {
            var text = File.ReadAllTextAsync("app.json").Result;
            var app = JsonSerializer.Deserialize<AppRegistration>(text);
            var client = new AuthenticationClient(app);

            if (File.Exists("auth.json"))
            {
                text = File.ReadAllTextAsync("auth.json").Result;
                var auth = JsonSerializer.Deserialize<Auth>(text);
            }
            else
            {
                DoLogin(client);
            }

            return;
        }
        
        var authClient = new AuthenticationClient("social.mattjakeman.com");
        var appRegistration = authClient.CreateApp("Fedinaut", Scope.Read | Scope.Write | Scope.Follow).Result;

        var jsonData = JsonSerializer.Serialize(appRegistration);
        File.WriteAllText("app.json", jsonData);
        
        DoLogin(authClient);
    }

    void DoLogin(AuthenticationClient authClient)
    {
        Utils.OpenBrowser(authClient.OAuthUrl());

        var dialog = new OAuthDialog(this);
        dialog.OnEnterCode += (sender, args) =>
        {
            var auth = authClient.ConnectWithCode(args.OAuthCode).Result;
            var jsonData = JsonSerializer.Serialize(auth);
            File.WriteAllText("auth.json", jsonData);
        };
    }
}