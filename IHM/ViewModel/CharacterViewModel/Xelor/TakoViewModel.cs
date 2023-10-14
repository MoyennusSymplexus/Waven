using IHM.Model;

namespace IHM.ViewModel
{
    internal class TakoViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public TakoViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}