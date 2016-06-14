CREATE TABLE [dbo].[tTrabajador_Periodo]
(
	[IdTrabajador] INT NOT NULL , 
    [IdPeriodo] INT NOT NULL, 
    PRIMARY KEY ([IdTrabajador], [IdPeriodo]), 
    CONSTRAINT [FK_tTrabajador_Periodo_ToTable] FOREIGN KEY ([idTrabajador]) REFERENCES [tTrabajador]([idTrabajador]), 
    CONSTRAINT [FK_tTrabajador_Periodo_ToTable_1] FOREIGN KEY ([idPeriodo]) REFERENCES [tPeriodo]([idPeriodo])
)
