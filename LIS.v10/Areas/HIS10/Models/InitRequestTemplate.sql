insert into HisTemplateRequests([Title],[Remarks])
values
('7 Days - Supplements only','7 days conditioning supplements'),
('21 Days - Basic Conditioning','21 days conditioning Basic'),
('21 Days - Thunderbird','21 days conditioning - ThunderBird Power');

insert into HisRequests([Title],[Description])
('Gamefowl Conditioning','Gamefowl Conditioning program');

insert into HisTemplateReqItem([HisTemplateRequestId],[HisRequestId],[Description],[Sort],[RefDay],[RefHour],[SchedTime])
values
-- 7 days supplement conditioning --
-- ref: http://gamefowl101.blogspot.com/2013/09/tatak-excellence-7-days-conditioning.html --
( 1, 1, 'Day 1: AMTYL 500 - Dosage: 1 tablet',1,1,0,''),
( 1, 1, 'Day 2: RESPIGEN 15 GEL/DROPS - Dosage: 1 GEL or 7 drops @ 6:00 AM  ',2,2,0,''),
( 1, 1, 'Day 3: RELOAD PLUS - Dosage: 7 drops before & after sparring',3,3,0,''),
( 1, 1, 'Day 3: PROMOTOR 43 - Dosage: 1 Capsule after afternoon feed',4,3,0,''),
( 1, 1, 'Day 4: ZEROMITE Shampoo - Dosage: 10ml mix to 2 gallons of water ',5,4,0,''),
( 1, 1, 'Day 5: VOLTPLEX KQ - Dosage: 1 Capsule after morning feed',6,5,0,''),
( 1, 1, 'Day 5: RELOAD PLUS - Dosage: 7 drops after morning and afternoon feeding',7,5,0,''),
( 1, 1, 'Day 6: RESPIGEN 15 GEL/DROPS  - Dosage: 1 GEL or 7 drops @ 6:00 AM  ',8,6,0,''),
( 1, 1, 'Day 6: VOLTPLEX KQ - Dosage: 1 Capsule after morning feed ',9,6,0,''),
( 1, 1, 'Day 6: RELOAD PLUS  - Dosage: 7 drops 30 Minutes after morning & afternoon feeding',10,6,0,''),
( 1, 1, 'Day 7: VOLTPLEX KQ  - Dosage: 1 CAPSULE AFTER MORNING FEED  ',11,7,0,''),
( 1, 1, 'Day 7: RELOAD PLUS  - Dosage: 7 drops 30 Minutes after morning & afternoon feeding',12,7,0,''),
( 1, 1, 'Day 7: RELOAD PLUS  - Dosage: 3 drops 2 hours before fight',13,7,0,'');
-- 21 days basic conditioning --
-- http://gamefowl101.blogspot.com/2013/07/ldi-21-days-conditioning-keep-by-gerald.html


-- 21 days thunderbird conditioning --
-- http://gamefowl101.blogspot.com/2013/06/21-days-thunderbird-power-to-win.html

