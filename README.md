# Fake Data Generator

## Purpose
Sample C# object-oriented REST API that generates fake data of nonexistent Danish persons.

## Dependencies

- The fake persons' first name, last name, and gender are extracted from the file `data/person-names.json`.
- The fake persons' postal code and town are extracted from the MySQL database `addresses`.

## Usage
- Start: `docker compose up --build -d`
- Stop: `docker compose down -v`

## MySQL Workbench
To connect to the MySQL database in MySQL Workbench, use:
- Host: `127.0.0.1`
- Port: `3308`
- User: `root`
- Password: `root`
- Schema: `addresses`

Then open the script in the `db` folder named `addresses.sql` and run it.  
This will insert all postal codes and cities into the database.