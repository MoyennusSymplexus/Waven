using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using IHM.Model;

namespace IHM.ViewModel
{
    public class ApplicationViewModel : ObservableObject
    {
        #region Fields and Enums

        private readonly BuildModel _build = new();

        #endregion

        #region Constructors

        public ApplicationViewModel() {
            // Add available pages
            PageViewModels.Add(new BuildViewModel(_build));
            PageViewModels.Add(new CharacterViewModel(_build));
            PageViewModels.Add(new LevelingViewModel());
            PageViewModels.Add(new GlossaireViewModel());
            PageViewModels.Add(new ShopCostViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #endregion

        #region Properties

        public ICommand ChangePageCommand => _changePageCommand ??= new RelayCommand(p => ChangeViewModel((IPageViewModel) p), p => p is IPageViewModel);

        public List<IPageViewModel?> PageViewModels => _pageViewModels ??= new List<IPageViewModel?>();

        public IPageViewModel? CurrentPageViewModel {
            get => _currentPageViewModel;
            private set {
                if (_currentPageViewModel == value) {
                    return;
                }

                _currentPageViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel? viewModel) {
            if (!PageViewModels.Contains(viewModel)) {
                PageViewModels.Add(viewModel);
            }

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion

        #region Fields

        private ICommand?              _changePageCommand;
        private IPageViewModel?        _currentPageViewModel;
        private List<IPageViewModel?>? _pageViewModels;

        #endregion
    }
}