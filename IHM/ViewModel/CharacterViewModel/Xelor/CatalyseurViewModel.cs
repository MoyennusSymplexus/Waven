using IHM.Model;

namespace IHM.ViewModel
{
    internal class CatalyseurViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public CatalyseurViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}