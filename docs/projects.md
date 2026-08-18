---
layout: default
title: "Projects"
permalink: /projects/
---

# Projects

## Order Sync and Failure Tracking Dashboard

My current 12-week capstone receives customer orders, validates and saves them, sends them to an outside test system, and tracks whether each transfer succeeds or fails. It is designed for employees and technical support staff who need to find failures, understand what went wrong, and retry an order after the problem is fixed.

### Minimum viable product

- Create and validate an order
- Save orders in a SQL database
- Send orders to a mock external API
- Record success or failure status, error messages, and activity logs
- Display order status in a simple dashboard
- Retry failed orders

### Architecture

`Order input` → `ASP.NET Core API` → `validation` → `SQL database` → `external test API` → `status and logs` → `dashboard and retry`

### Technology

**Backend:** C#, ASP.NET Core, REST API, Entity Framework Core

**Data:** SQL Server Express

**Interface:** Next.js dashboard, with Swagger for API testing

**Operations:** Serilog, Git, GitHub, VS Code, and a mock external API

### Definition of done

The completed project will demonstrate the full order flow from receipt through validation, storage, external delivery, status tracking, error reporting, and retry. It will be published on GitHub with clear setup instructions.

### Planned extensions

Role-based login, failure email alerts, reporting, real store or shipping integrations, cloud deployment, Docker, automated tests, and support for multiple outside systems are intentionally reserved for later versions.

---

## IT Ticket Manager

An evolving command-line application for managing support tickets and users. The project stores records in CSV files and demonstrates how one product can improve through different development disciplines.

**What it covers:** ticket creation and tracking, user records, file-based persistence, input handling, and iterative design.

**Coursework versions:** Python, Unix, logic, interface design, Figma, prompt engineering, and version control.

**Tech:** Python, CSV, command-line interfaces, Git

**Source:** [View the IT Ticket Manager repository](https://github.com/weknewtheworldwouldnotbethesame/ITticketmanager)

---

## Career Exploration & Project Documentation

Research, planning, and process documentation developed during the second semester, including career research for a Junior Software Developer role, a six-page project design document, a 12-week software-development roadmap, and an application workflow diagram.

**Skills:** technical writing, process mapping, presentation design, and career research.
