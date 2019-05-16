using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public string userId;

        public static Single completionStatus = 0;
            
        public MainPage()
        {
            this.InitializeComponent();
            CompletionTracker(completionStatus);
        }

        
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load page: " + e.SourcePageType.FullName);
        }

        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("login", typeof(Login)),
            ("home", typeof(Home)),
            ("orgdetails", typeof(OrgDetails)),
            ("pocpage", typeof(POCDetailsPage)),
            ("locdetails", typeof(LocationDetails)),
            ("scpPage", typeof(scopePage)),
            ("pbaPage", typeof(pbapage)),
            ("frwlPage", typeof(firewallPage)),
            ("scrCnfgPage", typeof(secureConfigPage)),
            ("usrAcsCtrlPage", typeof(userAccessControlPage)),
            ("mlwrPrtctnPage", typeof(malwareProtectionPage)),
            ("ptchMngmntPage", typeof(patchManagementPage))

        };

        private void NavigationViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            //handler for content frame navigation
            ContentFrame.Navigated += On_Navigated;

            //defualt to homepage
            NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems[0];

            //because ItemInvoked is used to naviagte, we call Navigate here to load home page
            NavigationViewControl_Navigate("login", new EntranceNavigationTransitionInfo());

            var goBack = new KeyboardAccelerator { Key = Windows.System.VirtualKey.GoBack };
            goBack.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(goBack);

            var altLeft = new KeyboardAccelerator
            {
                Key = Windows.System.VirtualKey.Left,
                Modifiers = Windows.System.VirtualKeyModifiers.Menu
            };
            altLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(altLeft);
        }


        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavigationViewControl_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavigationViewControl_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavigationViewControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }

        private void NavigationViewControl_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(SettingsPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }

            //following code prevents duplicates in backstack by getting pagetype before naavigation
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            //do not navigate if the selected page is currently loaded
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private bool On_BackRequested()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the navigation pane is overlayed.
            if (NavigationViewControl.IsPaneOpen && (NavigationViewControl.DisplayMode == NavigationViewDisplayMode.Compact || NavigationViewControl.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            ContentFrame.GoBack();
            return true;
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavigationViewControl.IsBackEnabled = ContentFrame.CanGoBack;

            if(ContentFrame.SourcePageType == typeof(SettingsPage))
            {
                NavigationViewControl.SelectedItem = (NavigationViewItem)NavigationViewControl.SettingsItem;
                NavigationViewControl.Header = "Settings";
            }

            else if (ContentFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));

                NavigationViewControl.Header = ((NavigationViewItem)NavigationViewControl.SelectedItem)?.Content?.ToString();
            }
        }

        private void CompletionTracker(Single c)
        {
            if (c == 0)
            {
                LocationDetailsMenuItem.Visibility = Visibility.Collapsed;
                LoginMenuItem.Visibility = Visibility.Visible;
                OrgIDHeader.Visibility = Visibility.Collapsed;
                PersonDetailsMenuItem.Visibility = Visibility.Collapsed;
                OrganisationDetailsMenuItem.Visibility = Visibility.Collapsed;
                Section1Header.Visibility = Visibility.Collapsed;
                BusinessScopeMenuItem.Visibility = Visibility.Collapsed;
                Section2Header.Visibility = Visibility.Collapsed;
                PasswordBasedAuthenticationMenuItem.Visibility = Visibility.Collapsed;
                Section3Header.Visibility = Visibility.Collapsed;
                FirewallsMenuItem.Visibility = Visibility.Collapsed;
                Section4Header.Visibility = Visibility.Collapsed;
                SecureConfigurationMenuItem.Visibility = Visibility.Collapsed;
                Section5Header.Visibility = Visibility.Collapsed;
                UserAccessControlMenuItem.Visibility = Visibility.Collapsed;
                Section6Header.Visibility = Visibility.Collapsed;
                AntiMalwareSoftwareMenuItem.Visibility = Visibility.Collapsed;
                Section7Header.Visibility = Visibility.Collapsed;
                PatchManagementMenuItem.Visibility = Visibility.Collapsed;
            }
            if (c == 1)
            {
                LoginMenuItem.Visibility = Visibility.Collapsed;
                OrgIDHeader.Visibility = Visibility.Visible;
                PersonDetailsMenuItem.Visibility = Visibility.Visible;
            }
            else if (c == 2)
            {
                OrganisationDetailsMenuItem.Visibility = Visibility.Visible;
            }
            else if (c == 3)
            {
                LocationDetailsMenuItem.Visibility = Visibility.Visible;
            }

            else if (c == 4)
            {
                secondSeperator.Visibility = Visibility.Visible;
                Section1Header.Visibility = Visibility.Visible;
                BusinessScopeMenuItem.Visibility = Visibility.Visible;
                Section2Header.Visibility = Visibility.Visible;
                PasswordBasedAuthenticationMenuItem.Visibility = Visibility.Visible;
                Section3Header.Visibility = Visibility.Visible;
                FirewallsMenuItem.Visibility = Visibility.Visible;
                Section4Header.Visibility = Visibility.Visible;
                SecureConfigurationMenuItem.Visibility = Visibility.Visible;
                Section5Header.Visibility = Visibility.Visible;
                UserAccessControlMenuItem.Visibility = Visibility.Visible;
                Section6Header.Visibility = Visibility.Visible;
                AntiMalwareSoftwareMenuItem.Visibility = Visibility.Visible;
                Section7Header.Visibility = Visibility.Visible;
                PatchManagementMenuItem.Visibility = Visibility.Visible;
            }
        }

        public static void setTrackerStatus(Single c)
        {
            completionStatus = c;
        }

        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            CompletionTracker(completionStatus);
        }

        private void NavigationViewControl_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            NavigationViewControl.IsPaneOpen = false;
        }

    }
}
