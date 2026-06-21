# 🧪 Pathology Management System

A scalable, cloud-ready **Pathology Management System** built using **ASP.NET Core Microservices**, **Ocelot API Gateway**, **Entity Framework Core**, **JWT Authentication**, and **Microsoft Azure**.

The platform digitizes laboratory workflows from patient registration to test result generation and report management.

---

# 📋 Overview

The Pathology Management System is designed to streamline pathology laboratory operations by providing:

* Patient Registration and Management
* Laboratory Test Management
* Dynamic Test Parameter Handling
* Result Entry and Validation
* Automated Pathology Report Generation
* Secure Authentication and Authorization
* Cloud-Native Deployment Architecture

The system follows a **Microservices Architecture** that enables independent deployment, scalability, and maintainability.

---

# 🏗 Architecture

```text
Client Browser
      │
      ▼
ASP.NET MVC Frontend
      │
      ▼
Ocelot API Gateway
      │
 ┌────┼────────────────────────────┐
 ▼    ▼         ▼         ▼        ▼

Auth  Patient   Test   Test Cart   Test Parameter
API    API      API      API            API

      │
      ▼

Azure SQL Database
```

### Additional Azure Services

* Azure App Service
* Azure SQL Database
* Azure Blob Storage
* Azure Service Bus
* Azure Key Vault

---

# 🚀 Technology Stack

## Frontend

* ASP.NET Core MVC
* Razor Views
* Bootstrap 5
* JavaScript
* jQuery

## Backend

* ASP.NET Core Web API
* Entity Framework Core
* Repository Pattern
* Service Layer Pattern
* DTO Pattern

## Security

* ASP.NET Identity
* JWT Authentication
* Role-Based Authorization
* HTTPS

## Database

* Microsoft SQL Server
* Entity Framework Core (Code First)
* Migrations

## Cloud Services

* Azure App Service
* Azure SQL Database
* Azure Blob Storage
* Azure Service Bus
* Azure Key Vault

## API Gateway

* Ocelot

---

# 📂 Solution Structure

```text
Lab
│
├── FrontEnd
│
├── Services
│   ├── Laboratory.Services.AuthAPI
│   ├── Laboratory.Services.PatientAPI
│   ├── Laboratory.Services.TestAPI
│   ├── Laboratory.Services.TestCartAPI
│   └── Laboratory.Services.TestParameterAPI
│
├── Laboratory.Web
│
├── wwwroot
│   └── Rotativa
│
└── Lab.sln
```

---

# 🔧 Microservices

## 1. Authentication Service

**Laboratory.Services.AuthAPI**

### Features

* User Registration
* Login
* JWT Token Generation
* Role Management
* ASP.NET Identity Integration

---

## 2. Patient Service

**Laboratory.Services.PatientAPI**

### Features

* Patient Registration
* Patient Information Management
* Search Patient Records
* Medical History Tracking

---

## 3. Test Service

**Laboratory.Services.TestAPI**

### Features

* Laboratory Test Management
* Test Categories
* Test Pricing
* Test Configuration

---

## 4. Test Cart Service

**Laboratory.Services.TestCartAPI**

### Features

* Test Selection
* Order Management
* Billing Preparation

---

## 5. Test Parameter Service

**Laboratory.Services.TestParameterAPI**

### Features

* Dynamic Test Parameters
* Laboratory Result Entry
* Reference Range Management
* Pathology Report Generation

---

# 🔐 Security Features

## Authentication

* ASP.NET Identity
* JWT Bearer Tokens
* Password Hashing
* Secure Login

## Authorization

### Role-Based Access Control

* Administrator
* Laboratory Technician
* Reception Staff
* Pathologist

## Security Best Practices

* HTTPS Enforcement
* Token Validation
* Secure Secret Management
* Azure Key Vault Integration

---

# 📊 Laboratory Features

## Supported Test Categories

### Blood Sugar Tests

* FBS
* PPBS
* RBS
* GTT
* Blood Sugar Series

### Lipid Profile

* Total Cholesterol
* Triglycerides
* HDL
* LDL
* VLDL
* Chol/HDL Ratio
* Non-HDL Cholesterol

### Renal Function Tests

* Serum Creatinine
* GFR

### Liver Function Tests

* Total Protein
* Albumin
* Globulin
* SGOT
* SGPT
* Total Bilirubin
* Direct Bilirubin
* Indirect Bilirubin
* ALP
* GGT

### Full Blood Count

* Hemoglobin
* WBC
* RBC
* Platelets
* PCV
* MCV
* MCH
* MCHC
* Differential Counts

### Additional Tests

* Electrolytes
* ESR
* CRP
* Calcium
* PT/INR
* HCG
* Urine Full Report

---

# 📄 Dynamic Report Generation

### Features

* PDF Report Generation
* Reference Range Display
* Unit Management
* Patient Information Section
* Laboratory Branding
* Professional Pathology Report Layout

---

# ☁ Azure Deployment

## Azure Services Used

| Service            | Purpose               |
| ------------------ | --------------------- |
| Azure App Service  | Hosting MVC and APIs  |
| Azure SQL Database | Relational Database   |
| Azure Blob Storage | Report Storage        |
| Azure Service Bus  | Service Communication |
| Azure Key Vault    | Secret Management     |

### Deployment Flow

1. Create Azure SQL Database
2. Deploy Authentication API
3. Deploy Microservices
4. Configure Ocelot API Gateway
5. Deploy MVC Frontend
6. Integration Testing

---

# 🔄 Service Communication

## Synchronous Communication

REST APIs are used for:

* Patient Validation
* Test Retrieval
* Authentication
* Immediate Data Access

## Asynchronous Communication

Azure Service Bus is used for:

* Report Generation Events
* Notification Processing
* Background Tasks
* Event-Driven Workflows

---

# 🗄 Database Design

## Entity Framework Core

* Code First Approach
* Automatic Migrations
* Strongly Typed Models
* Repository Pattern

### Core Entities

* Users
* Patients
* Tests
* Test Parameters
* Test Results
* Reports

---

# 🎯 Key Features

## Laboratory Management

* Patient Registration
* Test Management
* Result Entry
* Report Generation

## Dynamic Forms

* Test-Specific Parameter Entry
* Dynamic UI Rendering
* Strong DTO Validation

## Scalability

* Independent Microservices
* Azure Cloud Deployment
* API Gateway Routing

## Maintainability

* Clean Architecture
* Layered Design
* Repository Pattern
* Service Layer Pattern

---

# 🛠 Getting Started

## Prerequisites

* Visual Studio 2022
* .NET 8 SDK
* SQL Server
* Azure Subscription (Optional)

### Clone Repository

```bash
git clone https://github.com/yourusername/pathology-management-system.git
```

### Restore Packages

```bash
dotnet restore
```

### Apply Migrations

```bash
dotnet ef database update
```

### Run Solution

```bash
dotnet run
```

Or open:

```text
Lab.sln
```

in Visual Studio and start the solution.

---

# 👨‍💻 Author

**Prabath Kumarasinghe**

* MSc Artificial Intelligence
* Azure AI Engineer
* ASP.NET Core Developer

---

# 📜 License

This project is developed for educational and research purposes.

---

## 🧪 Pathology Management System

**Secure • Scalable • Cloud-Native Laboratory Diagnostics Platform**
