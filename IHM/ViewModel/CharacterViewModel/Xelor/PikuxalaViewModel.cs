using IHM.Model;

namespace IHM.ViewModel
{
    internal class PikuxalaViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public PikuxalaViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}