--Borrowed from http://bit.ly/1SLYVEy
USE BowlingStats                      -- The database I had recently attached
EXEC sp_change_users_login 'Report'	  -- Report will show 'Orphaned Users'
EXEC sp_change_users_login 'Auto_Fix', 'BowlingManager', NULL, 'Bowl300'  --Fix specific orphaned user