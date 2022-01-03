using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Functions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DatabaseService: IDatabaseService
    {
        public DatabaseService(IPost posts, IUser users)
        {
            Posts = posts;
            Users = users;
        }
        

        public IPost Posts { get; set; }
        public IUser Users { get; set; }
        
    }
}
