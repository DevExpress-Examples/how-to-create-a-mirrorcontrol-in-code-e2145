Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Effects
Imports DevExpress.Xpf.Controls

Namespace MirrorControl_CreatingManually
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim Mirror As New MirrorControl()

			Dim brush As New LinearGradientBrush()
			brush.StartPoint = New System.Windows.Point(0, 0)
			brush.EndPoint = New System.Windows.Point(1, 0)
			brush.GradientStops.Add(New GradientStop() With {.Color = Colors.Transparent, .Offset = 0})
			brush.GradientStops.Add(New GradientStop() With {.Color = Colors.White, .Offset = 1})
			Mirror.ReflectionOpacityMask = brush

			Dim projection As New PlaneProjection()
			projection.CenterOfRotationX = 0.5
			projection.CenterOfRotationY = 0.5
			Mirror.ContentProjection = projection

			Mirror.ReflectionEffect = New BlurEffect() With {.Radius = 15}

			Mirror.Content = New Calendar()
			LayoutRoot.Children.Add(Mirror)
			Grid.SetColumn(Mirror, 0)
			Grid.SetRow(Mirror, 4)

			Dim binding As Binding
			binding = New Binding("ContentProjection.RotationX") With {.Source = Mirror, .Mode = BindingMode.TwoWay}
			sldrRotX.SetBinding(Slider.ValueProperty, binding)
			binding = New Binding("ContentProjection.RotationY") With {.Source = Mirror, .Mode = BindingMode.TwoWay}
			sldrRotY.SetBinding(Slider.ValueProperty, binding)
		End Sub
	End Class
End Namespace
