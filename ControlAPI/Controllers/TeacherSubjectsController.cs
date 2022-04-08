#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlAPI.Contexts;
using ControlAPI.Models;

namespace ControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSubjectsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TeacherSubjectsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TeacherSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherSubject>>> GetTeacherSubject()
        {
            return await _context.TeacherSubject.ToListAsync();
        }

        // GET: api/TeacherSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherSubject>> GetTeacherSubject(Guid id)
        {
            var teacherSubject = await _context.TeacherSubject.FindAsync(id);

            if (teacherSubject == null)
            {
                return NotFound();
            }

            return teacherSubject;
        }

        // PUT: api/TeacherSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherSubject(Guid id, TeacherSubject teacherSubject)
        {
            if (id != teacherSubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacherSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherSubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TeacherSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherSubject>> PostTeacherSubject(TeacherSubject teacherSubject)
        {
            _context.TeacherSubject.Add(teacherSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherSubject", new { id = teacherSubject.Id }, teacherSubject);
        }

        // DELETE: api/TeacherSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherSubject(Guid id)
        {
            var teacherSubject = await _context.TeacherSubject.FindAsync(id);
            if (teacherSubject == null)
            {
                return NotFound();
            }

            _context.TeacherSubject.Remove(teacherSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherSubjectExists(Guid id)
        {
            return _context.TeacherSubject.Any(e => e.Id == id);
        }
    }
}
