/*
Procedimiento que consulta las facturas realizadas
Elaborado por Carlos García 
Fecha: 24/01/2023
*/

CREATE PROCEDURE sp_Invoice_Info
@Invoice int

AS

/*Si no se especifica un numero de factura se traeran todos los registros 
de lo contrario se traerá la informacion de la factura especififada*/

IF @Invoice = 0
BEGIN

	SELECT
		t0.Id as Invoice,
		t0.CustomerId,
		t1.CustName,
		FORMAT(t0.SubTotal, 'C2') as SubTotal,
		FORMAT(t0.TotalItbis, 'C2') as TotalItbis,
		FORMAT(t0.Total, 'C2') Total
	FROM
		Invoice t0
		INNER JOIN Customers t1 ON (t0.CustomerId = t1.Id)
	
END
ELSE
BEGIN

	SELECT
		t0.Id as Invoice,
		t0.CustomerId,
		t1.CustName,
		t1.Adress,
		FORMAT(t0.SubTotal, 'C2') as SubTotal,
		FORMAT(t0.TotalItbis, 'C2') as TotalItbis,
		FORMAT(t0.Total, 'C2') Total
	FROM
		Invoice t0
		INNER JOIN Customers t1 ON (t0.CustomerId = t1.Id)
	WHERE
		t0.Id = @Invoice

END