using System;

using CopilotDesktop.Helpers;
using CopilotDesktop.Services;

using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CopilotDesktop
{
  sealed partial class App : Application
  {
    private ThemeService _themeService;

    public App()
    {
      InitializeComponent();

      SettingsHelper.CreateSettings();

      Environment.SetEnvironmentVariable("WEBVIEW2_DEFAULT_BACKGROUND_COLOR", "0");
    }

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      var rootFrame = Window.Current.Content as Frame;

      if (rootFrame == null)
      {
        var coreApplication = CoreApplication.GetCurrentView();
        coreApplication.TitleBar.ExtendViewIntoTitleBar = true;

        ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(192, 48));

        _themeService = new ThemeService(Window.Current);
        _themeService.SetTheme();

        rootFrame = new Frame();

        if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
        }

        Window.Current.Content = rootFrame;
      }

      if (e.PrelaunchActivated == false)
      {
        if (rootFrame.Content == null)
        {
          rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }

        Window.Current.Activate();
      }
    }
  }
}