using System;
using System.Collections.Generic;
using System.Windows.Input;
using IHM.Model;
using WavenCore.Classes;
using WavenCore.Spells;

namespace IHM.ViewModel
{
    internal class CharacterViewModel : ObservableObject, IPageViewModel
    {
        #region Fields and Enums

        private readonly BuildModel     _build;
        private readonly SpellViewModel _spellViewModel;

        #endregion

        #region Constructors

        public CharacterViewModel(BuildModel build) {
            _build          = build;
            _spellViewModel = new SpellViewModel(_build, UpdateSummary);
        }

        #endregion

        #region Properties

        public ICharacterViewModel? CurrentCharacterViewModel {
            get {
                Type type = Type.GetType($"IHM.ViewModel.{_build.Character.SubClass}ViewModel", true) ?? throw new InvalidOperationException();
                return (ICharacterViewModel?) Activator.CreateInstance(type, _build);
            }
        }
        public IEnumerable<SpellWithSummary> Spells       => _spellViewModel.Spells;
        public ICommand                      RuneChanged  => _spellViewModel.RuneChanged;
        public ICommand                      LevelChanged => _spellViewModel.LevelChanged;
        public ICommand                      AddLevel     => _spellViewModel.AddLevel;
        public ICommand                      RemoveLevel  => _spellViewModel.RemoveLevel;
        public IEnumerable<Passive>          Passives     => _build.GetPassives();

        #endregion

        #region IPageViewModel Members

        public string Name => "Character";

        #endregion

        private void UpdateSummary() {
            OnPropertyChanged(nameof(Spells));
        }
    }
}