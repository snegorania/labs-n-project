CREATE TABLE регионы (
	Номер_региона int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	Название_региона varchar(162)
);

CREATE TABLE датчики (
	Номер_датчика int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	Номер_региона int,
	Название_датчика varchar(100),
	Пространственная_координата_датчика_широта double,
	Пространственная_координата_датчика_долгота double,
  FOREIGN KEY (Номер_региона) REFERENCES регионы(Номер_региона)
);

CREATE TABLE регистрация_показаний (
	Номер_регистрации_показаний int PRIMARY KEY AUTO_INCREMENT NOT NULL,
	Номер_датчика int,
	Дата_регистрации_показаний date,
	Время_регистрации_показаний time,
	Значение_температуры double,
  FOREIGN KEY (Номер_датчика) REFERENCES датчики(Номер_датчика)
);
