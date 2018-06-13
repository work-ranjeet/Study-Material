
DECLARE @TableName VARCHAR(MAX) = 'UserSocialAddress' 
DECLARE @result varchar(max) = ''

SET @result = @result + '---------------------------------------'+ @TableName +'---------------------------------------- ' + CHAR(13) 

SET @result = @result + 'IF EXISTS (' + CHAR(13) 
SET @result = @result + 'SELECT * ' + CHAR(13) 
SET @result = @result + 'FROM sys.objects ' + CHAR(13) 
SET @result = @result + 'WHERE object_id = OBJECT_ID(N\' '+ @TableName + '\') ' + CHAR(13) 
SET @result = @result + 'AND type IN ( ' + CHAR(13) 
SET @result = @result + 'N\'P\', ' + CHAR(13) 
SET @result = @result + 'N\'PC\'' + CHAR(13) 
SET @result = @result + ')' + CHAR(13) 
SET @result = @result + ')' + CHAR(13) 
SET @result = @result + 'DROP PROCEDURE Save' + @TableName + '(' + CHAR(13) 
SET @result = @result + 'GO' + CHAR(13) 

SET @result = @result + 'CREATE PROCEDURE Save' + @TableName + '(' + CHAR(13) 

SELECT @result = @result + '@' + ColumnName + ' '+ ColumnType
FROM
(
    SELECT  c.COLUMN_NAME   AS ColumnName, 
		CASE c.DATA_TYPE   
            WHEN 'bigint' THEN 'BIGINT'
            WHEN 'binary' THEN 'BINARY'
            WHEN 'bit' THEN 'BIT'      
            WHEN 'char' THEN 'String'
            WHEN 'date' THEN 'DATE'                
            WHEN 'datetime' THEN 'DATETIME'                     
            WHEN 'datetime2' THEN 'DATETIME2'                
            WHEN 'datetimeoffset' THEN 'DATETIMEOFFSET'                                 
            WHEN 'decimal' THEN  
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                    
            WHEN 'float' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Single?' ELSE 'Single' END                                    
            WHEN 'image' THEN 'Byte[]'
            WHEN 'int' THEN  
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Int32?' ELSE 'Int32' END
            WHEN 'money' THEN
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                
            WHEN 'nchar' THEN 'String'
            WHEN 'ntext' THEN 'String'
            WHEN 'numeric' THEN
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                            
            WHEN 'nvarchar' THEN 'String'
            WHEN 'real' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Double?' ELSE 'Double' END                                                                        
            WHEN 'smalldatetime' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                                    
            WHEN 'smallint' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Int16?' ELSE 'Int16'END            
            WHEN 'smallmoney' THEN  
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Decimal?' ELSE 'Decimal' END                                                                        
            WHEN 'text' THEN 'String'
            WHEN 'time' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'TimeSpan?' ELSE 'TimeSpan' END                                                                                    
            WHEN 'timestamp' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'DateTime?' ELSE 'DateTime' END                                    
            WHEN 'tinyint' THEN 
                CASE C.IS_NULLABLE
                    WHEN 'YES' THEN 'Byte?' ELSE 'Byte' END                                                
            WHEN 'uniqueidentifier' THEN 'Guid'
            WHEN 'varbinary' THEN 'Byte[]'
            WHEN 'varchar' THEN 'String'
            ELSE 'Object'
        END AS ColumnType, c.ORDINAL_POSITION 
FROM    INFORMATION_SCHEMA.COLUMNS c
WHERE   c.TABLE_NAME = @TableName 
) t
ORDER BY t.ORDINAL_POSITION
PRINT @result
