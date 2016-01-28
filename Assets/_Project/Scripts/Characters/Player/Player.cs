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

public class Player : MonoBehaviourSubject // Make this inherit from a base class... The base class will be IDamageable...
{
    [HideInInspector]
    public PlayerStatistics m_PlayerStatistics = null;
    [HideInInspector]
    public PlayerAbilities m_PlayerAbilities = null;
    [HideInInspector]
    public PlayerMovement m_PlayerMovement = null;
    [HideInInspector]
    public PlayerInput m_PlayerInput = null;
    [HideInInspector]
    public PlayerInventory m_PlayerInventory = null;
    [HideInInspector]
    public PlayerInteraction m_PlayerInteraction = null;

    public PlayerNumber PlayerNumber;

	public FollowCamera m_Camera;

	public HUD m_HUD;

	//Unity Callbacks
    void Awake()
    {
        AddObserver(GameManager.Instance);
        m_PlayerInteraction = GetComponentInChildren<PlayerInteraction>();
    }

    void OnEnable()
    {
        AddPlayerComponents();
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
        if (m_PlayerStatistics.m_Pools.Health > 0) //Probable temp???
        {
            // Button Input
            if (m_PlayerInput.Interact() != 0) { Interact(); }

            if (m_PlayerInput.Jump() != 0) { Jump(); }

            if (m_PlayerInput.Sprint() != 0) { Sprint(); }
            else { m_PlayerStatistics.m_IsSprinting = false; m_PlayerStatistics.CalculateSpeed(); }

            if (m_PlayerInput.Attack() != 0) { Attack(); }

            if (m_PlayerInput.Magic() != 0) { Magic(); }
        }

        if (m_PlayerInput.Pause() != 0) { Pause(); }

        if (m_PlayerInput.Help() != 0) { Help(); }
    }

    private void UpdateMovementInput()
    {
        if (m_PlayerStatistics.m_Pools.Health > 0) //Probable temp???
        {
            // Movement
            if (m_PlayerInput.Movement().magnitude != 0) { Movement(new Vector3(m_PlayerInput.Movement().x, m_PlayerInput.Movement().y, 0.0f)); }

            // Camera
            if (m_PlayerInput.Camera().magnitude != 0) { Camera(new Vector3(m_PlayerInput.Camera().x, m_PlayerInput.Camera().y, 0.0f)); }
        }
    }

    //private Methods
    private void AddPlayerComponents()
    {
        m_PlayerStatistics = (gameObject.GetComponent<PlayerStatistics>() == null ? gameObject.AddComponent<PlayerStatistics>() : gameObject.GetComponent<PlayerStatistics>());
        m_PlayerAbilities = (gameObject.GetComponent<PlayerAbilities>() == null ? gameObject.AddComponent<PlayerAbilities>() : gameObject.GetComponent<PlayerAbilities>());
        m_PlayerMovement = (gameObject.GetComponent<PlayerMovement>() == null ? gameObject.AddComponent<PlayerMovement>() : gameObject.GetComponent<PlayerMovement>());
        m_PlayerInventory = (gameObject.GetComponent<PlayerInventory>() == null ? gameObject.AddComponent<PlayerInventory>() : gameObject.GetComponent<PlayerInventory>());
    }

    //public Methods
    #region // Input
    public void AddInputScript()
    {
        m_PlayerInput = gameObject.AddComponent<PlayerInput>();
    }

    public void Movement(Vector3 aInput)
    {
        m_PlayerMovement.Movement(aInput);
    }

    public void Camera(Vector3 aInput)
    {
        m_PlayerMovement.Camera(aInput);
    }

    public void Interact()
    {
        m_PlayerInteraction.Interact();
    }

    public void Jump()
    {
        m_PlayerAbilities.Jump();
    }

    public void Sprint()
    {
        m_PlayerAbilities.Sprint();
    }

    public void Attack()
    {
        m_PlayerAbilities.Attack();
    }

    public void Magic()
    {
        m_PlayerAbilities.Magic();
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