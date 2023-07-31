
-- 1. Create Procedure for Select all countries
CREATE PROCEDURE [dbo].[PR_Country_SelectAll]
AS

SELECT [dbo].[LOC_Country].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]

FROM [dbo].[LOC_Country]
ORDER BY [dbo].[LOC_Country].[CountryName]


-- 2. Create Procedure for Select all states
CREATE PROCEDURE [dbo].[PR_State_SelectAll]
AS

SELECT [dbo].[LOC_State].[StateID]
      ,[dbo].[LOC_State].[CountryID]
	  ,[dbo].[LOC_State].[StateName]
	  ,[dbo].[LOC_State].[StateCode]
	  ,[dbo].[LOC_State].[Created]
	  ,[dbo].[LOC_State].[Modified]

FROM [dbo].[LOC_State]
INNER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_Country].[CountryID] = [dbo].[LOC_State].[CountryID]
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]


-- 3. Create Procedure for Select all cities
CREATE PROCEDURE [dbo].[PR_City_SelectAll]
AS

SELECT [dbo].[LOC_City].[CityID]
	  ,[dbo].[LOC_City].[CityName]
	  ,[dbo].[LOC_City].[StateID]
	  ,[dbo].[LOC_City].[CountryID]
	  ,[dbo].[LOC_City].[Citycode]
	  ,[dbo].[LOC_City].[CreationDate]
	  ,[dbo].[LOC_City].[Modified]

FROM [dbo].[LOC_City]
INNER JOIN [dbo].[LOC_State]
ON [dbo].[LOC_State].[StateID] = [dbo].[LOC_City].[StateID]
INNER JOIN [dbo].[LOC_Country] 
ON [dbo].[LOC_Country].[CountryID] = [dbo].[LOC_State].[CountryID]
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]
		,[dbo].[LOC_City].[CityName]


--===========================================================================================================


-- 4. Create Procedure for Select Country by PK
CREATE PROCEDURE [dbo].[PR_Country_SelectByPK]
	@CountryID int
AS

SELECT [dbo].[LOC_Country].[CountryName]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]

FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID
ORDER BY [dbo].[LOC_Country].[CountryName]


-- 5. Create Procedure for Select State by PK
CREATE PROCEDURE [dbo].[PR_State_SelectByPK]
	@StateID int
AS

SELECT [dbo].[LOC_State].[StateID]
      ,[dbo].[LOC_State].[CountryID]
	  ,[dbo].[LOC_State].[StateName]
	  ,[dbo].[LOC_State].[StateCode]
	  ,[dbo].[LOC_State].[Created]
	  ,[dbo].[LOC_State].[Modified]

FROM [dbo].[LOC_State]
INNER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_Country].[CountryID] = [dbo].[LOC_State].[CountryID]
WHERE [dbo].[LOC_State].[StateID] = @StateID
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]


-- 6. Create Procedure for Select City by PK
CREATE PROCEDURE [dbo].[PR_City_SelectByPK]
	@CityID int
AS

SELECT [dbo].[LOC_City].[CityID]
	  ,[dbo].[LOC_City].[CityName]
	  ,[dbo].[LOC_City].[StateID]
	  ,[dbo].[LOC_City].[CountryID]
	  ,[dbo].[LOC_City].[Citycode]
	  ,[dbo].[LOC_City].[CreationDate]
	  ,[dbo].[LOC_City].[Modified]

FROM [dbo].[LOC_City]
INNER JOIN [dbo].[LOC_State]
ON [dbo].[LOC_State].[StateID] = [dbo].[LOC_City].[StateID]
INNER JOIN [dbo].[LOC_Country] 
ON [dbo].[LOC_Country].[CountryID] = [dbo].[LOC_State].[CountryID]
WHERE [dbo].[LOC_City].[CityID] = @CityID
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]
		,[dbo].[LOC_City].[CityName]



--===========================================================================================================


-- 7. Create Insert Procedure to add any new record for Country
CREATE PROCEDURE [dbo].[PR_Country_Insert_Record]
	@CountryName	varchar(100),
	@CountryCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_Country]
(
	[CountryName]
   ,[CountryCode]
)
VALUES
(
	@CountryName,
	@CountryCode
)


-- 8. Create Insert Procedure to add new record for State.
CREATE PROCEDURE [dbo].[PR_State_Insert_Record]
	@StateName	varchar(100),
	@CountryID	int,
	@StateCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_State]
(
	[StateName]
   ,[CountryID]
   ,[StateCode]
)
VALUES
(
	@StateName,
	@CountryID,
	@StateCode
)


-- 9. Create Insert Procedure to add new record for City.
CREATE PROCEDURE [dbo].[PR_City_Insert_Record]
	@CityName	varchar(100),
	@StateID	int,
	@CountryID	int,
	@CityCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_City]
(
	[CityName]
   ,[StateID]
   ,[CountryID]
   ,[Citycode]
)
VALUES
(
	@CityName,
	@StateID,
	@CountryID,
	@CityCode
)


--===========================================================================================================


-- 10. Create Update Procedure to edit/modeify existing record for Country.
CREATE PROCEDURE [dbo].[PR_Country_UpdateByPK]
	@CountryID		int,
	@CountryName	varchar(100),
	@CountryCode	varchar(50)

AS
UPDATE [dbo].[LOC_Country]
	
	SET [CountryName] = @CountryName,
		[CountryCode] = @CountryCode

	WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 11. Create Update Procedure to edit/modify existing record for State.
CREATE PROCEDURE [dbo].[PR_State_UpdateByPK]
	@StateID	int,
	@StateName	varchar(100),
	@CountryID	int,
	@StateCode	varchar(50)

AS
UPDATE [dbo].[LOC_State]

	SET [StateName] = @StateName,
		[CountryID] = @CountryID,
		[StateCode] = @StateCode

	WHERE [dbo].[LOC_State].[StateID] = @StateID


-- 12. Create Update Procedure to edit/modify existing record for City.
CREATE PROCEDURE [dbo].[PR_City_UpdateByPK]
	@CityID		int,
	@CityName	varchar(100),
	@StateID	int,
	@CountryID	int,
	@CityCode	varchar(50)

AS
UPDATE [dbo].[LOC_City]

	SET [CityName] = @CityName,
		[StateID] = @StateID,
		[CountryID] = @CountryID,
		[Citycode] = @CityCode

	WHERE [dbo].[LOC_City].[CityID] = @CityID
	

--===========================================================================================================


-- 13. Create Delete Procedure to delete record for Country.
CREATE PROCEDURE [dbo].[PR_Country_DeleteByPK]
	@CountryID	int

AS

DELETE FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 14. Create Delete Procedure to delete record for State.
CREATE PROCEDURE [dbo].[PR_State_DeleteByPK]
	@StateID	int

AS

DELETE FROM [dbo].[LOC_State]
WHERE [dbo].[LOC_State].[StateID] = @StateID


-- 13. Create Delete Procedure to delete record for City.
CREATE PROCEDURE [dbo].[PR_City_DeleteByPK]
	@CityID	int

AS

DELETE FROM [dbo].[LOC_City]
WHERE [dbo].[LOC_City].[CityID] = @CityID
