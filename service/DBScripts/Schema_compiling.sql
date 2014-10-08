--USE [mta_nyc_subway]

/****** Object:  Table [dbo].[agency]    Script Date: 9/10/2014 5:41:11 PM ******/


/****** Object:  StoredProcedure [dbo].[sp_BuildStations]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_BuildStations]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_BuildStations]
GO
/****** Object:  Table [dbo].[trips]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[trips]') AND type in (N'U'))
DROP TABLE [dbo].[trips]
GO
/****** Object:  Table [dbo].[transfers]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[transfers]') AND type in (N'U'))
DROP TABLE [dbo].[transfers]
GO
/****** Object:  Table [dbo].[stops]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[stops]') AND type in (N'U'))
DROP TABLE [dbo].[stops]
GO
/****** Object:  Table [dbo].[stop_times]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[stop_times]') AND type in (N'U'))
DROP TABLE [dbo].[stop_times]
GO
/****** Object:  Table [dbo].[station_stops]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[station_stops]') AND type in (N'U'))
DROP TABLE [dbo].[station_stops]
GO
/****** Object:  Table [dbo].[station_routes]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[station_routes]') AND type in (N'U'))
DROP TABLE [dbo].[station_routes]
GO
/****** Object:  Table [dbo].[station]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[station]') AND type in (N'U'))
DROP TABLE [dbo].[station]
GO
/****** Object:  Table [dbo].[shapes]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shapes]') AND type in (N'U'))
DROP TABLE [dbo].[shapes]
GO
/****** Object:  Table [dbo].[routes]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[routes]') AND type in (N'U'))
DROP TABLE [dbo].[routes]
GO
/****** Object:  Table [dbo].[realtime_vehicle_position]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[realtime_vehicle_position]') AND type in (N'U'))
DROP TABLE [dbo].[realtime_vehicle_position]
GO
/****** Object:  Table [dbo].[realtime_trips]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[realtime_trips]') AND type in (N'U'))
DROP TABLE [dbo].[realtime_trips]
GO
/****** Object:  Table [dbo].[realtime_stop_time_updates]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[realtime_stop_time_updates]') AND type in (N'U'))
DROP TABLE [dbo].[realtime_stop_time_updates]
GO
/****** Object:  Table [dbo].[realtime_alerts]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[realtime_alerts]') AND type in (N'U'))
DROP TABLE [dbo].[realtime_alerts]
GO
/****** Object:  Table [dbo].[calendar_dates]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[calendar_dates]') AND type in (N'U'))
DROP TABLE [dbo].[calendar_dates]
GO
/****** Object:  Table [dbo].[calendar]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[calendar]') AND type in (N'U'))
DROP TABLE [dbo].[calendar]
GO
/****** Object:  Table [dbo].[agency]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[agency]') AND type in (N'U'))
DROP TABLE [dbo].[agency]
GO

/****** Object:  Table [dbo].[StaticSchedule]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StaticSchedule]') AND type in (N'U'))
DROP TABLE [dbo].[StaticSchedule]
GO

/****** Object:  Table [dbo].[StaticSchedule]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RealtimeSchedule]') AND type in (N'U'))
DROP TABLE [dbo].[RealtimeSchedule]
GO

/****** Object:  View [dbo].[SubwaySchedule]    Script Date: 9/22/2014 5:16:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubwaySchedule]') AND type in (N'V'))
DROP VIEW [dbo].[SubwaySchedule]
GO



/****** Object:  Table [dbo].[CurrentBatch]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurrentBatch]') AND type in (N'U'))
DROP TABLE [dbo].[CurrentBatch]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_BuildStations]') AND type in (N'P'))
DROP PROCEDURE [dbo].[sp_BuildStations]
GO

/****** Object:  StoredProcedure [dbo].[sp_CreateRealtimeSchedule]    Script Date: 9/22/2014 4:31:56 PM ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_CreateRealtimeSchedule]') AND type in (N'P'))
DROP PROCEDURE [dbo].[sp_CreateRealtimeSchedule]
GO


CREATE TABLE [dbo].[agency](
	[agency_id] [nvarchar](32) NOT NULL,
	[agency_name] [nvarchar](32) NOT NULL,
	[agency_url] [nvarchar](128) NOT NULL,
	[agency_timezone] [nvarchar](32) NOT NULL,
	[agency_lang] [varchar](50) NULL,
	[agency_phone] [varchar](50) NULL,
 CONSTRAINT [agency_name_pkey] PRIMARY KEY CLUSTERED 
(
	[agency_id] ASC
)
) 




/****** Object:  Table [dbo].[calendar]    Script Date: 9/10/2014 5:41:11 PM ******/






CREATE TABLE [dbo].[calendar](
	[service_id] [nvarchar](32) NOT NULL,
	[monday] [char](1) NOT NULL,
	[tuesday] [char](1) NOT NULL,
	[wednesday] [char](1) NOT NULL,
	[thursday] [char](1) NOT NULL,
	[friday] [char](1) NOT NULL,
	[saturday] [char](1) NOT NULL,
	[sunday] [char](1) NOT NULL,
	[start_date] [nvarchar](16) NOT NULL,
	[end_date] [nvarchar](16) NOT NULL,
 CONSTRAINT [calendar_sid_pkey] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)
) 




/****** Object:  Table [dbo].[calendar_dates]    Script Date: 9/10/2014 5:41:11 PM ******/






CREATE TABLE [dbo].[calendar_dates](
	[service_id] [nvarchar](32) NOT NULL,
	[date] [nvarchar](12) NOT NULL,
	[exception_type] [varchar](50) NULL,
 CONSTRAINT [calendar_dates_pkey] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC,
	[date] ASC
)
) 




/****** Object:  Table [dbo].[realtime_alerts]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[realtime_alerts](
	[trip_id] [nvarchar](128) NOT NULL,
	[alert_text] [nvarchar](128) NOT NULL
	CONSTRAINT [realtime_alerts_tid_pkey] PRIMARY KEY CLUSTERED 
	(
		[trip_id] ASC
	)
) 


/****** Object:  Table [dbo].[realtime_stop_time_updates]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[realtime_stop_time_updates](
	[trip_id] [nvarchar](128) NOT NULL,
	[arrival] [datetime] NULL,
	[departure] [datetime] NULL,
	[stop_id] [nvarchar](8) NOT NULL,
	[scheduled_track] [nvarchar](4) NULL,
	[actual_track] [nvarchar](4) NULL
	CONSTRAINT [realtime_stops_pkey] PRIMARY KEY CLUSTERED 
	(
		[trip_id] ASC, [stop_id] ASC
	)
) 


/****** Object:  Table [dbo].[realtime_trips]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[realtime_trips](
	[trip_id] [nvarchar](128) NOT NULL,
	[start_date] [smalldatetime] NULL,
	[route_id] [nvarchar](8) NOT NULL,
	[is_assigned] [bit] NULL,
	[direction] [nvarchar](5) NULL,
	[train_id] [nvarchar](32) NULL
	CONSTRAINT [realtime_trips_pkey] PRIMARY KEY CLUSTERED 
	(
		[trip_id] ASC
	)
) 


/****** Object:  Table [dbo].[realtime_vehicle_position]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[realtime_vehicle_position](
	[trip_id] [nvarchar](128) NOT NULL,
	[current_stop_sequence] [int] NULL,
	[current_status] [nvarchar](15) NULL,
	[timestamp] [datetime] NULL,
	[stop_id] [nvarchar](8) NOT NULL
	CONSTRAINT [realtime_positions_pkey] PRIMARY KEY CLUSTERED 
	(
		[trip_id] ASC, [stop_id] ASC
	)
) 


/****** Object:  Table [dbo].[routes]    Script Date: 9/10/2014 5:41:11 PM ******/






CREATE TABLE [dbo].[routes](
	[agency_id] [varchar](12) NULL,
	[route_id] [nvarchar](4) NOT NULL,
	[route_short_name] [varchar](4) NULL,
	[route_long_name] [varchar](46) NULL,
	[route_type] [smallint] NULL,
	[route_desc] [varchar](2048) NULL,
	[route_url] [varchar](512) NULL,
	[route_color] [varchar](9) NULL,
	[route_text_color] [varchar](9) NULL,
 CONSTRAINT [route_id_pkey] PRIMARY KEY CLUSTERED 
(
	[route_id] ASC
)
) 




/****** Object:  Table [dbo].[shapes]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[shapes](
	[shape_id] [nvarchar](50) NOT NULL,
	[shape_pt_sequence] [int] NOT NULL,
	[shape_pt_lat] [real] NOT NULL,
	[shape_pt_lon] [real] NOT NULL,
 CONSTRAINT [shapes_pkey] PRIMARY KEY CLUSTERED 
(
	[shape_id] ASC,
	[shape_pt_sequence] ASC
)
) 


/****** Object:  Table [dbo].[station]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[station](
	[station_id] [nvarchar](6) NOT NULL,
	[station_name] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[station_id] ASC
)
) 


/****** Object:  Table [dbo].[station_routes]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[station_routes](
	[route_id] [nvarchar](6) NOT NULL,
	[station_id] [nvarchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[route_id] ASC,
	[station_id] ASC
)
) 


/****** Object:  Table [dbo].[station_stops]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[station_stops](
	[stop_id] [nvarchar](6) NOT NULL,
	[station_id] [nvarchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[stop_id] ASC,
	[station_id] ASC
)
) 


/****** Object:  Table [dbo].[stop_times]    Script Date: 9/10/2014 5:41:11 PM ******/






CREATE TABLE [dbo].[stop_times](
	[trip_id] [nvarchar](128) NOT NULL,
	[stop_id] [nvarchar](4) NOT NULL,
	[arrival_time] [varchar](8) NULL,
	[departure_time] [varchar](8) NULL,
	[stop_sequence] [smallint] NULL,
	[pickup_type] [smallint] NULL,
	[drop_off_type] [smallint] NULL
	 CONSTRAINT [stop_times_pkey] PRIMARY KEY CLUSTERED 
	(
		[trip_id] ASC,
		[stop_id] ASC
	)
) 




/****** Object:  Table [dbo].[stops]    Script Date: 9/10/2014 5:41:11 PM ******/






CREATE TABLE [dbo].[stops](
	[stop_id] [nvarchar](8) NOT NULL,
	[stop_name] [nvarchar](128) NOT NULL,
	[stop_lat] [real] NULL,
	[stop_lon] [real] NULL,
	[location_type] [smallint] NULL,
	[parent_station] [varchar](6) NULL,
 CONSTRAINT [stops_id_pkey] PRIMARY KEY CLUSTERED 
(
	[stop_id] ASC
)
) 




/****** Object:  Table [dbo].[transfers]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[transfers](
	[from_stop_id] [nvarchar](8) NOT NULL,
	[to_stop_id] [nvarchar](8) NOT NULL,
	[transfer_type] [smallint] NULL,
	[min_transfer_time] [smallint] NULL,
 CONSTRAINT [transfers_pkey] PRIMARY KEY CLUSTERED 
(
	[from_stop_id] ASC,
	[to_stop_id] ASC
)
) 


/****** Object:  Table [dbo].[trips]    Script Date: 9/10/2014 5:41:11 PM ******/






CREATE TABLE [dbo].[trips](
	[route_id] [nvarchar](4) NOT NULL,
	[trip_id] [nvarchar](128) NOT NULL,
	[service_id] [varchar](46) NULL,
	[trip_headsign] [varchar](68) NULL,
	[direction_id] [smallint] NOT NULL,
	[shape_id] [varchar](14) NULL,
 CONSTRAINT [trip_id_pkey] PRIMARY KEY CLUSTERED 
(
	[trip_id] ASC
)
) 



CREATE TABLE [dbo].[StaticSchedule](
	TripId [nvarchar](128) NOT NULL,
	StationId [nvarchar](6) NOT NULL,
	BatchVersion int NOT NULL,
	RouteId [nvarchar](4) NOT NULL,
	StationName [varchar](128) NULL,
	RouteName [varchar](46) NULL,
	ArrivalTime datetime2 not null,
	Direction char(1) not null,
	DestinationStationId [nvarchar](6) NOT NULL,
	IsRealtime bit not null
 CONSTRAINT [trip_static_schedule_pkey] PRIMARY KEY CLUSTERED 
(
	BatchVersion ASC, 
	TripId, StationId, RouteId
)
) 

CREATE TABLE [dbo].[RealtimeSchedule](
	TripId [nvarchar](128) NOT NULL,
	StationId [nvarchar](6) NOT NULL,
	BatchVersion int NOT NULL,
	RouteId [nvarchar](4) NOT NULL,
	StationName [varchar](128) NULL,
	RouteName [varchar](46) NULL,
	ArrivalTime datetime2 not null,
	Direction char(1) not null,
	DestinationStationId [nvarchar](6) NOT NULL,
	IsRealtime bit not null
 CONSTRAINT [trip_realtime_schedule_pkey] PRIMARY KEY CLUSTERED 
(
	BatchVersion ASC, 
	TripId, StationId, RouteId
)
) 



CREATE TABLE [dbo].[CurrentBatch](
	Id int NOT NULL,
	BatchVersion int NOT NULL Default(0),
	Label varchar(32)
	
 CONSTRAINT [current_batch_pkey] PRIMARY KEY CLUSTERED 
(
	Id 
)
) 


GO

INSERT INTO CurrentBatch (Id, BatchVersion, Label) VALUES (1, 0, 'Static'), (2, 0, 'Realtime')
GO




CREATE VIEW [dbo].[SubwaySchedule]
AS

	(
		SELECT       dbo.StaticSchedule.*
			FROM       dbo.StaticSchedule INNER JOIN dbo.CurrentBatch ON dbo.StaticSchedule.BatchVersion = dbo.CurrentBatch.BatchVersion AND dbo.CurrentBatch.Id = 1
	)
			UNION ALL 

	(
		SELECT       dbo.RealtimeSchedule.*
			FROM       dbo.RealtimeSchedule INNER JOIN dbo.CurrentBatch ON dbo.RealtimeSchedule.BatchVersion = dbo.CurrentBatch.BatchVersion AND dbo.CurrentBatch.Id = 2
	)

GO



/****** Object:  StoredProcedure [dbo].[sp_BuildStations]    Script Date: 9/10/2014 5:41:11 PM ******/

CREATE PROCEDURE [dbo].[sp_BuildStations]
AS
BEGIN

TRUNCATE TABLE station_stops;
TRUNCATE TABLE station_routes;
TRUNCATE TABLE station;


-- Add the transfers
INSERT INTO station_stops
select from_stop_id, min(to_stop_id)
from transfers 
group by from_stop_id
order by from_stop_id

-- Add stations with no transfers
INSERT INTO station_stops
select distinct stop_id, stop_id from stops
where location_type = 1 
AND stop_id not IN (SELECT stop_id from station_stops)


-- populate stations
INSERT INTO station
select distinct station_id, s.stop_name
from station_stops ss INNER JOIN stops s on ss.station_id = s.stop_id

-- populate routes
INSERT INTO station_routes
select distinct  t.route_id, ss.station_id
FROM stop_times st
INNER JOIN trips t on t.trip_id = st.trip_id
INNER JOIN stops s on s.stop_id = st.stop_id
inner JOIn station_stops ss on s.parent_station = ss.stop_id
--INNER JOIN station stn on stn.station_id = ss.station_id

--ALTER TABLE dbo.stop_times ADD CONSTRAINT
--	PK_stop_times PRIMARY KEY CLUSTERED 
--	(
--	stop_id,
--	trip_id
--	)

--CREATE NONCLUSTERED INDEX [IX_stop_times_arrival_time] ON [dbo].stop_times
--(
--	arrival_time ASC,
--	trip_id ASC,
--	stop_id ASC
--)

END
GO
/****** Object:  StoredProcedure [dbo].[[sp_CreateStaticSchedule]]    Script Date: 9/17/2014 9:24:15 AM ******/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_CreateStaticSchedule]') AND type in (N'P'))
DROP PROCEDURE [dbo].[sp_CreateStaticSchedule]
GO



CREATE PROCEDURE [dbo].[sp_CreateStaticSchedule]
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
--	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @current_batch_id as int;
	declare @new_batch_id as int;

	select @current_batch_id = BatchVersion from CurrentBatch WHERE Id = 1 -- Static Batch

	IF ( ISNULL(@current_batch_id, -1 ) = -1)
	BEGIN
		INSERT INTO CurrentBatch VALUES (1,0, 'Static')
		SET @current_batch_id = 0
	END


	set  @new_batch_id = @current_batch_id + 1;

IF  EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_StaticSchedule_ArrivalTime' AND object_id = OBJECT_ID(N'[dbo].[StaticSchedule]')) 
--IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[[IX_StaticSchedule_ArrivalTime]]') )
DROP INDEX [IX_StaticSchedule_ArrivalTime] ON [dbo].[StaticSchedule]

INSERT INTO StaticSchedule (TripId,StationId,BatchVersion,RouteId,StationName,
RouteName,ArrivalTime,Direction,
DestinationStationId,IsRealtime)
SELECT      
	stop_times.trip_id, 
	station.station_id, 
	@new_batch_id as BatchVersion,
	routes.route_id, 
	station.station_name, 
	dbo.routes.route_long_name
	, DATEADD(SECOND, CONVERT(int, SUBSTRING( stop_times.arrival_time, 1, 2)) * 60 * 60
	 + CONVERT(int, SUBSTRING( stop_times.arrival_time, 4, 2)) * 60
	 + CONVERT(int, SUBSTRING( stop_times.arrival_time, 7, 2)), CONVERT(datetime2, Convert(date, getdate())))
	-- , stop_times.arrival_time, 
	,trips.direction_id,0,
	0 AS IsRealtime
	
FROM        
	dbo.station 
	INNER JOIN station_stops on station_stops.station_id = station.station_id
	INNER JOIN  dbo.stops ON dbo.station_stops.stop_id = dbo.stops.parent_station
	INNER JOIN  dbo.stop_times ON dbo.stop_times.stop_id = dbo.stops.stop_id 
	INNER JOIN dbo.trips ON dbo.stop_times.trip_id = dbo.trips.trip_id
	INNER JOIN routes ON dbo.routes.route_id = dbo.trips.route_id 
	INNER JOIN calendar on trips.service_id = calendar.service_id
	where routes.route_id NOT IN (	 '1','2','3','4','5','5X','6','6X','GS','L')
	AND 
		(  
			( datepart(dw, getdate()) = 1 AND calendar.sunday = '1' )
			OR ( datepart(dw, getdate()) = 2 AND calendar.monday = '1' )
			OR ( datepart(dw, getdate()) = 3 AND calendar.tuesday = '1' )
			OR ( datepart(dw, getdate()) = 4 AND calendar.wednesday = '1' )
			OR ( datepart(dw, getdate()) = 5 AND calendar.thursday = '1' )
			OR ( datepart(dw, getdate()) = 6 AND calendar.friday = '1' )
			OR ( datepart(dw, getdate()) = 7 AND calendar.saturday = '1' )
		)

	--AND stop_times.arrival_time < '24:00:00'
	--AND PARSE(stop_times.arrival_time as time) > CAST( GETDATE() as time )
	--AND PARSE(stop_times.arrival_time as time) < CAST( DATEADD(MINUTE, 30, GETDATE()) as time )
	--order by arrival_time ASC

-- SELECT top 100 * FROM StaticSchedule

UPDATE CurrentBatch SET BatchVersion = @new_batch_id WHERE BatchVersion = @current_batch_id AND Id = 1

DELETE FROM StaticSchedule 
WHERE BatchVersion <> @new_batch_id

--CREATE NONCLUSTERED INDEX [IX_StaticSchedule_ArrivalTime] ON [dbo].[StaticSchedule]
--(
--	[StationId] ASC,
--	[ArrivalTime] ASC
--)

END
GO




create PROCEDURE [dbo].[sp_CreateRealtimeSchedule]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @current_batch_id as int;
	declare @new_batch_id as int;

	select @current_batch_id = BatchVersion from CurrentBatch WHERE Id = 2 -- Realtime Batch

	IF ( ISNULL(@current_batch_id, -1 ) = -1)
	BEGIN
		INSERT INTO CurrentBatch VALUES (2,0, 'Realtime')
		SET @current_batch_id = 0
	END


	set  @new_batch_id = @current_batch_id + 1;



INSERT INTO RealtimeSchedule  
SELECT      
	realtime_stop_time_updates.trip_id, 
	station.station_id, 
	@new_batch_id as BatchVersion,
	routes.route_id, 
	station.station_name, 
	dbo.routes.route_long_name
	,ISNULL( realtime_stop_time_updates.arrival,  realtime_stop_time_updates.departure)
	,CASE realtime_trips.direction when 'NORTH' then 'N' else 'S' end
	,'-101' -- TODO Destination statuoins 
	,1 AS IsRealtime
	
FROM        
	dbo.station 
	INNER JOIN station_stops on station_stops.station_id = station.station_id
	INNER JOIN  dbo.stops ON dbo.station_stops.stop_id = dbo.stops.parent_station
	INNER JOIN  dbo.realtime_stop_time_updates ON dbo.realtime_stop_time_updates.stop_id = dbo.stops.stop_id 
	INNER JOIN dbo.realtime_trips ON dbo.realtime_stop_time_updates.trip_id = dbo.realtime_trips.trip_id
	INNER JOIN routes ON dbo.routes.route_id = dbo.realtime_trips.route_id 



UPDATE CurrentBatch SET BatchVersion = @new_batch_id WHERE BatchVersion = @current_batch_id AND Id = 2

DELETE FROM RealtimeSchedule 
WHERE BatchVersion <> @new_batch_id

END


IF  EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_RealtimeSchedule_ArrivalTime' AND object_id = OBJECT_ID(N'[dbo].[RealtimeSchedule]')) 
DROP INDEX [IX_RealtimeSchedule_ArrivalTime] ON [dbo].[RealtimeSchedule]
GO

CREATE NONCLUSTERED INDEX [IX_RealtimeSchedule_ArrivalTime] ON [dbo].[RealtimeSchedule]
(
	[StationId] ASC,
	[ArrivalTime] ASC
)