using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace IHM
{
    public class FilterableComboBox : ComboBox
    {
        #region Static Fields and Methods

        public static readonly DependencyProperty OnlyValuesInListProperty =
            DependencyProperty.Register(nameof(OnlyValuesInList), typeof(bool), typeof(FilterableComboBox));
        public static readonly DependencyProperty EffectivelySelectedItemProperty =
            DependencyProperty.Register(nameof(EffectivelySelectedItem), typeof(object), typeof(FilterableComboBox));

        #endregion

        #region Fields and Enums

        private string           _currentFilter = string.Empty; //We use a currentFilter because Searchable ComboBox auto complete by default
        private bool             _shouldTriggerSelectedItemChanged;
        private ICollectionView? _view;
        private Action<bool>?    _wasArrowKey;

        #endregion

        #region Constructors

        public FilterableComboBox() {
            IsEditable          = true;
            IsTextSearchEnabled = true;
            StaysOpenOnEdit     = true;
            IsReadOnly          = false;

            Loaded                      += FilteredComboBox_Loaded;
            SelectionChanged            += FilteredComboBox_SelectionChanged;
            SelectionEffectivelyChanged += FilteredComboBox_SelectionEffectivelyChanged;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     If true, on lost focus or enter key pressed, checks the text in the combobox. If the text is not present
        ///     in the list, it leaves it blank.
        /// </summary>
        public bool OnlyValuesInList {
            get => (bool) GetValue(OnlyValuesInListProperty);
            set => SetValue(OnlyValuesInListProperty, value);
        }

        /// <summary>
        ///     Selected item, changes only on lost focus or enter key pressed
        /// </summary>
        public object? EffectivelySelectedItem {
            get => (bool) GetValue(EffectivelySelectedItemProperty);
            set => SetValue(EffectivelySelectedItemProperty, value);
        }
        private TextBox EditableTextBox => GetTemplateChild("PART_EditableTextBox") as TextBox ?? throw new InvalidOperationException();

        #endregion

        /// <summary>
        ///     Triggers on lost focus or enter key pressed, if the selected item changed since the last time focus was lost or
        ///     enter was pressed.
        /// </summary>
        public event Action<FilterableComboBox, object?> SelectionEffectivelyChanged;

        protected override void OnPreviewKeyDown(KeyEventArgs e) {
            switch (e) {
                case {Key: Key.Down} when !IsDropDownOpen:
                    IsDropDownOpen = true;
                    e.Handled      = true;
                    break;
                case {Key: Key.Down}:
                case {Key: Key.Up}:
                    _wasArrowKey?.Invoke(true);
                    e.Handled = true;
                    break;
                case {Key: Key.Escape}:
                    ClearFilter();
                    IsDropDownOpen = true;
                    break;
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e) {
            if (OnlyValuesInList) {
                Text = SelectedItem?.ToString() ?? "";
            }

            if (!_shouldTriggerSelectedItemChanged) {
                return;
            }

            SelectionEffectivelyChanged(this, SelectedItem);
            _shouldTriggerSelectedItemChanged = false;

            IsDropDownOpen = false;

            base.OnPreviewLostKeyboardFocus(e);
        }

        private void ClearFilter() {
            if (string.IsNullOrEmpty(_currentFilter)) {
                return;
            }

            _currentFilter = "";
            Text           = "";
            CollectionViewSource.GetDefaultView(ItemsSource).Refresh();
        }

        private void FilteredComboBox_Loaded(object? sender, RoutedEventArgs e) {
            var tb = new TextBoxBaseUserChangeTracker(EditableTextBox);
            tb.UserTextChanged += FilteredComboBox_UserTextChange;
            _wasArrowKey       =  tb.WasArrowKey;
        }

        private void FilteredComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            _shouldTriggerSelectedItemChanged = true;
        }

        private void FilteredComboBox_SelectionEffectivelyChanged(FilterableComboBox sender, object? e) {
            EffectivelySelectedItem = e;
        }

        private void FilteredComboBox_UserTextChange(object? sender, EventArgs e) {
            _currentFilter = EditableTextBox.Text[..EditableTextBox.SelectionStart].ToLower(CultureInfo.InvariantCulture);
            FreezeAndRefreshView();
        }

        protected override void OnItemsSourceChanged(IEnumerable? oldValue, IEnumerable? newValue) {
            base.OnItemsSourceChanged(oldValue, newValue);

            if (newValue != null) {
                _view        =  CollectionViewSource.GetDefaultView(newValue);
                _view.Filter += FilterItem;
            }

            if (oldValue == null) {
                return;
            }

            ICollectionView oldView = CollectionViewSource.GetDefaultView(oldValue);

            if (oldView != null) {
                oldView.Filter -= FilterItem;
            }
        }

        private void RefreshView() {
            bool isDropDownOpen = IsDropDownOpen;
            //always hide because showing it enables the user to pick with up and down keys, otherwise it's not working because of the glitch in view.Refresh()
            IsDropDownOpen = false;
            _view?.Refresh();

            if (!string.IsNullOrEmpty(_currentFilter) || isDropDownOpen) {
                IsDropDownOpen = true;
            }

            if (SelectedItem != null) {
                return;
            }

            if (Text == string.Empty) {
                return;
            }

            SelectedItem = ItemsSource.Cast<object>().FirstOrDefault(x => x.ToString() == Text);
        }

        private void FreezeAndRefreshView() {
            string text     = Text;
            int    selStart = EditableTextBox.SelectionStart;
            int    selLen   = EditableTextBox.SelectionLength;
            RefreshView();
            Text                            = text;
            EditableTextBox.SelectionStart  = selStart;
            EditableTextBox.SelectionLength = selLen;
        }

        private bool FilterItem(object item) {
            if (_currentFilter.Length == 0) {
                return true;
            }

            var itemAsString = item.ToString();
            return itemAsString != null && itemAsString.ToLower(CultureInfo.InvariantCulture).Contains(_currentFilter);
        }

        #region Nested type: TextBoxBaseUserChangeTracker

        private class TextBoxBaseUserChangeTracker
        {
            #region Fields and Enums

            private bool _rewriteAll;
            private bool _wasArrowKey;

            #endregion

            #region Constructors

            public TextBoxBaseUserChangeTracker(TextBox textBoxBase) {
                TextBoxBase = textBoxBase;

                TextBoxBase.PreviewTextInput += OnPreviewTextInput;
                TextBoxBase.TextChanged      += OnTextChanged;
                TextBoxBase.PreviewKeyDown   += OnPreviewKeyDown;
            }

            #endregion

            #region Properties

            private bool    IsTextInput { get; set; }
            private TextBox TextBoxBase { get; }

            #endregion

            private void OnPreviewKeyDown(object sender, KeyEventArgs e) {
                if (AllTextIsSelected()) {
                    _rewriteAll = true;
                }

                if (e.Key != Key.Back) {
                    return;
                }

                if (CursorIsAtBeginning()) {
                    return;
                }

                if (CursorIsNotAtBeginningOfSelection()) {
                    return;
                }

                TextBoxBase.SelectionStart--;
                TextBoxBase.SelectionLength++;
                e.Handled = true;
                UserTextChanged?.Invoke(this, e);
            }

            private bool CursorIsNotAtBeginningOfSelection() {
                return TextBoxBase.SelectionStart + TextBoxBase.SelectionLength != TextBoxBase.Text.Length;
            }

            private bool CursorIsAtBeginning() {
                return TextBoxBase.SelectionStart == 0;
            }

            private bool AllTextIsSelected() {
                return TextBoxBase.SelectionLength == TextBoxBase.Text.Length;
            }

            private void OnTextChanged(object sender, TextChangedEventArgs e) {
                if (_rewriteAll) {
                    UserTextChanged?.Invoke(this, e);
                }

                if (!IsTextInput && !_wasArrowKey) {
                    UserTextChanged?.Invoke(this, e);
                }

                IsTextInput  = false;
                _wasArrowKey = false;
                _rewriteAll  = false;
            }

            private void OnPreviewTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs) {
                IsTextInput = true;
            }

            public event EventHandler? UserTextChanged;

            public void WasArrowKey(bool b) {
                _wasArrowKey = b;
            }
        }

        #endregion
    }
}