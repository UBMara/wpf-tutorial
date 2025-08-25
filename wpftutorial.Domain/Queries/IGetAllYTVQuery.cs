using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Models;

namespace wpftutorial.Domain.Queries
{
    public  interface IGetAllYTVQuery
    {

        Task<IEnumerable<YTViewer>> Execute();
    }
}
