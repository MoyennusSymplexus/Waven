using IHM.Model;

namespace IHM.ViewModel
{
    internal class KasaiViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public KasaiViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}