using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WavenCore.Classes;

namespace IHM.View
{
    /// <summary>
    ///     Interaction logic for PassiveView.xaml
    /// </summary>
    public partial class PassiveView : UserControl
    {
        #region Static Fields and Methods

        public static readonly DependencyProperty PassiveProperty =
            DependencyProperty.RegisterAttached(nameof(Passive), typeof(IEnumerable<Passive>), typeof(PassiveView), new PropertyMetadata(null));

        #endregion

        #region Constructors

        public PassiveView() {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public IEnumerable<Passive> Passive {
            get => (IEnumerable<Passive>) GetValue(PassiveProperty);
            set => SetValue(PassiveProperty, value);
        }

        #endregion
    }
}