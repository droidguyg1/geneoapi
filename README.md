# GeneoAPI

GeneoAPI is an Open Source (xxx license) generic API to manage genealogy tree with Database storage.

## License

        Licensed under the Apache License, Version 2.0 (the "License");
        you may not use this file except in compliance with the License.
        You may obtain a copy of the License at
        
        http://www.apache.org/licenses/LICENSE-2.0
        
        Unless required by applicable law or agreed to in writing, software
        distributed under the License is distributed on an "AS IS" BASIS,
        WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
        or implied. See the License for the specific language governing
        permissions and limitations under the License.


## Available Operations

### Create A New Tree

POST /tree

Body:
```json
{
  "short_name": "unique string",
  "description": "string"
}
```

## Database Schema

Note:
1. For now, the truth about the DB schema is in the models of the GeneoAPI project.
2. .Net Migration mechanism (seems a good solution to me so far):
    * Create an initial migration: `dotnet ef migrations add InitialCreate`
    * Create an SQL script from migrations: `dotnet ef migrations script`
    * Apply the schema migrations to the DB: `dotnet ef database update` 

Schema:

```sql
CREATE TABLE `geneo_tree` (
  `short_name` varchar(25) NOT NULL DEFAULT '',
  `description` varchar(255) NOT NULL DEFAULT '',
  `created_datetime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE current_timestamp(),
  `tree_uuid` char(50) NOT NULL,
  PRIMARY KEY (`tree_uuid`)
) 
ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci 
COMMENT='GeneoTree, a root of every genealogy tree'
```

## TODOs

* For geneo tree uuid and create date:
    * attach to response to user if provided in the request: "TreeUid/CreateDate is ignored; value provided by the system."
* Remove "ON UPDATE current_timestamp()" from geneo tree DDL.