using GeneoAPI_1.Models;
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
public class PersonController : ControllerBase
{
    private readonly ILogger<GeneoTreeController> _logger;

    public PersonController(ILogger<GeneoTreeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("person/{guid}")]
    public Person GetOne(Guid guid)
    {
        Person? person;

        using(var context = new GeneoDbContext()) {
            person = context.Persons.Find(guid.ToString());
        }
        _logger.LogInformation($"Returned person for ID={guid}");

        return person;
    }

    [HttpPost("person")]
    public string Create(Person person)
    {
        person.Uuid = Guid.NewGuid().ToString();
        person.CreatedDate = DateTime.Now;

        using (var context = new GeneoDbContext())
        {
            context.Persons.Add(person);
            context.SaveChanges();
        }


        return person.Uuid;
    }
}