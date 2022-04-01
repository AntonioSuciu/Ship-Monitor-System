# Ship-Monitor-System

This aplication was done as part of the SQL Knowledge Checking for NAPA.

A.1. In the SQL File, you can find all necessary DB (database) objects to support an application used by a ships’ monitoring system.

1.  DB contains information about:
- Country 
  - country_id 
  - country_name
- Port 
  - port_id
  - port_name
  - port_country_id
- Ship 
  - ship_id
  - ship_name
  - ship_speed_max
- Voyage 
  - voyage_ship_id
  - voyage_date 
  - voyage_departure_port
  - voyage_start
  - voyage_arrival_port
  - voyage_end

2. Populate tables

3. Define a view that returns ports from a specific country order by name

4. Write a query that returns the number of the ports for each country that has at least one port

5. Write a query that returns the number of the ports for each country, including the countries without ports

6. Write a query that returns port_name and country_name for countries with more than one port

7. Write a query that returns the average time in days spent by a ship given as a parameter in a voyage for voyages started last month

B. 1. A Web Application that uses the Database described above. The application allows for data visualization as defined by point A.1.7. So far, the application uses for Backend: C#. Using Github forVersion Control during development.
