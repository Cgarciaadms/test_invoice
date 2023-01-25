/*
Procedimiento que actualiza la informacion de un cliente en especifico
Elaborado por: carlos Garcia
Fecha: 01/24/2023
*/

CREATE PROCEDURE sp_Update_Customer
@Id int,
@Custname varchar (70),
@Adress varchar(120),
@Status bit,
@CustomerTypeId int

AS


UPDATE 
	Customers 
SET
	CustName = @CustName,
	Adress = @Adress,
	Status = @Status,
	CustomerTypeId = @CustomerTypeId
WHERE
	Id = @Id