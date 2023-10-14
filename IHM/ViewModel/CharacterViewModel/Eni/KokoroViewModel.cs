using IHM.Model;

namespace IHM.ViewModel
{
    internal class KokoroViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public KokoroViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}