DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `auto_input`(IN NumRows INT, IN MinVal INT, IN MaxVal INT, IN CurYear INT)
BEGIN
	DECLARE i INT;
    DECLARE cdate text;
	SET i = 1;
	WHILE i <= NumRows DO
		SET cdate = CONCAT(CurYear, '-', ROUND(RAND() * (12 - 1) + 1), '-', ROUND(RAND() * (30 - 1) + 1));
        INSERT INTO users ( Name, Bdate, Score ) VALUES (CONCAT("Name", i), cdate, ROUND(RAND() * (MaxVal - MinVal) + MinVal));
		SET i = i + 1;
	END WHILE;
    SET i = 1;
    WHILE i <= NumRows DO
		SET cdate = CONCAT(CurYear, '-', ROUND(RAND() * (12 - 1) + 1), '-', ROUND(RAND() * (30 - 1) + 1));
		INSERT INTO orders ( `Desc`, Odate, Cnt ) VALUES (CONCAT("Decs", i), cdate, ROUND(RAND() * (MaxVal - MinVal) + MinVal));
		SET i = i + 1;
	END WHILE;
END$$
DELIMITER ;
