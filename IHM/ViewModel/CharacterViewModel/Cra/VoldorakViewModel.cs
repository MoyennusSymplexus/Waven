using IHM.Model;

namespace IHM.ViewModel
{
    internal class VoldorakViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public VoldorakViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}