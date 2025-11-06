CREATE DATABASE CosmeticsDB;
GO
USE CosmeticsDB;

CREATE TABLE Make_products (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT,
    ImagePath VARCHAR(200)
);

CREATE TABLE Hair_products (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT,
    ImagePath VARCHAR(200)
);

CREATE TABLE Skin_products (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT,
    ImagePath VARCHAR(200)
);

CREATE TABLE Per_products (
    ProductID INT PRIMARY KEY IDENTITY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT,
    ImagePath VARCHAR(200)
);

CREATE TABLE Cart (
    CartID INT PRIMARY KEY IDENTITY,
    ProductID INT,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT,
    TotalAmount DECIMAL(10,2)
);

CREATE TABLE Customer (
    UserID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100),
    Gender VARCHAR(10),
    Email VARCHAR(100),
    Phone VARCHAR(15),
    Address VARCHAR(200),
    Password VARCHAR(50)
);

CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY IDENTITY,
    UserID INT,
    TotalAmount DECIMAL(10,2),
    PaymentDate DATETIME DEFAULT GETDATE()
);
