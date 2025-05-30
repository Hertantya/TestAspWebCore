--Run this script first
create Database TestDb

USE [TestDb]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](50) NULL,
	[EmpAge] [int] NULL,
	[EmpAddress] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddEmployee]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddEmployee]
    @Name varchar(50),
    @Age int,
    @Address varchar(50)
AS
BEGIN
    INSERT INTO Employee(EmpName, EmpAge, EmpAddress)
    VALUES (@Name, @Age, @Address);
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEmployee]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Delete
CREATE PROCEDURE [dbo].[sp_DeleteEmployee]
    @Id INT
AS
BEGIN
    DELETE FROM Employee WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmployee]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Read (Get all)
CREATE PROCEDURE [dbo].[sp_GetAllEmployee]
AS
BEGIN
    SELECT * FROM Employee;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeById]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Read (Get by ID)
CREATE PROCEDURE [dbo].[sp_GetEmployeeById]
    @Id INT
AS
BEGIN
    SELECT * FROM Employee WHERE Id = @Id;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeList]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Read (Get all)
create PROCEDURE [dbo].[sp_GetEmployeeList]
AS
BEGIN
    SELECT Id,EmpName FROM Employee;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrderList]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Read (Get all)
create PROCEDURE [dbo].[sp_GetOrderList]
AS
BEGIN
    SELECT A.Id , B.EmpName , C.Name, A.Amount
	from 
	dbo.[Order] A 
	inner join 
	Employee B on A.EmployeeId = B.Id
	inner join
	Product C on A.ProductId = C.Id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductList]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Read (Get all)
create PROCEDURE [dbo].[sp_GetProductList]
AS
BEGIN
    SELECT Id,Name FROM Product;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 5/27/2025 3:59:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Update
CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
    @Id INT,
    @Name varchar(50),
    @Age int,
    @Address varchar(50)
AS
BEGIN
    UPDATE Employee
    SET EmpName = @Name,
        EmpAge = @Age,
        EmpAddress = @Address
    WHERE Id = @Id;
END

GO
