using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Models;

namespace wpf_tutorial.Stores
{
    public class SelectedYTVStore 
    {
        private YTViewer _selectedYTViewer;

        public YTViewer SelectedYTViewer
        {
            get { return _selectedYTViewer; }
            set
            {
                _selectedYTViewer = value;
                SelectedYTVChanged?.Invoke();
            }
        }

        public event Action SelectedYTVChanged;
    }
}
