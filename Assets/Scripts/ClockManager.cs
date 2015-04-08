using UnityEngine;
using System.Collections;

public class ClockManager : MonoBehaviour 
{

	#region PRIVATE PROPERTIES
	#endregion

	#region PRIVATE METHODS

	void Awake ()
	{
		clockHand.speed = initialClockSpeed;
	}

	void OnEnable ()
	{
		ClockElement.OnTrigger += ClockElementListener;
	}

	void OnDisable ()
	{
		ClockElement.OnTrigger -= ClockElementListener;
	}

	private void ClockElementListener (ClockElement element)
	{

	}
	
	#endregion

	#region PUBLIC PROPERTIES

	public ClockHand clockHand;
	public float initialClockSpeed = 20f;

	#endregion

	#region PUBLIC METHODS
	#endregion

}
