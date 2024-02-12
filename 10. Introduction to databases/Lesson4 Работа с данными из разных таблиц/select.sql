SELECT * FROM lesson4.`общий список`;
SELECT ФИО, `Д/р`, Адрес FROM lesson4.`общий список`;
SELECT ФИО, Статус FROM lesson4.`общий список` WHERE Адрес = 'Можга';
SELECT ФИО FROM lesson4.`общий список` WHERE Адрес = 'Москва' AND Группа = 'Работа';
SELECT `Д/р` FROM lesson4.`общий список` WHERE Адрес = 'Москва' OR Группа = 'Работа';

SELECT * FROM lesson4.Люди INNER JOIN lesson4.Адреса ON id = `Чей адрес`;
SELECT * FROM lesson4.Люди LEFT JOIN lesson4.Адреса ON id = `Чей адрес`;
SELECT * FROM lesson4.Люди RIGHT JOIN lesson4.Адреса ON id = `Чей адрес`;
SELECT * FROM lesson4.Люди FULL JOIN lesson4.Адреса ON id = `Чей адрес`;
-- В MySQL нет оператора FULL JOIN. Вместо этого можно использовать оператор LEFT JOIN и RIGHT JOIN с оператором UNION для эмуляции FULL JOIN
SELECT * FROM lesson4.Люди LEFT JOIN lesson4.Адреса ON id = `Чей адрес` UNION SELECT * FROM lesson4.Люди RIGHT JOIN lesson4.Адреса ON id = `Чей адрес`;
SELECT ФИО, Адрес, Комментарий FROM lesson4.Люди RIGHT JOIN lesson4.Адреса ON id = `Чей адрес`;