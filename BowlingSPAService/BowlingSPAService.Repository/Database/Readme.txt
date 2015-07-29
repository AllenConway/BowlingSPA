1. Restore BowlingStats.bak to your SQL Server Instance
2. Use the Restore Orphaned User.sql script if you wish to restore the 'BowlingManager' orphaned user (from configuration). You may create or use your own new or existing user, and this is NOT a required step.
3. Update the connection string for Entity Framework in both App.Config within the Repository layer and Web.Config in the WebAPI layer
