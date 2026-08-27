# 🌊 ACM - Aquatic Community Method Platform

**Client:** "Mayim Shavim" (Non-Profit Organization)

<p align="center">
  <img width="30%" src="https://github.com/user-attachments/assets/8c72c452-5e6f-4627-9d30-9a42da59af9a" />
  <img width="30%" src="https://github.com/user-attachments/assets/3dc28b6d-e26c-4a1e-aef4-aa8c9d5d5958" />
  <img width="30%" src="https://github.com/user-attachments/assets/60dca9a8-5079-4347-99b1-282aae29b383" />
</p>

## 📖 Overview

**ACM Application** is a full-stack hydrotherapy management platform for coordinating lessons, child development, and communication between instructors, parents, and managers. The system combines a cross-platform mobile application with a secure REST API and AWS-backed data services.

### Key Roles & Features
- 👨‍💼 **Manager Portal**: Group management, system reports, instructor overview, and attendance tracking.
- 🏊‍♂️ **Instructor Portal**: Lesson scheduling, attendance boards, achievement editing, progress reporting, and child profiles.
- 👨‍👩‍👧 **Parent Portal**: Progress reports, lesson history, appointment booking, and instant notifications.
- 🤖 **AI-Powered Insights**: Automated progress summaries, group analysis, and exercise recommendations based on development data.

- ## Architecture

The platform uses a client-server architecture:

- **Mobile client**: A React Native and Expo application with role-based navigation for managers, instructors, and parents.
- **REST API**: An ASP.NET Core 8 Web API written in C# that handles authentication, authorization, validation, scheduling, reporting, chat, and notifications.
- **Data services**: An application data layer that integrates Amazon DynamoDB for user, child, group, lesson, attendance, and progress data.
- **AWS deployment**: The backend and supporting infrastructure were originally deployed using Amazon Web Services.
- **External integrations**: Push notifications, file attachments, and an AI provider are accessed through backend services so the mobile client remains focused on the user experience.

## 🛠 Tech Stack

- **Frontend**: React Native, Expo, React Navigation, Vector Icons, Linear Gradient, SVG
- **Backend**: C# ASP.NET Core 8 Web API
- **Cloud & Data**: Amazon Web Services, Amazon DynamoDB
- **Security**: JWT bearer authentication, role-based authorization, and PBKDF2 password hashing
- **Capabilities**: Scheduling, attendance management, progress reporting, chat, push notifications, and AI-assisted analysis
- **Testing**: Expo Go (iOS & Android)
