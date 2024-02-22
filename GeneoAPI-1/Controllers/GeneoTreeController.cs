using GeneoAPI_1.Entities;
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
[Route("api")]
public class GeneoTreeController : ControllerBase
{
    private readonly ILogger<GeneoTreeController> _logger;

    public GeneoTreeController(ILogger<GeneoTreeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("geneo-tree/{guid}")]
    public GeneoTree GetOne(Guid guid)
    {
        GeneoTree? tree;

        using(var context = new GeneoDbContext()) {
            tree = context.Trees.Find(guid.ToString());
        }

        return tree;
    }

    [HttpGet("geneo-trees")]
    public IEnumerable<GeneoTree> Get()
    {
        List<GeneoTree> trees;
        using(var context = new GeneoDbContext()) {
            trees = context.Trees.ToList();
        }

        return trees;
    }

    [HttpPost("geneo-tree")]
    public string Create(GeneoTree geneoTree)
    {
        geneoTree.TreeUuid = Guid.NewGuid().ToString();
        geneoTree.CreatedDate = DateTime.Now;

        using (var context = new GeneoDbContext())
        {
            context.Trees.Add(geneoTree);
            context.SaveChanges();
        }


        return geneoTree.ShortName;
    }
}