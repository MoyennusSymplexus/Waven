using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using IHM.Commands.Build;
using WavenCore.Equipments;

namespace IHM.View
{
    /// <summary>
    ///     Interaction logic for BuildView.xaml
    /// </summary>
    public partial class BuildView : UserControl
    {
        #region Static Fields and Methods

        public static readonly DependencyProperty LoadCommandProperty =
            DependencyProperty.RegisterAttached(nameof(LoadCommand), typeof(ICommand), typeof(BuildView), new PropertyMetadata(null));

        public static readonly DependencyProperty LevelChangedProperty =
            DependencyProperty.RegisterAttached(nameof(LevelChanged), typeof(ICommand), typeof(BuildView), new PropertyMetadata(null));

        public static readonly DependencyProperty RuneChangedProperty =
            DependencyProperty.RegisterAttached(nameof(RuneChanged), typeof(ICommand), typeof(BuildView), new PropertyMetadata(null));

        #endregion

        #region Constructors

        public BuildView() {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public ICommand LoadCommand {
            get => (ICommand) GetValue(LoadCommandProperty);
            set => SetValue(LoadCommandProperty, value);
        }

        public ICommand LevelChanged {
            get => (ICommand) GetValue(LevelChangedProperty);
            set => SetValue(LevelChangedProperty, value);
        }

        public ICommand RuneChanged {
            get => (ICommand) GetValue(RuneChangedProperty);
            set => SetValue(RuneChangedProperty, value);
        }

        #endregion

        private void BuildLoaded(object sender, RoutedEventArgs e) {
            LoadCommand?.Execute(null);
        }

        private void ChangeLevel(object sender, RoutedEventArgs e) {
            var                textBox  = sender as TextBox;
            BindingExpression? binding  = textBox?.GetBindingExpression(TextBox.TextProperty);
            object?            dataItem = binding?.DataItem;

            if (BindingOperations.DisconnectedSource == dataItem) {
                //Quand on clique sur une autre Textbox; l'event est levé à nouveau car on déconstruit la liste donnant lieu à une source déconnectée
                return;
            }

            if (!int.TryParse(textBox?.Text, out int result)) {
                return;
            }

            LevelChanged?.Execute(new LevelChangedCommand.UpdateItem((dataItem as Equipment)!, result));
        }

        private void ChangeRune(object sender, RoutedEventArgs e) {
            RuneChanged?.Execute(null);
        }
    }
}