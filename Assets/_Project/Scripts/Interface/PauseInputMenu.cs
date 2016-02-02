/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 06/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * 
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseInputMenu : MonoBehaviourSubject
{
    private GameObject m_OptionsMenuCanvas;
    private UnityEngine.EventSystems.EventSystem m_EventSystem;

    #region // ButtonTextObjects
    private Text m_InputTypeText;
    private Text m_InteractText;
    private Text m_JumpText;
    private Text m_SprintText;
    private Text m_AttackText;
    private Text m_PauseText;
    private Text m_HelpText;
    #endregion

    public PlayerNumber m_PlayerNumber;

    void Awake()
    {
        m_OptionsMenuCanvas = GameObject.Find("OptionsMenu");
        m_EventSystem = FindObjectOfType<UnityEngine.EventSystems.EventSystem>();

        m_InputTypeText = GameObject.Find("KeyboardOrXbox").GetComponentInChildren<Text>();
        m_InteractText = GameObject.Find("Interact").GetComponentInChildren<Text>();
        m_JumpText = GameObject.Find("Jump").GetComponentInChildren<Text>();
        m_SprintText = GameObject.Find("Sprint").GetComponentInChildren<Text>();
        m_AttackText = GameObject.Find("Attack").GetComponentInChildren<Text>();
        m_PauseText = GameObject.Find("Pause").GetComponentInChildren<Text>();
        m_HelpText = GameObject.Find("Help").GetComponentInChildren<Text>();
    }

    void OnEnable()
    {
        m_EventSystem.SetSelectedGameObject(GameObject.Find("KeyboardOrXbox"));
        RefreshButtonText();
    }

    void RefreshButtonText()
    {
        
    }

    public void CycleControlType(Button aButton)
    {
        //Cycle between Keyboard or Xbox controls
        
    }

    public void Interact(Button aButton)
    {
        
    }

    public void Jump(Button aButton)
    {
        
    }

    public void Sprint(Button aButton)
    {
        
    }

    public void Attack(Button aButton)
    {
        
    }

    public void Pause(Button aButton)
    {
        
    }

    public void Help(Button aButton)
    {
        
    }

    public void Back()
    {
        gameObject.SetActive(false);
        m_OptionsMenuCanvas.SetActive(true);
    }
}