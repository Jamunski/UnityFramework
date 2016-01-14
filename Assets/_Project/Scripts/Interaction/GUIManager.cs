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

public class GUIManager : MonoBehaviour
{
    public Text interactionName;
    public Image interactionIcon;

    private PlayerInteraction player;

    void Awake()
    {
        //Will be more than on PlayerInteractionManager object in multiplayer
        player = GameObject.FindObjectOfType<PlayerInteraction>();
    }

    void Update()
    {
        if (player.current != null)
        {
            interactionName.text = player.current.Name;
            interactionIcon.sprite = player.current.Icon;
            interactionIcon.enabled = true;
        }
        else
        {
            interactionName.text = "";
            interactionIcon.enabled = false;
        }
    }
}

/*
Notes: Find a better way to handle this class so it can function well for a multiplayers game...
*/