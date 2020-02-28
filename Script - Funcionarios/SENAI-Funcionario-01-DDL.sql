CREATE DATABASE T_Peoples;
GO

USE T_Peoples;
GO

CREATE TABLE Funcionario (
	IdFucionario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR (255),
	Sobrenome		VARCHAR (255)
	);
	GO

CREATE TABLE Data_Nascimento (
	IdData_Nascimento	INT PRIMARY KEY IDENTITY,
	Data_Nascimento		DATETIME2
	);
	GO

CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	NomeUsuario		VARCHAR (255) UNIQUE
	);
	GO

CREATE TABLE Usuario (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	Email			VARCHAR (255) NOT NULL UNIQUE,
	Senha			VARCHAR (255) NOT NULL,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
	);
	GO