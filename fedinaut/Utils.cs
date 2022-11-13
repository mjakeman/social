using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Fedinaut;

public class Utils
{
    public static void OpenBrowser(string url)
    {
        // yuck... can we add support for gtk_show_uri on macOS?
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start("xdg-open", url);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Process.Start("open", url);
        }
        else
        {
            throw new NotImplementedException($"{nameof(OpenBrowser)} not implemented for {RuntimeInformation.OSDescription}");
        }
    }
}