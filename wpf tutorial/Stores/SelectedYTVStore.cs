using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Models;

namespace wpf_tutorial.Stores
{
    public class SelectedYTVStore 
    {
        private YTViewer _selectedYTViewer;
        private readonly YTVStore _ytvStore;

        public event Action SelectedYTVChanged;

        public SelectedYTVStore(YTVStore ytvStore)
        {
            _ytvStore = ytvStore;

            _ytvStore.YTVAddedEvent += ytvStore_YTVAdded;
            _ytvStore.YTVUpdated += ytvStore_YTVUpdated;
        }

        private void ytvStore_YTVAdded(YTViewer viewer)
        {
            SelectedYTViewer = viewer;
        }

        private void ytvStore_YTVUpdated(YTViewer viewer)
        {

            if (viewer.Id == SelectedYTViewer?.Id)
            {
                SelectedYTViewer = viewer;
            }
        }

        public YTViewer SelectedYTViewer
        {
            get { return _selectedYTViewer; }
            set
            {
                _selectedYTViewer = value;
                SelectedYTVChanged?.Invoke();
            }

        }
    }
}
