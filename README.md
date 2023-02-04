
# rifaz
app de rifas <br>
aplicação feita em .Net Core 6

# DATABASE

<img src="./img/re.png" width="40%">


# ANOTATIONS



## MIGRATIONS

    cd App.Rifas.Core.DataAccess
    
### CREATE MIGRATIONS

    dotnet ef --startup-project ../App.Rifas.Core.Api/App.Rifas.Core.Api migrations add myMigration01


### UPDATE MIGRATIONS
	
	dotnet ef --startup-project ../App.Rifas.Core.Api/App.Rifas.Core.Api database update
	

### REMOVE MIGRATIONS

	dotnet ef --startup-project ../App.Rifas.Core.Api/App.Rifas.Core.Api migrations remove
