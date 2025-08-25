using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Models;
using wpftutorialFramework.DTOs;

namespace wpftutorialFramework
{
    public class YTViewrsDBContext : DbContext
    {

        public DbSet<YTViewerDTO> YTViewers { get; set; }
        public YTViewrsDBContext(DbContextOptions options) : base(options) { }
    }
}
