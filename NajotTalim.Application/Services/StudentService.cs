using Microsoft.EntityFrameworkCore;
using NajotTalim.Application.Abstractions;
using NajotTalim.Application.Models;
using NajotTalim.Domain.Entities;

namespace NajotTalim.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext _context;

        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CreateStudentModel model)
        {
            var student = new Student()
            {
                FullName = model.FullName,
                BirthDate = model.BirthDate,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.UtcNow
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
           if (student == null)
            {
                throw new Exception("Not found");
            }

           _context.Students.Remove(student);
           await _context.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            return await _context.Students.Select(x => new StudentViewModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                PhoneNumber = x.PhoneNumber
            }).ToListAsync(); 
        }

        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                throw new Exception("Not found");
            }

            return new StudentViewModel()
            {
                Id = student.Id,
                FullName = student.FullName,
                BirthDate = student.BirthDate,
                PhoneNumber = student.PhoneNumber
            };
        }

        public async Task UpdateAsync(UpdateStudentModel model)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            entity.FullName = model.FullName ?? entity.FullName;
            entity.BirthDate = model.BirthDate ?? entity.BirthDate;
            entity.PhoneNumber = model.PhoneNumber ?? entity.PhoneNumber;

            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
