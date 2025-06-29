USE [AccountManagement]
GO
/****** Object:  StoredProcedure [dbo].[GetAccounts]    Script Date: 6/8/2025 11:33:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAccounts]
    @PageIndex INT,
    @PageSize INT,
    @OrderBy NVARCHAR(50),
    @Name NVARCHAR(MAX) = '%',
    @AccountType NVARCHAR(MAX) = '%',
    @CashFrom DECIMAL(18,2) = NULL,
    @CashTo DECIMAL(18,2) = NULL,
    @Total INT OUTPUT,
    @TotalDisplay INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Total rows in the table
    SELECT @Total = COUNT(*) FROM Accounts;

    -- Build filter count SQL
    DECLARE @countSql NVARCHAR(MAX) = '
        SELECT @TotalDisplay = COUNT(*) 
        FROM Accounts a 
        WHERE 1 = 1 
        AND a.Name LIKE ''%'' + @xName + ''%'' 
        AND a.AccountType LIKE ''%'' + @xAccountType + ''%''';

    IF @CashFrom IS NOT NULL
        SET @countSql += ' AND a.Cash >= @xCashFrom';

    IF @CashTo IS NOT NULL
        SET @countSql += ' AND a.Cash <= @xCashTo';

    DECLARE @countParams NVARCHAR(MAX) = '
        @xName NVARCHAR(MAX),
        @xAccountType NVARCHAR(MAX),
        @xCashFrom DECIMAL(18,2),
        @xCashTo DECIMAL(18,2),
        @TotalDisplay INT OUTPUT';

    EXEC sp_executesql @countSql, @countParams,
        @xName = @Name,
        @xAccountType = @AccountType,
        @xCashFrom = @CashFrom,
        @xCashTo = @CashTo,
        @TotalDisplay = @TotalDisplay OUTPUT;

    -- Build main query
    DECLARE @sql NVARCHAR(MAX) = '
        SELECT * FROM Accounts a 
        WHERE 1 = 1 
        AND a.Name LIKE ''%'' + @xName + ''%'' 
        AND a.AccountType LIKE ''%'' + @xAccountType + ''%''';

    IF @CashFrom IS NOT NULL
        SET @sql += ' AND a.Cash >= @xCashFrom';

    IF @CashTo IS NOT NULL
        SET @sql += ' AND a.Cash <= @xCashTo';

    SET @sql += ' ORDER BY ' + @OrderBy + ' OFFSET @PageSize * (@PageIndex - 1) ROWS FETCH NEXT @PageSize ROWS ONLY';

    DECLARE @params NVARCHAR(MAX) = '
        @xName NVARCHAR(MAX),
        @xAccountType NVARCHAR(MAX),
        @xCashFrom DECIMAL(18,2),
        @xCashTo DECIMAL(18,2),
        @PageIndex INT,
        @PageSize INT';

    EXEC sp_executesql @sql, @params,
        @xName = @Name,
        @xAccountType = @AccountType,
        @xCashFrom = @CashFrom,
        @xCashTo = @CashTo,
        @PageIndex = @PageIndex,
        @PageSize = @PageSize;

    -- Optional debug
    PRINT @sql;
    PRINT @countSql;
END
