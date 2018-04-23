using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Core.Native;
using System.Windows;

namespace NavBarSampleSL {
    public class NavPanePopupHelper {
        public static NavPanePopup GetPopup(NavBarControl nControl) {
            if (nControl == null || !(nControl.View is NavigationPaneView)) return null;
            return LayoutHelper.FindElement(nControl, fe => fe is NavPanePopup) as NavPanePopup;
        }
    }

    public partial class MainPage : UserControl {
        NavPanePopup NavPopup { get; set; }
        public MainPage() {
            InitializeComponent();
            View.NavPaneExpandedChanged += OnNavPaneExpandedChanged;
            View.NavPaneExpandedChanging += OnNavPaneExpandedChanging;
            View.Loaded += OnViewLoaded;
        }

        void OnViewLoaded(object sender, RoutedEventArgs e) {
            NavPopup = NavPanePopupHelper.GetPopup(navBarControl1);
            ((NavPanePopupWindowContent)NavPopup.Child).SizeChanged += OnPopupWindowSizeChanged;
            ((NavPanePopupWindowContent)NavPopup.Child).Loaded += OnPopupWindowLoaded;
        }

        private void OnPopupWindowLoaded(object sender, RoutedEventArgs e) {
            ((NavPanePopupWindowContent)NavPopup.Child).Width = View.PreviousWidth - View.ActualWidth; 
        }
        void OnPopupWindowSizeChanged(object sender, SizeChangedEventArgs e) {
            NavPanePopupWindowContent npw = sender as NavPanePopupWindowContent;
            View.OpenedWidth = npw.ActualWidth;
        }

        void OnNavPaneExpandedChanged(object sender, NavPaneExpandedChangedEventArgs e) {
            if (View == null) View = sender as CustomNavigationPaneView;
            if (!View.IsExpanded)
                View.OpenedWidth = View.ActualWidth;
        }
        void OnNavPaneExpandedChanging(object sender, NavPaneExpandedChangingEventArgs e) {
            View.PreviousWidth = View.ActualWidth;
        }
    }
}
