namespace Fedinaut;

using Adw;

public class OAuthDialog
{
    public class OAuthEventArgs : EventArgs
    {
        public String OAuthCode { get; init; }
    }
    
    private readonly EntryRow _entry;
    public EventHandler<OAuthEventArgs> OnEnterCode;
    
    void OnLoginAttempt(MessageDialog dialog, MessageDialog.ResponseSignalArgs e)
    {
        var code = GLib.Internal.StringHelper.ToStringUtf8(Gtk.Internal.Editable.GetText(_entry.Handle));
        Console.WriteLine($"Using code: {code}");
        
        OnEnterCode.Invoke(this, new OAuthEventArgs { OAuthCode = code});
    }
    
    public OAuthDialog(Window parent)
    {
        _entry = EntryRow.New();

        var dialog = new MessageDialog();
        dialog.Heading = "Authorise Client";
        dialog.Body = "Enter the OAuth code from your browser.";
        dialog.SetExtraChild(_entry);
        
        dialog.SetModal(true);
        dialog.SetTransientFor(parent);
        
        dialog.AddResponse("connect", "Connect");
        dialog.OnResponse += OnLoginAttempt;

        dialog.Present();
    }
}