using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using IHM.Commands.Build;
using IHM.Model;
using WavenCore.Classes;
using WavenCore.Equipments;
using WavenCore.Metadata;
using WavenCore.Nodes;
using ClassListing = WavenCore.Classes.Listing;
using EquipmentListing = WavenCore.Equipments.Listing;

namespace IHM.ViewModel
{
    internal class BuildViewModel : ObservableObject, IPageViewModel
    {
        #region Fields and Enums

        private readonly BuildModel       _build;
        private readonly ClassListing     _classListing     = new();
        private readonly EquipmentListing _equipmentListing = new();
        private          bool             _isLoadingClass;

        #endregion

        #region Constructors

        public BuildViewModel(BuildModel build) {
            _build = build;
            _build.SetCharacter(_classListing.GetCharacter(nameof(Bunelame)));
            ToungViewModel   = new ToungViewModel(_build);
            LermiteViewModel = new LermiteViewModel(_build);
            BuildLoaded      = new BuildLoadedCommand(this);
            AddToNode        = new AddNodeCommand(UpdateListNode);
            RemoveToNode     = new RemoveNodeCommand(UpdateListNode);
            AddLevel         = new AddLevelCommand(UpdateEquipments);
            RemoveLevel      = new RemoveLevelCommand(UpdateEquipments);
            LevelChanged     = new LevelChangedCommand(UpdateEquipments);
            RuneChanged      = new RuneChangedCommand(UpdateSummary);
            AddRing          = new AddRingCommand(UpdateEquipments, _build);
            AddCuff          = new AddCuffCommand(UpdateEquipments, _build);
            MaxAll           = new MaxAllCommand(UpdateAll, _build);
            RemoveEquipment  = new RemoveEquipmentCommand(UpdateEquipments, _build);
        }

        #endregion

        #region Properties

        public ToungViewModel   ToungViewModel   { get; }
        public LermiteViewModel LermiteViewModel { get; }

        public IEnumerable<string> ListClass {
            get {
                _isLoadingClass = true;
                return _classListing.GetClasses();
            }
        }
        public string SelectedListClass {
            get {
                OnPropertyChanged(nameof(SelectedListSubClass));
                return _build.Character.Class;
            }

            set {
                if (_isLoadingClass) {
                    _isLoadingClass = false;
                    return;
                }

                _build.SetCharacter(_classListing.GetCharacterFromClass(value));
                OnPropertyChanged(nameof(ListSubClass));
            }
        }
        public IEnumerable<string> ListSubClass => _classListing.GetSubClasses(SelectedListClass);

        public string SelectedListSubClass {
            get => _build.Character.SubClass;
            set {
                _build.SetCharacter(_classListing.GetCharacter(value));
                UpdateSummary();
            }
        }

        public IEnumerable<Equipment>          RingList        => _equipmentListing.GetRings();
        public IEnumerable<Equipment>          CuffList        => _equipmentListing.GetCuffs();
        public ObservableCollection<Equipment> Equipments      => new(_build.Equipment);
        public ObservableCollection<Node>      NodeList        => new(_build.Nodes);
        public CharacterStatSummary            Summary         => _build.GetSummary();
        public ICommand                        BuildLoaded     { get; }
        public ICommand                        LevelChanged    { get; }
        public ICommand                        RuneChanged     { get; }
        public ICommand                        AddToNode       { get; }
        public ICommand                        RemoveToNode    { get; }
        public ICommand                        AddLevel        { get; }
        public ICommand                        RemoveLevel     { get; }
        public ICommand                        AddRing         { get; }
        public ICommand                        AddCuff         { get; }
        public ICommand                        MaxAll          { get; }
        public ICommand                        RemoveEquipment { get; }

        #endregion

        #region IPageViewModel Members

        public string Name => "Build";

        #endregion

        private void UpdateListNode() {
            OnPropertyChanged(nameof(NodeList));
            UpdateSummary();
        }

        private void UpdateEquipments() {
            OnPropertyChanged(nameof(Equipments));
            UpdateSummary();
        }

        private void UpdateSummary() {
            OnPropertyChanged(nameof(Summary));
            ToungViewModel.Update();
            LermiteViewModel.Update();
        }

        private void UpdateAll() {
            OnPropertyChanged(nameof(Equipments));
            OnPropertyChanged(nameof(Summary));
            ToungViewModel.Update();
            LermiteViewModel.Update();
        }
    }
}