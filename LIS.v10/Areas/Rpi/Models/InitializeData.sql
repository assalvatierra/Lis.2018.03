insert into RpiDevices([Description],[Version])
values('LIS Rpi','v1');

insert into RpiControls([DtSchedule],[Data],[RpiDeviceId])
values('3/13/2018 12:00:00','{Temp:0,Humidity:0,Light:0,Fan:0,Water:0}',1);

insert into RpiDatalogs([DtRead],[DataRead],[RpiDeviceId])
	values('3/13/2018 12:00:00','{"Temp":34.1,"Humidity":50,"Light":0,"Fan":0,"Water":0}',1),
		  ('3/13/2018 12:00:00','{"Temp":34.5,"Humidity":50,"Light":0,"Fan":0,"Water":0}',1),
		  ('3/13/2018 12:00:00','{"Temp":34.3,"Humidity":50,"Light":0,"Fan":0,"Water":0}',1);
 