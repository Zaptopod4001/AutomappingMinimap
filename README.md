# Automapping Minimap (Unity 2018.4 / C#)

![Automapping minimap](/doc/automapping_minimap.gif)

## What is it?

Automapping minimap with a circular field of vision, using Unity uGUI system for rendering.

* Automap demo script that shows how to use minimap.

* Automap class that handles automapping the area around player. Player vision circle radius can be user defined.

* Automap rendering is handled using IAutomapRenderer interface, that defines the methods needed for map rendering.

* AutoMapRenderer shows an implementation how to use IAutoMapRenderer to render a minimap, in this case using uGUI system.

* Simple player inputs to simulate moving player character in map data. Most likely, minimap wouldn't be the only view for the player.


## Classes

### AutomapDemo
How to setup map data for minimap rendering and how to redraw the minimap when map data changes. Note - one wouldn't probably update the minimap every frame like in the example.

### Automap
Handles the updating of visible map area, player and NPCs in the map view. Controls minimap view rendering using methods of IAutomapRenderer.

### AutomapRenderer
Shows how to create a minimap renderer that implements IAutomapRenderer interface.

### Cell
Data container class for map cell, containing cell content type and visited data.

### Save 
Generic save and load class that can be used to serialize/deserialize any class into a binary file, including this minimap. Press S to save and L to load the minimap data in demo scene. Note, player position isn't saved along minimap data.


## About
I created this automapping minimap way back for myself for different personal Unity projects. I don't use this kind of setup any more. Sprites created by me also.

## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
