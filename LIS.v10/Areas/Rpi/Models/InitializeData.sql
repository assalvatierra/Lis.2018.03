insert into RpiDevices([Description])
values('LIS Rpi');

insert into RpiControls([DtSchedule],[Data],[RpiDeviceId])
values('3/13/2018 12:00:00','{Temp:0,Humidity:0,Light:0,Fan:0,Water:0}',1);

insert into RpiDatalogs([DtRead],[DataRead],[RpiDeviceId])
values('3/13/2018 12:00:00','{Temp:0,Humidity:0,Light:0,Fan:0,Water:0}',1);
 