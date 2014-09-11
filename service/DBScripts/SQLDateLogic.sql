DECLARE @TestDate DATETIME
SET @TestDate = '2014-09-07'
SELECT DatePart(dw, @TestDate) AS Part, DateName(dw, @TestDate) as Name