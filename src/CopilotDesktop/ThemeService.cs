using System;

using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace CopilotDesktop
{
  internal class ThemeService
  {
    private readonly UISettings _uiSetting;
    private readonly Window _currentWindow;

    public ThemeService(Window currentWindow)
    {
      _currentWindow = currentWindow;

      _uiSetting = new UISettings();
      _uiSetting.ColorValuesChanged += (_, __) => SetTheme();
    }

    public async void SetTheme()
    {
      if (_currentWindow == null)
      {
        return;
      }

      await _currentWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
      {
        var foregroundColor = _uiSetting.GetColorValue(UIColorType.Foreground);

        (Window.Current.Content as FrameworkElement).RequestedTheme = ElementTheme.Default;

        SetThemeForTitleBar(foregroundColor == Color.FromArgb(255, 0, 0, 0));
      });
    }

    private void SetThemeForTitleBar(bool isLightTheme)
    {
      var titleBar = ApplicationView.GetForCurrentView().TitleBar;

      var grayColor = Color.FromArgb(255, 128, 128, 128);

      var whiteForegroundColor = Color.FromArgb(255, 255, 255, 255);
      var whitePressedForegroundColor = Color.FromArgb(255, 192, 192, 192);
      var whiteHoverBackgroundColor = Color.FromArgb(24, 255, 255, 255);
      var whitePressedBackgroundColor = Color.FromArgb(16, 255, 255, 255);

      var blackForegroundColor = Color.FromArgb(255, 0, 0, 0);
      var blackPressedForegroundColor = Color.FromArgb(255, 96, 96, 96);
      var blackHoverBackgroundColor = Color.FromArgb(24, 0, 0, 0);
      var blackPressedBackgroundColor = Color.FromArgb(16, 0, 0, 0);

      //// Foreground
      titleBar.ButtonForegroundColor = isLightTheme ? blackForegroundColor : whiteForegroundColor;
      titleBar.ButtonHoverForegroundColor = isLightTheme ? blackForegroundColor : whiteForegroundColor;
      titleBar.ButtonPressedForegroundColor = isLightTheme ? blackPressedForegroundColor : whitePressedForegroundColor;
      titleBar.ButtonInactiveForegroundColor = grayColor;
      titleBar.InactiveForegroundColor = grayColor;
      titleBar.ForegroundColor = isLightTheme ? blackForegroundColor : whiteForegroundColor;

      //// Background
      titleBar.BackgroundColor = Colors.Transparent;
      titleBar.ButtonBackgroundColor = Colors.Transparent;
      titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
      titleBar.ButtonHoverBackgroundColor = isLightTheme ? blackHoverBackgroundColor : whiteHoverBackgroundColor;
      titleBar.ButtonPressedBackgroundColor = isLightTheme ? blackPressedBackgroundColor : whitePressedBackgroundColor;
      titleBar.InactiveBackgroundColor = Colors.Transparent;
    }
  }
}