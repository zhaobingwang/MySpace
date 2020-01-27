add-migration InitializeMySpaceDbConfiguration -c MySpaceDbContext -o Data/Migrations/MSSQLServer/MySpaceDb
update-database -c MySpaceDbContext