using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeneoAPI_1.Models;

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
[Table("geneo_tree")]
public class GeneoTree
{
    [Key]
    [Column("tree_uuid")]
    public string? TreeUuid { get; set; }
    
    [Column("created_datetime")]
    public DateTime CreatedDate { get; set; }
    
    [Column("short_name")]
    public string? ShortName { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }

    public virtual ICollection<Person> Persons { get; set; }
}