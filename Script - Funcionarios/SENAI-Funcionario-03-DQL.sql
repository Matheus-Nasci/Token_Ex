USE T_Peoples;

SELECT * FROM Funcionario;
SELECT * FROM Data_Nascimento;

SELECT Nome, Sobrenome FROM Funcionario

UPDATE Funcionario SET Nome = 'Paulo', Sobrenome = 'Andrade' WHERE IdFucionario = 3;

DELETE FROM Funcionario WHERE IdFucionario = 6;

SELECT IdTipoUsuario, NomeUsuario FROM TipoUsuario;