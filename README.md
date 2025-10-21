# 🌌 Physics-Based Solar System Simulation

<div align="center">
<img src="/solar_system_preview.png" alt="Solar System Preview" width="70%">
</div>

*A **real-time simulation** of planets, moons, and orbital mechanics using **Newtonian physics** and **N-body gravitational interactions**.*

---

## 🔬 Scientific Overview

This Unity project simulates celestial bodies based on **physics-based formulas**. It solves the **N-body problem** in real-time, allowing you to:

- ✅ Calculate **mutual gravitational forces** between multiple bodies  
- ✅ Predict **orbital paths** using **Euler integration**  
- ✅ Visualize **runtime orbit predictions** dynamically  
- ✅ Customize **planet and moon parameters**, including mass, radius, and initial velocity  

This system is ideal for **educational demonstrations**, research visualizations, or exploring classical mechanics phenomena such as **Mercury’s orbital precession**.

---

## 🌟 Key Features

### Physics-Based Simulation
- Implements Newton’s law of universal gravitation:  
![Newton](https://github.com/user-attachments/assets/acf23792-27f3-4461-b199-76816a369b35)
- Computes **gravitational acceleration** between all bodies at each timestep.
- Updates **velocities and positions** in real-time using **Euler integration**.
- Supports **multiple interacting bodies**, including planets, moons, and artificial objects.

### **2. Orbit Prediction**
- Predicts **future trajectories** for each body.
- Visualizes predicted orbits with **LineRenderer**.
- Supports **individual body preview** or **all-body orbit display**.

### **3. Runtime Simulation**
- Bodies move in real-time according to **physical forces**.
- Adjustable **timeScale** to simulate faster or slower motion.
- Works in both **Editor** and **Build** for consistent results.

### **4. Customizable Bodies**
- Configure **mass, radius, initial velocity**, and parent-child relationships (for moons).  
- Moons automatically inherit **parent planet velocity** if assigned.  
- Orbit trails can be assigned **distinct vibrant colors** for clarity.

---

## 🎬 Example Scenes

<div align="center">

### 🌞 Solar System
Full solar system simulation with planets and orbit prediction.  
<img src="https://github.com/user-attachments/assets/c3967040-159d-4805-ade5-0939e1cd8b59" alt="Solar System Video" width="90%">

### 🌑 Two Moons
Realtime simulation of a planet with two moons showing gravitational interactions.  
<img src="https://github.com/user-attachments/assets/56c5b18c-8b3a-487d-8276-81a395bb475b" alt="Two Moons Video" width="90%">

### ☿ Mercury Precession
Demonstrates **precession of Mercury’s orbit** due to gravitational perturbations.  
<img src="https://github.com/user-attachments/assets/97d6b7da-cfda-4151-8a99-283569723fa8" alt="Mercury Precession Video" width="90%">

</div>

---

## ⚡ Getting Started

### **Requirements**
- Unity 2020.3 or higher  
- Compatible with both **Editor** and **Build** environments

### **Installation**
```bash
git clone https://github.com/yourusername/PhysicsSolarSystem.git
