using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;
using DevExpress.Xpf.Controls;

namespace MirrorControl_CreatingManually {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            MirrorControl Mirror = new MirrorControl();

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new System.Windows.Point(0, 0);
            brush.EndPoint = new System.Windows.Point(1, 0);
            brush.GradientStops.Add(new GradientStop() {Color = Colors.Transparent , Offset = 0});
            brush.GradientStops.Add(new GradientStop() { Color = Colors.White, Offset = 1 });
            Mirror.ReflectionOpacityMask = brush;

            PlaneProjection projection = new PlaneProjection();
            projection.CenterOfRotationX = 0.5;
            projection.CenterOfRotationY = 0.5;
            Mirror.ContentProjection = projection;

            Mirror.ReflectionEffect = new BlurEffect() { Radius = 15 };

            Mirror.Content = new Calendar();
            LayoutRoot.Children.Add(Mirror);
            Grid.SetColumn(Mirror, 0);
            Grid.SetRow(Mirror, 4);

            Binding binding;
            binding = new Binding("ContentProjection.RotationX") {
                Source = Mirror, Mode = BindingMode.TwoWay
            };
            sldrRotX.SetBinding(Slider.ValueProperty, binding);
            binding = new Binding("ContentProjection.RotationY") {
                Source = Mirror, Mode = BindingMode.TwoWay
            };
            sldrRotY.SetBinding(Slider.ValueProperty, binding);
        }
    }
}
