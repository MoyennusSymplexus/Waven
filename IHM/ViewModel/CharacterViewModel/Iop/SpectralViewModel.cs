using IHM.Model;

namespace IHM.ViewModel
{
    internal class SpectralViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public SpectralViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}