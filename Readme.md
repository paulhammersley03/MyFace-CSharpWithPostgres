# "MyFace" Social Network Exercise


## Install software

You'll need Postgres server and PG Admin.  
You probably already have this installed.

If you don't, you can download PG Admin from [here](https://www.pgadmin.org/download/pgadmin-4-windows/).
When running through the installer you can keep all the default options and choose a sensible root password.


## Setup

* Open PGAdmin workbench
* Create a Database called my `myface`
* Create a schema called `myface`.
* Using the Query tool run the `bootstrapDatabase.sql` script to create the tables and insert some test data.

* Then create a connection.config inside the MyFace Project folder
* Add the following xml to the file and replace the User Id and the Password.
```
<connectionStrings>
  <add name="MyPostgres" providerName="System.Data.SqlClient" connectionString="Server=127.0.0.1;Port=5432;Database=myface;User Id=YourUserId; Password=YourPassword;" />
</connectionStrings>
```
