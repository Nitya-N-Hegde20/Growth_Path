
using GRowthPath.AssignmentAPI.Models.DTO;

namespace GRowthPath.AssignmentAPI.Service
{
    public interface IAssignmentService
    {
        Task<bool> AssignCourse(string employeeId, int courseId);
        //Task<IEnumerable<CourseAssignmentDto>> GetAllAssignmentsAsync();
        //Task<CourseAssignmentDto> GetAssignmentByIdAsync(int assignmentId);
        //Task<bool> UpdateAssignmentAsync(int assignmentId, CourseAssignmentDto updatedAssignment);
        //Task<bool> DeleteAssignmentAsync(int assignmentId);

    }
}