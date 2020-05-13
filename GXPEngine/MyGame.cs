using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine

public class MyGame : Game
{
	//----------------change size to correct screen size
	public MyGame() : base(960, 720, false)		
	{		
		Screens screen = new Screens();
		AddChild(screen);	
	}


	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}