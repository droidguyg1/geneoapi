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
1. To be moved from here to schema migration mechanism.
2. Migration mechanism:
    3. Via Rider?  How is it represented/usable for devs using different IDE?
    4. Other?

Schema:

```sql
create table geneo_tree
(
    short_name       varchar(25)   default ''            not null,
    description      varchar(255)   default ''           not null,
    created_datetime timestamp default CURRENT_TIMESTAMP not null,
    tree_uuid        varchar(25)                         not null,
    constraint geneo_tree_pk
        primary key (tree_uuid)
)
    comment 'GeneoTree, a root of every genealogy tree';
```