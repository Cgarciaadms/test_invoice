
/*
Procedimiento que Inserta el detalle de la factura
Elaborado por Carlos Garcia
Fecha: 24/01/2023
*/

ALTER PROCEDURE sp_Insert_Invoice_Detail
@Id int OUTPUT,
@CustomerId int,
@Qty int,
@Price decimal(18, 2),
@TotalItbis decimal(18, 2),
@SubTotal decimal(18, 2),
@Total decimal(18, 2)

AS 

INSERT INTO InvoiceDetail
(
	CustomerId,
	Qty,
	Price,
	TotalItbis,
	SubTotal,
	Total
)
VALUES
(
	@CustomerId,
	@Qty,
	@Price,
	@TotalItbis,
	@SubTotal,
	@Total
)

SET @Id = @@IDENTITY