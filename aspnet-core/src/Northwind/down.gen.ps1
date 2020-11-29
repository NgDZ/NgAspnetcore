





$url = "https://raw.githubusercontent.com/harryho/db-samples/master/sqlite/northwind_core.sql" 
$output = "Northwind.sql"
$start_time = Get-Date

Invoke-WebRequest -Uri $url -OutFile $output

dotnet ef dbcontext scaffold "DataSource=Northwind.db;Cache=Shared" Microsoft.EntityFrameworkCore.Sqlite -c NorthwindDbContext --force


Move-Item .\Northwind.db ..\NgAspnetcore.HttpApi.Host\