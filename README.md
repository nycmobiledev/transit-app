transit-app
===========

The latest versions of client and server portion of the transit apo reside here.

/client - Xamarin mobile platform versions
/service - Azure C# webservice files

# Setting up Local Development  Environemt

1. Create a Local SQL Database called mta_nyc_subway
2. Execute service/DBScripts/Schema.sql to create the tables and stored Procs. Note: this is repeatable to reresh the schema
3. Set up the ConnectionString in the web/app.config to point to the database
4. Populate Data  
	Option 1) Run unit tests from service\TransitApp.Server\WebApi.TestConsole\JobsTest.cs
	Option 2) Start the WebApi project and execute Web Jobs GTFSStatic , GTFSRealtime
5. Run the WebProject and get the local URL