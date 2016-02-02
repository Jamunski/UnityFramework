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
	NA = -1, //No Peripheral, useful for AI
	Joystick = 0,
	Keyboard
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

	public void SetActionInput(InputConfig aInputConfig, string aAction, InputPC aInput, InputType aInputType = InputType.Tap)
	{
		aInputConfig.SetInputElement(aInputConfig.InputObjects[aAction], aInput, aInputType);
	}

	public void SetActionInput(InputConfig aInputConfig, string aAction, InputXBOX aInput, InputType aInputType = InputType.Tap)
	{
		aInputConfig.SetInputElement(aInputConfig.InputObjects[aAction], aInput, aInputType);
	}

	private void InitializeInputConfigs()
	{
		m_InputConfigs[0] = new InputConfig(InputPeripheral.Keyboard);
		for (int i = 0; i < m_ControllersConnected; i++)
		{
			m_InputConfigs[i + 1] = new InputConfig(InputPeripheral.Joystick);
		}
		//if controllers connected == 3, set the fourth player to Keyboard
		if (m_ControllersConnected != 0 || m_ControllersConnected != 8)
		{
			m_InputConfigs[m_ControllersConnected + 1] = new InputConfig(InputPeripheral.Keyboard);
			// Every other controller should have peripheral NA after this...
			for (int i = 0; i < (m_InputConfigs.Length - 1) - m_ControllersConnected; i++)
			{
				m_InputConfigs[i + m_ControllersConnected + 1] = new InputConfig(InputPeripheral.NA);
			}
		}
	}

	private void InitializeActionInputs()
	{
		SetActionInput(m_InputConfigs[0], "MoveX", InputPC.MoveX, InputType.Hold);
		SetActionInput(m_InputConfigs[0], "MoveY", InputPC.MoveY, InputType.Hold);
		SetActionInput(m_InputConfigs[0], "CameraX", InputPC.MouseX, InputType.Hold);
		SetActionInput(m_InputConfigs[0], "CameraY", InputPC.MouseY, InputType.Hold);

		SetActionInput(m_InputConfigs[0], "CenterCamera", InputPC.C, InputType.Tap);

		SetActionInput(m_InputConfigs[0], "Jump", InputPC.V, InputType.Hold);
		SetActionInput(m_InputConfigs[0], "Sprint", InputPC.LeftShift, InputType.Hold);
		SetActionInput(m_InputConfigs[0], "Dodge", InputPC.Space, InputType.Tap);

		SetActionInput(m_InputConfigs[0], "UseItem", InputPC.F, InputType.Tap);
		SetActionInput(m_InputConfigs[0], "Interact", InputPC.E, InputType.Tap);

		SetActionInput(m_InputConfigs[0], "LeftAction1", InputPC.MouseLeftClick, InputType.Tap);
		SetActionInput(m_InputConfigs[0], "LeftAction2", InputPC.MouseLeftClick, InputType.DoubleTap);
		SetActionInput(m_InputConfigs[0], "RightAction1", InputPC.MouseRightClick, InputType.Tap);
		SetActionInput(m_InputConfigs[0], "RightAction2", InputPC.MouseRightClick, InputType.DoubleTap);



		SetActionInput(m_InputConfigs[1], "MoveX", InputXBOX.LeftStickX, InputType.Hold);
		SetActionInput(m_InputConfigs[1], "MoveY", InputXBOX.LeftStickY, InputType.Hold);
		SetActionInput(m_InputConfigs[1], "CameraX", InputXBOX.RightStickX, InputType.Hold);
		SetActionInput(m_InputConfigs[1], "CameraY", InputXBOX.RightStickY, InputType.Hold);

		SetActionInput(m_InputConfigs[1], "CenterCamera", InputXBOX.RightStickClick, InputType.Tap);

		SetActionInput(m_InputConfigs[1], "Jump", InputXBOX.Y, InputType.Hold);
		SetActionInput(m_InputConfigs[1], "Sprint", InputXBOX.LeftStickClick, InputType.Hold);
		SetActionInput(m_InputConfigs[1], "Dodge", InputXBOX.B, InputType.Tap);

		SetActionInput(m_InputConfigs[1], "UseItem", InputXBOX.X, InputType.Tap);
		SetActionInput(m_InputConfigs[1], "Interact", InputXBOX.A, InputType.Tap);

		SetActionInput(m_InputConfigs[1], "LeftAction1", InputXBOX.LeftBumper, InputType.Tap);
		SetActionInput(m_InputConfigs[1], "LeftAction2", InputXBOX.LeftTrigger, InputType.Tap);
		SetActionInput(m_InputConfigs[1], "RightAction1", InputXBOX.RightBumper, InputType.Tap);
		SetActionInput(m_InputConfigs[1], "RightAction2", InputXBOX.RightTrigger, InputType.Tap);
	}

	private int GetNumControllersConnected()
	{
		return Input.GetJoystickNames().Length;
	}

	private void SetDefaultPeripheral()
	{
		
	}
}

[Serializable]
public class InputObj
{
	public InputType Type;
	public Enum InputElement;
	public float ValueLastFrame;

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

	private string m_PeripheralString;

	public InputConfig(InputPeripheral aPeripheral = InputPeripheral.NA, PlayerNumber aNumber = PlayerNumber.God, int aJoystickNumber = 0)
	{
		Peripheral = aPeripheral;
		Number = aNumber;
		JoystickNumber = aJoystickNumber;
		InputObjects = new Dictionary<string, InputObj>();

		if (aPeripheral == InputPeripheral.Joystick && aNumber != PlayerNumber.God)
		{
			m_PeripheralString = Peripheral.ToString() + Number.ToString();

		}
		else
		{
			m_PeripheralString = Peripheral.ToString();
		}
		TempSetInputObjs();
	}

	public bool CheckInput(InputObj aInputObject)
	{
		switch (aInputObject.Type)
		{
			case InputType.Tap:
				if (Input.GetAxis(m_PeripheralString + "_" + aInputObject.InputElement.ToString()) > 0) //need to handle GOD element
				{
					return true;
				}
				break;
			case InputType.DoubleTap:
				break;
			case InputType.Hold:
				if (Input.GetAxis(m_PeripheralString + "_" + aInputObject.InputElement.ToString()) > 0)
				{
					return true;
				}
				break;
			case InputType.Toggle:
				break;
			default:
				Debug.Log("Unhandled Input Type " + aInputObject);
				break;
		}
		return false;
	}

	public void SetInputElement(InputObj aInputObj, InputPC aInput, InputType aInputType = InputType.Tap)
	{
		aInputObj.InputElement = aInput;
		aInputObj.Type = aInputType;
	}

	public void SetInputElement(InputObj aInputObj, InputXBOX aInput, InputType aInputType = InputType.Tap)
	{
		aInputObj.InputElement = aInput;
		aInputObj.Type = aInputType;
	}

	private void TempSetInputObjs()
	{
		InputObj MoveX = new InputObj(InputType.Hold);
		InputObj MoveY = new InputObj(InputType.Hold);
		InputObj CameraX = new InputObj(InputType.Hold);
		InputObj CameraY = new InputObj(InputType.Hold);

		InputObj CenterCamera = new InputObj(InputType.Tap);

		InputObj Jump = new InputObj(InputType.Tap);
		InputObj Sprint = new InputObj(InputType.Hold);
		InputObj Dodge = new InputObj(InputType.Tap);

		InputObj UseItem = new InputObj(InputType.Tap);
		InputObj Interact = new InputObj(InputType.Tap);

		InputObj LeftAction1 = new InputObj(InputType.Tap);
		InputObj LeftAction2 = new InputObj(InputType.Tap);
		InputObj RightAction1 = new InputObj(InputType.Tap);
		InputObj RightAction2 = new InputObj(InputType.Tap);

		InputObj Pause = new InputObj(InputType.Tap);
		InputObj Help = new InputObj(InputType.Tap);

		InputObjects.Add("MoveX", MoveX);
		InputObjects.Add("MoveY", MoveY);
		InputObjects.Add("CameraX", CameraX);
		InputObjects.Add("CameraY", CameraY);

		InputObjects.Add("CenterCamera", CenterCamera);

		InputObjects.Add("Jump", Jump);
		InputObjects.Add("Sprint", Sprint);
		InputObjects.Add("Dodge", Dodge);

		InputObjects.Add("UseItem", UseItem);
		InputObjects.Add("Interact", Interact);

		InputObjects.Add("LeftAction1", LeftAction1);
		InputObjects.Add("LeftAction2", LeftAction2);
		InputObjects.Add("RightAction1", RightAction1);
		InputObjects.Add("RightAction2", RightAction2);

		InputObjects.Add("Pause", Pause);
		InputObjects.Add("Help", Help);
	}

	private void SetInputObjs(InputObj aInputObj, InputType aInputType, string aActionName)
	{
		aInputObj.Type = aInputType;

		InputObjects.Add(aActionName, aInputObj);
	}

	private void CollectInputElements()
	{
		//Read input elements from the database...
		//for (int i = 0; i < InputManager.Instance.m_InputActions.Count; i++)
		//{
		//	SetInputObjs(thing, InputType.Tap, InputManager.Instance.m_InputActions[i].Name);
		//}
	}
}