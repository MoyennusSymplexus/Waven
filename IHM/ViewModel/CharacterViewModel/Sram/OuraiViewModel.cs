using IHM.Model;

namespace IHM.ViewModel
{
    internal class OuraiViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public OuraiViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}