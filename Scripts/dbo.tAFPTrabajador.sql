CREATE TABLE [dbo].[tAFPTrabajador]
(
	[IdAFPTrabajador] INT NOT NULL PRIMARY KEY, 
    [idAFP] INT NULL, 
    [idComisionesAFP] INT NULL, 
    [FechaInicio] DATE NULL, 
    [FechaFin] DATE NULL, 
    [CUSSP] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Table_ToTable] FOREIGN KEY ([idAFP]) REFERENCES [tAFP]([idAFP]), 
    CONSTRAINT [FK_Table_ToTable_1] FOREIGN KEY ([idComisionesAFP]) REFERENCES [tComisionesAFP]([idComisionesAFP])
)
