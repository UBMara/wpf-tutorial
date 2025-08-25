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
    public class EditYTVViewModel : ViewModelBase
    {
        public Guid viewrID { get;}
        public YTVDetailsFormViewModel YTVDetailsFormViewModel { get; }

        public EditYTVViewModel(YTViewer yTViewer, YTVStore ytvStore, ModelNavigationStore modelNavigationStore)
        {
            viewrID = yTViewer.Id;

            ICommand submitComand = new EditCommand(this, ytvStore, modelNavigationStore);
            ICommand cancelComand = new CloseModalCommand(modelNavigationStore);

            YTVDetailsFormViewModel = new YTVDetailsFormViewModel(submitComand, cancelComand)
            {
                UserName = yTViewer.UserName,
                IsSubscribed = yTViewer.IsSubscribed,
                IsMember = yTViewer.IsMember
            };
        }
    }
}
