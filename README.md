
# Unity RPG & Inventory System Exercise

**!!!This project is not a game but a project to better understand the basics of building an RPG game.**  
  

#### All the **credits** for this project goes to Brackeys & Sebastian Lague's [How to make an RPG in Unity](https://www.youtube.com/watch?v=nu5nyrB9U_o&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7) series on Youtube.
![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)
## Introduction

!This is an exercise project, **NOT** a **game**.  
My main objective in making this project was to implement an inventory system & learning/using scriptable objects. In this simple exercise you can control the player using right and left mouse button to walk or interact with objects, you can adjust the camera. And also attack or be attacked by an enemy AI.

![alt-text-1](https://via.placeholder.com/468x300?text=App+Screenshot+Here)
## Features

- Control player with left & right mouse buttons: **left click** on ground **to walk**, **right click** on objects **to interact**.
- Control the **camera** using **A, D to look left or right**, **and mouse scroll wheel** to **adjust zoom** value.
- There are **4 types** of **objects** in this scene:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; **a. The blue box :** Player **cannot walk over** this object can only walk around this box to get from one side to another.  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; **b. The yellow sphere :** When player **right clicks** this object, player walks towards the object and stops in front of the object. This **focus** can be broken by clicking another interactable object or left clicking on the ground to walk somewhere else. Once player is infront of the object and is still focused, **if you move the sphere anywhere on the scene the player will keep following the sphere** until you click somewhere else.  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; **c. Coins :** Player can **collect coins by right clicking** on them. This will put the coin in the players' inventory. Once the coin is in the players' **inventory** you can **right click the slot storing the coin to drop the coin** back into the world wherever you are in the world. Since coin is not a usable item, left clicking the coin icon on the inventory slot will trigger a debug log message stating that coin is not a usable item.  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; **d. The red box :** Player can collect this item by **right clicking** on it. This object is a **health regen object**, when the inventory slot storing this item is left clicked if player does not have full health a chunk of health will be regened immediately. This object **cannot be dropped**.

- There is an **enemy AI** on the scene. When player gets in the enemys' notice radius enemy will start **chasing the player** and will hit the player until it dies, player runs away or the player dies. **Player can attack** the enemy **using right click**. There is a **cooldown** on the attack preventing span clicking.
- The **inventory system** is **inspired by minecraft**, other than objects of same type not stacking, it pretty much behaves the same way. Player can **see** their **whole inventory** by clicking **"I"** on the keyboard.
## Installation


To run the RPG Exercise on your Windows system, follow these steps:

&nbsp;&nbsp;&nbsp; 1. Clone this repository or download it as a ZIP file.  
&nbsp;&nbsp;&nbsp; 2. Open the project in Visual Studio or your preferred C++ IDE.  
&nbsp;&nbsp;&nbsp; 3. Build and run the project.

