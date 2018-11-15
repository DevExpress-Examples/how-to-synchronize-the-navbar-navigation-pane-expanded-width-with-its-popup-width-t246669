<!-- default file list -->
*Files to look at*:

* [CustomNavigationPaneView.cs](./CS/NavBarSampleSL/CustomNavigationPaneView.cs) (VB: [CustomNavigationPaneView.vb](./VB/NavBarSampleSL/CustomNavigationPaneView.vb))
* [MainPage.xaml](./CS/NavBarSampleSL/MainPage.xaml) (VB: [MainPage.xaml](./VB/NavBarSampleSL/MainPage.xaml))
* [MainPage.xaml.cs](./CS/NavBarSampleSL/MainPage.xaml.cs) (VB: [MainPage.xaml](./VB/NavBarSampleSL/MainPage.xaml))
<!-- default file list end -->
# How to synchronize the NavBar Navigation Pane expanded width with its popup width


<p>By default, Microsoft Outlook allows you to synchronize the Navigation Pane width in expanded mode with its Popup Window width.</p>
<p>This example illustrates how to add similar behavior to the NavBar.</p>
<p>To add this functionality, it is necessary to add event handlers for NavPaneExpandedChanged and NavPaneExpandedChanging events, which will keep the NavBar and Popup actual widths synchronized when they are changed.</p>
<p>Then it is necessary to create a NavigationPaneView descendant and override the UpdatePresenterTemplateByEnabledState method, which should set your stored width for NavBar before the latter changes its visual state.<br /><br />To learn more on how to implement similar functionality in WPF, refer to the <a href="https://www.devexpress.com/Support/Center/p/E4302">E4302</a> example.</p>

<br/>


