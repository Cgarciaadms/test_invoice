/*
Procedimiento que consulta los clientes creados
Elaborado por Carlos Garcia
Fecha: 24/01/2023
*/

ALTER PROCEDURE sp_Search_Customer 
@CtdRegistros int,
@Criterio varchar(70),
@Status bit,
@CustomerIdType int

AS

--EXEC sp_Search_Customer 100, '', null, 0

DECLARE @Sql nvarchar(max),
		@LocalParams Nvarchar(max),
		@Where varchar(max)


--Si la cantidad de registros a devolver es igual a cero traera todos los registros de lo contrario devolvera la cantidad especificada
IF @CtdRegistros =  0
	SET @Sql = 'SELECT '
ELSE 
	SET @Sql = 'SELECT TOP ' + CAST(@CtdRegistros as varchar(25))

--Campos a devolver en la consulta
SET @Sql = @Sql + 't0.Id,
				   t0.CustName,
				   t0.Adress,
				   t0.Status,
				   t0.CustomerTypeId,
				   t1.Description '

--Establecemos el from u origen de los datos
SET @Sql = @Sql + 'FROM Customers t0
				   INNER JOIN	CustomerTypes t1 ON (t0.CustomerTypeId = t1.Id) '

--Se establecen los filtros a realizar
SET @Where = ''

--Filtro del criterio si el mismo no es nulo o no viene vacío
IF ISNULL(@Criterio, '') <> ''
BEGIN	
	--Se valida si el criterio es numerico para realizar la busqueda por el ID del cliente, si no es numerico se buscara por el nombre del cliente
	IF ISNUMERIC(@Criterio) = 1
	BEGIN
		SET @Where = 'WHERE t0.Id = @Criterio '
	END
	ELSE
	BEGIN
		SET @Criterio = '%' + @Criterio + '%'
		SET @Where = 'WHERE t0.CustName LIKE @Criterio '
	END
END

--Filtro del status
IF @Status IS NOT NULL
BEGIN
	--Se validada si el criterio no es null o si está vacío, esto para establecer la clausula where de ser necesario
	IF ISNULL(@Criterio, '') <> ''
	BEGIN
		SET @Where = @Where + 'AND t0.Status = @Status '
	END
	ELSE
	BEGIN
		SET @Where = 'WHERE t0.Status = @Status '
	END
END

--Filtro del customerIdType
--Se valida si el customer type es mayor a cero. Si es mayor a cero el usuario quiere realizar la busqueda por customerType
IF @CustomerIdType > 0
BEGIN
	--Se validada si el criterio no es null o si está vacío y si el status no es null esto para establecer la clausula where de ser necesario
	IF ISNULL(@Criterio, '') <> '' OR @Status IS NOT NULL
	BEGIN
		SET @Where = @Where + 'AND t0.CustomerTypeId = @CustomerIdType '
	END
	ELSE
	BEGIN
		SET @Where = 'WHERE t0.CustomerTypeId = @CustomerIdType '
	END
END

--Establecemos los parametros que serán enviados en el query string
 SET @LocalParams = '@Criterio			varchar(70),
				     @Status			bit,
				     @CustomerIdType	int'

--Creamos el query string que se quiere ejecutar con las variables @Sql y @Where
SET @Sql = @Sql + @Where

--Ejecutamos el query string
EXEC sp_executesql @Sql,
				   @LocalParams,
				   @Criterio,
				   @Status,
				   @CustomerIdType
