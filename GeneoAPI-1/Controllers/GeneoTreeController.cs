using Microsoft.AspNetCore.Mvc;

/*
        Licensed under the Apache License, Version 2.0 (the "License");
        you may not use this file except in compliance with the License.
        You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

        Unless required by applicable law or agreed to in writing, software
        distributed under the License is distributed on an "AS IS" BASIS,
        WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
        or implied. See the License for the specific language governing
        permissions and limitations under the License.
*/

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