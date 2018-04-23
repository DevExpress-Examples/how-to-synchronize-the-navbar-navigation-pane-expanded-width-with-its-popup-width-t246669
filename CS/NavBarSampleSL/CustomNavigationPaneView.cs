using DevExpress.Xpf.NavBar;

namespace NavBarSampleSL {
    public class CustomNavigationPaneView : NavigationPaneView {
        public double OpenedWidth { get; set; }
        public double PreviousWidth { get; set; }
        protected override void UpdatePresenterTemplateByEnabledState() {
            if (OpenedWidth != 0) {
                ExpandedWidth = OpenedWidth;
            }
            base.UpdatePresenterTemplateByEnabledState();
        }
    }
}
