Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Controls
Imports DevExpress.Xpf.NavBar
Imports DevExpress.Xpf.Core.Native
Imports System.Windows

Namespace NavBarSampleSL
    Public Class NavPanePopupHelper
        Public Shared Function GetPopup(ByVal nControl As NavBarControl) As NavPanePopup
            If nControl Is Nothing OrElse Not(TypeOf nControl.View Is NavigationPaneView) Then
                Return Nothing
            End If
            Return TryCast(LayoutHelper.FindElement(nControl, Function(fe) TypeOf fe Is NavPanePopup), NavPanePopup)
        End Function
    End Class

    Partial Public Class MainPage
        Inherits UserControl

        Private Property NavPopup() As NavPanePopup
        Public Sub New()
            InitializeComponent()
            AddHandler View.NavPaneExpandedChanged, AddressOf OnNavPaneExpandedChanged
            AddHandler View.NavPaneExpandedChanging, AddressOf OnNavPaneExpandedChanging
            AddHandler View.Loaded, AddressOf OnViewLoaded
        End Sub

        Private Sub OnViewLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            NavPopup = NavPanePopupHelper.GetPopup(navBarControl1)
            AddHandler CType(NavPopup.Child, NavPanePopupWindowContent).SizeChanged, AddressOf OnPopupWindowSizeChanged
            AddHandler CType(NavPopup.Child, NavPanePopupWindowContent).Loaded, AddressOf OnPopupWindowLoaded
        End Sub

        Private Sub OnPopupWindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            CType(NavPopup.Child, NavPanePopupWindowContent).Width = View.PreviousWidth - View.ActualWidth
        End Sub
        Private Sub OnPopupWindowSizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
            Dim npw As NavPanePopupWindowContent = TryCast(sender, NavPanePopupWindowContent)
            View.OpenedWidth = npw.ActualWidth
        End Sub

        Private Sub OnNavPaneExpandedChanged(ByVal sender As Object, ByVal e As NavPaneExpandedChangedEventArgs)
            If View Is Nothing Then
                View = TryCast(sender, CustomNavigationPaneView)
            End If
            If Not View.IsExpanded Then
                View.OpenedWidth = View.ActualWidth
            End If
        End Sub
        Private Sub OnNavPaneExpandedChanging(ByVal sender As Object, ByVal e As NavPaneExpandedChangingEventArgs)
            View.PreviousWidth = View.ActualWidth
        End Sub
    End Class
End Namespace
