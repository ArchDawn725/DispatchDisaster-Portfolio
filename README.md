# DispatchDisaster-Portfolio


**Dispatch Disaster (2020)**

An early large-scale emergency-management simulation and my first major Unity project.


**⭐ Project Overview**

Dispatch Disaster is a real-time emergency-management strategy game inspired by my experience working with 911 dispatch systems. Developed between late 2019 and mid-2020, the game features city-scale map generation, multi-agency call handling, vehicle dispatch logic, dynamic regional influence, and a competitive/cooperative 3-player multiplayer mode built on Photon.

This was my first near-completed Unity game, built entirely solo—including all 3D art created inside the Unity engine—before I had exposure to Blender or proper mesh workflows. The project was cancelled due to performance bottlenecks caused by hand-built modular models, but I may revisit the concept in the future.


**🎮 Gameplay Summary**

Players take the role of a 911 dispatcher operating Police, Fire, Medical, or all three agencies in single-player. Emergencies spawn across a dynamically expanding playfield, and players must dispatch vehicles, manage transport routes, balance response priorities, and prevent regions from hitting zero influence.

In multiplayer, three players compete for regional control while sharing the risk that if any region hits zero influence, everyone loses, creating a unique simultaneous competitive-cooperative tension.


**🧩 Key Features**

Procedural urban map generation

Three distinct emergency-response systems (Police, Fire, Medical)

Fully functional 3-player Photon multiplayer

In-game achievements and challenge system

Region influence tracking and loss conditions

Expandable zones that increase gameplay complexity

Vehicle routing, priority handling, and timed emergency resolution

Unique agency-specific mechanics and progression paths


**🏗️ Architecture Overview**

Dispatch Disaster was built before I had learned scalable code architecture patterns. As a result, the project features:

Large “god scripts”

Duplicated logic across agencies

Limited separation between systems and managers

Heavy runtime object instantiation

Many tightly coupled systems

Inefficient custom mesh construction

Manual Unity-editor-built 3D models (block-by-block)

Although the architecture is rough, I include this repo in the portfolio because it demonstrates:

Early problem-solving

My foundation as a programmer

The starting point from which I grew into strong architecture and system design skills

The ability to scope, design, and nearly complete a large solo project



**🗂️ Key Scripts to Review**

Below are recommended categories. Because the original architecture is loose, choose any script matching these descriptions. I can help locate them in your repo once it is uploaded.

*Core*

Game Initialization Script — bootstraps the city, loads starting data, sets player agency

*Systems*

Emergency Spawn System — generates emergency events with varying priority/timeout logic

Vehicle Dispatch System — routes vehicles, tracks arrival, handles scene logic

Influence System — manages regional influence values and loss states

Agency Behavior Scripts — per-agency logic for Police, Fire, Medical

Gameplay Loop Controller — processes updates, call resolutions, and state changes

*Managers*

Map Generation Manager — builds the city layout and zones

Vehicle Manager — handles pooling/spawning of engines, cruisers, and ambulances

Multiplayer Manager (Photon) — synchronizes calls, regions, and player actions

*UI*

Start Screen Controller — unique animated menu state

HUD Call Display System — shows active calls, timers, priorities

Achievements UI System

Utilities / Tools

Debug/Test Spawner

Timer or Async Handler



**📁 Project Structure**
/AI
/Core
/Data
/Managers
/Networking   (Photon)
/Systems
/UI
/Utilities
/Tools


**🧪 Development Notes**
Scalability & Performance

3D models constructed manually in the Unity editor

No batching/static optimization

Heavy draw calls when zoomed out

Tightly coupled systems causing costly updates

Gameplay Systems

Emergency timing and prioritization logic

Unique flow for each response agency

Player-controlled home bases, upgrade paths, and zone expansion

Multiplayer

Photon room setup for 3 players

Shared map, separate agencies, synchronized emergencies

Hybrid competitive-cooperative ruleset



**🚒 Why This Project Matters**

Despite being my earliest large Unity project, Dispatch Disaster represents:

My ability to take a large idea and execute it solo

Early exposure to systemic design (spawn logic, transportation, timing, global states)

My first attempt at multiplayer networking

My foundational understanding of game loops, state management, and large-scale codebases

A major stepping stone that shaped how I approached architecture in all future projects

This project shows the starting point of my engineering growth—from god scripts and duplicated logic to the modular, scalable architectures I use today.



**📚 Lessons Learned**

Importance of proper code architecture and avoiding god-classes

The value of modularity and reusable components

Why tools like Blender are critical for optimized art workflows

Performance pitfalls of editor-built meshes

How multiplayer fundamentally shapes system design

Benefits of separating UI, managers, core systems, and data

Increased awareness of complexity scaling on large maps

How to scope and structure large solo projects



**🛠️ Tech Stack**

Unity 2019.x

C#

Photon PUN Multiplayer

Custom procedural city generation

Unity UI (UGUI)



**🖼️ Full Image Gallery**

![109777368_1173432083018156_2028845277040491646_n](https://github.com/user-attachments/assets/23521953-15b4-4542-8109-3f5dab67d809)
![116747182_1185006081860756_4910486803769201389_n](https://github.com/user-attachments/assets/906c9fc4-3cef-4f48-8753-9116043c4a45)
![116011512_1179817395712958_1177496243353723763_n](https://github.com/user-attachments/assets/f688ed3e-aa58-4de4-a768-b8a5ceadb143)
![116053397_1178714729156558_3486775079620312383_n](https://github.com/user-attachments/assets/250e4c9e-479f-42d0-918c-34342b82cca2)
![120758470_1239679623060068_3933782257837487254_n](https://github.com/user-attachments/assets/df7cf8bd-b075-4aa8-9c68-e678da4a98ba)
![120602534_1239679609726736_3787354000081363126_n](https://github.com/user-attachments/assets/a5aaa963-548c-4a3e-b753-fa81aaa8ec3a)
![120809794_1239679596393404_4665186726324375992_n](https://github.com/user-attachments/assets/09d03d3d-2596-47fa-af97-71abce41563e)
![120560976_1239679659726731_6283579011452932670_n](https://github.com/user-attachments/assets/885e7734-fc6e-4a82-bcce-926982da6f82)
![120655682_1239679639726733_445761680061342367_n](https://github.com/user-attachments/assets/9f320c4d-e7d7-44e8-8ebd-1c68c6f1c49b)
![120759417_1239679669726730_16214949013209118_n](https://github.com/user-attachments/assets/cf0db565-fc21-4451-9c12-a7685efb2e5e)
