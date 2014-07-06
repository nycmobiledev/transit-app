

ALTER TABLE agency 
      ALTER COLUMN agency_id nvarchar(32) NOT NULL;
GO
ALTER TABLE agency ADD CONSTRAINT agency_name_pkey 
      PRIMARY KEY (agency_id);

ALTER TABLE agency 
      ALTER COLUMN agency_name nvarchar(32) NOT NULL;
ALTER TABLE agency 
      ALTER COLUMN agency_url nvarchar(128) NOT NULL;
ALTER TABLE agency 
      ALTER COLUMN agency_timezone nvarchar(32) NOT NULL;

ALTER TABLE stops ADD CONSTRAINT stops_id_pkey
      PRIMARY KEY (stop_id);
ALTER TABLE stops 
      ALTER COLUMN stop_id nvarchar(8)  NOT NULL;
ALTER TABLE stops 
      ALTER COLUMN stop_name nvarchar(128) NOT NULL;


ALTER TABLE stops ADD CONSTRAINT stop_parent_fkey
      FOREIGN KEY (parent_station)
      REFERENCES stops(stop_id);


ALTER TABLE routes ADD CONSTRAINT routes_id_pkey
      PRIMARY KEY (route_id);
ALTER TABLE routes ADD CONSTRAINT routes_agency_fkey
      FOREIGN KEY (agency_id) 
      REFERENCES agency(agency_id);
ALTER TABLE routes ADD CONSTRAINT routes_rtype_fkey
      FOREIGN KEY (route_type) 
      REFERENCES route_types(route_type);

-- Calendar
ALTER TABLE calendar 
      ALTER COLUMN service_id nvarchar(32) NOT NULL;
GO
ALTER TABLE calendar ADD CONSTRAINT calendar_sid_pkey
      PRIMARY KEY (service_id) ;
ALTER TABLE calendar 
      ALTER COLUMN monday char NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN tuesday char NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN wednesday char NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN thursday char NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN friday char NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN saturday char NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN sunday char NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN start_date nvarchar(16) NOT NULL;
ALTER TABLE calendar 
      ALTER COLUMN end_date nvarchar(16) NOT NULL;

ALTER TABLE calendar_dates 
      ALTER COLUMN service_id nvarchar(32) NOT NULL;
GO


ALTER TABLE calendar_dates 
      ALTER COLUMN date nvarchar(12) NOT NULL;
GO

ALTER TABLE calendar_dates ADD CONSTRAINT calendar_dates_pkey
      PRIMARY KEY (service_id,date) ;

ALTER TABLE calendar_dates ADD CONSTRAINT cal_sid_fkey
      FOREIGN KEY (service_id)
      REFERENCES calendar(service_id);


ALTER TABLE shapes  
      ALTER COLUMN shape_id nvarchar(50) NOT NULL;
ALTER TABLE shapes 
      ALTER COLUMN shape_pt_lat real NOT NULL;
ALTER TABLE shapes 
      ALTER COLUMN shape_pt_lon real NOT NULL;
ALTER TABLE shapes 
      ALTER COLUMN shape_pt_sequence int NOT NULL;

ALTER TABLE shapes ADD CONSTRAINT shapes_pkey
      PRIMARY KEY (shape_id,shape_pt_sequence) ;

ALTER TABLE stop_times  
      ALTER COLUMN trip_id nvarchar(128) NOT NULL;

ALTER TABLE stop_times  
      ALTER COLUMN stop_id nvarchar(4) NOT NULL;

ALTER TABLE stop_times ADD CONSTRAINT stop_times_pkey
      PRIMARY KEY (trip_id,stop_id) ;

ALTER TABLE trips 
      ALTER COLUMN trip_id nvarchar(128) NOT NULL;

ALTER TABLE trips 
      ALTER COLUMN route_id nvarchar(4) NOT NULL;

ALTER TABLE routes 
      ALTER COLUMN route_id nvarchar(4) NOT NULL;
GO
ALTER TABLE routes ADD CONSTRAINT route_id_pkey
      PRIMARY KEY (route_id);
ALTER TABLE trips ADD CONSTRAINT trip_id_pkey
      PRIMARY KEY (trip_id);
ALTER TABLE trips ADD CONSTRAINT trip_rid_fkey
      FOREIGN KEY (route_id)
      REFERENCES [routes](route_id);
--ALTER TABLE trips ADD CONSTRAINT trip_sid_fkey
--      FOREIGN KEY (service_id)
--      REFERENCES calendar(service_id);


ALTER TABLE transfers 
	ALTER COLUMN from_stop_id nvarchar(8) NOT NULL;

	
ALTER TABLE transfers 
	ALTER COLUMN to_stop_id nvarchar(8) NOT NULL;



ALTER TABLE transfers ADD CONSTRAINT xfer_fsid_fkey
      FOREIGN KEY (from_stop_id)
      REFERENCES stops(stop_id);
ALTER TABLE transfers ADD CONSTRAINT xfer_tsid_fkey
      FOREIGN KEY (to_stop_id)
      REFERENCES stops(stop_id);

ALTER TABLE transfers ADD CONSTRAINT transfers_pkey
      PRIMARY KEY (from_stop_id,to_stop_id) ;
