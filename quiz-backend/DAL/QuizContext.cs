using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_backend.DAL
{
    public class QuizContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }


        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options)
        {
        }


        public DbSet<quiz_backend.Models.Quiz> Quiz { get; set; }
    }
}
