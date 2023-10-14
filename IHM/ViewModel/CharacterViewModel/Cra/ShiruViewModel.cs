using IHM.Model;

namespace IHM.ViewModel
{
    internal class ShiruViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public ShiruViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}