using System.Collections.Generic;
using System.Windows;
using IHM.Model;
using WavenCore.Equipments.SpecificCalculator;

namespace IHM.ViewModel
{
    internal class ToungViewModel : ObservableObject
    {
        #region Fields and Enums

        private readonly BuildModel _buildModel;

        #endregion

        #region Constructors

        internal ToungViewModel(BuildModel buildModel) {
            _buildModel = buildModel;
        }

        #endregion

        #region Properties

        public IEnumerable<ToungEffect> ToungEffects => ToungCalculator.GetEffects(_buildModel.GetSummary());
        public Visibility               IsVisible    => _buildModel.ToungIsOn() ? Visibility.Visible : Visibility.Collapsed;

        #endregion

        public void Update() {
            OnPropertyChanged(nameof(IsVisible));
            OnPropertyChanged(nameof(ToungEffects));
        }
    }
}