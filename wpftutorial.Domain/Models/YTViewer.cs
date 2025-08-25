using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpftutorial.Domain.Models
{
    public class YTViewer
    {

        public Guid Id { get; }
        public string UserName { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }
        public YTViewer(Guid id, string userName, bool isSubscribed, bool isMember)
        {
            Id = id;
            UserName = userName;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}