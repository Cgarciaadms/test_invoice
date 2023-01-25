/*
Procedimiento que trae los datos del detalle de un Invoice en especifico
Elaborado por Carlos Garcia
Fecha: 24/01/2023
*/


CREATE PROCEDURE sp_Invoice_Detail_Info
@Invoice int

AS

SELECT
	ROW_NUMBER() OVER(PARTITION BY CustomerId ORDER BY Id) as Linea,
	Qty as Cantidad,
	FORMAT(Price, 'C2') as Precio,
	FORMAT(TotalItbis, 'C2') as TotalItbis,
	FORMAT(SubTotal, 'C2') as SubTotal,
	FORMAT(Total, 'C2') as Total
FROM
	InvoiceDetail
WHERE
	CustomerId = @Invoice
	