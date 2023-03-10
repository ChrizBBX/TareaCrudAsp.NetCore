CREATE DATABASE TareaCrudEmpleado	

GO
USE TareaCrudEmpleado
GO

CREATE TABLE tbEmpleados
(
	empe_Id INT IDENTITY, 
	empe_Nombres NVARCHAR(150),
	empe_Apellidos  NVARCHAR(150),
	empe_Sexo   CHAR,
	empe_Telefono NVARCHAR(15),

	CONSTRAINT PK_tbEmpleados_empe_Id PRIMARY KEY(empe_Id),
	CONSTRAINT CK_tbEmpleados_empe_sexo CHECK (empe_Sexo IN ('M','F'))
);

INSERT INTO tbEmpleados
VALUES('Chris','Aguilar','M','99122654')

SELECT * FROM tbEmpleados