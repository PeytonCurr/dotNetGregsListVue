-- Active: 1686681110274@@rds-mysql-10mintutorial.c81ovpu4pgjf.us-west-2.rds.amazonaws.com@3306@dotNetGregsListVue

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8mb4 COMMENT '';

CREATE TABLE
    IF NOT EXISTS cars(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        make VARCHAR(255) NOT NULL,
        model VARCHAR(255) NOT NULL,
        imgUrl VARCHAR(255) NOT NULL,
        body VARCHAR(255) NOT NULL,
        pice INT NOT NULL,
        description VARCHAR(500) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 COMMENT '';