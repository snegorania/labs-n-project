CREATE PROCEDURE temp_loc (IN name_region VARCHAR(162))
begin
SELECT Название_датчика, Пространственная_координата_датчика_широта, Пространственная_координата_датчика_долгота
FROM датчики INNER JOIN регионы ON регионы.Номер_региона = датчики.Номер_региона
WHERE Название_региона = name_region;
END