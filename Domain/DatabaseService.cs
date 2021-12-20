using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DatabaseService 
    {

        public IPost Posts { get; set; }
        public IUser Users { get; set; }
    }
}
