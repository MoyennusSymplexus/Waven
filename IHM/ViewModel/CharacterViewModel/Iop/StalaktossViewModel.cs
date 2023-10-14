using IHM.Model;

namespace IHM.ViewModel
{
    internal class StalaktossViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public StalaktossViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}