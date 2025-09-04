# 🛒 Evolve Store - E-Commerce Website (ASP.NET Core)

Evolve Store is a **full-featured E-Commerce Web API** built with **ASP.NET Core 8.0** and **Entity Framework Core**, providing authentication, shopping basket management, orders, and payment integration with Stripe.

---

## ✨ Features

- 🔐 **Authentication & Authorization**
  - User registration with **Email OTP Verification**
  - Login / Logout with **JWT + Refresh Tokens**
  - Password reset via OTP
  - Role-based authorization (Admin/User)

- 🛍️ **Product Management**
  - Get all products with **Pagination & Filtering**
  - Get product details with images
  - Browse products by category

- 🛒 **Basket (Shopping Cart)**
  - Create / Update / Delete basket
  - Real-time basket updates

- 📦 **Orders**
  - Create new order from basket
  - Get all orders for logged-in user
  - Get order details
  - Multiple delivery methods

- 💳 **Payments (Stripe Integration)**
  - Create or update **Payment Intent**
  - Secure payment processing with Stripe

- ⚡ **Additional**
  - Centralized error handling
  - Response caching for products
  - Rate limiting for OTP requests

---

## 🛠️ Tech Stack

- **Backend:** ASP.NET Core 8.0 (Web API)
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Authentication:** ASP.NET Identity + JWT + Refresh Tokens
- **Payment Gateway:** Stripe
- **Object Mapping:** AutoMapper
- **Caching:** In-Memory Cache
- **Architecture:** Repository Pattern + Unit of Work

---

## 📂 Project Structure

Evolve_Store/
│── Controllers/ # API Controllers (Accounts, Basket, Orders, Payments, Products)
│── Domain/Models/ # Entities & Domain Models
│── Domain/DTOs/ # Data Transfer Objects
│── Infrastructure/ # Persistence & Repository Implementation
│── Services/ # Business Logic & Services
│── appsettings.json # Configurations (DB, JWT, Stripe, Email, etc.)

📌 API Endpoints (Summary)
🔐 Authentication

POST /api/accounts/signup → Register new user

POST /api/accounts/signup/verify → Verify OTP code

POST /api/accounts/login → Login user

POST /api/accounts/password/send-otp → Send OTP for password reset

POST /api/accounts/password/reset → Reset password

POST /api/accounts/logout → Logout and invalidate refresh token

🛍️ Products

GET /api/product → Get all products (with pagination & filtering)

GET /api/product/product/{id} → Get product by ID

GET /api/product/category/{id} → Get products by category

🛒 Basket

GET /api/basket/{id} → Get basket

POST /api/basket → Update/Create basket

DELETE /api/basket/{id} → Delete basket

📦 Orders

POST /api/orders → Create new order

GET /api/orders → Get all user orders

GET /api/orders/{id} → Get order details

GET /api/orders/deliveryMethods → Get available delivery methods

💳 Payments

POST /api/payments?basketId={id} → Create/Update payment intent
