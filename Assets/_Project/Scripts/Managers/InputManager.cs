/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 06/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * 
\*********************************************NOTES**********************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public enum InputPeripheral
{
    Joystick = 0,
    Keyboard,
    AI
}

public enum InputType
{
    Tap = 0,
    DoubleTap,
    Hold,
    Toggle
}

public enum PlayerNumber
{
    AI = -1, //No need to check input, AI will manage inputs on its own...
    God = 0, //GOD, all Joysticks or Keyboard...
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight
}

public class InputStrings
{
    public InputPeripheral InputType;
    public PlayerNumber PlayerNumber;
    public int JoystickNumber;



    public string MoveXInput;
    public string MoveYInput;
    public string CameraXInput;
    public string CameraYInput;

    public string InteractInput;
    public string JumpInput;
    public string SprintInput;
    public string AttackInput;
    public string MagicInput;

    public string PauseInput;
    public string HelpInput;


}

public enum InputXBOXControls
{
    A = 0, B, X, Y, // Face Buttons
    LeftBumper, RightBumper, // Bumpers
    Back, Start, // Options
    LeftStickClick, RightStickClick, // Stick Clicks
    LeftStickX, LeftStickY, RightStickX, RightStickY, // Stick Axes
    DpadX, DpadY, // Dpad Axes
    LeftTrigger, RightTrigger // Triggers
}

public enum InputPCControls
{
    MouseX = 0, MouseY, MouseScrollWheel, MouseLeftClick, MouseRightClick, MouseMiddleClick, Mouse3, Mouse4, Mouse5, Mouse6,// Mouse
    Escape, Tab, CapsLock, LeftShift, LeftControl, LeftAlt, // Left
    Space, RightAlt, RightShift, Return, // Right
    F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,
    BackQuote, Alpha0, Alpha1, Alpha2, Alpha3, Alpha4, Alpha5, Alpha6, Alpha7, Alpha8, Alpha9, // Top Row Numbers
    Minus, Equals, Backspace,
    Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G, H, J, K, L, Z, X, C, V, B, N, M, // Characters
    LeftSquareBracket, RightSquareBracket, Backslash, Semicolon, Quote, Comma, Period, Slash,
    Insert, Delete, Home, End, PageUp, PageDown,
    Keypad0, Keypad1, Keypad2, Keypad3, Keypad4, Keypad5, Keypad6, Keypad7, Keypad8, Keypad9,
    KeypadPeriod, KeypadEnter, KeypadPlus, KeypadMinus, KeypadMultiply, KeypadDivide, NumLock,
    MoveX, MoveY,
    LeftArrow, RightArrow, UpArrow, DownArrow // Arrow Keys
}

public class InputManager : Observer
{
    // private members
    private static InputManager instance;

    private Dictionary<string, InputPCControls> m_PCControls = new Dictionary<string, InputPCControls>();
    private Dictionary<string, InputXBOXControls> m_XBOXControls = new Dictionary<string, InputXBOXControls>();

    //public members
    public InputConfig[] m_InputConfigs { get; private set; }

    public InputStrings[] m_InputStrings { get; private set; }

    public string m_InputValueStorred;

    public int m_ControllersConnected { get; private set; }

    public static InputManager Instance
    {
        get
        {
            if (instance == null) { instance = new InputManager(); }
            return instance;
        }
    }

    private InputManager()
    {
        m_InputStrings = new InputStrings[9]; // There is a maximum of 8 player support, 0 is God element
        m_InputConfigs = new InputConfig[9]; // There is a maximum of 8 player support, 0 is God element

        m_ControllersConnected = GetNumControllersConnected();

        InitializeDictionaries();
        InitializePlayerNumbers();

        if (m_ControllersConnected == 0)           /////////////TEMPORARY PLEASE DELETE ME!!!!!!!!!
        {
            m_InputStrings[0].InputType = InputPeripheral.Keyboard;
            m_InputStrings[1].InputType = InputPeripheral.Keyboard;
        }

        for (int i = 0; i < m_InputStrings.Length; i++)
        {
            ReInitializeInputStrings(ref m_InputStrings[i]);
        }
        SetPlayerControllerNumbers();
    }

    private void InitializeInputConfigs()
    {
        //m_InputConfigs
    }

    private void InitialiseInputObjects()
    {
        //Go through the InputObj_Database and get the values.....
    }

    private int GetNumControllersConnected()
    {
        return Input.GetJoystickNames().Length;
    }

    private void InitializeDictionaries()
    {
        #region // m_PCControls Dictionary Setup
        m_PCControls.Add("mouse 0", InputPCControls.MouseLeftClick);
        m_PCControls.Add("mouse 1", InputPCControls.MouseRightClick);
        m_PCControls.Add("mouse 2", InputPCControls.MouseMiddleClick);
        //Missing ScrollWheel...
        m_PCControls.Add("mouse 3", InputPCControls.Mouse3);
        m_PCControls.Add("mouse 4", InputPCControls.Mouse4);
        m_PCControls.Add("mouse 5", InputPCControls.Mouse5);
        m_PCControls.Add("mouse 6", InputPCControls.Mouse6);

        m_PCControls.Add("escape", InputPCControls.Escape);
        m_PCControls.Add("tab", InputPCControls.Tab);
        m_PCControls.Add("caps lock", InputPCControls.CapsLock);
        m_PCControls.Add("left shift", InputPCControls.LeftShift);
        m_PCControls.Add("left ctrl", InputPCControls.LeftControl);
        m_PCControls.Add("left alt", InputPCControls.LeftAlt);

        m_PCControls.Add("space", InputPCControls.Space);
        m_PCControls.Add("right alt", InputPCControls.RightAlt);
        m_PCControls.Add("right shift", InputPCControls.RightShift);
        m_PCControls.Add("return", InputPCControls.Return);

        m_PCControls.Add("f1", InputPCControls.F1);
        m_PCControls.Add("f2", InputPCControls.F2);
        m_PCControls.Add("f3", InputPCControls.F3);
        m_PCControls.Add("f4", InputPCControls.F4);
        m_PCControls.Add("f5", InputPCControls.F5);
        m_PCControls.Add("f6", InputPCControls.F6);
        m_PCControls.Add("f7", InputPCControls.F7);
        m_PCControls.Add("f8", InputPCControls.F8);
        m_PCControls.Add("f9", InputPCControls.F9);
        m_PCControls.Add("f10", InputPCControls.F10);
        m_PCControls.Add("f11", InputPCControls.F11);
        m_PCControls.Add("f12", InputPCControls.F12);

        m_PCControls.Add("`", InputPCControls.BackQuote);
        m_PCControls.Add("0", InputPCControls.Alpha0);
        m_PCControls.Add("1", InputPCControls.Alpha1);
        m_PCControls.Add("2", InputPCControls.Alpha2);
        m_PCControls.Add("3", InputPCControls.Alpha3);
        m_PCControls.Add("4", InputPCControls.Alpha4);
        m_PCControls.Add("5", InputPCControls.Alpha5);
        m_PCControls.Add("6", InputPCControls.Alpha6);
        m_PCControls.Add("7", InputPCControls.Alpha7);
        m_PCControls.Add("8", InputPCControls.Alpha8);
        m_PCControls.Add("9", InputPCControls.Alpha9);

        m_PCControls.Add("-", InputPCControls.Minus);
        m_PCControls.Add("=", InputPCControls.Equals);
        m_PCControls.Add("backspace", InputPCControls.Backspace);

        m_PCControls.Add("q", InputPCControls.Q);
        m_PCControls.Add("w", InputPCControls.W);
        m_PCControls.Add("e", InputPCControls.E);
        m_PCControls.Add("r", InputPCControls.R);
        m_PCControls.Add("t", InputPCControls.T);
        m_PCControls.Add("y", InputPCControls.Y);
        m_PCControls.Add("u", InputPCControls.U);
        m_PCControls.Add("i", InputPCControls.I);
        m_PCControls.Add("o", InputPCControls.O);
        m_PCControls.Add("p", InputPCControls.P);
        m_PCControls.Add("a", InputPCControls.A);
        m_PCControls.Add("s", InputPCControls.S);
        m_PCControls.Add("d", InputPCControls.D);
        m_PCControls.Add("f", InputPCControls.F);
        m_PCControls.Add("g", InputPCControls.G);
        m_PCControls.Add("h", InputPCControls.H);
        m_PCControls.Add("j", InputPCControls.J);
        m_PCControls.Add("k", InputPCControls.K);
        m_PCControls.Add("l", InputPCControls.L);
        m_PCControls.Add("z", InputPCControls.Z);
        m_PCControls.Add("x", InputPCControls.X);
        m_PCControls.Add("c", InputPCControls.C);
        m_PCControls.Add("v", InputPCControls.V);
        m_PCControls.Add("b", InputPCControls.B);
        m_PCControls.Add("n", InputPCControls.N);
        m_PCControls.Add("m", InputPCControls.M);

        m_PCControls.Add("[", InputPCControls.LeftSquareBracket);
        m_PCControls.Add("]", InputPCControls.RightSquareBracket);
        m_PCControls.Add("\\", InputPCControls.Backslash);
        m_PCControls.Add(";", InputPCControls.Semicolon);
        m_PCControls.Add("'", InputPCControls.Quote);
        m_PCControls.Add(",", InputPCControls.Comma);
        m_PCControls.Add(".", InputPCControls.Period);
        m_PCControls.Add("/", InputPCControls.Slash);

        m_PCControls.Add("insert", InputPCControls.Insert);
        m_PCControls.Add("delete", InputPCControls.Delete);
        m_PCControls.Add("home", InputPCControls.Home);
        m_PCControls.Add("end", InputPCControls.End);
        m_PCControls.Add("page up", InputPCControls.PageUp);
        m_PCControls.Add("page down", InputPCControls.PageDown);

        m_PCControls.Add("[0]", InputPCControls.Keypad0);
        m_PCControls.Add("[1]", InputPCControls.Keypad1);
        m_PCControls.Add("[2]", InputPCControls.Keypad2);
        m_PCControls.Add("[3]", InputPCControls.Keypad3);
        m_PCControls.Add("[4]", InputPCControls.Keypad4);
        m_PCControls.Add("[5]", InputPCControls.Keypad5);
        m_PCControls.Add("[6]", InputPCControls.Keypad6);
        m_PCControls.Add("[7]", InputPCControls.Keypad7);
        m_PCControls.Add("[8]", InputPCControls.Keypad8);
        m_PCControls.Add("[9]", InputPCControls.Keypad9);

        m_PCControls.Add("[.]", InputPCControls.KeypadPeriod);
        m_PCControls.Add("enter", InputPCControls.KeypadEnter);
        m_PCControls.Add("[+]", InputPCControls.KeypadPlus);
        m_PCControls.Add("[-]", InputPCControls.KeypadMinus);
        m_PCControls.Add("[*]", InputPCControls.KeypadMultiply);
        m_PCControls.Add("[/]", InputPCControls.KeypadDivide);
        m_PCControls.Add("numlock", InputPCControls.NumLock);

        m_PCControls.Add("left", InputPCControls.LeftArrow);
        m_PCControls.Add("right", InputPCControls.RightArrow);
        m_PCControls.Add("up", InputPCControls.UpArrow);
        m_PCControls.Add("down", InputPCControls.DownArrow);
        #endregion

        #region // m_XBOXControls Dictionary Setup
        // PlayerGod
        m_XBOXControls.Add("joystick button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick button 9", InputXBOXControls.RightStickClick);
        // UNSURE...
        m_XBOXControls.Add(KeyCode.JoystickButton11.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton12.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton13.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton14.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton15.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton16.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton17.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton18.ToString(), InputXBOXControls.A);
        m_XBOXControls.Add(KeyCode.JoystickButton19.ToString(), InputXBOXControls.A);

        // Player1
        m_XBOXControls.Add("joystick 1 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 1 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 1 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 1 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 1 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 1 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 1 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 1 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 1 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 1 button 9", InputXBOXControls.RightStickClick);

        // Player2
        m_XBOXControls.Add("joystick 2 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 2 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 2 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 2 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 2 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 2 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 2 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 2 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 2 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 2 button 9", InputXBOXControls.RightStickClick);

        // Player3
        m_XBOXControls.Add("joystick 3 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 3 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 3 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 3 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 3 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 3 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 3 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 3 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 3 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 3 button 9", InputXBOXControls.RightStickClick);

        // Player4
        m_XBOXControls.Add("joystick 4 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 4 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 4 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 4 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 4 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 4 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 4 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 4 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 4 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 4 button 9", InputXBOXControls.RightStickClick);

        // Player5
        m_XBOXControls.Add("joystick 5 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 5 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 5 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 5 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 5 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 5 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 5 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 5 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 5 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 5 button 9", InputXBOXControls.RightStickClick);

        // Player6
        m_XBOXControls.Add("joystick 6 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 6 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 6 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 6 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 6 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 6 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 6 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 6 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 6 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 6 button 9", InputXBOXControls.RightStickClick);

        // Player7
        m_XBOXControls.Add("joystick 7 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 7 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 7 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 7 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 7 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 7 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 7 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 7 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 7 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 7 button 9", InputXBOXControls.RightStickClick);

        // Player8
        m_XBOXControls.Add("joystick 8 button 0", InputXBOXControls.A);
        m_XBOXControls.Add("joystick 8 button 1", InputXBOXControls.B);
        m_XBOXControls.Add("joystick 8 button 2", InputXBOXControls.X);
        m_XBOXControls.Add("joystick 8 button 3", InputXBOXControls.Y);
        m_XBOXControls.Add("joystick 8 button 4", InputXBOXControls.LeftBumper);
        m_XBOXControls.Add("joystick 8 button 5", InputXBOXControls.RightBumper);
        m_XBOXControls.Add("joystick 8 button 6", InputXBOXControls.Back);
        m_XBOXControls.Add("joystick 8 button 7", InputXBOXControls.Start);
        m_XBOXControls.Add("joystick 8 button 8", InputXBOXControls.LeftStickClick);
        m_XBOXControls.Add("joystick 8 button 9", InputXBOXControls.RightStickClick);
        #endregion
    }









    public void OnInputChanged()
    {
        for (int i = 0; i < m_InputStrings.Length; i++)
        {
            ReInitializeInputStrings(ref m_InputStrings[i]);
        }
        SetPlayerControllerNumbers();
    }


    public void SetPlayerControllerNumbers()
    {
        //Only set a controller number to an element containing InputType.Joystick
        //Iterate through all the elements of m_InputStrings and collect all of the elements with InputType.Joystick
        int controllersAssigned = 0;

        for (int i = 0; i < m_InputStrings.Length; i++)
        {
            if (m_InputStrings[i].InputType == InputPeripheral.Joystick)
            {
                if (m_InputStrings[i].PlayerNumber != PlayerNumber.God)
                {
                    m_InputStrings[i].JoystickNumber = ++controllersAssigned;
                }
            }
        }
        //Go through all the elements containing InputType.Joystick and in order from player1 - 8 set their Controller numbers.
        //Set the numbers regardless of if there are any joysticks connected.
        //If there are no Joysticks connected another function will handle setting all players not set to keyboard to AI
    }


    private void InitializePlayerNumbers()
    {
        int numPlayers = m_InputStrings.Length;
        for (int i = 0; i < numPlayers; i++)
        {
            m_InputStrings[i].PlayerNumber = (PlayerNumber)i;
        }
    }

    public void ReInitializeInputStrings(ref InputStrings aInputStrings)
    {
        if (aInputStrings.InputType == InputPeripheral.Joystick)
        {
            aInputStrings.MoveXInput = InputXBOXControls.LeftStickX.ToString();
            aInputStrings.MoveYInput = InputXBOXControls.LeftStickY.ToString();
            aInputStrings.CameraXInput = InputXBOXControls.RightStickX.ToString();
            aInputStrings.CameraYInput = InputXBOXControls.RightStickY.ToString();

            aInputStrings.InteractInput = InputXBOXControls.X.ToString();
            aInputStrings.JumpInput = InputXBOXControls.A.ToString();
            aInputStrings.SprintInput = InputXBOXControls.Y.ToString();
            aInputStrings.AttackInput = InputXBOXControls.RightTrigger.ToString();
            aInputStrings.MagicInput = InputXBOXControls.LeftTrigger.ToString();

            aInputStrings.PauseInput = InputXBOXControls.Start.ToString();
            aInputStrings.HelpInput = InputXBOXControls.Back.ToString();
        }
        else if (aInputStrings.InputType == InputPeripheral.Keyboard)
        {
            aInputStrings.MoveXInput = InputPCControls.MoveX.ToString();
            aInputStrings.MoveYInput = InputPCControls.MoveY.ToString();
            aInputStrings.CameraXInput = InputPCControls.MouseX.ToString();
            aInputStrings.CameraYInput = InputPCControls.MouseY.ToString();

            aInputStrings.InteractInput = InputPCControls.E.ToString();
            aInputStrings.JumpInput = InputPCControls.Space.ToString();
            aInputStrings.SprintInput = InputPCControls.C.ToString();
            aInputStrings.AttackInput = InputPCControls.MouseRightClick.ToString();
            aInputStrings.MagicInput = InputPCControls.MouseLeftClick.ToString();

            aInputStrings.PauseInput = InputPCControls.Escape.ToString();
            aInputStrings.HelpInput = InputPCControls.Tab.ToString();
        }
    }

    public void SetInputType(ref InputStrings aInputStrings, InputPeripheral aInputType) // InputManager.Instance.m_InputStrings[PlayerNumber.One], InputType.XBOX;
    {
        //Only used in the input menus, input menu needs to call this once on apply changes... Should be a larger function which considers more...
        aInputStrings.InputType = aInputType;
    }

    public void SetInputString(ref string aStringToChange) // InputManager.Instance.m_InputStrings[PlayerNumber.One].InteractInput;
    {
        //Set the input of the playerNumber passed...
        //Decide the value you want to change and then call the coroutine to wait for input.
        //Once the user has hit a key, map that key to the function string passed in.
        string keyPressed = "";
        // Call the coroutine here

        // Grab the key pressed from the coroutine

        // Set aStringToChange to keyPressed from coroutine.
        aStringToChange = keyPressed;
    }

    //Keyboard...
    public IEnumerator GetKeyPressed_cr() // pass the input type you want to check for.
    {
        bool keyPressed = false;
        string input = "";
        Debug.Log("Input Now");

        while (!keyPressed)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("KeyPressed: " + Input.inputString);
                keyPressed = true;
                input = Input.inputString;
            }
            yield return null;
        }

        m_InputValueStorred = input;
        yield return null;
    }

    public override void OnNotify(ref GameObject aEntity, GameEvent aEvent)
    {

    }
}

[Serializable]
public class InputObj
{
    public InputType Type;
    public Enum InputElement;
    public static float ValueLastFrame;

    public void SetInputEnum(InputPeripheral aPeripheral)
    {
        switch (aPeripheral)
        {
            case InputPeripheral.Joystick:
                InputElement = new InputXBOXControls();
                break;
            case InputPeripheral.Keyboard:
                InputElement = new InputPCControls();
                break;
            case InputPeripheral.AI:
                Debug.Log("Peripheral set to AI");
                break;
            default:
                Debug.Log("Unhandled Peripheral");
                break;
        }
    }
}

public class InputConfig
{
    public InputPeripheral Peripheral;
    public PlayerNumber Number;
    public int JoystickNumber;
    public Dictionary<string, InputObj> InputObjects;

    public void AddInputElement(string aInputName, InputObj aInputObj)
    {
        //Add an element to the Dictionary based on the input_database
        aInputObj.SetInputEnum(Peripheral);
        InputObjects.Add(aInputName, aInputObj);
    }

    public bool HandleInput(InputObj aInputObject)
    {
        switch (aInputObject.Type)
        {
            case InputType.Tap:
                if (Input.GetAxis(Peripheral.ToString() + Number.ToString() + aInputObject.InputElement.ToString()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                break;
            case InputType.DoubleTap:
                return true;
                break;
            case InputType.Hold:
                return true;
                break;
            case InputType.Toggle:
                return true;
                break;
            default:
                Debug.Log("Unhandled Input Type " + aInputObject);
                return false;
                break;
        }
    }

}