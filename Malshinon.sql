/* Create the database */
CREATE DATABASE  IF NOT EXISTS malshinon;

/* Switch to the malshinon database */
USE malshinon;
/* CREATE TABLE people*/
CREATE TABLE People
(id int PRIMARY KEY AUTO_INCREMENT ,
secret_code VARCHAR(250) UNIQUE,
first_name VARCHAR (250) UNIQUE,
last_name VARCHAR(250),
type ENUM ("reporter", "target", "both", "potential_agent"),
num_reports int DEFAULT 0,
num_mentions int DEFAULT 0  );

CREATE TABLE IntelReports
(id int PRIMARY KEY AUTO_INCREMENT ,
reporter_id int ,
target_id int ,
text Text, 
timestamp DATETIME DEFAULT NOW(),
FOREIGN KEY(reporter_id)REFERENCES People(id), 
FOREIGN KEY(target_id)REFERENCES People(id) );
