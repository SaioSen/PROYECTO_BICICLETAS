﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PROYECTO_BICICLETAS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PROYECTO_BICICLETAS.Models.Producto> Productos {get;set;}

        public DbSet<PROYECTO_BICICLETAS.Models.Proforma> Proformas {get;set;}
        public DbSet<PROYECTO_BICICLETAS.Models.Pago> Pago {get;set;}

        

    }
}
