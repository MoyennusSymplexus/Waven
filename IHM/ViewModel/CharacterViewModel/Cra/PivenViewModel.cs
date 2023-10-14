using IHM.Model;

namespace IHM.ViewModel
{
    internal class PivenViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public PivenViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}