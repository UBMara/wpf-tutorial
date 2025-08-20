using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Models;
using wpf_tutorial.Stores;

namespace wpf_tutorial.ViewModels
{
    internal class YTVDetailsModelView : ViewModelBase
    {
        private readonly SelectedYTVStore _selectedYTViewerStore;

        public bool HasSelectedYTViewer => _selectedYTViewerStore.SelectedYTViewer != null;

        public string UserName => _selectedYTViewerStore.SelectedYTViewer?.UserName ?? "UnKnown";

        public string IsSubscribedDisplay => (_selectedYTViewerStore.SelectedYTViewer?.IsSubscribed ?? false) ? "Yes" : "No";

        public string IsMemberDisplay => (_selectedYTViewerStore.SelectedYTViewer?.IsMember ?? false) ? "Yes" : "No";

        public YTVDetailsModelView(SelectedYTVStore selectedYTViewerStore)
        {
            _selectedYTViewerStore = selectedYTViewerStore;

            _selectedYTViewerStore.SelectedYTVChanged += SelectedYTViewrStore_SelectedYTViChanged;
        }

        protected override void Dispose()
        {
            _selectedYTViewerStore.SelectedYTVChanged -= SelectedYTViewrStore_SelectedYTViChanged;
            base.Dispose();
        }

        private void SelectedYTViewrStore_SelectedYTViChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYTViewer));
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }
    }
}
