select * from realtime_trips
where trip_id = '116550_1..S02R'

SELECT * 
from realtime_trips RT
INNER JOIN trips T on 
INNER JOIN calendar C ON T.service_id = c.service_id
where t.trip_id LIKE '%116550_1..S02R'
and c.wednesday = 1

/*
DECLARE @SQLString nvarchar(max)
SELECT @SQLString = '
SELECT *
FROM  Calendar
WHERE ' + DATENAME(dw, CURRENT_TIMESTAMP) + '=1'

exec sp_executesql @SQLString 
*/

SELECT * FROM calendar
WHERE wednesday= 1