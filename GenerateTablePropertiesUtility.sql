USE CLINICAL
GO
SELECT 'public ' +
CASE i.Data_Type
WHEN 'varchar' then 'string'
WHEN 'int' then 'int'
WHEN 'DateTime' then 'DateTime'
WHEN 'tinyint' then 'bool'
WHEN 'Numeric' then 'decimal'
WHEN 'Float' then 'decimal'
WHEN 'Decimal' then 'decimal'
WHEN 'bigint' then 'long'
WHEN 'smallint' then 'int'
WHEN 'bit' then 'bool'
WHEN 'text' then 'string'
WHEN 'nvarchar' then 'string'
WHEN 'datetime2' then 'DateTime'
END
+ ' ' + I.COLUMN_NAME + ' {get; set;}'

FROM INFORMATION_SCHEMA.COLUMNS I
WHERE I.TABLE_NAME ='Patients'