﻿insert into HisTemplateRequests([Title],[Remarks])
values
('7 Days - Supplements only','7 days conditioning supplements'),
('21 Days - Basic Conditioning','21 days conditioning Basic'),
('21 Days - Thunderbird','21 days conditioning - ThunderBird Power');

insert into HisRequests([Title],[Description])
values ('Gamefowl Conditioning','Gamefowl Conditioning program');

insert into HisTemplateReqItems([HisTemplateRequestId],[HisRequestId],[Remarks],[Sort],[RefDay],[RefHour],[SchedTime])
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
( 1, 1, 'Day 7: RELOAD PLUS  - Dosage: 3 drops 2 hours before fight',13,7,0,''),
-- 21 days basic conditioning --
-- http://gamefowl101.blogspot.com/2013/07/ldi-21-days-conditioning-keep-by-gerald.html
( 2, 2, 'Day 1: ACTIVITY: Training (Sampi, Palakad), SUPPLEMENT: CALVEEX 1 tablet per head',1,1,0,' 4:00 AM '),
( 2, 2, 'Day 1: ACTIVITY: Lighting (Pailaw sa Gradas), SUPPLEMENT: VIMINOLAK 1/2 tablet per head',2,1,0,'7:00 PM '),
( 2, 2, 'Day 2: ACTIVITY: Lighting (Pailaw sa Gradas), SUPPLEMENT: LDI B-12 1 tablet per head',3,2,0,'4:00 AM'),
( 2, 2, 'Day 2: ACTIVITY: Scratching (Pakaskas)',4,2,0,'9:00 AM'),
( 2, 2, 'Day 2: ACTIVITY: Lighting (Pailaw sa Gradas), SUPPLEMENT: VIMINOLAK 1/2 tablet per head',4,2,0,'7:00 PM'),
( 2, 2, 'Day 3: ACTIVITY: Training (Sampi, Palakad), SUPPLEMENT: REDGEL Forte 1 Capsule per head',5,3,0,'4:00 AM'),
( 2, 2, 'Day 3: ACTIVITY: Lighting (Pailaw sa Gradas)',6,3,0,'7:00 PM'),
( 2, 2, 'Day 4: ACTIVITY: Rest on Cording Area',7,4,0,''),
( 2, 2, 'Day 5: ACTIVITY: Rest on Keeping Stalls, SUPPLEMENT: THIABEX XS INJECT 0.5cc per head',8,5,0,'7:00 PM'),
( 2, 2, 'Day 6: ACTIVITY: Training & Sparring, SUPPLEMENT:  CALVEEX 1 tablet per head after sparring',9,6,0,'4:00 AM'),
( 2, 2, 'Day 6: ACTIVITY: Rest on Cording Area',10,6,0,'7:00 AM'),  
( 2, 2, 'Day 6: ACTIVITY: Rest on Keeping Stalls',11,6,0,'7:00 PM'),
( 2, 2, 'Day 7: ACTIVITY: Delouse (Paligo sa manok), SUPPLEMENT: WASH OUT shampoo',12,7,0,'9:00 AM'),
( 2, 2, 'Day 7: ACTIVITY: Rest on Limbering Pen',13,7,0,'7:00 PM'),
( 2, 2, 'Day 8: ACTIVITY: Training (Sampi, Palakad), SUPPLEMENT:  CALVEEX 1 tablet per head',14,8,0,'4:00 AM'),
( 2, 2, 'Day 8: ACTIVITY: Lighting (Pailaw sa Gradas), SUPPLEMENT: VIMINOLAK 1/2 tablet per head',15,8,0,'7:00 PM'),
( 2, 2, 'Day 9: ACTIVITY: Training (Sampi, Palakad), SUPPLEMENT: LDI B-12 1 tablet per head',16,9,0,'4:00 AM'),
( 2, 2, 'Day 9: ACTIVITY: Lighting (Pailaw sa Gradas), SUPPLEMENT: VIMINOLAK 1/2 tablet per head',17,9,0,'7:00 PM'),
( 2, 2, 'Day 10: ACTIVITY: Training (Sampi, Palakad)',18,10,0,'4:00 AM'),
( 2, 2, 'Day 10: ACTIVITY: Rest on Keeping stalls',19,10,0,'12:00 NN'),
( 2, 2, 'Day 10: ACTIVITY: Lighting (Pailaw, Palakad), SUPPLEMENT: THIABEX XS INJECT 0.5cc/head',20,10,0,'7:00 PM'),
( 2, 2, 'Day 11: ACTIVITY: Training & Sparring, SUPPLEMENT: CALVEEX 1 tablet / head after sparring',21,11,0,'4:00 AM'),
( 2, 2, 'Day 11: ACTIVITY: Rest on Cording Area',22,11,0,'12:00 NN'),
( 2, 2, 'Day 11: ACTIVITY: Rest on Keeping Stalls',23,11,0,'7:00 PM'),
( 2, 2, 'Day 12: ACTIVITY: Deworm (Purga), SUPPLEMENT: VERMEX FORTE 1 tablet/head',24,12,0,'4:00 AM'),
( 2, 2, 'Day 12: ACTIVITY: Rest on Cording Area',24,12,0,'7:00 AM'),
( 2, 2, 'Day 13: ACTIVITY: Delouse (Paligo sa Manok), SUPPLEMENT: WASH OUT shampoo',25,13,0,'9:00 AM'),
( 2, 2, 'Day 13: ACTIVITY: Rest on Limbering pen',26,13,0,'7:00 AM'),
( 2, 2, 'Day 14: ACTIVITY: Delouse (Paligo sa Manok), SUPPLEMENT: CALVEEX 1 tablet / head',27,14,0,'9:00 AM'),
( 2, 2, 'Day 14: ACTIVITY: Rest on Limbering pen, SUPPLEMENT: VIMINOLAK 1/2 tablet / head',28,14,0,'7:00 AM'),
( 2, 2, 'Day 15: ACTIVITY: Rest on Cording Area',29,15,0,'7:00 AM'),
( 2, 2, 'Day 15: ACTIVITY: Rest on Keeping Stalls, SUPPLEMENT: CYDROXO B-12 Inject 0.5cc / head',30,15,0,'7:00 AM'),
( 2, 2, 'Day 16: ACTIVITY: Last Sparring, SUPPLEMENT: CALVEEX 1/2 tablet / head after sparring',31,16,0,'4:00 AM'),
( 2, 2, 'Day 16: ACTIVITY: Rest on Cording Area',32,16,0,'7:00 AM'),
( 2, 2, 'Day 17: ACTIVITY: Delouse, SUPPLEMENT:WASH OUT shampoo',33,17,0,'9:00 AM'),
( 2, 2, 'Day 17: ACTIVITY: Rest on Limbering Pens, SUPPLEMENT: VIMINOLAK 1/2 tablet / head',34,17,0,'12:00 NN'),
( 2, 2, 'Day 18: ACTIVITY: Mild Training (Kahig, Palakad)',35,18,0,'4:00 AM'),
( 2, 2, 'Day 18: ACTIVITY: Rest on Cording Area',36,18,0,'12:00 NN'),
( 2, 2, 'Day 18: ACTIVITY: Lighting (Pailaw sa Gradas)',37,18,0,'7:00 PM'),
( 2, 2, 'Day 19: ACTIVITY: Mild Training (Palakad sa Gradas), SUPPLEMENT: REDGEL Forte 1 Caps/ head',38,19,0,'4:00 PM'),
( 2, 2, 'Day 19: ACTIVITY: Rest on Keeping stalls, drop every for hours (check droppings)',39,19,0,'7:00 PM'),
( 2, 2, 'Day 19: ACTIVITY: Pailaw sa Gradas, SUPPLEMENT: LDI B-12 1 tablet per head',40,19,0,'7:00 PM'),
( 2, 2, 'Day 20: ACTIVITY: Rest on Keeping stalls, SUPPLEMENT: BEE POLLEN 1 tablet per head',41,20,0,'9:00 AM'),
( 2, 2, 'Day 20: ACTIVITY: Drop every 4 hours and check droppings, SUPPLEMENT: CYDROXO B-12 Inject 0.5cc / head',42,20,0,'6:00 PM'),
( 2, 2, 'Day 21: ACTIVITY: FIGHT DAY -----  Goodluck! ',43,21,0,''),

-- 21 days thunderbird conditioning --
-- http://gamefowl101.blogspot.com/2013/06/21-days-thunderbird-power-to-win.html
( 3, 3, 'Day 1: SUPPLEMENT: Give One caplet of Ganador Max',1,1,0,' 12:00 NN '),
( 3, 3, 'Day 2: SUPPLEMENT: Delouse using Thunderbird Pusham',2,2,0,''),
( 3, 3, 'Day 3: SUPPLEMENT: Inject 0.5cc of Bexan XP after feeding',3,3,0,'12:00 NN'),
( 3, 3, 'Day 4: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning feeding.',4,4,0,''),
( 3, 3, 'Day 4: ACTIVITY: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',5,4,0,''),
( 3, 3, 'Day 4: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding',6,4,0,''),
( 3, 3, 'Day 5: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning feeding.',7,5,0,''),
( 3, 3, 'Day 5: ACTIVITY: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',8,5,0,''),
( 3, 3, 'Day 5: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding',9,5,0,''),
( 3, 3, 'Day 6: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning feeding.',10,6,0,''),
( 3, 3, 'Day 6: ACTIVITY: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',11,6,0,''),
( 3, 3, 'Day 6: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding',12,6,0,''),
( 3, 3, 'Day 7: SUPPLEMENT: Give One caplet of Ganador Max  (Noon time)',13,7,0,''),
( 3, 3, 'Day 8: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',14,8,0,''),
( 3, 3, 'Day 8: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',15,8,0,''),
( 3, 3, 'Day 8: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',16,8,0,''),
( 3, 3, 'Day 9: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',17,9,0,''),
( 3, 3, 'Day 9: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',18,9,0,''),
( 3, 3, 'Day 9: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',19,9,0,''),
( 3, 3, 'Day 10: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',20,10,0,''),
( 3, 3, 'Day 10: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',21,10,0,''),
( 3, 3, 'Day 10: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',22,10,0,''),
( 3, 3, 'Day 10: SUPPLEMENT: Give One caplet of Ganador Max (Noon time)',23,10,0,''),
( 3, 3, 'Day 11: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',24,11,0,''),
( 3, 3, 'Day 11: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',25,11,0,''),
( 3, 3, 'Day 11: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',26,11,0,''),
( 3, 3, 'Day 11: SUPPLEMENT: Inject 0.5cc of Bexan XP after feeding',27,11,0,''),
( 3, 3, 'Day 12: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',27,12,0,''),
( 3, 3, 'Day 12: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',27,12,0,''),
( 3, 3, 'Day 12: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',27,12,0,''),
( 3, 3, 'Day 13: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',28,13,0,''),
( 3, 3, 'Day 13: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',29,13,0,''),
( 3, 3, 'Day 13: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',30,13,0,''),
( 3, 3, 'Day 13: SUPPLEMENT: Give One caplet of Ganador Max (Noon time)',31,13,0,''),
( 3, 3, 'Day 14: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',31,14,0,''),
( 3, 3, 'Day 14: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',32,14,0,''),
( 3, 3, 'Day 14: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',33,14,0,''),
( 3, 3, 'Day 15: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',34,15,0,''),
( 3, 3, 'Day 15: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',35,15,0,''),
( 3, 3, 'Day 15: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',36,15,0,''),
( 3, 3, 'Day 15: SUPPLEMENT: Delouse using Thunderbird Pusham',37,15,0,''),
( 3, 3, 'Day 16: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',38,16,0,''),
( 3, 3, 'Day 16: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',38,16,0,''),
( 3, 3, 'Day 16: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',38,16,0,''),
( 3, 3, 'Day 16: SUPPLEMENT: Give One caplet of Ganador Max (Noon time)',38,16,0,''),
( 3, 3, 'Day 17: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',39,17,0,''),
( 3, 3, 'Day 17: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',40,17,0,''),
( 3, 3, 'Day 17: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',41,17,0,''),
( 3, 3, 'Day 17: SUPPLEMENT: Inject 0.3cc of Bexan XP after feeding',42,17,0,''),
( 3, 3, 'Day 18: ACTIVITY: Fifteen minutes scratching at 4:00 am and then back to cord area for morning',43,18,0,''),
( 3, 3, 'Day 18: SUPPLEMENT: Give 1 caplet of Rovistress after the exercise between 9:00-10:00 am.',44,18,0,''),
( 3, 3, 'Day 18: ACTIVITY: Put them in flypen at 9:00 am-3:00 pm, then back to cord area for afternoon feeding.',45,18,0,''),
( 3, 3, 'Day 18: ACTIVITY: Propel with lights and loud sounds like they were inside the cockpit arena.',46,18,0,''),
( 3, 3, 'Day 19: ACTIVITY: Reduce pellets and gradually increase corn',47,19,0,''),
( 3, 3, 'Day 19: ACTIVITY: Place them in their resting stall covered with dark color clothes.',48,19,0,''),
( 3, 3, 'Day 19: ACTIVITY: Limber to check droppings every 3 hours.',49,19,0,''),
( 3, 3, 'Day 19: ACTIVITY: Avoid giving medicines/vitamins during this period.',50,19,0,''),
( 3, 3, 'Day 20: ACTIVITY: Reduce pellets and gradually increase corn',51,20,0,''),
( 3, 3, 'Day 20: ACTIVITY: Place them in their resting stall covered with dark color clothes.',52,20,0,''),
( 3, 3, 'Day 20: ACTIVITY: Limber to check droppings every 3 hours.',53,20,0,''),
( 3, 3, 'Day 20: ACTIVITY: Avoid giving medicines/vitamins during this period.',54,20,0,''),
( 3, 3, 'Day 21: ACTIVITY: Reduce pellets and gradually increase corn',55,21,0,''),
( 3, 3, 'Day 21: ACTIVITY: Place them in their resting stall covered with dark color clothes.',56,21,0,''),
( 3, 3, 'Day 21: ACTIVITY: Limber to check droppings every 3 hours.',57,21,0,''),
( 3, 3, 'Day 21: ACTIVITY: Avoid giving medicines/vitamins during this period.',58,21,0,'');