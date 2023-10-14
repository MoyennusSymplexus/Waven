using IHM.Model;

namespace IHM.ViewModel
{
    internal class GemmeViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public GemmeViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}