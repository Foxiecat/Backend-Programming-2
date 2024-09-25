drop database if exists ga_emne7_avansert;
create database ga_emne7_avansert;
use ga_emne7_avansert;

# create user
CREATE USER IF NOT EXISTS 'neptune'@'localhost' IDENTIFIED BY 'Progynova2';
CREATE USER IF NOT EXISTS 'neptune'@'%' IDENTIFIED BY 'Progynova2';

GRANT ALL privileges ON ga_emne7_avansert.* TO 'neptune'@'%';
GRANT ALL privileges ON ga_emne7_avansert.* TO 'neptune'@'localhost';

FLUSH PRIVILEGES;

create table Person
(
    Id int auto_increment primary key,
    FirstName varchar(255),
    LastName varchar(255),
    Age int
);