//Any class which needs to observe any subjects

using UnityEngine;
using System.Collections;

public abstract class Observer
{
    ~Observer() { }
	public virtual void OnNotify(ref GameObject aEntity, GameEvent aEvent)
	{

	}
	public virtual void OnNotify(ref GameObject aEntity, string aEvent)
	{

	}
}
