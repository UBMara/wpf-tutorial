using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_tutorial.Commands;
using wpf_tutorial.Stores;

namespace wpf_tutorial.ViewModels
{
    public class YTVViewModel :ViewModelBase
    {
        public YTVListingModelView YTVListingModelView { get;}
        public YTVDetailsModelView YTVDetailsModelView { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand LoadCommand { get; }
        public ICommand AddYTViewerCommand { get; }

        public YTVViewModel(YTVStore ytvStore, SelectedYTVStore selectedYTViewer, ModelNavigationStore modelNavigationStore)
        {
            YTVListingModelView = new YTVListingModelView(ytvStore, selectedYTViewer, modelNavigationStore);
            YTVDetailsModelView = new YTVDetailsModelView(selectedYTViewer);

            LoadCommand = new LoadCommand(this, ytvStore);
            AddYTViewerCommand = new OpenAddYTVCommand(ytvStore, modelNavigationStore);
        }
        public static YTVViewModel LoadViewModel(YTVStore ytvStore, SelectedYTVStore selectedYTViewer, ModelNavigationStore modelNavigationStore)
        {
            YTVViewModel viewModel = new YTVViewModel(ytvStore, selectedYTViewer, modelNavigationStore);

            viewModel.LoadCommand.Execute(null);

            return viewModel;
        }

    }
}
