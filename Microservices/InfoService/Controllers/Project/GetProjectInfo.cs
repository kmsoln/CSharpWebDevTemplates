using InfoService.Config;
using Microsoft.AspNetCore.Mvc;

namespace InfoService.Controllers.Project;

public partial class ProjectController
{
    [HttpGet("GetProjectInfo")]
    public IActionResult GetProjectInfo()
    {
        Log(LogLevel.Information, "GetProjectInfo method called.");
        
        return Ok(new
        {
            ProjectName = ProjectInfo.ProjectName,
            StudentName = ProjectInfo.StudentName,
            StudentGroup = ProjectInfo.StudentGroup
        });
    }
}