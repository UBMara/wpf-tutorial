using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_tutorial.Models
{
    public class YTViewer
    {

        public string UserName { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }
        public YTViewer(string userName, bool isSubscribed, bool isMember)
        {
            UserName = userName;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}
