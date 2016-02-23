1. Restore BowlingStats.bak to your SQL Server Instance
2. Ensure 'SQL Server and Windows Authentication mode' is set in the 'Security' properties for the SQL Server instance. After doing so right-click instance and select 'Restart'. Without allowing mixed mode logins, the new user even after restoring will never be able to log on.
3. Use the Restore Orphaned User.sql script if you wish to restore the 'BowlingManager' orphaned user (from configuration). You may create or use your own new or existing user, and this is NOT a required step.
4. Update the connection string for Entity Framework in both App.Config within the Repository layer and Web.Config in the WebAPI layer
