using System;
using System.Collections.Generic;

using CopilotDesktop.Helpers;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CopilotDesktop
{
  public sealed partial class MainPage : Page
  {
    private readonly Dictionary<string, string> Copilots = new Dictionary<string, string>
    {
      { Consts.WindowsCopilot, "https://edgeservices.bing.com/edgesvc/chat?&darkschemeovr=1&FORM=SHORUN&udscs=1&udsnav=1&setlang=en-US&udsedgeshop=1&clientscopes=noheader,coauthor,chat,visibilitypm,udsedgeshop,wincopilot,docvisibility,channelstable,udsinwin11,&copilotsupported=1,&browserversion=119.0.2151.72,&udsframed=1" },
      { Consts.BingCopilot, "https://edgeservices.bing.com/edgesvc/chat?&darkschemeovr=1&FORM=SHORUN&udscs=1&udsnav=1&setlang=en-US&udsedgeshop=1&clientscopes=windowheader,coauthor,chat,visibilitypm,udsedgeshop,docvisibility,channelstable,udsinwin11,&copilotsupported=1,&browserversion=119.0.2151.72,&udsframed=1" },
    };

    public MainPage()
    {
      InitializeComponent();
      Initialize();
    }

    private async void Initialize()
    {
      Window.Current.SetTitleBar(TitleBarGrid);

      await WebViewControl.EnsureCoreWebView2Async();

      WebViewControl.CoreWebView2.Settings.IsStatusBarEnabled = false;
      WebViewControl.CoreWebView2.Settings.IsSwipeNavigationEnabled = false;

      LoadPage();
    }

    private void UseWindowsCopilot(object sender, RoutedEventArgs e)
    {
      SettingsHelper.SetValue(Consts.CopilotMode, Consts.WindowsCopilot);
      LoadPage();
    }

    private void UseBingCopilot(object sender, RoutedEventArgs e)
    {
      SettingsHelper.SetValue(Consts.CopilotMode, Consts.BingCopilot);
      LoadPage();
    }

    private void Refresh(object sender, RoutedEventArgs e)
    {
      LoadPage();
    }

    private void LoadPage()
    {
      var copilotMode = (string)SettingsHelper.GetValue(Consts.CopilotMode);
      var url = Copilots[copilotMode];
      WebViewControl.Source = new Uri(url);
    }
  }
}