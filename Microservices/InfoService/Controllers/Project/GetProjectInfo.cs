using InfoService.Config;
using Microsoft.AspNetCore.Mvc;

namespace InfoService.Controllers.Project;

public partial class ProjectController
{
    [HttpGet("GetProjectInfo")]
    public IActionResult GetProjectInfo()
    {
        ProjectInfo projectInfo = new();

        return Ok(projectInfo);
    }
}