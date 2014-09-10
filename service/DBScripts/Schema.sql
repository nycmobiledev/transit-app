USE [mta_nyc_subway]

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

/****** Object:  Table [dbo].[agency]    Script Date: 9/10/2014 5:48:26 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TripAlert]') AND type in (N'U'))
DROP TABLE [dbo].[TripAlert]
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
) 


/****** Object:  Table [dbo].[realtime_stop_time_updates]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[realtime_stop_time_updates](
	[trip_id] [nvarchar](128) NOT NULL,
	[arrival] [datetime] NULL,
	[departure] [datetime] NULL,
	[stop_id] [nvarchar](8) NOT NULL,
	[scheduled_track] [nvarchar](4) NULL,
	[actual_track] [nvarchar](4) NULL
) 


/****** Object:  Table [dbo].[realtime_trips]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[realtime_trips](
	[trip_id] [nvarchar](128) NOT NULL,
	[start_date] [smalldatetime] NULL,
	[route_id] [nvarchar](8) NOT NULL,
	[is_assigned] [bit] NULL,
	[direction] [nvarchar](5) NULL,
	[train_id] [nvarchar](32) NULL
) 


/****** Object:  Table [dbo].[realtime_vehicle_position]    Script Date: 9/10/2014 5:41:11 PM ******/




CREATE TABLE [dbo].[realtime_vehicle_position](
	[trip_id] [nvarchar](128) NOT NULL,
	[current_stop_sequence] [int] NULL,
	[current_status] [nvarchar](15) NULL,
	[timestamp] [datetime] NULL,
	[stop_id] [nvarchar](8) NULL
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
	[drop_off_type] [smallint] NULL,
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



CREATE TABLE [dbo].[TripAlert](
	TripId [nvarchar](128) NOT NULL,
	StationId [nvarchar](6) NOT NULL,
	BatchVersion int NOT NULL,
	RouteId [nvarchar](4) NOT NULL,
	StationName [varchar](128) NULL,
	RouteName [varchar](46) NULL,
	[Time] timestamp not null,
	DestinationStationId [nvarchar](6) NOT NULL,
	IsRealtime bit not null
 CONSTRAINT [trip_alery_pkey] PRIMARY KEY CLUSTERED 
(
	BatchVersion ASC, 
	TripId, StationId, RouteId
)
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


END


