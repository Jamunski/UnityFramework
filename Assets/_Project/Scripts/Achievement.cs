using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[System.Serializable]
public class Achievement
{
    public string Name;
    public bool Acquired;
    public Sprite Image;

    public List<Condition> conditions;

    public UnityEvent OnConditionsMet;

    public Achievement()
    {
        conditions = new List<Condition>();
    }

    public void CheckConditions() // Call in the Achievement Manager
    {
        //iterate through all the conditions in the achievement and check if they are all true.
        //If all the conditions are true, set the achievement to acquired and call OnUnlock()
        bool allConditionsMet = true;
        for (int i = 0; i < conditions.Count; i++)
        {
            if (conditions[i].Acquired != true)
            {
                allConditionsMet = false;
            }
        }
        if (allConditionsMet)
        {
			Acquired = true;
            OnUnlock();
        }
    }

    void OnUnlock() // Call in the Achievement List???
    {
        //Call any functions you would like to occur for every achievement
		Debug.Log("Acquired Achievement!!");

        OnConditionsMet.Invoke();
    }

    [System.Serializable]
    public class Condition
    {
        public string ConditionName;
        public bool Acquired;
    }
}