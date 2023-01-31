DELIMITER //
CREATE PROCEDURE temp_min_max (IN temp_date1 date, IN temp_date2 date)
BEGIN
  SELECT MIN(Значение_температуры) AS min_temp, MAX(Значение_температуры) AS max_temp FROM регистрация_показаний WHERE Дата_регистрации_показаний BETWEEN temp_date1 AND temp_date2;
END //