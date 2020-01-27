CREATE TABLE [dbo].[bank_client] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [nom]       VARCHAR (50) NOT NULL,
    [prenom]    VARCHAR (50) NOT NULL,
    [telephone] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[bank_compte] (
    [id]           INT             IDENTITY (1, 1) NOT NULL,
    [numero]       VARCHAR (50)    NOT NULL,
    [idClient]     INT             NOT NULL,
    [solde]        DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[bank_operation] (
    [id]           INT             IDENTITY (1, 1) NOT NULL,
    [numCompte]    VARCHAR (50)    NOT NULL,
    [dateCreation] DATETIME        NOT NULL,
    [type]         VARCHAR (50)    NOT NULL,
    [montant]      DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);