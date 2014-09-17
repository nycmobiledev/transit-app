transit-app
===========

The latest versions of client and server portion of the transit apo reside here.

/client - Xamarin mobile platform versions
/service - Azure C# webservice files

# Setting up Local Development  Environemt

1. Create a Local SQL Database called mta_nyc_subway
2. Execute Schema.sql to create the tables and stored Procs
3. Set up the Connection settings to point to the databnase
4. Fill Data Option 1) Run unit tests. 2) execute Web Jobs GTFSStatic , GTFSRealtime
5. Run the WebProject and get the URL