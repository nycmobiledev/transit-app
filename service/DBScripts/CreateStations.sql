
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'station_stops'))
BEGIN
   DROP table station_stops
END

-- TABLE to map stations to primary station
create table station_stops
(
	stop_id nvarchar(6) not null,
	station_id nvarchar(6) not null,
	 PRIMARY KEY CLUSTERED 
	(
		stop_id ASC, station_id ASC
	)
)

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

IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'station'))
BEGIN
   DROP table station
END
-- Unique stations
create table station
(
	station_id nvarchar(6) not null Primary KEY clustered,
	station_name nvarchar(128),
)

-- populate stations
INSERT INTO station
select distinct station_id, s.stop_name
from station_stops ss INNER JOIN stops s on ss.station_id = s.stop_id


IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'station_routes'))
BEGIN
   DROP table station_routes
END

-- Routes/Lines for each station
create table station_routes
(
	route_id nvarchar(6) not null,
	station_id nvarchar(6) not null
	PRIMARY KEY CLUSTERED 
	(
		route_id ASC, station_id ASC
	)
)

-- populate routes
INSERT INTO station_routes
select distinct  t.route_id, ss.station_id
FROM stop_times st
INNER JOIN trips t on t.trip_id = st.trip_id
INNER JOIN stops s on s.stop_id = st.stop_id
inner JOIn station_stops ss on s.parent_station = ss.stop_id
--INNER JOIN station stn on stn.station_id = ss.station_id

