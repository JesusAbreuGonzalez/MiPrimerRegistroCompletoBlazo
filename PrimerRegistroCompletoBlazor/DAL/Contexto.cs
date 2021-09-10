using Microsoft.EntityFrameworkCore;
using PrimerRegistroCompletoBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerRegistroCompletoBlazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Estudiantes { get; set; }

    }
}
