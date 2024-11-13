using GRowthPath.AssignmentAPI.Data;
using GRowthPath.AssignmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GRowthPath.AssignmentAPI.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly AssignmentDbContext _context;

        public AssignmentService(AssignmentDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignCourse(string employeeId, int courseId)
        {
            // Check if the course is already assigned to the employee
            var existingAssignment = await _context.CourseAssignments
.AnyAsync(a => a.EmployeeId == employeeId && a.CourseId == courseId);
            if (existingAssignment)
            {
                return false;  // Already assigned
            }

            // Assign the course to the employee
            var assignment = new CourseAssignment
            {
                EmployeeId = employeeId,
                CourseId = courseId
            };

            _context.CourseAssignments.Add(assignment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
