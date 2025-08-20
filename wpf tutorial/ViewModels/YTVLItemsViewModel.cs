using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_tutorial.Models;

namespace wpf_tutorial.ViewModels
{
    internal class YTVLItemsViewModel : ViewModelBase
    {
        public YTViewer YTViewer { get; }

        public string UserName => YTViewer.UserName;

        public ICommand EditComand { get;}

        public ICommand DeleteComand { get; }

        public YTVLItemsViewModel(YTViewer yTViewer)
        {
            YTViewer = yTViewer;
        }
    }
}
