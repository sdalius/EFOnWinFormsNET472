using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Context;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Repositories
{
    public class PetsRepository
    {
        private readonly MacAssignmentContext _context;

        public PetsRepository(MacAssignmentContext context)
        {
            _context = context;
        }

        public async Task<List<Pets>> Read()
        {
            var pets = await _context.Pets.ToListAsync();
            return pets;
        }

        public async Task CreateAsync()
        {
            var petList = new List<Pets>
            {
                new Pets
                {
                     Name="atsibodai"
                },
                                new Pets
                {
                     Name="tu"
                },
                                                new Pets
                {
                     Name="esi"
                },
                                                                new Pets
                {
                     Name="atsibodai"
                },
                                                                                new Pets
                {
                     Name="man"
                },
                                                                                                new Pets
                {
                     Name="tu"
                },
                                                                                                                new Pets
                {
                     Name="jau"
                },
                                                                                                                                new Pets
                {
                     Name="hehe"
                }
            };


            await _context.AddRangeAsync(petList);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(List<Pets> petsList)
        {
            _context.UpdateRange(petsList);

            await _context.SaveChangesAsync();
        }
    }
}
