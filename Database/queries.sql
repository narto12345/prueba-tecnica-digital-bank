CREATE DATABASE prueba_digital_bank;

CREATE TABLE USERS (
	id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
	name VARCHAR(100) NOT NULL,
    birthdate date NOT NULL,
    gender CHAR(1)
);

-- INSERT INTO users(name, birthdate, gender) VALUES ('Duvan', '2000-04-04', 'M'), ('David', '2000-04-28', 'M');

SELECT * FROM USERS;

/*
DELIMITER $$

CREATE PROCEDURE sp_users_crud(
    IN p_action VARCHAR(10),
    IN p_id INT,
    IN p_name VARCHAR(100),
    IN p_birthdate DATE,
    IN p_gender CHAR(1)
)
BEGIN
    IF UPPER(p_action) = 'INSERT' THEN
        INSERT INTO USERS(name, birthdate, gender) VALUES (p_name, p_birthdate, p_gender);
        SELECT LAST_INSERT_ID() AS new_id;

    ELSEIF 
		UPPER(p_action) = 'SELECT' AND p_id IS NULL THEN
        SELECT * FROM USERS;

    ELSEIF UPPER(p_action) = 'SELECT' AND p_id IS NOT NULL THEN
        SELECT * FROM USERS WHERE id = p_id;

    ELSEIF UPPER(p_action) = 'UPDATE' THEN
        UPDATE USERS
        SET name = p_name,
            birthdate = p_birthdate,
            gender = p_gender
        WHERE id = p_id;

        SELECT ROW_COUNT() AS updated_rows;

    ELSEIF UPPER(p_action) = 'DELETE' THEN
        DELETE FROM USERS WHERE id = p_id;
        SELECT ROW_COUNT() AS deleted_rows;
    END IF;
END$$

DELIMITER ;
*/

CALL sp_users_crud('INSERT', NULL, 'Angie', '2003-12-01', 'F');
CALL sp_users_crud('SELECT', NULL, NULL, NULL, NULL);
CALL sp_users_crud('SELECT', 4, NULL, NULL, NULL);
CALL sp_users_crud('UPDATE', 4, 'Nicolas Sosa', '2000-04-19', 'M');
CALL sp_users_crud('DELETE', 8, NULL, NULL, NULL);


