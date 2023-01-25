/*
Procedimeinto que inserta la cabecera de la factura
Elaborado por Carlos Garcia
Fecha: 24/01/2023
*/

CREATE PROCEDURE sp_Insert_Invoice
@Id int OUTPUT,
@CustomerId int,
@TotalItbis decimal(18, 2),
@SubTotal decimal(18, 2),
@Total decimal(18, 2)


AS 

INSERT INTO Invoice 
(
	CustomerId,
	TotalItbis,
	SubTotal,
	Total
)
VALUES
(
	@CustomerId,
	@TotalItbis,
	@SubTotal,
	@Total
)

SET @Id = @@IDENTITY