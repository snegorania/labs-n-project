CREATE TABLE region (
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	name varchar(162)
);

CREATE TABLE sensor (
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	id_region int,
	name varchar(100),
	latitude double,
	longitude double,
  FOREIGN KEY (id_region) REFERENCES region(id) ON DELETE SET NULL
);

CREATE TABLE indication (
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	id_sensor int,
	date_indication date,
	time_indication time,
	temperature double,
  FOREIGN KEY (id_sensor) REFERENCES sensor(id) ON DELETE SET NULL
);

CREATE TABLE user (
  id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	login VARCHAR(100),
  password VARCHAR(100),
  mail VARCHAR (100)
);

INSERT INTO region (name)
VALUES 
('Minsk'), 
('Homiel'), 
('Brest'), 
('Mogilev'), 
('Vitebsk'), 
('Zhlobin'), 
('Pruzhany'), 
('Bobruisk');

INSERT INTO sensor (id_region, name, latitude, longitude)
VALUES
(1, 'Mi0', 53.903060, 27.598118),
(1, 'Mi1', 53.917752, 27.595064),
(2, 'Ho0', 52.406773, 30.938385),
(2, 'Ho1', 52.445106, 30.995607),
(3, 'Br0', 52.086048, 23.654296),
(3, 'Br1', 52.109189, 23.634521),
(4, 'Mo0', 53.887884, 30.358338),
(4, 'Mo1', 53.947128, 30.421592),
(5, 'Vi0', 55.168744, 30.141959),
(5, 'Vi1', 55.168744, 30.141959),
(6, 'Zh0', 52.912732, 30.057463),
(6, 'Zh1', 52.873748, 30.010066),
(7, 'Pr0', 52.583217, 24.439599),
(7, 'Pr1', 52.580260, 24.365605),
(8, 'Bo0', 53.184210, 29.125015),
(8, 'Bo1', 53.143378, 29.078073);

INSERT INTO indication (id_sensor,	date_indication,	time_indication, temperature)
VALUES
(17, '2023-09-09', '10:00:00', 10),
(17, '2023-09-09', '20:00:00', 7),
(18, '2023-09-09', '10:00:00', 13),
(18, '2023-09-09', '20:00:00', 14),
(19, '2023-09-09', '10:00:00', 0),
(19, '2023-09-09', '20:00:00', 7),
(20, '2023-09-09', '10:00:00', 13),
(20, '2023-09-09', '20:00:00', 15),
(21, '2023-09-09', '10:00:00', 20),
(21, '2023-09-09', '20:00:00', 19),
(22, '2023-09-09', '10:00:00', 4),
(22, '2023-09-09', '20:00:00', 7),
(23, '2023-09-09', '10:00:00', 17),
(23, '2023-09-09', '20:00:00', 14),
(24, '2023-09-09', '10:00:00', 0),
(24, '2023-09-09', '20:00:00', -1),
(25, '2023-09-09', '10:00:00', 6),
(25, '2023-09-09', '20:00:00', 9),
(26, '2023-09-09', '10:00:00', 5),
(26, '2023-09-09', '20:00:00', 2),
(27, '2023-09-09', '10:00:00', 0),
(27, '2023-09-09', '20:00:00', -7),
(28, '2023-09-09', '10:00:00', 30),
(28, '2023-09-09', '20:00:00', 27),
(29, '2023-09-09', '10:00:00', 18),
(29, '2023-09-09', '20:00:00', 13),
(30, '2023-09-09', '10:00:00', 6),
(30, '2023-09-09', '20:00:00', 3),
(31, '2023-09-09', '10:00:00', 14),
(31, '2023-09-09', '20:00:00', 17),
(32, '2023-09-09', '10:00:00', 7),
(32, '2023-09-09', '20:00:00', 7);

INSERT INTO user(login, password, mail)
VALUES
('Anna', '123', 'realgasarrow@gmail.com'),
('Katya', '456', 'ek.smuraga@gmail.com'),
('Admin', 'admin', 'noreply@admin.com'),
('Sergey','changeme', 'svelimovich@mail.ru'),
('Medv', '777','clonov02@mail.ru');

DELIMETER //
CREATE PROCEDURE temp_min_max (IN temp_date1 date, IN temp_date2 date)
BEGIN
  SELECT MIN(temperature) AS min_temp, MAX(temperature) AS max_temp FROM indication WHERE date_indication BETWEEN temp_date1 AND temp_date2;
END//
CREATE PROCEDURE temp_dev ()
begin
SELECT name, temperature, ABS(temperature - (SELECT AVG(temperature) FROM indication)) AS deviation
FROM indication INNER JOIN sensor ON sensor.id = id_sensor;
end //
CREATE PROCEDURE temp_loc (IN name_region VARCHAR(162))
begin
SELECT sensor.name, latitude, longitude 
FROM sensor INNER JOIN region ON region.id = id_region
WHERE region.name = name_region;
END//
CREATE PROCEDURE temperature_date(IN temp_date date, IN temp_time time)
BEGIN
  SELECT sensor.name, temperature FROM indication INNER JOIN sensor ON id_sensor = sensor.id WHERE date_indication = temp_date AND time_indication = temp_time ORDER BY temperature;
END//
