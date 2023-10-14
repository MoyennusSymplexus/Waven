using IHM.Model;

namespace IHM.ViewModel
{
    internal class GurpapaViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public GurpapaViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}