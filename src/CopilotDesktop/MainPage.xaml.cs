using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CopilotDesktop
{
  public sealed partial class MainPage : Page
  {
    private const string WindowsCopilotUrl = "https://edgeservices.bing.com/edgesvc/chat?udsframed=1&form=SHORUN&clientscopes=chat,coauthor,noheader,udsedgeshop,channelstable,wincopilot,udsinwin11,&shellsig=2c8c738a716cbab378267d3754f22c92d0fdee83&setlang=en-US&darkschemeovr=1";
    private const string BingCopilotUrl = "https://edgeservices.bing.com/edgediscover/query?&darkschemeovr=1&FORM=SHORUN&udscs=1&udsnav=1&setlang=en-US&features=udssydinternal&clientscopes=windowheader,coauthor,chat,&udsframed=1#";

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
      
      WebViewControl.Source = new Uri(WindowsCopilotUrl);
    }
  }
}