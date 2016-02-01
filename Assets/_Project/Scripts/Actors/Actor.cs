﻿/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 06/12/15
 * Function: Acts as communication interface between input and gameObject. Contains no logic, only 
 * references to all other player components.
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * Has to attach every other player script onto the player object
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviourSubject
{
	[HideInInspector]
	public ActorStatistics m_Statistics = null;
	[HideInInspector]
	public ActorAbilities m_Abilities = null;
	[HideInInspector]
	public ActorMovement m_Movement = null;
	[HideInInspector]
	public PlayerInput m_Input = null;
	[HideInInspector]
	public ActorInventory m_Inventory = null;
	[HideInInspector]
	public Interaction m_Interaction = null;

	public PlayerNumber PlayerNumber;

	public FollowCamera m_Camera;

	public HUD m_HUD;

	//Unity Callbacks
	void Start()
	{
        Debug.Log(InputXBOXControls.RightStickY.ToString());
		AddObserver(GameManager.Instance);
		m_Statistics = new ActorStatistics(gameObject.GetComponent<Actor>());
		if (m_HUD != null)
		{
			m_HUD.InitializeBars();
		}
		m_Interaction = GetComponentInChildren<Interaction>();
	}

	void OnEnable()
	{
		AddActorComponents();
		AddInputScript();
	}

	void Update()
	{
		UpdateButtonInput();
	}

	void FixedUpdate()
	{
		UpdateMovementInput();
	}

	// private Methods
	private void UpdateButtonInput()
	{
		if (m_Statistics.m_Pools.Health > 0) //Probable temp???
		{
			// Button Input
			if (m_Input.Interact() != 0) { Interact(); }

			if (m_Input.Sprint() != 0) { Sprint(); }
			else { m_Statistics.m_IsSprinting = false; m_Statistics.CalculateSpeed(); }

			if (m_Input.Attack() != 0) { Attack(); }

			if (m_Input.Magic() != 0) { Magic(); }
		}

		if (m_Input.Pause() != 0) { Pause(); }

		if (m_Input.Help() != 0) { Help(); }
	}

	private void UpdateMovementInput()
	{
		if (m_Statistics.m_Pools.Health > 0) //Probable temp???
		{
			// Movement
			if (m_Input.Movement().magnitude != 0) { Movement(new Vector3(m_Input.Movement().x, m_Input.Movement().y, 0.0f)); }

			// Camera
			if (m_Input.Camera().magnitude != 0) { Camera(new Vector3(m_Input.Camera().x, m_Input.Camera().y, 0.0f)); }

            if (m_Input.Jump() != 0) { Jump(); }
        }
	}

	//private Methods
	private void AddActorComponents()
	{
		m_Abilities = (gameObject.GetComponent<ActorAbilities>() == null ? gameObject.AddComponent<ActorAbilities>() : gameObject.GetComponent<ActorAbilities>());
		m_Movement = (gameObject.GetComponent<ActorMovement>() == null ? gameObject.AddComponent<ActorMovement>() : gameObject.GetComponent<ActorMovement>());
		m_Inventory = (gameObject.GetComponent<ActorInventory>() == null ? gameObject.AddComponent<ActorInventory>() : gameObject.GetComponent<ActorInventory>());
	}

	//public Methods
	#region // Input
	public void AddInputScript()
	{
		m_Input = gameObject.AddComponent<PlayerInput>();
	}

	public void Movement(Vector3 aInput)
	{
		m_Movement.Movement(aInput);
	}

	public void Camera(Vector3 aInput)
	{
		m_Movement.Camera(aInput);
	}

	public void Interact()
	{
		m_Interaction.Interact();
	}

	public void Jump()
	{
		m_Abilities.Jump();
	}

	public void Sprint()
	{
		m_Abilities.Sprint();
	}

	public void Attack()
	{
		m_Abilities.Attack();
	}

	public void Magic()
	{
		m_Abilities.Magic();
	}

	public void Pause()
	{
		Debug.Log("PauseButtonHit");
		if (GameObject.FindObjectOfType<PauseGame>())
		{
			GameObject.FindObjectOfType<PauseGame>().Pause(gameObject);
		}
		else
		{
			Debug.Log("PauseFailed, no PauseGame object in the scene");
		}
	}

	public void Help()
	{
		Debug.Log("HelpButtonHit");
	}
	#endregion
}