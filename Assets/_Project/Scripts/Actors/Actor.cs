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

	//Unity Callbacks
	void Start()
	{
        Debug.Log(InputXBOX.RightStickY.ToString());
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
			if (InputManager.Instance.m_InputConfigs[(int)PlayerNumber].CheckInput(InputManager.Instance.m_InputConfigs[(int)PlayerNumber].InputObjects["Jump"]))
			{
				m_Abilities.Jump();
			}

			if (InputManager.Instance.m_InputConfigs[(int)PlayerNumber].CheckInput(InputManager.Instance.m_InputConfigs[(int)PlayerNumber].InputObjects["Pause"]))
			{
				Pause();
			}

			if (InputManager.Instance.m_InputConfigs[(int)PlayerNumber].CheckInput(InputManager.Instance.m_InputConfigs[(int)PlayerNumber].InputObjects["Interact"]))
			{
				m_Interaction.Interact();
			}
		}
	}

	private void UpdateMovementInput()
	{
		if (m_Statistics.m_Pools.Health > 0) //Probable temp???
		{
			if (InputManager.Instance.m_InputConfigs[(int)PlayerNumber].CheckInput(InputManager.Instance.m_InputConfigs[(int)PlayerNumber].InputObjects["Interact"]))
			{

			}
			// Movement
			//if (m_Input.Movement().magnitude != 0) { Movement(new Vector3(m_Input.Movement().x, m_Input.Movement().y, 0.0f)); }

			//// Camera
			//if (m_Input.Camera().magnitude != 0) { Camera(new Vector3(m_Input.Camera().x, m_Input.Camera().y, 0.0f)); }

			//if (m_Input.Jump() != 0) { Jump(); }
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