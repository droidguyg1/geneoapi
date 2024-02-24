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
[Table("person")]
public class Person
{
    [Key]
    // [Column("uuid")]
    public string? Uuid { get; set; }
    
    // [Column("created_datetime")]
    public DateTime CreatedDate { get; set; }
    
    [Required]
    [MaxLength(50)]
    // [Column("first_name")]
    public string? FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    // [Column("last_name")]
    public string? LastName { get; set; }

    [Required]
    // [Column("birth_date")]
    public DateOnly? BirthDate { get; set; }

    [Required]
    // [Column("geneo_tree_uuid")]
    public virtual GeneoTree GeneoTree { get; set; }
    
}