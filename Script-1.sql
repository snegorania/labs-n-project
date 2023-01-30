CREATE TABLE Регионы (
	Номер_региона int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	Название_региона varchar(162)
);

CREATE TABLE Датчики (
	Номер_датчика int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	Номер_региона int FOREIGN KEY Регионы.Номер_региона,
	Название_датчика varchar(100),
	Пространственная_координата_датчика_широта double,
	Пространственная_координата_датчика_долгота double,
);

CREATE TABLE Регистрация_показаний (
	Номер_регистрации_показаний int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	Номер_датчика int FOREIGN KEY Датчики.Название_датчика,
	Дата_регистрации_показаний date,
	Время_регистрации_показаний time,
	Значение_температуры double
);

INSERT INTO Регионы (Название_региона)
VALUES 
(Беларусь),
(Укракина),
(Россия),
(Узбекистан),
(Казахстан),
(Туркменистан),
(Грузия);

