using IHM.Model;

namespace IHM.ViewModel
{
    internal class ExpingoleViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public ExpingoleViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}