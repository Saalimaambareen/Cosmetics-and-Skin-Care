# Cosmetics-and-Skin-Care
A desktop application that allows users to register, browse, and purchase cosmetic products through an interactive cart and payment system. Includes an admin module to view products, customers, and purchase details. Built using Visual Basic .NET and SQL Server for smooth database integration and efficient management.
# 💄 Cosmetics and Skin Care System

### A VB.NET + SQL Server-based shopping management system  
Developed by **Saalima Ambareen**  
📧 ambareensaalima2@gmail.com  
🎓 BCA, Kristu Jayanti College  

---

## 🧠 Overview
The **Cosmetics and Skin Care System** is a desktop application built using **Visual Basic .NET** with **SQL Server** as the backend.  
It enables customers to browse, select, and purchase cosmetic products, while administrators can manage product and customer data efficiently.

---

## ⚙️ Features

### 🛍️ Customer Module
- **User Registration & Login**
  - New users can create accounts with email and password validation.
  - Login opens the main shopping dashboard.

- **Product Browsing**
  - Displays products from multiple categories:
    - Make-up products  
    - Hair products  
    - Skin products  
    - Perfume products  

- **Cart System**
  - Adds selected products automatically to the cart.
  - Displays product details, image, price, and quantity.
  - Calculates total amount dynamically.
  - Option to remove or clear items from cart.

- **Payment Confirmation**
  - Final form displays total and confirms purchase.
  - Payment details stored securely in SQL Server.

---

### 🧑‍💼 Admin Module
- **View Products**
  - Displays all products from each category in a single form.
- **View Customers & Purchases**
  - Shows registration details and order history.

---

## 🗄️ Database Details

**Database Name:** `CosmeticsDB`

### 🧾 Tables
| Table Name         | Description                              |
|--------------------|------------------------------------------|
| `Make_products`    | Contains details of all makeup items     |
| `Hair_products`    | Stores information on hair care items    |
| `Skin_products`    | Stores details of skin care products     |
| `Per_products`     | Holds data about perfumes and fragrances |
| `Cart`             | Temporary cart for current orders        |
| `Customer`         | Stores registered customer details       |
| `Payment`          | Stores final payment and order records   |

---

## 💻 Technologies Used
| Component        | Technology             |
|------------------|------------------------|
| Frontend         | Visual Basic .NET      |
| Backend          | ADO.NET, SQL Server    |
| Database         | Microsoft SQL Server   |
| IDE              | Visual Studio          |
| Language         | VB.NET                 |

---

## 🚀 How to Run the Project
1. **Open Project**
   - Download or clone this repository.
   - Open the `.sln` file in **Visual Studio**.

2. **Set Up Database**
   - Open **SQL Server Management Studio (SSMS)**.
   - Execute the SQL script from `Database/CosmeticsDB.sql`.

3. **Configure Connection**
   - Open `App.config` and update the connection string with your SQL Server credentials.

   Example:
   ```xml
   <connectionStrings>
     <add name="CosmeticsDBConnection"
          connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=CosmeticsDB;Integrated Security=True"/>
   </connectionStrings>
