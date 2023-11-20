using System;
using System.Linq;

using Windows.Storage;

namespace CopilotDesktop.Helpers
{
  internal class SettingsHelper
  {
    private static readonly ApplicationDataContainer Settings = ApplicationData.Current.LocalSettings;

    public static void SetValue(string key, object value)
    {
      Settings.Values[key] = value;
    }

    public static object GetValue(string key)
    {
      if (Settings.Values.Any(x => x.Key == key))
      {
        return Settings.Values[key];
      }

      throw new NullReferenceException();
    }

    public static void CreateSettings()
    {
      if (!Settings.Values.Any(x => x.Key == Consts.CopilotMode))
      {
        Settings.Values[Consts.CopilotMode] = Consts.WindowsCopilot;
      }
    }
  }
}