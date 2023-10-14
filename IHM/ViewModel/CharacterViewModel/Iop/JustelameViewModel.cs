using IHM.Model;

namespace IHM.ViewModel
{
    internal class JustelameViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public JustelameViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}