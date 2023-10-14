using System.Globalization;
using System.Windows;
using IHM.Model;
using WavenCore.Equipments.SpecificCalculator;
using WavenCore.Metadata;

namespace IHM.ViewModel
{
    internal class LermiteViewModel : ObservableObject
    {
        #region Fields and Enums

        private readonly BuildModel            _buildModel;
        private          CharacterStatSummary? _summary;

        #endregion

        #region Constructors

        internal LermiteViewModel(BuildModel buildModel) {
            _buildModel = buildModel;
        }

        #endregion

        #region Properties

        public string LermiteDamage         => LermiteCalculator.GetDamage(_summary).ToString(CultureInfo.InvariantCulture);
        public string LermiteCriticalDamage => LermiteCalculator.GetCriticalDamage(_summary).ToString(CultureInfo.InvariantCulture);

        public Visibility IsVisible => _buildModel.LermiteIsOn() ? Visibility.Visible : Visibility.Collapsed;

        #endregion

        public void Update() {
            _summary = _buildModel.GetSummary();

            OnPropertyChanged(nameof(LermiteDamage));
            OnPropertyChanged(nameof(LermiteCriticalDamage));
            OnPropertyChanged(nameof(IsVisible));
        }
    }
}