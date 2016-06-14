CREATE TABLE [dbo].[tComisionesAFP]
(
	[IdComisionesAFP] INT NOT NULL PRIMARY KEY, 
    [idAFP] INT NULL, 
    [mes] DATE NULL, 
    [comisionFija] REAL NULL, 
    [comisionVariable] REAL NULL, 
    [primaSeguros] REAL NULL, 
    [comisionFlujo] REAL NULL, 
    [remuneracionMaxima] REAL NULL
)
