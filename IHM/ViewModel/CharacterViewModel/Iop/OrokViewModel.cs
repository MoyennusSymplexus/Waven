using IHM.Model;

namespace IHM.ViewModel
{
    internal class OrokViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public OrokViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}