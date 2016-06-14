CREATE TABLE [dbo].[tDetalleConcepto]
(
	[IdDetallePlanilla] INT NOT NULL , 
    [idConcepto] INT NOT NULL, 
    [Monto] REAL NULL, 
    PRIMARY KEY ([IdDetallePlanilla], [idConcepto])
)
