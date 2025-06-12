# Malshinon — Community Intel Reporting System

## 📋 Project Overview

**Malshinon** is a simulated intelligence platform designed to collect reports from civilians ("tattletales" - מלשינים) about other individuals in their community ("targets"). The system processes this data to:

- Identify potential recruits (informants providing valuable information)
- Track individuals frequently reported (potential threats)
- Detect suspicious activity patterns based on report frequency and timing

The project simulates real-world intelligence workflows where human-generated reports are analyzed to reveal patterns and assess potential risks.

---

## 🚀 Functional Requirements

### 📝 Intel Reporting Workflow

1. The user logs in using either a name or secret code.
2. The user specifies the target (by name or code).
3. A free-text report is submitted.
4. The system:
   - Stores the report with a timestamp.
   - Updates reporter and target analytics.
5. If the reporter or target does not exist, a new record is created with a unique secret code.

### 🆔 Identity & Secret Codes

- Each person (reporter or target) has a unique, persistent secret code.
- New entries automatically receive a generated secret code.
- Users may identify themselves or targets by either name or code.
- The system can retrieve a person’s secret code given their full name.

### 📥 CSV Data Import

- The system supports importing reports from a CSV file.
- CSV structure includes: reporter name/code, target name/code, report text, timestamp.
- Import process:
  - Parses the file
  - Handles new or existing people (assigning codes)
  - Inserts each report into the database

### 📊 Analysis & Evaluation Logic

#### 🕵️ Identifying Potential Recruits

A reporter is considered a recruit candidate if:

- They have submitted **at least 10 reports**.
- Their **average report length** is **100+ characters**.

These metrics identify consistent, informative reporters.

#### ⚠️ Flagging High-Risk Targets

A target is marked dangerous if:

- Mentioned in **20+ distinct reports**, or
- Mentioned **3+ times within any 15-minute window**.

This reflects sustained or sudden concern, indicating elevated risk.

### 🚨 Alerts

The system automatically triggers an alert when:

- A target’s status changes to dangerous, or
- 3+ reports occur about the same target within 15 minutes.

Each alert records:

- Target identity
- Relevant time window
- Reason/explanation

---

## ⚙️ Technical Guidelines

- **No persistent data storage in memory** — all data stored in **MySQL**.
- Proper **input validation** and **error handling**.
- Database **indexing** and **normalization** ensured.
- Key actions (input, imports, alerts, errors) logged to file or DB.

---

## 💻 C# Application Features

1. **Report Submission Flow**
   - Identify reporter & target by name/code.
   - Input and store report text.
   - Auto-create new people if needed.
   
2. **Secret Code Management**
   - Retrieve codes by name.
   - Generate codes for new people.
   
3. **CSV Import**
   - Load data safely into DB.
   - Validate file structure and rows.
   
4. **Analysis Dashboard**
   - List potential recruits.
   - List dangerous targets.
   - Show triggered alerts.

---

## 🧪 Testing & Logging

**Testing for:**

- Secret code management
- CSV import process
- Threshold evaluations

**Logging of:**

- Report submissions
- Alert creation
- CSV imports
- System errors

---

