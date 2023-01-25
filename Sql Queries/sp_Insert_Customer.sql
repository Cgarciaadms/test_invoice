/*
Procedimiento que crea un cliente nuevo
Elaborado por: carlos Garcia
Fecha: 24/01/2023
*/

ALTER PROCEDURE sp_Insert_Customer
@Id int OUTPUT,
@Custname varchar (70),
@Adress varchar(120),
@Status bit,
@CustomerTypeId int

AS


INSERT INTO Customers 
(
	CustName,
	Adress,
	Status,
	CustomerTypeId
)
VALUES 
(
	@Custname,
	@Adress,
	@Status,
	@CustomerTypeId
)

SET @Id = @@IDENTITY