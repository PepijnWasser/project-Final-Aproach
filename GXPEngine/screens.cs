using System;
using GXPEngine;

public enum Screen
{
    startScreen,
    game,
    endScreen
}



class Screens : Canvas
{
    Level _level;
    EndScreen _endScreen;
    Startscreen _startScreen;

    Screen screen = Screen.startScreen;

    int _score = 0;


    public Screens() : base(1920, 1080)
    {
        ResetScreens();
    }

    void ResetScreens()
    {
        DestroyScreens();
        MakeNewScreen();
    }

    void Update()
    {
        TestChangeScreen();
    }

    /// ///////////////////////////////////////////////////////////////////////
    /// Check if the screen needs to change
    /// ///////////////////////////////////////////////////////////////////////
    void TestChangeScreen()
    {
        if (_level != null)
        {
            if (_level.ChangeScreen())       
            {
                screen = Screen.endScreen;
                ResetScreens();
            }
            
        }
        if (_endScreen != null)
        {
            if (_endScreen.ChangeScreen())  
            {
                screen = Screen.startScreen;
                ResetScreens();
            }
        }
        if (_startScreen != null)
        {
            if (_startScreen.ChangeScreen())
            {
                screen = Screen.game;
                ResetScreens();
            }
        }
    }

    /// ///////////////////////////////////////////////////////////////////////
    /// if there is a active screen destroy it
    /// ///////////////////////////////////////////////////////////////////////
    void DestroyScreens()
    {
        if (_endScreen != null)
        {
            _endScreen.LateDestroy();
            _endScreen = null;
        }
        if (_level != null)
        {
            _score = _level.GetScore();
            _level.LateDestroy();
            _level = null;
        }
        if (_startScreen != null)
        {
            _startScreen.LateDestroy();
            _startScreen = null;
        }
    }

    /// ///////////////////////////////////////////////////////////////////////
    /// make the correct screen
    /// ///////////////////////////////////////////////////////////////////////
    void MakeNewScreen()
    {
        if (screen == Screen.game)
        {
            _level = new Level();
            AddChild(_level); 
             
        }
        if (screen == Screen.startScreen)
        {
           _startScreen = new Startscreen();
           AddChild(_startScreen);
        }
        if (screen == Screen.endScreen)
        {
            _endScreen = new EndScreen(_score);
            AddChild(_endScreen);
        }

    }
}