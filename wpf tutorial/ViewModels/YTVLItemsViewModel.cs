using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_tutorial.Commands;
using wpftutorial.Domain.Models;
using wpf_tutorial.Stores;

namespace wpf_tutorial.ViewModels
{
    public class YTVLItemsViewModel : ViewModelBase
    {
        public YTViewer YTViewer { get; private set; }

        public string UserName => YTViewer.UserName;

        private bool _isDeleting;

        public bool IsDeleting
        {
            get { return _isDeleting; }
            set
            {
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
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

        public ICommand EditComand { get;}

        public ICommand DeleteComand { get; }

        public YTVLItemsViewModel(YTViewer ytViewr, YTVStore ytvStore, ModelNavigationStore modelNavigationStore)
        {
            YTViewer = ytViewr;

            EditComand = new OpenEditCommand(this, ytvStore, modelNavigationStore);
            DeleteComand = new DeleteCommand(this, ytvStore);
        }

        public void Update(YTViewer viewer)
        {
            YTViewer = viewer;

            OnPropertyChanged(nameof(UserName));
        }
    }
}
