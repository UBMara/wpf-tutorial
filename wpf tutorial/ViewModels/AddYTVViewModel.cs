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
    public class AddYTVViewModel : ViewModelBase
    {
        public YTVDetailsFormViewModel YTVDetailsFormViewModel { get; }

        public AddYTVViewModel(YTVStore ytvStore, ModelNavigationStore modelNavigationStore)
        {
            ICommand cancelComand = new CloseModalCommand(modelNavigationStore);
            ICommand submitCommand = new AddCommand(this, ytvStore, modelNavigationStore);

            YTVDetailsFormViewModel = new YTVDetailsFormViewModel(submitCommand, cancelComand);
        }

    }
}
