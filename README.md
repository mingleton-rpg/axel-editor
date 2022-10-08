# [MRPG 2.0] axel-editor
Created for a potential Mingleton RPG 2.0, the Axel (ASCII Pixel) editor allows the manipulation and saving of Axel sprites for use within the ASSCRAX (**AS**cii **S**implified **C**onsole-based **R**enderer for **AX**els) engine. 
As using the name ASSCRAX might imply, this project is made entirely as a fun experiment, so should be treated as such.

## Running the program
1. Install Microsoft's .NET framework v6 or higher
2. Download this repository and open a CMD in the primary folder
3. Use `dotnet run` to start it
> Currently this app only works on Windows machines. This may be changed in the future.

## Rendering
This project operates entirely in a .NET console app, and should eventuate into a full 2D rendering engine using ASCII instead of pixels. This editor provides the groundwork required for the rendering engine for the full game, while providing a graphical way to generate Axel sprites.

## Axel Sprites
The current vision for MRPG 2.0 is for it to be a Pokemon-like reinterpretation of the mechanics featured in the old, text-based RPG. As such, the rendering engine needs to handle things like player collision, position of pixels, etc., thus a simple ASCII editor can't really do what we need. This editor is designed to save to .AXL files, which will be used to render objects within the RPG (if and when it eventuates).
If someone were so inclined, it could also be repurposed to developer Axel sprites for other programs as well.