drop database if exists Advanced_Programming;
create database Advanced_Programming;
use Advanced_Programming;

# create user
CREATE USER IF NOT EXISTS 'neptune'@'localhost' IDENTIFIED BY 'n3ptun3';
CREATE USER IF NOT EXISTS 'neptune'@'%' IDENTIFIED BY 'n3ptun3';

GRANT ALL privileges ON Advanced_Programming.* TO 'ga-app'@'%';
GRANT ALL privileges ON Advanced_Programming.* TO 'ga-app'@'localhost';

FLUSH PRIVILEGES;

create table Person
(
    Id int auto_increment primary key,
    FirstName varchar(255),
    LastName varchar(255),
    Age int
);