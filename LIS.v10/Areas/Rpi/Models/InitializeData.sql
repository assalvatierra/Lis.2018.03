﻿insert into RpiVersions([VersionNo],[Description])
values('v10','LIS Rpi');

insert into RpiDataTypes([Description])
values('Temperature'), ('Humidity'), 
	  ('Lumens'), ('Units');

insert into RpiComponents([ComponentName],[Description],[RpiDataTypeId])
values('DHT22','Temp and Humidity Sensor',1),
	  ('LED','Light',3);

insert into RpiVersionMaps([NameMap],[PinNo],[RpiComponentId],[RpiVersionId])
values('v10Map',18,1,1), ('v10Map',23,2,1);


insert into RpiDevices([Description],[RpiVersionId])
values('LIS Rpi',1);

insert into RpiControls([DtSchedule],[Data],[RpiDeviceId])
values('3/21/2018 15:00:00','{"TempMin":20,"TempMax":28,"Light":0,"Socket01":0,"Socket02":0}',1);

insert into RpiDatalogs([DtRead],[DataRead],[RpiDeviceId])
	values('3/13/2018 10:00:00','{"Temp":34.1,"Humidity":50,"Light":0,"Fan":0,"Water":0}',1),
		  ('3/13/2018 11:00:00','{"Temp":34.5,"Humidity":50,"Light":0,"Fan":0,"Water":0}',1),
		  ('3/13/2018 12:00:00','{"Temp":34.3,"Humidity":50,"Light":0,"Fan":0,"Water":0}',1);
 