create PROCEDURE BuscaPopulacaoPorPais
    @Nome_Pais VARCHAR(100)
AS
BEGIN
    SELECT Population, Year
    FROM population
    WHERE Entity like @Nome_Pais
	order by Year
END