﻿SET IDENTITY_INSERT Inventory.InventoryTransaction ON
GO

MERGE INTO Inventory.InventoryTransaction AS TARGET
USING (VALUES ( 1, '10255', 5, 20),
              ( 2, '10265',	5, 0),
              ( 3, '10266',	5, 20),
              ( 4, '10270',	5, 20),
              ( 5, '10273',	5, 2),
              ( 6, '10274',	5, 20),
              ( 7, '10276',	5, 20),
              ( 8, '10278',	5, 20),
              ( 9, '10280',	5, 20),
              (10, '10281',	5, 20),
              (11, '10283',	5, 20),
              (12, '10290',	5, 20),
              (13, '10292',	5, 20),
              (14, '10293',	5, 20),
              (15, '10294',	5, 20),
              (16, '10295',	5, 0),
              (17, '10297',	5, 20),
              (18, '10298',	5, 20),
              (19, '10299',	5, 20),
              (20, '10300',	5, 20),
              (21, '10302',	5, 0),
              (22, '10303',	5, 20),
              (23, '10304',	5, 20),
              (24, '10305',	5, 20),
              (25, '10306',	5, 20),
              (26, '10307',	5, 20),
              (27, '10309',	5, 20),
              (28, '10312',	5, 20),
              (29, '10314',	5, 20),
              (30, '10315',	5, 0),
              (31, '10316',	5, 20),
              (32, '10317',	5, 20),
              (33, '10320',	5, 20),
              (34, '10321',	5, 0),
              (35, '10323',	5, 20),
              (36, '10497',	5, 20),
              (37, '21028',	5, 20),
              (38, '21034',	5, 20),
              (39, '21042',	5, 20),
              (40, '21044',	5, 20),
              (41, '21054',	5, 20),
              (42, '21056',	5, 20),
              (43, '21057',	5, 20),
              (44, '21058',	5, 20),
              (45, '21060',	5, 0),
              (46, '21318',	5, 20),
              (47, '21323',	5, 20),
              (48, '21325',	5, 20),
              (49, '21326',	5, 20),
              (50, '21327',	5, 20),
              (51, '21330',	5, 20),
              (52, '21332',	5, 20),
              (53, '21334',	5, 20),
              (54, '21335',	5, 20),
              (55, '21336',	5, 20),
              (56, '21337',	5, 20),
              (57, '21338',	5, 20),
              (58, '21339',	5, 20),
              (59, '21340',	5, 20),
              (60, '21341',	5, 0),
              (61, '40220',	5, 20),
              (62, '40517',	5, 20),
              (63, '40518', 5, 20))
AS SOURCE (InventoryId, ProductId, InventoryActionId, InventoryCredit)
ON TARGET.InventoryId = SOURCE.InventoryId
WHEN MATCHED THEN UPDATE SET ProductId                = SOURCE.ProductId,
                             InventoryActionId = SOURCE.InventoryActionId,
                             InventoryCredit          = SOURCE.InventoryCredit
WHEN NOT MATCHED THEN INSERT (InventoryId,
                              ProductId,
                              InventoryActionId,
                              InventoryCredit)
                      VALUES (SOURCE.InventoryId,
                              SOURCE.ProductId,
                              SOURCE.InventoryActionId,
                              SOURCE.InventoryCredit)
WHEN NOT MATCHED BY SOURCE THEN DELETE;

SET IDENTITY_INSERT Inventory.InventoryTransaction OFF
GO