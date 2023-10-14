using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using IHM.Commands.Build;
using WavenCore.Spells;

namespace IHM.View
{
    /// <summary>
    ///     Interaction logic for SpellView.xaml
    /// </summary>
    public partial class SpellView : UserControl
    {
        #region Static Fields and Methods

        public static readonly DependencyProperty SpellsProperty =
            DependencyProperty.RegisterAttached(nameof(Spells), typeof(IEnumerable<SpellWithSummary>), typeof(SpellView), new PropertyMetadata(null));

        public static readonly DependencyProperty RuneChangedProperty =
            DependencyProperty.RegisterAttached(nameof(RuneChanged), typeof(ICommand), typeof(SpellView), new PropertyMetadata(null));

        public static readonly DependencyProperty LevelChangedProperty =
            DependencyProperty.RegisterAttached(nameof(LevelChanged), typeof(ICommand), typeof(SpellView), new PropertyMetadata(null));

        public static readonly DependencyProperty AddLevelProperty =
            DependencyProperty.RegisterAttached(nameof(AddLevel), typeof(ICommand), typeof(SpellView), new PropertyMetadata(null));

        public static readonly DependencyProperty RemoveLevelProperty =
            DependencyProperty.RegisterAttached(nameof(RemoveLevel), typeof(ICommand), typeof(SpellView), new PropertyMetadata(null));

        #endregion

        #region Constructors

        public SpellView() {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public ICommand LevelChanged {
            get => (ICommand) GetValue(LevelChangedProperty);
            set => SetValue(LevelChangedProperty, value);
        }
        public ICommand AddLevel {
            get => (ICommand) GetValue(AddLevelProperty);
            set => SetValue(AddLevelProperty, value);
        }
        public ICommand RemoveLevel {
            get => (ICommand) GetValue(RemoveLevelProperty);
            set => SetValue(RemoveLevelProperty, value);
        }
        public IEnumerable<SpellWithSummary> Spells {
            get => (IEnumerable<SpellWithSummary>) GetValue(SpellsProperty);
            set => SetValue(SpellsProperty, value);
        }
        public ICommand RuneChanged {
            get => (ICommand) GetValue(RuneChangedProperty);
            set => SetValue(RuneChangedProperty, value);
        }

        #endregion

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

            LevelChanged?.Execute(new LevelChangedCommand.UpdateSpell((dataItem as Spell)!, result));
        }

        private void AddingLevel(object sender, RoutedEventArgs e) {
            AddLevel?.Execute(null);
        }

        private void RemovingRune(object sender, RoutedEventArgs e) {
            RemoveLevel?.Execute(null);
        }

        private void ChangeRune(object sender, RoutedEventArgs e) {
            RuneChanged?.Execute(null);
        }
    }
}