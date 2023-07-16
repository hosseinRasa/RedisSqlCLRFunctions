EXEC sp_configure 'show advanced options' , 1;
RECONFIGURE;
EXEC sp_configure 'clr enable' ,1;
    RECONFIGURE;
 EXEC sp_configure 'clr strict security', 0;
    RECONFIGURE;
CREATE ASSEMBLY SQLCLRDemo
FROM 'E:\ClrTest\RedisModification.dll';
GO
CREATE FUNCTION ConnectToRedis(@server nvarchar(255), @port nvarchar(4)) RETURNS bit
EXTERNAL NAME RedisModification.[RedisModification.RedisClrFunction].Connect;
GO


select dbo.ConnectToRedis('','')