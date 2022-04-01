--You have to define all necessary DB (database) objects to support an application used by a ships’
--monitoring system.

create database ShipsMonitoringSystem

--Your DB must contain information about:
--- Country (country_id, country_name)

CREATE TABLE Country(
country_id INT NOT NULL PRIMARY KEY,
country_name VARCHAR(50)
)

--- Port (port_id, port_name, port_country_id)

CREATE TABLE Port(
port_id INT NOT NULL,
port_name VARCHAR(50) NOT NULL PRIMARY KEY,
port_country_id INT
)

--- Ship (ship_id, ship_name, ship_speed_max)

CREATE TABLE Ship(
ship_id INT NOT NULL PRIMARY KEY,
ship_name VARCHAR(50),
ship_speed_max INT)

--- Voyage (voyage_ship_id, voyage_date, voyage_departure_port, voyage_start, voyage_arrival_port, voyage_end)
CREATE TABLE Voyage(
voyage_ship_id INT NOT NULL,
voyage_date date NOT NULL,
voyage_departure_port VARCHAR(50),
voyage_start datetime,
voyage_arrival_port VARCHAR(50),
voyage_end datetime
)

ALTER TABLE Voyage
ADD CONSTRAINT PK_Voyage PRIMARY KEY (voyage_ship_id, voyage_date)

ALTER TABLE Voyage
ADD CONSTRAINT FK_Ship_ID
FOREIGN KEY (Voyage_ship_id) REFERENCES Ship(Ship_ID)

select v.voyage_departure_port from Voyage v

ALTER TABLE Voyage
ADD CONSTRAINT FK_Departure_Port
FOREIGN KEY (Voyage_Departure_Port) REFERENCES Port(Port_name)

ALTER TABLE Voyage
ADD CONSTRAINT FK_Arrival_Port
FOREIGN KEY (Voyage_Arrival_Port) REFERENCES Port(Port_name)


ALTER TABLE Port
ADD CONSTRAINT FK_Port_ID
FOREIGN KEY (port_country_id) REFERENCES Country(Country_ID)



--2. Populate tables

INSERT INTO Country(country_id, country_name)
VALUES
(1, 'Albania'),
(2,'Andorra'),
(3,'Finland'),
(4,'France'),
(5,'Germany'),
(6,'Italy'),
(7, 'Latvia'),
(8, 'The Netherlands'),
(9, 'Romania'),
(10, 'Sweden'),
(11, 'China'),
(12, 'Australia'),
(13, 'Singapore'),
(14, 'Argentina'),
(15, 'Angola')


INSERT INTO Port(port_id, port_name, port_country_id)
VALUES
(1, 'Constanta', 9),
(2, 'Helsinki', 3),
(3, 'Riga', 7),
(4, 'Malmo', 10),
(5, 'Palermo', 6),
(6, 'Nanjing', 11),
(7, 'Guangzhou', 11),
(8, 'Luanda', 15),
(9, 'Brisbane', 12),
(10, 'Sydney', 12),
(11, 'Melbourne', 12),
(12, 'Singapore', 13),
(13, 'Ushuaia', 14)

INSERT INTO Ship(ship_id, ship_name, ship_speed_max)
VALUES
(1, 'MS Baltic Princess', 50),
(2, 'Stena Nautica', 45),
(3, 'Ever Given', 22),
(4, 'Ever Ace', 32),
(5, 'Fregata Regele Ferdinand', 36)


INSERT INTO Voyage(voyage_ship_id, voyage_date, voyage_departure_port, voyage_start, voyage_arrival_port, voyage_end)
VALUES
(1, '20220329', 'Helsinki', '20220329 17:00:00', 'Malmo', '20220330 20:00:00'),
(5, '20220211', 'Brisbane', '20220211 10:48:25', 'Constanta', '20220317 05:11:19'),
(5, '20220318', 'Constanta', '20220318 07:00:05', 'Riga', '20220322 22:13:46'),
(2, '20220223', 'Malmo', '20220223 16:27:21', 'Riga', '20220224 23:53:42'),
(2, '20211217', 'Singapore', '20211217 04:24:23', 'Brisbane', '20211229 17:23:31'),
(2, '20220210', 'Riga', '20220210 09:32:21', 'Malmo', '20220211 18:00:00'),
(5, '20220207', 'Singapore', '20220207 04:26:58', 'Brisbane', '20220209 21:08:01'),
(3, '20220305', 'Constanta', '20220305 07:00:05', 'Riga', '20220316 22:13:46'),
(3, '20220317', 'Riga', '20220317 14:22:39', 'Constanta', '20220331 16:12:44')

--3. Define a view that returns ports from a specific country order by name

GO
CREATE VIEW View_Australian_ports AS
SELECT p.port_id as 'PORT ID', p.port_name as 'PORT NAME', c.country_name as 'COUNTRY' FROM Port p
INNER JOIN Country c on p.port_country_id = c.country_id
WHERE c.country_name = 'Australia'
ORDER BY p.port_name
OFFSET 0 ROWS
GO

select * from View_Australian_ports

--4. Write a query that returns the number of the ports for each country that has at least one port
SELECT c.country_name, count(c.country_name) as 'Number of ports' From Country c
INNER JOIN Port p
on C.country_id = p.port_country_id
group by c.country_name

--5. Write a query that returns the number of the ports for each country, including the countries without ports
SELECT c.country_name, count(p.port_country_id) as 'Number of ports' From Country c
left JOIN Port p
on C.country_id = p.port_country_id
group by c.country_name


--6. Write a query that returns port_name and country_name for countries with more than one port

SELECT c.country_name, count(c.country_name) as 'Number of ports' From Country c
INNER JOIN Port p
on C.country_id = p.port_country_id
group by c.country_name
having count(c.country_name) > 1

--7. Write a query that returns the average time in days spent by a ship given as a parameter in a voyage for
--voyages started last month
--Select * from Ship s
--INNER JOIN Voyage v on s.ship_id = v.voyage_ship_id
--where (select month(v.voyage_date)) IN (SELECT (MONTH(GETDATE() - (SELECT day(GETDATE()+1)))))

GO
CREATE OR ALTER PROCEDURE ship_avg_voyage_days (@voyage_ship_id INT)
AS
BEGIN
	Select avg(datediff(day, CONVERT(DATE, v.voyage_start), CONVERT(DATE, v.voyage_end))) as 'Average of Days travelled'
	-- the average of the dfferences between the start date and end date
	from Voyage v
	INNER JOIN Ship s on v.voyage_ship_id = s.ship_id
	where v.voyage_ship_id = @voyage_ship_id
	AND 
	(select month(v.voyage_date)) IN (SELECT (MONTH(GETDATE() - (SELECT day(GETDATE()+1)))))
	-- the month of the voyage date is the previous month
	-- this is done by checking that the voyage began is the the month before,
	-- where the month before is computed by substracting (the number of days in this month + 1)
END

exec ship_avg_voyage_days @voyage_ship_id = 5

--select	CONVERT(DATE, v.voyage_start) as 'Start Date',
--		CONVERT(DATE, v.voyage_end) as 'End date',
--		(datediff(day, CONVERT(DATE, v.voyage_start), CONVERT(DATE, v.voyage_end))) as 'Days passed'
--from Voyage v
--inner join ship s on v.voyage_ship_id = s.ship_id
--where v.voyage_ship_id = 5