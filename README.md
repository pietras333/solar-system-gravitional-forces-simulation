# 🌌 Physics-Based Solar System Simulation

![Solar System Preview](assets/solar_system_preview.png)  
*A real-time simulation of planets, moons, and orbital mechanics.*

---

realtime editor feedback for two moon earths and their realtime forces update


https://github.com/user-attachments/assets/56c5b18c-8b3a-487d-8276-81a395bb475b


in editor realtime feedback of config

https://github.com/user-attachments/assets/2fd3bbdb-20f4-470e-a117-0edfe0626cd8

solar system movement

https://github.com/user-attachments/assets/c3967040-159d-4805-ade5-0939e1cd8b59

mercury precession

https://github.com/user-attachments/assets/97d6b7da-cfda-4151-8a99-283569723fa8




## 🔭 Overview

This Unity project simulates celestial bodies using **physics-based formulas** and the **N-body problem**. It includes:

- ✅ Newtonian gravitational interactions
- ✅ Runtime orbit prediction and visualization
- ✅ Euler integration for position and velocity updates
- ✅ Customizable planets, moons, and initial velocities

Perfect for educational purposes, visualizing classical mechanics, or demonstrating phenomena like **Mercury’s precession**.

---

## 🌟 Key Features

### **Physics-Based Simulation**
- Calculates gravitational acceleration between all bodies:
\[
F = G \frac{m_1 m_2}{r^2}, \quad a = \frac{F}{m_1}
\]
- Updates velocities and positions in **real-time** using physics formulas.
- Supports multiple bodies (planets, moons, asteroids) interacting simultaneously.

### **Orbit Prediction**
- Predicts future trajectories using **Euler integration**.
- Draws predicted paths with **LineRenderer**.
- Supports **per-body orbit preview** or **all-body previews**.

### **Runtime Simulation**
- Real-time movement of bodies based on gravitational forces.
- Adjustable **timeScale** for speeding up or slowing down the simulation.
- Works in **Editor** and **Build** for consistent visualization.

### **Customizable Bodies**
- Set **mass**, **radius**, and **initial velocity** in the Inspector.
- Moons can inherit **parent planet velocity** for realistic orbits.
- Orbits can have **distinct vibrant colors** for clarity.

---

## 🎬 Example Scenes / Videos

| Scene | Description | Preview |
|-------|-------------|---------|
| 🌞 Solar System | Full solar system simulation | ![Solar System Video]() |
| 🌑 Two Moons | Planet with two orbiting moons | ![Two Moons Video](assets/video_placeholder.png) |
| ☿ Mercury Precession | Demonstrates precession around the Sun | ![Mercury Precession Video](assets/video_placeholder.png) |

> Replace `assets/video_placeholder.png` with actual GIFs, videos, or YouTube links.

---

## ⚡ Getting Started

### **Requirements**
- Unity 2020.3 or higher  
- Works in **Editor** and **Build**

### **Installation**
```bash
git clone https://github.com/yourusername/PhysicsSolarSystem.git
