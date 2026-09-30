# 🌊 ACM Application
> **React Native Mobile App & .NET 8 Web API Server**  

![React Native](https://img.shields.io/badge/React_Native-0.86.3-61DAFB?style=for-the-badge&logo=react&logoColor=black)
![Expo](https://img.shields.io/badge/Expo-SDK_57-000000?style=for-the-badge&logo=expo&logoColor=white)
![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-ES6+-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

---

<img width="472" height="1024" alt="image" src="https://github.com/user-attachments/assets/b16850f3-87d3-4a37-bf6d-8a3606d42305" />
<img width="472" height="1024" alt="image" src="https://github.com/user-attachments/assets/719def85-7824-4d56-8ad2-19ab2fe655e4" />
<img width="739" height="1600" alt="image" src="https://github.com/user-attachments/assets/495cc4df-7930-4310-9fe1-2297a1cada74" />

## 📖 Overview

**ACM Application** is a full-stack hydrotherapy management platform for coordinating lessons, child development, and communication between instructors, parents, and managers. The system combines a cross-platform mobile application with a secure REST API and AWS-backed data services.

### Key Roles & Features
- 👨‍💼 **Manager Portal**: Group management, system reports, instructor overview, and attendance tracking.
- 🏊‍♂️ **Instructor Portal**: Lesson scheduling, attendance boards, achievement editing, progress reporting, and student profiles.
- 👨‍👩‍👧 **Parent Portal**: Progress reports, lesson history, appointment booking, and instant notifications.
- 🤖 **AI-Powered Insights**: Automated progress summaries, group analysis, and exercise recommendations based on development data.

### Architecture

The platform uses a two-tier architecture designed for AWS deployment:

- **Mobile client**: A React Native and Expo application with role-based navigation for managers, instructors, and parents.
- **REST API**: An ASP.NET Core 8 Web API written in C# that handles authentication, authorization, validation, scheduling, reporting, chat, and notifications.
- **AWS data services**: Amazon DynamoDB stores users, children, groups, lessons, attendance, progress reports, conversations, and notifications.
- **AWS authentication**: Amazon Cognito is supported for managed user authentication and password-reset flows, with JWT authorization at the API layer.
- **AWS deployment and storage**: The ASP.NET Core API is prepared for AWS Elastic Beanstalk, with Amazon S3 planned for durable chat attachment storage.
- **External integrations**: Push notifications and an OpenRouter-compatible AI provider are accessed through backend services.

---

## 🛠 Tech Stack

- **Frontend**: React Native, Expo, React Navigation, Vector Icons, Linear Gradient, SVG
- **Backend**: C# ASP.NET Core 8 Web API
- **AWS Cloud Services**: Amazon DynamoDB, Amazon Cognito, Amazon S3, AWS Elastic Beanstalk
- **Security**: JWT bearer authentication, role-based authorization, Cognito integration, and PBKDF2 password hashing
- **Capabilities**: Scheduling, attendance management, progress reporting, chat, push notifications, and AI-assisted analysis
- **Testing**: Expo Go (iOS & Android)

## 📋 Prerequisites

Before running the application, make sure you have the following installed on your machine:

1. **Node.js** (v18.0.0 or higher) & **npm**  
   👉 [Download Node.js](https://nodejs.org/)
2. **.NET 8 SDK** (Required if running the backend server locally)  
   👉 [Download .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
3. **Expo Go App** on your mobile phone:
   - 📱 **iOS**: Download from [Apple App Store](https://apps.apple.com/app/expo-go/id982107779)
   - 🤖 **Android**: Download from [Google Play Store](https://play.google.com/store/apps/details?id=host.exp.exponent)
   - *Ensure your phone and computer are connected to the same Wi-Fi network.*

---

## 🚀 Step-by-Step Setup & Execution

### 1️⃣ Clone the Repository

Open your terminal or command prompt and run:
```bash
git clone https://github.com/ronenmilikhov/ACM-Hydrotherapy-Management-Platform.git
cd ACM-Hydrotherapy-Management-Platform
```

---

### 2️⃣ Install Dependencies

Install the required npm packages for the React Native app:
```bash
npm install
```

---

### 3️⃣ Configure Local Environment Variables

#### Frontend Configuration (`.env`)
Create a `.env` file in the root folder by copying `.env.example`:
```bash
# On Windows PowerShell:
copy .env.example .env

# On Mac/Linux:
cp .env.example .env
```
Default `.env` contents:
```env
EXPO_PUBLIC_API_BASE_URL=https://your-elastic-beanstalk-environment.example.com/api
```

#### Backend Configuration (`appsettings.json`)
If running the backend server locally, navigate to `ServerSide/ReactServerSide/` and copy `appsettings.Example.json` to `appsettings.json`:
```bash
cd ServerSide/ReactServerSide
copy appsettings.Example.json appsettings.json
cd ../..
```

---

### 4️⃣ Start the Backend Server (Optional / Local Dev)

To launch the .NET Web API backend server locally:
```bash
cd ServerSide/ReactServerSide
dotnet run
```
The development profile listens at `https://localhost:7171` and `http://localhost:5202`.

For a physical phone, set `EXPO_PUBLIC_API_BASE_URL` to a reachable HTTPS deployment or to your computer's LAN address. Do not use `localhost` from a physical phone.

---

### 5️⃣ Run the Mobile App & Test in Expo Go 📱

Navigate back to the root directory and start Expo:
```bash
npm start
```
*Alternatively, you can run:*
```bash
npx expo start
```

#### 📲 Testing on your physical phone with **Expo Go**:
1. Open the **Expo Go** app on your iOS or Android device.
2. **On Android**: Tap "Scan QR code" and point your camera at the QR code displayed in your terminal.
3. **On iOS**: Open your built-in iPhone Camera app and scan the QR code displayed in your terminal, then tap the link to open in Expo Go.
4. The application will bundle and launch instantly on your device! 🎉

#### 🖥️ Testing on Simulators / Web:
While the terminal process is running, press:
- `a` to open in **Android Emulator**
- `i` to open in **iOS Simulator**
- `w` to open in **Web Browser**

---

## 📂 Project Architecture

```
ACM-Hydrotherapy-Management-Platform/
├── assets/                     # App icons, splash screens, and images
├── components/                 # Reusable UI components & backgrounds
├── Instructor/                 # Instructor portal screens & logic
├── Manager/                    # Manager portal screens & logic
├── Parent/                     # Parent portal screens & logic
├── notifications/              # Push notification handlers
├── theme/                      # App design tokens & global styles
├── ServerSide/                 # .NET 8 Web API and supporting services
│   └── ReactServerSide/        # ASP.NET Core project files, controllers & DAL
├── App.js                      # Main App Entry & Navigation container
├── apiConfig.js                # API base URL resolver & Auth headers
├── .env.example                # Frontend environment template
├── .gitignore                  # Git security & binary exclusions
└── package.json                # Project dependencies & scripts
```

The backend template is at `ServerSide/ReactServerSide/appsettings.Example.json`. Copy it to `appsettings.json` for local development and provide AWS region, DynamoDB access, Cognito App Client ID, JWT secret, and AI provider settings. Never commit real credentials.

---
