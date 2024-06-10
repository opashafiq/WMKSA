using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDBContext _context;

        public PersonRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPerson(Person toCreate)
        {
            _context.Persons.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<Person> DeletePerson(int personId)
        {
            var person = _context.Persons
                .FirstOrDefault(p => p.Id == personId);

            if (person is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.Persons.Remove(person);

            await _context.SaveChangesAsync();
            return person;

        }



        public async Task<ICollection<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int personId)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == personId);
        }

        public async Task<Person> UpdatePerson(Person toUpdate /*int personId, string name, string email*/)
        {
            //var person = await _context.Persons
            //    .FirstOrDefaultAsync(p => p.Id == personId);

            //person.Name = name;
            //person.Email = email;

            _context.Persons.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
