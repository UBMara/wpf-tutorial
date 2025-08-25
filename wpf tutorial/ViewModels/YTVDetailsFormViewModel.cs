using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf_tutorial.ViewModels
{
    public class YTVDetailsFormViewModel : ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get => _userName;
            set
            {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                    OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private bool _isSubscribed;

        public bool IsSubscribed
        {
            get => _isSubscribed;
            set
            {
                    _isSubscribed = value;
                    OnPropertyChanged(nameof(IsSubscribed));
            }
        }

        private bool _isMember;

        public bool IsMember
        {
            get => _isMember;
            set
            {
                    _isMember = value;
                    OnPropertyChanged(nameof(IsMember));
            }
        }
        private bool _isSubmitting;

        public bool IsSubmitting
        {
            get => _isSubmitting;
            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
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

        private bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public bool CanSubmit  => !string.IsNullOrEmpty(UserName);

        public ICommand SubmitComand { get;}

        public ICommand CancelComand { get; }

        public YTVDetailsFormViewModel(ICommand submitComand, ICommand cancelComand)
        {
            SubmitComand = submitComand;
            CancelComand = cancelComand;
        }
    }
}
