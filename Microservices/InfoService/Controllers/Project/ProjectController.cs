using Microsoft.AspNetCore.Mvc;

namespace InfoService.Controllers.Project;

[ApiController]
[Route("api/[Controller]")]
public partial class ProjectController(
    ILogger<ProjectController> logger
) : Controller;