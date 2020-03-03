# Automapping Minimap (Unity 2018.4 / C#)

![Automapping minimap](/doc/automapping_minimap.gif)

## What is it?

Automapping minimap with a circular field of vision, using Unity uGUI system for rendering.

* Automap demo script that shows how to use minimap.

* Automap class that handles automapping the area around player. Player vision circle radius can be user defined.

* Automap rendering is handled using IAutomapRenderer interface, that defines the methods needed for map rendering.

* AutoMapRender shows an implementation how to use IAutoMapRenderer to render a minimap, in this case using uGUI system.

* Simple player input to move player character in map data. Typically this minimap wouldn't be the only view for the player.


## Classes

### AutomapDemo
How to setup mapdata for minimap rendering and how to redraw the minimap when data changes. Note - one wouldn't probably update the minimap every frame like in this example.

### Automap
Handles updating visible mapdata area and player position in map view. Controls minimap view rendering using methods of IAutomapRenderer.

### AutomapRender
Shows how to create a minimap renderer that uses IAutomapRenderer interface.

### Cell
Data container class for map cell, is cell visited.

### Save 
Generic save and load class that can be used to serialize/deserialize any class into Binary finle, including this minimap. Press S to save and L to load minimap data - note, player position isn't saved along minimap data.


## About
I created this auto-mapping minimapper way back for myself for different personal Unity projects. I don't use this kind of setup any more.

## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
