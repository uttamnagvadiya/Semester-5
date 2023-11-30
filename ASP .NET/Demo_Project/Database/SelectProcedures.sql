-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LOC_Country <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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


-- 2. Create Procedure for Select Country by PK
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_SelectByPK]
	@CountryID	int
AS
SELECT [dbo].[LOC_Country].[CountryID]
	  ,[dbo].[LOC_Country].[CountryName]
      ,[dbo].[LOC_Country].[CountryCode]
	  ,[dbo].[LOC_Country].[Created]
	  ,[dbo].[LOC_Country].[Modified]
FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID
ORDER BY [dbo].[LOC_Country].[CountryName]


-- 3. Create Insert Procedure to add any new record for Country
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_Insert_Record]
	@CountryName	varchar(100),
	@CountryCode	varchar(100)
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


-- 4. Create Update Procedure to edit/modify existing record for Country.
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_UpdateByPK]
	@CountryID				 int,
	@CountryName	varchar(100),
	@CountryCode	varchar(100)
AS
UPDATE [dbo].[LOC_Country]
	SET  [dbo].[LOC_Country].[CountryName] = @CountryName
		,[dbo].[LOC_Country].[CountryCode] = @CountryCode
		,[dbo].[LOC_Country].[Modified] = GETDATE()
	WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 5. Create Delete Procedure to delete record into Country Table.
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_DeleteByPK]
	@CountryID	int
AS
DELETE FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID


-- 6. Search Country by Country Name or Country Code.
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_Search]
	@CountryName	varchar(100) = null,
	@CountryCode	varchar(100) = null
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


-- 7. Country Name for Dropdown Combobox.
CREATE OR ALTER PROCEDURE [dbo].[PR_Country_SelectForDropdown]
AS
SELECT  [dbo].[LOC_Country].[CountryID]
	   ,[dbo].[LOC_Country].[CountryName]
FROM [dbo].[LOC_Country]
ORDER BY [dbo].[LOC_Country].[CountryName]





-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LOC_State <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

-- 1. Create Procedure for Select all states
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


-- 2. Create Procedure for Select State by PK
CREATE OR ALTER PROCEDURE [dbo].[PR_State_SelectByPK]
	@StateID	int
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


-- 3. Create Insert Procedure to add new record for State.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_Insert_Record]
	@CountryID			 int,
	@StateName	varchar(100),
	@StateCode	varchar(100)
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


-- 4. Create Update Procedure to edit/modify existing record for State.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_UpdateByPK]
	@StateID			 int,
	@CountryID			 int,
	@StateName	varchar(100),
	@StateCode	varchar(100)
AS
UPDATE [dbo].[LOC_State]
	SET  [dbo].[LOC_State].[StateName] = @StateName
		,[dbo].[LOC_State].[CountryID] = @CountryID
		,[dbo].[LOC_State].[StateCode] = @StateCode
		,[dbo].[LOC_State].[Modified] = GETDATE()
	WHERE [dbo].[LOC_State].[StateID] = @StateID


-- 5. Create Delete Procedure to delete record into State Table.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_DeleteByPK]
	@StateID	int
AS
DELETE FROM [dbo].[LOC_State]
WHERE [dbo].[LOC_State].[StateID] = @StateID


-- 6. Search State by State Name or State Code.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_Search]
	@StateName		varchar(100) = NULL,
	@StateCode		varchar(100) = NULL,
	@CountryName	varchar(100) = NULL
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
WHERE [dbo].[LOC_Country].[CountryName] LIKE CONCAT('%', @CountryName, '%')
AND [dbo].[LOC_State].[StateName] LIKE CONCAT('%', @StateName, '%')
AND [dbo].[LOC_State].[StateCode] LIKE CONCAT('%', @StateCode, '%')
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]


-- 7. State Name for Dropdown Combobox.
CREATE OR ALTER PROCEDURE [dbo].[PR_State_SelectForDropdown]
	@CountryID		int
AS
SELECT  [dbo].[LOC_State].[StateID]
	   ,[dbo].[LOC_State].[StateName]	
FROM [dbo].[LOC_State]
WHERE [dbo].[LOC_State].[CountryID] = @CountryID
ORDER BY [dbo].[LOC_State].[StateName]





-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> LOC_City <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

-- 1. Create Procedure for Select all cities
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


-- 2. Create Procedure for Select City by PK
CREATE OR ALTER PROCEDURE [dbo].[PR_City_SelectByPK]
	@CityID	 int
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


-- 3. Create Insert Procedure to add new record for City.
CREATE OR ALTER PROCEDURE [dbo].[PR_City_Insert_Record]
	@StateID			 int,
	@CountryID			 int,
	@CityName	varchar(100),
	@CityCode	varchar(100)
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


-- 4. Create Update Procedure to edit/modify existing record for City.
CREATE OR ALTER PROCEDURE [dbo].[PR_City_UpdateByPK]
	@CityID				 int,
	@StateID			 int,
	@CountryID			 int,
	@CityName	varchar(100),
	@CityCode	varchar(100)
AS
UPDATE [dbo].[LOC_City]
	SET  [dbo].[LOC_City].[CityName] = @CityName
		,[dbo].[LOC_City].[StateID] = @StateID
		,[dbo].[LOC_City].[CountryID] = @CountryID
		,[dbo].[LOC_City].[Citycode] = @CityCode
		,[dbo].[LOC_City].[Modified] = GETDATE()
	WHERE [dbo].[LOC_City].[CityID] = @CityID


-- 5. Create Delete Procedure to delete record into City Table.
CREATE OR ALTER PROCEDURE [dbo].[PR_City_DeleteByPK]
	@CityID	 int
AS
DELETE FROM [dbo].[LOC_City]
WHERE [dbo].[LOC_City].[CityID] = @CityID


-- 6. Search City by City Name or City Code.
CREATE OR ALTER PROCEDURE [dbo].[PR_City_Search]
	@CityName	varchar(100) = null,
	@CityCode	varchar(100) = null
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
WHERE [dbo].[LOC_City].[CityName] LIKE CONCAT('%', @CityName, '%')
AND [dbo].[LOC_City].[Citycode] LIKE CONCAT('%', @CityCode, '%')
ORDER BY [dbo].[LOC_Country].[CountryName]
        ,[dbo].[LOC_State].[StateName]
		,[dbo].[LOC_City].[CityName]


-- 7. City Name for Dropdown Combobox.
CREATE OR ALTER PROCEDURE [dbo].[PR_City_SelectForDropdown]
AS
SELECT	[dbo].[LOC_City].[CityID]
	   ,[dbo].[LOC_City].[CityName]
FROM [dbo].[LOC_City]
ORDER BY [dbo].[LOC_City].[CityName]




-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> MST_Branch <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

-- 1. Create Procedure for Select all branches.
CREATE OR ALTER PROCEDURE [dbo].[PR_Branch_SelectAll]
AS
SELECT  [dbo].[MST_Branch].[BranchID]
	   ,[dbo].[MST_Branch].[BranchName]
	   ,[dbo].[MST_Branch].[BranchCode]
	   ,[dbo].[MST_Branch].[Created]
	   ,[dbo].[MST_Branch].[Modified]
FROM [dbo].[MST_Branch]
ORDER BY [dbo].[MST_Branch].[BranchName]


-- 2. Create Procedure for Select Branch by PK.
CREATE OR ALTER PROCEDURE [dbo].[PR_Branch_SelectByPK]
	@BranchID	int
AS
SELECT  [dbo].[MST_Branch].[BranchID]
	   ,[dbo].[MST_Branch].[BranchName]
	   ,[dbo].[MST_Branch].[BranchCode]
	   ,[dbo].[MST_Branch].[Created]
	   ,[dbo].[MST_Branch].[Modified]
FROM [dbo].[MST_Branch]
WHERE [dbo].[MST_Branch].[BranchID] = @BranchID
ORDER BY [dbo].[MST_Branch].[BranchName]


-- 3. Create Insert Procedure to add new record for Branch.
CREATE OR ALTER PROCEDURE [dbo].[PR_Branch_Insert_Record]
	@BranchName	varchar(100),
	@BranchCode	varchar(100)
AS
INSERT INTO [dbo].[MST_Branch]
(
	[dbo].[MST_Branch].[BranchName],
	[dbo].[MST_Branch].[BranchCode]
)
VALUES
(
	@BranchName,
	@BranchCode
)


-- 4. Create Update Procedure to edit/modify existing record for Branch.
CREATE OR ALTER PROCEDURE [dbo].[PR_Branch_UpdateByPK]
	@BranchID			 int,
	@BranchName	varchar(100),
	@BranchCode varchar(100)
AS
UPDATE [dbo].[MST_Branch]
	SET [dbo].[MST_Branch].[BranchName] = @BranchName,
		[dbo].[MST_Branch].[BranchCode] = @BranchCode,
		[dbo].[MST_Branch].[Modified] = GETDATE()
	WHERE [dbo].[MST_Branch].[BranchID] = @BranchID


-- 5. Create Delete Procedure to delete record into Branch Table.
CREATE OR ALTER PROCEDURE [dbo].[PR_Branch_DeleteByPK]
	@BranchID int
AS
DELETE FROM [dbo].[MST_Branch]
WHERE [dbo].[MST_Branch].[BranchID] = @BranchID


-- 6. Search Branch by Branch Name or Branch Code.
CREATE OR ALTER PROCEDURE [dbo].[PR_Branch_Search]
	@BranchName	varchar(100) = null,
	@BranchCode varchar(100) = null
AS
SELECT	[dbo].[MST_Branch].[BranchID]
	   ,[dbo].[MST_Branch].[BranchName]
	   ,[dbo].[MST_Branch].[BranchCode]
	   ,[dbo].[MST_Branch].[Created]
	   ,[dbo].[MST_Branch].[Modified]
FROM [dbo].[MST_Branch]
WHERE [dbo].[MST_Branch].[BranchName] LIKE CONCAT('%', @BranchName, '%')
AND [dbo].[MST_Branch].[BranchCode] LIKE CONCAT('%', @BranchCode, '%')
ORDER BY [dbo].[MST_Branch].[BranchName]


-- 7. Branch Name for Dropdown Combobox
CREATE OR ALTER PROCEDURE [dbo].[PR_Branch_SelectForDropdown]
AS
SELECT  [dbo].[MST_Branch].[BranchID]
	   ,[dbo].[MST_Branch].[BranchName]
FROM [dbo].[MST_Branch]
ORDER BY [dbo].[MST_Branch].[BranchName]





-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> MST_Student <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

-- 1. Create Procedure for Select all students.
CREATE OR ALTER PROCEDURE [dbo].[PR_Student_SelectAll]
AS
SELECT  [dbo].[MST_Student].[StudentID]
	   ,[dbo].[MST_Student].[StudentName]
	   ,[dbo].[MST_Student].[BranchID]
	   ,[dbo].[MST_Branch].[BranchName]
	   ,[dbo].[MST_Branch].[BranchCode]
	   ,[dbo].[MST_Student].[CityID]
	   ,[dbo].[LOC_City].[CityName]
	   ,[dbo].[MST_Student].[Created]
FROM [dbo].[MST_Student]
INNER JOIN [dbo].[MST_Branch]
ON [dbo].[MST_Branch].[BranchID] = [dbo].[MST_Student].[BranchID]
INNER JOIN [dbo].[LOC_City]
ON [dbo].[LOC_City].[CityID] = [dbo].[MST_Student].[CityID]
ORDER BY [dbo].[MST_Student].[StudentID]


-- 2. Create Procedure for Select Student by PK.
CREATE OR ALTER PROCEDURE [dbo].[PR_Student_SelectByPK]
	@StudentID int
AS
SELECT  [dbo].[MST_Student].[StudentID]
	   ,[dbo].[MST_Student].[StudentName]
	   ,[dbo].[MST_Student].[Email]
	   ,[dbo].[MST_Student].[MobileNoStudent]
	   ,[dbo].[MST_Student].[MobileNoFather]
	   ,[dbo].[MST_Student].[BranchID]
	   ,[dbo].[MST_Branch].[BranchName]
	   ,[dbo].[MST_Branch].[BranchCode]
	   ,[dbo].[MST_Student].[CityID]
	   ,[dbo].[LOC_City].[CityName]
	   ,[dbo].[LOC_City].[Citycode]
	   ,[dbo].[LOC_State].[StateID]
	   ,[dbo].[LOC_State].[StateName]
	   ,[dbo].[LOC_State].[StateCode]
	   ,[dbo].[LOC_Country].[CountryID]
	   ,[dbo].[LOC_Country].[CountryName]
	   ,[dbo].[LOC_Country].[CountryCode]
	   ,[dbo].[MST_Student].[Created]
	   ,[dbo].[MST_Student].[Modified]
	   ,[dbo].[MST_Student].[Age]
	   ,[dbo].[MST_Student].[Address]
	   ,[dbo].[MST_Student].[BirthDate]
	   ,[dbo].[MST_Student].[Gender]
	   ,[dbo].[MST_Student].[IsActive]
FROM [dbo].[MST_Student]
INNER JOIN [dbo].[MST_Branch]
ON [dbo].[MST_Branch].[BranchID] = [dbo].[MST_Student].[BranchID]
INNER JOIN [dbo].[LOC_City]
ON [dbo].[LOC_City].[CityID] = [dbo].[MST_Student].[CityID]
INNER JOIN [dbo].[LOC_State]
ON [dbo].[LOC_City].[StateID] = [dbo].[LOC_State].[StateID]
INNER JOIN [dbo].[LOC_Country]
ON [dbo].[LOC_City].[CountryID] = [dbo].[LOC_Country].[CountryID]
WHERE [dbo].[MST_Student].[StudentID] = @StudentID
ORDER BY [dbo].[MST_Student].[StudentID]


-- 3. Create Insert Procedure to add new record for Student.
-- PR_Student_Insert_Record @StudentName="Uttam Nagvadiya", @Email="uttam123@gmail.com", @MobileNoStudent="1234567890", @BranchID=4, @CityID=1
CREATE OR ALTER PROCEDURE [dbo].[PR_Student_Insert_Record]
	@StudentName		varchar(100),
	@MobileNoStudent	varchar(100),
	@Email				varchar(100),
	@MobileNoFather		varchar(100) = null,
	@Address			varchar(500) = null,
	@Password			varchar(100) = null,
	@Gender				 varchar(50) = null,
	@BirthDate				datetime = null,
	@Age						 int = null,
	@IsActive					 bit = null,
	@BranchID					 int,
	@CityID						 int
	
AS
INSERT INTO [dbo].[MST_Student]
(
	[dbo].[MST_Student].[StudentName],
	[dbo].[MST_Student].[MobileNoStudent],
	[dbo].[MST_Student].[Email],
	[dbo].[MST_Student].[BranchID],
	[dbo].[MST_Student].[CityID],
	[dbo].[MST_Student].[MobileNoFather],
	[dbo].[MST_Student].[Address],
	[dbo].[MST_Student].[Password],
	[dbo].[MST_Student].[Gender],
	[dbo].[MST_Student].[BirthDate],
	[dbo].[MST_Student].[Age],
	[dbo].[MST_Student].[IsActive]
)
VALUES
(
	@StudentName,
	@MobileNoStudent,
	@Email,
	@BranchID,
	@CityID,
	@MobileNoFather,
	@Address,
	@Password,
	@Gender,
	@BirthDate,
	@Age,
	@IsActive
)


-- 4. Create Update Procedure to edit/modify existing record for Student.
CREATE OR ALTER PROCEDURE [dbo].[PR_Student_UpdateByPK]
	@StudentName		varchar(100),
	@MobileNoStudent	varchar(100),
	@Email				varchar(100),
	@MobileNoFather		varchar(100) = null,
	@Address			varchar(500) = null,
	@Password			varchar(100) = null,
	@Gender				 varchar(50) = null,
	@BirthDate				datetime = null,
	@Age						 int = null,
	@IsActive					 bit = null,
	@StudentID					 int,
	@BranchID					 int,
	@CityID						 int
AS
UPDATE [dbo].[MST_Student]
	SET [dbo].[MST_Student].[StudentName]		= @StudentName,
		[dbo].[MST_Student].[MobileNoStudent]	= @MobileNoStudent,
		[dbo].[MST_Student].[Email]				= @Email,
		[dbo].[MST_Student].[BranchID]			= @BranchID,
		[dbo].[MST_Student].[CityID]			= @CityID,
		[dbo].[MSt_Student].[MobileNoFather]	= @MobileNoFather,
		[dbo].[MST_Student].[Address]			= @Address,
		[dbo].[MST_Student].[Password]			= @Password,
		[dbo].[MST_Student].[Gender]			= @Gender,
		[dbo].[MST_Student].[BirthDate]			= @BirthDate,
		[dbo].[MST_Student].[Age]				= @Age,	
		[dbo].[MST_Student].[IsActive]			= @IsActive,
		[dbo].[MST_Student].[Modified]			= GETDATE()
	WHERE [dbo].[MST_Student].[StudentID]		= @StudentID


-- 5. Create Delete Procedure to delete record into Student Table.
CREATE OR ALTER PROCEDURE [dbo].[PR_Student_DeleteByPK]
	@StudentID int
AS
DELETE FROM [dbo].[MST_Student]
WHERE [dbo].[MST_Student].[StudentID] = @StudentID


-- 6.
CREATE OR ALTER PROCEDURE [dbo].[PR_Student_Search]
	@StudentName	varchar(100) = NULL,
	@BranchName		varchar(100) = NULL,
	@CityName		varchar(100) = NULL
AS
SELECT  [dbo].[MST_Student].[StudentID]
	   ,[dbo].[MST_Student].[StudentName]
	   ,[dbo].[MST_Student].[BranchID]
	   ,[dbo].[MST_Branch].[BranchName]
	   ,[dbo].[MST_Branch].[BranchCode]
	   ,[dbo].[MST_Student].[CityID]
	   ,[dbo].[LOC_City].[CityName]
	   ,[dbo].[MST_Student].[Created]
FROM [dbo].[MST_Student]
INNER JOIN [dbo].[MST_Branch]
ON [dbo].[MST_Branch].[BranchID] = [dbo].[MST_Student].[BranchID]
INNER JOIN [dbo].[LOC_City]
ON [dbo].[LOC_City].[CityID] = [dbo].[MST_Student].[CityID]
WHERE [dbo].[MST_Student].[StudentName] LIKE CONCAT('%', @StudentName, '%')
AND [dbo].[MST_Branch].[BranchName] LIKE CONCAT('%', @BranchName, '%')
AND [dbo].[LOC_City].[CityName] LIKE CONCAT('%', @CityName, '%')
ORDER BY [dbo].[MST_Student].[StudentID]