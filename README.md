# Fake Data Generator

## Purpose
Sample C# object-oriented REST API that generates fake data of nonexistent Danish persons.

## Dependencies

- The fake persons' first name, last name, and gender are extracted from the file `data/person-names.json`.
- The fake persons' postal code and town are extracted from the MySQL database `addresses`.

## Usage
- Start: `docker compose up --build -d`
- Stop: `docker compose down -v`