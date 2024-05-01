using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMono : MonoBehaviour
{	
	public bool log = false;

	public void Log(string message)
	{
		if (this.log)
		{
			Debug.Log(message);
		}
	}

	public IEnumerator PerformActionAfterDelay(float delay, System.Action action)
	{
		yield return new WaitForSeconds(delay);
		action();
	}
}
