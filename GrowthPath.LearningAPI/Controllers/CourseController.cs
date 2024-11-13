using GrowthPath.LearningAPI.Models;
using GrowthPath.LearningAPI.Models.DTO;
using GrowthPath.LearningAPI.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrowthPath.LearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ResponseDTO _response = new ResponseDTO();
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddCourse(Course course)
        {
            var createdCourse = await _courseService.AddCourseAsync(course);
            _response.IsSuccess = true;
            _response.Message = "Course added successfully";
            _response.Result = createdCourse;
            return Ok(_response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId) return BadRequest("Course ID mismatch");

            var updated = await _courseService.UpdateCourseAsync(course);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await _courseService.DeleteCourseAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}

