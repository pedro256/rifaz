
# rifaz
app de rifas


## ANOTATIONS



### CREATE MIGRATIONS

    cd App.Rifas.Core.DataAccess

    dotnet ef --startup-project ../App.Rifas.Core.Api/App.Rifas.Core.Api migrations add myMigration01


### UPDATE MIGRATIONS
	
	dotnet ef --startup-project ../App.Rifas.Core.Api/App.Rifas.Core.Api database update
	

### REMOVE MIGRATIONS

	dotnet ef --startup-project ../App.Rifas.Core.Api/App.Rifas.Core.Api migrations remove
