﻿using Microsoft.EntityFrameworkCore;
using StudentManagmentWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentWPF.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7O1MGHI\SQLEXPRESS;Initial Catalog=StudentManagment;Integrated Security=True;TrustServerCertificate=True");


        }
    }
}