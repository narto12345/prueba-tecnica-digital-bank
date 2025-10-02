CREATE DATABASE prueba_digital_bank;

CREATE TABLE USERS (
	id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
	name VARCHAR(100) NOT NULL,
    birthdate date NOT NULL,
    gender CHAR(1)
);

INSERT INTO users(name, birthdate, gender) VALUES ('Duvan', '2000-04-04', 'M'), ('David', '2000-04-28', 'M');

SELECT * FROM USERS;

