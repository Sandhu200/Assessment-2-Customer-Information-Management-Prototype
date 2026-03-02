Bank Management Prototype – Project Overview

This document presents a comprehensive overview of the Bank Management Prototype, outlining its architecture, components, technology stack, and key architectural observations.

1. Executive Summary

The Bank Management Prototype is a C#-based banking system designed to demonstrate core banking operations through multiple interfaces. The solution is divided into three primary components:

Console Application (Talwinder_CLI) – Provides command-line interaction for account operations.

Graphical User Interface (GUI) – A Windows Forms application for visual customer and account management.

Unit Testing Project (TestProject) – Ensures correctness and reliability of the core business logic.

The system models various bank account types—Everyday, Investment, and Omni—each implementing distinct rules for withdrawals, fees, overdrafts, and interest calculations.

2. Solution Architecture & Project Structure

The repository consists of three independent Visual Studio projects:

2.1 Talwinder_CLI (Console Application)

Framework: .NET 8

Purpose: Acts as the primary driver of the banking domain logic through command-line simulation.

Key Components:

Program.cs – Entry point; initializes sample customers and accounts, simulates banking transactions.

Account.cs (Abstract Class) – Defines shared properties (Id, Balance) and core methods (Deposit, Withdraw).

Derived Account Types:

EverydayAccount

InvestmentAccount

OmniAccount

Customer.cs – Represents customer data.

FailedWithdrawalException.cs – Custom exception handling business rule violations (e.g., insufficient funds, fee application).

This project encapsulates the primary domain logic of the system.

2.2 GUI (Windows Forms Application)

Framework: .NET Framework 4.7.2

Purpose: Provides a graphical interface for managing customers and accounts.

Architectural Pattern:

The GUI follows a simplified Model-View-Controller (MVC) pattern:

Model: Customer.cs

View:

CustomerForm.cs (CRUD operations)

Form1.cs (Main dashboard)

Controller: CustomerController.cs (Business logic handling)

Features:

Customer management (Create, Read, Update, Delete)

Account selection and transaction processing

Deposit and withdrawal operations

Architectural Observation:

This project contains a separate implementation of the Account hierarchy, duplicating logic already present in Talwinder_CLI. Although functionally similar, these implementations exist in different namespaces and are not shared.

This introduces maintainability and consistency risks.

2.3 TestProject (Unit Testing)

Framework: .NET 9

Testing Framework: MSTest

Purpose:

Validates the business logic implemented in the Talwinder_CLI project.

Test Coverage Includes:

Successful deposits and withdrawals

Failed withdrawals and fee application

Staff discount validation

Interest calculation logic

Overdraft rule enforcement

This ensures correctness, reliability, and regression protection.

3. Core Domain Model
3.1 Account Hierarchy

The system is built around an abstract Account base class, which defines:

Id

Balance

Deposit()

Withdraw()

Concrete Account Types
EverydayAccount

Standard transactional account

No overdraft

No interest

No additional fees

InvestmentAccount

Accrues interest

Charges fees for failed withdrawals

Staff members receive a 50% discount on fees

OmniAccount

Includes overdraft facility

Interest applied only to balances above $1000

Charges failed withdrawal fees

Staff discount applicable

Each account type demonstrates polymorphism and encapsulated business rules.

4. Technology Stack
Component	Technology
Console Application	.NET 8
GUI Application	.NET Framework 4.7.2
Testing	.NET 9 + MSTest
Architecture Pattern	MVC (GUI)
Language	C#
5. Execution Guide
Running the Console Application

Set Talwinder_CLI as the startup project.

Run from Visual Studio
OR

dotnet run --project Talwinder_CLI
Running the GUI Application

Set GUI as the startup project.

Run from Visual Studio.

Running Unit Tests

Open Test Explorer in Visual Studio.

Click Run All Tests.


Conclusion

The Bank Management Prototype demonstrates strong foundational object-oriented principles, including abstraction, inheritance, and polymorphism. The inclusion of unit testing further strengthens reliability.

However, architectural refinement—specifically consolidating shared domain logic into a reusable class library—is essential to elevate the project from a prototype to a scalable and maintainable enterprise-level solution.
