# attention-please

A tool to count down those days to celebrate.


## Database migrations

A small section to remember the flow for mgrations when dealing with combinations of EFCore, 
NHibernate, SqlServer and PostGres


```
#Example
dotnet run "AttentionPlease:DbProvider=SqlServer" "ConnectionStrings:Storage=TheProdConnStringForMigrations"
```