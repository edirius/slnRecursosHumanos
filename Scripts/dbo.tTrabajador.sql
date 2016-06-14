CREATE TABLE [dbo].[tTrabajador] (
    [IdTrabajador]     INT          NOT NULL,
    [NombreTrabajador] VARCHAR (30) NOT NULL,
    [ApePat]           VARCHAR (50) NOT NULL,
    [ApeMat]           VARCHAR (50) NOT NULL,
    [Direccion]        VARCHAR (50) NULL,
    [CelularEmpresa]   VARCHAR(15)   NULL,
    [CelularPersonal]  VARCHAR(15)   NULL,
    [Sexo]             BIT          NULL,
    [Ciudad]           INT          NULL,
    [FechaNacimiento]  DATE         NULL,
    [Activo]           BIT          NULL,
    [Sueldo] REAL NULL, 
    PRIMARY KEY CLUSTERED ([IdTrabajador] ASC)
);

