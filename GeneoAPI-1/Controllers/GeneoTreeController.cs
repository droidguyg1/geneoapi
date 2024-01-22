using Microsoft.AspNetCore.Mvc;

namespace GeneoAPI_1.Controllers;

[ApiController]
[Route("tree")]
public class GeneoTreeController : ControllerBase
{
    private readonly ILogger<GeneoTreeController> _logger;

    public GeneoTreeController(ILogger<GeneoTreeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGeneoTree")]
    public IEnumerable<GeneoTree> Get()
    {
        return Enumerable.Range(1, 2).Select(index => new GeneoTree
            {
                CreatedDate = DateTime.Now,
                ShortName = "TREE" + Random.Shared.Next(1, 99999),
                Description = "Some description here."
            })
            .ToArray();
    }

    [HttpPost(Name = "CreateGeneoTree")]
    public string Create(GeneoTree geneoTree)
    {
        return geneoTree.ShortName;
    }
}