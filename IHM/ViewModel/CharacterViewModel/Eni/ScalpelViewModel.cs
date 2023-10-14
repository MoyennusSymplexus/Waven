using IHM.Model;

namespace IHM.ViewModel
{
    internal class ScalpelViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public ScalpelViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}