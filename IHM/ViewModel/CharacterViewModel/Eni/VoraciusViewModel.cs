using IHM.Model;

namespace IHM.ViewModel
{
    internal class VoraciusViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public VoraciusViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}