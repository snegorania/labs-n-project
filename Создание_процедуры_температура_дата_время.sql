DELIMITER //
CREATE PROCEDURE temperature_date(IN temp_date date, IN temp_time time)
BEGIN
  SELECT Значение_температуры FROM регистрация_показаний WHERE Дата_регистрации_показаний = temp_date AND Время_регистрации_показаний = temp_time;
END //