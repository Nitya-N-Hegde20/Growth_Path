using GRowthPath.AssignmentAPI.Models.DTO;
using GRowthPath.AssignmentAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRowthPath.AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {

        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost("assign-course")]
        public async Task<IActionResult> AssignCourse([FromBody] CourseAssignmentDto request)
        {
            if (string.IsNullOrEmpty(request.EmployeeId) || request.CourseId == 0)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    Message = "Employee ID and Course ID are required."
                });
            }

            var result = await _assignmentService.AssignCourse(request.EmployeeId, request.CourseId);

            if (!result)
            {
                return Conflict(new ApiResponse
                {
                    IsSuccess = false,
                    Message = "Course already assigned to this employee."
                });
            }

            return Ok(new ApiResponse
            {
                IsSuccess = true,
                Message = "Course assigned successfully."
            });
        }

    }

}


