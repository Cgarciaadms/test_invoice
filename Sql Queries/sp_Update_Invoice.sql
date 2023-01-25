/*
Procedimeinto que actualiza la cabecera de la factura
Elaborado por Carlos Garcia
Fecha: 24/01/2023
*/

ALTER PROCEDURE sp_Update_Invoice
@Id int,
@CustomerId int,
@TotalItbis decimal(18, 2),
@SubTotal decimal(18, 2),
@Total decimal(18, 2)


AS 

UPDATE
	Invoice
SET
	CustomerId = @CustomerId,
	TotalItbis = @TotalItbis,
	SubTotal = @SubTotal,
	Total= @Total
WHERE
	Id = @Id