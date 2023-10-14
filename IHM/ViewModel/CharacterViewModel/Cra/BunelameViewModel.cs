﻿using IHM.Model;

namespace IHM.ViewModel
{
    internal class BunelameViewModel : ICharacterViewModel
    {
        #region Fields and Enums

        private readonly BuildModel _build;

        #endregion

        #region Constructors

        public BunelameViewModel(BuildModel build) {
            _build = build;
        }

        #endregion
    }
}