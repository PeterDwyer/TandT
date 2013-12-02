using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;

namespace Template
{
	public sealed partial class MainPage : Page
	{
		private Popup settingsPopup;

		private void OnCommandRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs eventArgs)
		{
			eventArgs.Request.ApplicationCommands.Add(new SettingsCommand("SettingsId", "About", OnSettingsCommand));
			eventArgs.Request.ApplicationCommands.Add(new SettingsCommand("PrivacyPolicyId", "Privacy Policy", OpenPrivacyPolicy));
		}

		private async void OpenPrivacyPolicy(IUICommand command)
		{
            Uri uri = new Uri("http://www.penguin.co.uk/static/cs/uk/0/penguin_privacyterms/privacypolicy.html");
			await Launcher.LaunchUriAsync(uri);
		}

		private void OnSettingsCommand(IUICommand command)
		{
			double width = 400;
			double height = Window.Current.Bounds.Height;

			settingsPopup = new Popup();
			settingsPopup.IsLightDismissEnabled = true;
			settingsPopup.Width = width;
			settingsPopup.Height = height;

			// Add the proper animation for the panel.
			settingsPopup.ChildTransitions = new TransitionCollection();
			settingsPopup.ChildTransitions.Add(new PaneThemeTransition()
				{
					Edge = (SettingsPane.Edge == SettingsEdgeLocation.Right)
						       ? EdgeTransitionLocation.Right
						       : EdgeTransitionLocation.Left
				});

			SettingsPaneContent myPane = new SettingsPaneContent();
			myPane.Width = width;
			myPane.Height = height;

			settingsPopup.SetValue(Canvas.LeftProperty,
			                       SettingsPane.Edge == SettingsEdgeLocation.Right ? (Window.Current.Bounds.Width - width) : 0);
			settingsPopup.SetValue(Canvas.TopProperty, 0);
			settingsPopup.Child = myPane;
			settingsPopup.IsOpen = true;
		}
	}
}