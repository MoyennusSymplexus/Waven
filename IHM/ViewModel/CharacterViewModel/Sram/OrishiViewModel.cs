using IHM.Model;

namespace IHM.ViewModel
{
    internal class OrishiViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public OrishiViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}