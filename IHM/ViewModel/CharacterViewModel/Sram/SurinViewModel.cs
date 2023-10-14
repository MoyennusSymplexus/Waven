using IHM.Model;

namespace IHM.ViewModel
{
    internal class SurinViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public SurinViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}