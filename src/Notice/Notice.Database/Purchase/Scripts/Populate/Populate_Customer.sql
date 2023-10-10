-- emailfake.com

SET IDENTITY_INSERT Purchase.Customer ON
GO

MERGE INTO Purchase.Customer AS TARGET
USING (VALUES (1, 'Julie.Hartshorn@wpgotten.com'),
              (2, 'William.Pierce@wpgotten.com'),
              (3, 'Christine.Brandt@wpgotten.com'),
              (4, 'Patsy.Hauser@wpgotten.com'),
              (5, 'Carlos.Riley@wpgotten.com'),
              (6, 'Edward.Tate@wpgotten.com'),
              (7, 'Christi.Miller@wpgotten.com'))
AS SOURCE (CustomerId, EmailAddress)
ON TARGET.CustomerId = SOURCE.CustomerId
WHEN MATCHED THEN UPDATE SET TARGET.EmailAddress        = SOURCE.EmailAddress
WHEN NOT MATCHED THEN INSERT (CustomerId,
                              EmailAddress)
                      VALUES (SOURCE.CustomerId,
                              SOURCE.EmailAddress);

SET IDENTITY_INSERT Purchase.Customer OFF
GO