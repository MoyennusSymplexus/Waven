using IHM.Model;

namespace IHM.ViewModel
{
    internal class KartanaViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public KartanaViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}