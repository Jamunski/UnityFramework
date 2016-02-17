/*********************************************HEADER*********************************************\
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
	public ActorInventory m_Inventory = null;
	[HideInInspector]
	public Interaction m_Interaction = null;

	public PlayerNumber PlayerNumber;

	public FollowCamera m_Camera;

	public HUD m_HUD;

	private InputConfig m_PlayerInputConfig;

	//Unity Callbacks
	void Start()
	{
		AddObserver(GameManager.Instance);
		m_PlayerInputConfig = InputManager.Instance.m_InputConfigs[(int)PlayerNumber];
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
		if(m_PlayerInputConfig.CheckInput(m_PlayerInputConfig.InputObjects["Interact"], this) > 0.01f)
		{
			m_Interaction.Interact();
		}

		if( m_PlayerInputConfig.CheckInput(m_PlayerInputConfig.InputObjects["Pause"], this) > 0.01f)
		{
			Pause();
		}
	}

	private void UpdateMovementInput()
	{
		//Call Movement Here: Take all the movement inputs and populate a vector2 with their values.

		if(MovementInput().magnitude > 0.01f)
		{
			m_Movement.Movement(new Vector3(MovementInput().x, MovementInput().y, 0));
		}

		if(m_PlayerInputConfig.CheckInput(m_PlayerInputConfig.InputObjects["Jump"], this) > 0.01f)
		{

		}

		// Movement
		//if (m_Input.Movement().magnitude != 0) { Movement(new Vector3(m_Input.Movement().x, m_Input.Movement().y, 0.0f)); }

		//// Camera
		//if (m_Input.Camera().magnitude != 0) { Camera(new Vector3(m_Input.Camera().x, m_Input.Camera().y, 0.0f)); }

		//if (m_Input.Jump() != 0) { Jump(); }
	}

	//private Methods
	private void AddActorComponents()
	{
		m_Abilities = (gameObject.GetComponent<ActorAbilities>() == null ? gameObject.AddComponent<ActorAbilities>() : gameObject.GetComponent<ActorAbilities>());
		m_Movement = (gameObject.GetComponent<ActorMovement>() == null ? gameObject.AddComponent<ActorMovement>() : gameObject.GetComponent<ActorMovement>());
		m_Inventory = (gameObject.GetComponent<ActorInventory>() == null ? gameObject.AddComponent<ActorInventory>() : gameObject.GetComponent<ActorInventory>());
	}

	//public Methods
	public Vector2 MovementInput()
	{
		Vector2 movementVector = new Vector2();

		movementVector.y += m_PlayerInputConfig.CheckInput(m_PlayerInputConfig.InputObjects["MoveForward"], this);

		movementVector.y -= m_PlayerInputConfig.CheckInput(m_PlayerInputConfig.InputObjects["MoveBackward"], this);

		movementVector.x -= m_PlayerInputConfig.CheckInput(m_PlayerInputConfig.InputObjects["MoveLeft"], this);

		movementVector.x += m_PlayerInputConfig.CheckInput(m_PlayerInputConfig.InputObjects["MoveRight"], this);

		return movementVector;
	}

	public void Pause() // Probably should be handled in the game manager...
	{
		Debug.Log("PauseButtonHit");
		try
		{
			GameObject.FindObjectOfType<PauseGame>().Pause(gameObject);
		}
		catch
		{
			Debug.Log("PauseFailed, no PauseGame object in the scene");
		}
	}
}