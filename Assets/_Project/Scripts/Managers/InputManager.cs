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


public abstract class InputPeripheral
{
	public string PeripheralString;

	public abstract void SetPeripheralString(PlayerNumber aPlayerNumber);
}

public class PeripheralNA : InputPeripheral
{
	public override void SetPeripheralString(PlayerNumber aPlayerNumber)
	{
		PeripheralString = "NA";
	}
}

public class PeripheralPC : InputPeripheral
{
	public override void SetPeripheralString(PlayerNumber aPlayerNumber)
	{
		PeripheralString = "Keyboard";
	}
}

public class PeripheralXBOX : InputPeripheral
{
	public override void SetPeripheralString(PlayerNumber aPlayerNumber)
	{
		if (aPlayerNumber != PlayerNumber.God)
		{
			PeripheralString = "Joystick" + aPlayerNumber.ToString();
		}
		else
		{
			PeripheralString = "Joystick";
		}
	}
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

public enum InputXBOX
{
	A = 0, B, X, Y, // Face Buttons
	LeftBumper, RightBumper, // Bumpers
	Back, Start, // Options
	LeftStickClick, RightStickClick, // Stick Clicks
	LeftStickX, LeftStickY, RightStickX, RightStickY, // Stick Axes
	DpadX, DpadY, // Dpad Axes
	LeftTrigger, RightTrigger // Triggers
}

public enum InputPC
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

public class InputManager
{
	// private members
	private static InputManager instance;

	public List<InputActions> m_InputActions;

	//public members
	public InputConfig[] m_InputConfigs { get; private set; }

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
		m_ControllersConnected = GetNumControllersConnected();

		InitializeInputConfigs();

		InitializeActionInputs();
	}

	private void InitializeInputConfigs()
	{
		m_InputConfigs = new InputConfig[9];

		m_InputConfigs[0] = new InputConfig(new PeripheralPC());
		for (int i = 0; i < m_ControllersConnected; i++)
		{
			m_InputConfigs[i + 1] = new InputConfig(new PeripheralXBOX());
		}
		//if controllers connected == 3, set the fourth player to Keyboard
		if (m_ControllersConnected != 8)
		{
			// Every other controller should have peripheral NA after this...
			for (int i = 0; i < (m_InputConfigs.Length - 1) - m_ControllersConnected; i++)
			{
				m_InputConfigs[i + m_ControllersConnected + 1] = new InputConfig(new PeripheralNA()); // NULL INPUT PERIPHERAL
			}
			m_InputConfigs[m_ControllersConnected + 1] = new InputConfig(new PeripheralPC());
		}
	}

	//PLEASE CHANGE ME!!! if there are 100 peripheral types then you will need to overload 100 times...
	public void CreateActionInput(InputConfig aInputConfig, string aAction, InputPC aInput, InputType aInputType = InputType.Tap)
	{
		aInputConfig.InputObjects.Add(aAction, new InputObj());
		aInputConfig.InputObjects[aAction].InputElement = aInput;
		aInputConfig.InputObjects[aAction].Type = aInputType;
	}

	public void CreateActionInput(InputConfig aInputConfig, string aAction, InputXBOX aInput, InputType aInputType = InputType.Tap)
	{
		aInputConfig.InputObjects.Add(aAction, new InputObj());
		aInputConfig.InputObjects[aAction].InputElement = aInput;
		aInputConfig.InputObjects[aAction].Type = aInputType;
	}

	//PLEASE CHANGE ME!!!
	private void InitializeActionInputs()
	{
		Debug.Log(m_InputConfigs[1].Peripheral.ToString());
		CreateActionInput(m_InputConfigs[1], "MoveForward", InputPC.W, InputType.Hold);
		CreateActionInput(m_InputConfigs[1], "MoveBackward", InputPC.S, InputType.Hold);
		CreateActionInput(m_InputConfigs[1], "MoveLeft", InputPC.A, InputType.Hold);
		CreateActionInput(m_InputConfigs[1], "MoveRight", InputPC.D, InputType.Hold);
		// CheckAxisInput(InputObj aNegativeAction, Inputobj aPositiveAction)
		// Create an axis input using both existing actions...
		// This is useful for the situation with movement and stuff, players will still be able to remap the individual InputObj
		// because the axis action will refer to those objects...

		CreateActionInput(m_InputConfigs[1], "CameraX", InputPC.MouseX, InputType.Hold);
		CreateActionInput(m_InputConfigs[1], "CameraY", InputPC.MouseY, InputType.Hold);
		CreateActionInput(m_InputConfigs[1], "CameraX", InputPC.MouseX, InputType.Hold);
		CreateActionInput(m_InputConfigs[1], "CameraY", InputPC.MouseY, InputType.Hold);

		CreateActionInput(m_InputConfigs[1], "CenterCamera", InputPC.C, InputType.Tap);

		CreateActionInput(m_InputConfigs[1], "Jump", InputPC.V, InputType.Tap);
		CreateActionInput(m_InputConfigs[1], "Sprint", InputPC.LeftShift, InputType.Hold);
		CreateActionInput(m_InputConfigs[1], "Dodge", InputPC.Space, InputType.Tap);

		CreateActionInput(m_InputConfigs[1], "UseItem", InputPC.F, InputType.Tap);
		CreateActionInput(m_InputConfigs[1], "Interact", InputPC.E, InputType.Tap);

		CreateActionInput(m_InputConfigs[1], "LeftAction1", InputPC.MouseLeftClick, InputType.Tap);
		CreateActionInput(m_InputConfigs[1], "LeftAction2", InputPC.MouseLeftClick, InputType.DoubleTap);
		CreateActionInput(m_InputConfigs[1], "RightAction1", InputPC.MouseRightClick, InputType.Tap);
		CreateActionInput(m_InputConfigs[1], "RightAction2", InputPC.MouseRightClick, InputType.DoubleTap);

		CreateActionInput(m_InputConfigs[1], "Pause", InputPC.Escape, InputType.Tap);
		CreateActionInput(m_InputConfigs[1], "Help", InputPC.Tab, InputType.Tap);

		//CreateActionInput(m_InputConfigs[2], "MoveX", InputXBOX.LeftStickX, InputType.Hold);
		//CreateActionInput(m_InputConfigs[2], "MoveY", InputXBOX.LeftStickY, InputType.Hold);
		//CreateActionInput(m_InputConfigs[2], "CameraX", InputXBOX.RightStickX, InputType.Hold);
		//CreateActionInput(m_InputConfigs[2], "CameraY", InputXBOX.RightStickY, InputType.Hold);

		//CreateActionInput(m_InputConfigs[2], "CenterCamera", InputXBOX.RightStickClick, InputType.Tap);

		//CreateActionInput(m_InputConfigs[2], "Jump", InputXBOX.Y, InputType.Hold);
		//CreateActionInput(m_InputConfigs[2], "Sprint", InputXBOX.LeftStickClick, InputType.Hold);
		//CreateActionInput(m_InputConfigs[2], "Dodge", InputXBOX.B, InputType.Tap);

		//CreateActionInput(m_InputConfigs[2], "UseItem", InputXBOX.X, InputType.Tap);
		//CreateActionInput(m_InputConfigs[2], "Interact", InputXBOX.A, InputType.Tap);

		//CreateActionInput(m_InputConfigs[2], "LeftAction1", InputXBOX.LeftBumper, InputType.Tap);
		//CreateActionInput(m_InputConfigs[2], "LeftAction2", InputXBOX.LeftTrigger, InputType.Tap);
		//CreateActionInput(m_InputConfigs[2], "RightAction1", InputXBOX.RightBumper, InputType.Tap);
		//CreateActionInput(m_InputConfigs[2], "RightAction2", InputXBOX.RightTrigger, InputType.Tap);
	}

	private int GetNumControllersConnected()
	{
		return Input.GetJoystickNames().Length;
	}
}

[Serializable]
public class InputObj
{
	public InputType Type;
	public Enum InputElement;
	public float ValueLastFrame;
	public bool IsToggled;

	public InputObj(InputType aType = InputType.Tap)
	{
		Type = aType;
		ValueLastFrame = 0.0f;
	}
}

[Serializable]
public class InputConfig
{
	public InputPeripheral Peripheral;
	public PlayerNumber Number;
	public int JoystickNumber;
	public Dictionary<string, InputObj> InputObjects;

	public InputConfig(InputPeripheral aPeripheral, PlayerNumber aNumber = PlayerNumber.God, int aJoystickNumber = 0)
	{
		Peripheral = aPeripheral;
		Number = aNumber;
		JoystickNumber = aJoystickNumber;
		InputObjects = new Dictionary<string, InputObj>();

		Peripheral.SetPeripheralString(Number);
		Debug.Log(aNumber);
		//SetInputObjs();
	}

	//--------------------------------------------------------------------	
	//public delegate void ButtonInputDelegate();
	//protected ButtonInputDelegate m_ButtonInputDel;
	//public void CheckInput(InputObj aInputObject, Actor aActor, ButtonInputDelegate aInputDel)
	//aInputDel();
	//--------------------------------------------------------------------

	public float CheckInput(InputObj aInputObject, Actor aActor)
	{

		if (InputManager.Instance.m_InputConfigs[(int)aActor.PlayerNumber].Peripheral != null)
		{

			switch (aInputObject.Type)
			{

				case InputType.Tap: //Needs some more work...
					if (Mathf.Abs(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString())) > 0.01 && aInputObject.ValueLastFrame < 0.01f) //need to handle GOD element
					{
						aInputObject.ValueLastFrame = 1.0f;
						return Mathf.Sign(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString()));
					}
					else if (Mathf.Abs(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString())) < 0.01)
					{
						aInputObject.ValueLastFrame = 0.0f;
					}
					break;
				case InputType.DoubleTap: // Not Implemented
					break;
				case InputType.Hold:
					if (Mathf.Abs(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString())) > 0.01)
					{
						return Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString());
					}
					break;
				case InputType.Toggle:
					if (Mathf.Abs(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString())) > 0.01 && aInputObject.ValueLastFrame < 0.01f && !aInputObject.IsToggled) //need to handle GOD element
					{
						aInputObject.ValueLastFrame = 1.0f;
						aInputObject.IsToggled = true;
						return Mathf.Sign(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString()));
					}
					else if (Mathf.Abs(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString())) > 0.01 && aInputObject.ValueLastFrame < 0.01f && aInputObject.IsToggled) //need to handle GOD element
					{
						aInputObject.ValueLastFrame = 1.0f;
						aInputObject.IsToggled = false;
					}
					else if (aInputObject.IsToggled && Mathf.Abs(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString())) < 0.01) // if no input and toggled
					{
						//currently toggled
						aInputObject.ValueLastFrame = 0.0f;
						
						return Mathf.Sign(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString()));
					}
					else if (Mathf.Abs(Input.GetAxis(Peripheral.PeripheralString + "_" + aInputObject.InputElement.ToString())) < 0.01)
					{
						aInputObject.ValueLastFrame = 0.0f;
					}
					break;
				default:
					Debug.Log("Unhandled Input Type " + aInputObject);
					break;

			}
			return 0.0f;
		}
		else
		{
			Debug.Log(aActor.name + " Peripheral set to " + InputManager.Instance.m_InputConfigs[(int)aActor.PlayerNumber].Peripheral);
			return 0.0f;
		}
	}

}