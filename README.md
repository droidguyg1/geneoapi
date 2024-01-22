# GenealogyAPI

GenealogyAPI is an Open Source (xxx license) generic API to manage genealogy tree with Database storage.

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

```sql
create table geneo_tree
(
    short_name       VARCHAR   default ''                not null,
    description      varchar   default ''                not null,
    created_datetime timestamp default CURRENT_TIMESTAMP not null,
    tree_id          uuid                                null,
    constraint geneo_tree_pk
    primary key (tree_id)
)
comment 'GeneoTree, a root of every genealogy tree';
```