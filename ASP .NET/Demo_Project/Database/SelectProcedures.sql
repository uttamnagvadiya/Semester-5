-- 1. Create Procedure for Select all countries
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_SelectAll]
AS

SELECT [dbo].[LOC_Country].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]

FROM [dbo].[LOC_Country]
ORDER BY [dbo].[LOC_Country].[CountryName]


-- 2. Create Procedure for Select all states
-- PR_State_SelectAll
CREATE OR ALTER PROCEDURE [dbo].[PR_State_SelectAll]
AS

SELECT [dbo].[LOC_State].[StateID]
      ,[dbo].[LOC_Country].[CountryName]
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
CREATE OR ALTER PROCEDURE [dbo].[PR_City_SelectAll]
AS

SELECT [dbo].[LOC_City].[CityID]
	  ,[dbo].[LOC_City].[CityName]
	  ,[dbo].[LOC_City].[Citycode]
	  ,[dbo].[LOC_City].[StateID]
	  ,[dbo].[LOC_State].[StateName]
	  ,[dbo].[LOC_City].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
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
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_SelectByPK]
	@CountryID int
AS

SELECT [dbo].[LOC_Country].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]

FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID
ORDER BY [dbo].[LOC_Country].[CountryName]


-- 5. Create Procedure for Select State by PK
CREATE OR ALTER PROCEDURE [dbo].[PR_State_SelectByPK]
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
CREATE OR ALTER PROCEDURE [dbo].[PR_City_SelectByPK]
	@CityID int
AS

SELECT [dbo].[LOC_City].[CityID]
	  ,[dbo].[LOC_City].[CityName]
	  ,[dbo].[LOC_City].[StateID]
	  ,[dbo].[LOC_State].[StateName]
	  ,[dbo].[LOC_City].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
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
-- [PR_Country_Insert_Record] @CountryName = 'India', @CountryCode = 'IND'
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_Insert_Record]
	@CountryName	varchar(100),
	@CountryCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_Country]
(
	[dbo].[LOC_Country].[CountryName]
   ,[dbo].[LOC_Country].[CountryCode]
)
VALUES
(
	@CountryName,
	@CountryCode
)


-- 8. Create Insert Procedure to add new record for State.
-- PR_State_Insert_Record @StateName = 'Maharashtra', @StateCode = 'MH', @CountryID = 15
CREATE OR ALTER PROCEDURE [dbo].[PR_State_Insert_Record]
	@StateName	varchar(100),
	@CountryID	int,
	@StateCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_State]
(
	[dbo].[LOC_State].[StateName]
   ,[dbo].[LOC_State].[CountryID]
   ,[dbo].[LOC_State].[StateCode]
)
VALUES
(
	@StateName,
	@CountryID,
	@StateCode
)


-- 9. Create Insert Procedure to add new record for City.
-- PR_City_Insert_Record @CityName = 'Jamnagar', @CityCode = 'JM', @StateID = 1, @CountryID = 15
CREATE OR ALTER PROCEDURE [dbo].[PR_City_Insert_Record]
	@CityName	varchar(100),
	@StateID	int,
	@CountryID	int,
	@CityCode	varchar(50)

AS
INSERT INTO [dbo].[LOC_City]
(
	[dbo].[LOC_City].[CityName]
   ,[dbo].[LOC_City].[StateID]
   ,[dbo].[LOC_City].[CountryID]
   ,[dbo].[LOC_City].[Citycode]
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
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_UpdateByPK]
	@CountryID		int,
	@CountryName	varchar(100),
	@CountryCode	varchar(50)

AS
UPDATE [dbo].[LOC_Country]
	
	SET  [dbo].[LOC_Country].[CountryName] = @CountryName
		,[dbo].[LOC_Country].[CountryCode] = @CountryCode
		,[dbo].[LOC_Country].[Modified] = GETDATE()

	WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 11. Create Update Procedure to edit/modify existing record for State.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_UpdateByPK]
	@StateID	int,
	@StateName	varchar(100),
	@CountryID	int,
	@StateCode	varchar(50)

AS
UPDATE [dbo].[LOC_State]

	SET  [dbo].[LOC_State].[StateName] = @StateName
		,[dbo].[LOC_State].[CountryID] = @CountryID
		,[dbo].[LOC_State].[StateCode] = @StateCode
		,[dbo].[LOC_State].[Modified] = GETDATE()

	WHERE [dbo].[LOC_State].[StateID] = @StateID


-- 12. Create Update Procedure to edit/modify existing record for City.
CREATE OR ALTER PROCEDURE [dbo].[PR_City_UpdateByPK]
	@CityID		int,
	@CityName	varchar(100),
	@StateID	int,
	@CountryID	int,
	@CityCode	varchar(50)

AS
UPDATE [dbo].[LOC_City]

	SET  [dbo].[LOC_City].[CityName] = @CityName
		,[dbo].[LOC_City].[StateID] = @StateID
		,[dbo].[LOC_City].[CountryID] = @CountryID
		,[dbo].[LOC_City].[Citycode] = @CityCode
		,[dbo].[LOC_City].[Modified] = GETDATE()

	WHERE [dbo].[LOC_City].[CityID] = @CityID
	

--===========================================================================================================


-- 13. Create Delete Procedure to delete record for Country.
-- [PR_Country_DeleteByPK] @CountryID = 7
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_DeleteByPK]
	@CountryID	int

AS

DELETE FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 14. Create Delete Procedure to delete record for State.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_DeleteByPK]
	@StateID	int

AS

DELETE FROM [dbo].[LOC_State]
WHERE [dbo].[LOC_State].[StateID] = @StateID


-- 15. Create Delete Procedure to delete record for City.
CREATE OR ALTER PROCEDURE [dbo].[PR_City_DeleteByPK]
	@CityID	int

AS

DELETE FROM [dbo].[LOC_City]
WHERE [dbo].[LOC_City].[CityID] = @CityID


--===========================================================================================================

-- 26. Search Country by Country Name or Country Code.
-- PR_Country_Search @CountryName = ''
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_Search]
	@CountryName	varchar(150) = null,
	@CountryCode	varchar(25) = null
AS

SELECT [dbo].[LOC_Country].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]

FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryName] LIKE CONCAT('%', @CountryName, '%')
AND [dbo].[LOC_Country].[CountryCode] LIKE CONCAT('%', @CountryCode, '%')
ORDER BY [dbo].[LOC_Country].[CountryName]
.


-- 27. Search State by State Name or State Code.



-- 28. Search City by City Name or City Code.



-- 29. Country Name for Dropdown Combobox.
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_SelectForDropdown]
AS
SELECT  [dbo].[LOC_Country].[CountryID]
	   ,[dbo].[LOC_Country].[CountryName]
FROM [dbo].[LOC_Country]
ORDER BY [dbo].[LOC_Country].[CountryName]



-- 30. State Name for Dropdown Combobox.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_SelectForDropdown]
AS
SELECT  [dbo].[LOC_State].[StateID]
	   ,[dbo].[LOC_State].[StateName]	
FROM [dbo].[LOC_State]
ORDER BY [dbo].[LOC_State].[StateName]