using UnityEngine;
using System.Collections;

public class SymbolManager : MonoBehaviour 
{
	#region PRIVATE PROPERTIES
	#endregion

	#region PRIVATE METHODS

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void 

	#endregion

	#region PUBLIC PROPERTIES
	public ClockElement[] clockElements;
	#endregion

	#region PUBLIC METHODS

	public void SetShape ( ClockElement.Position position, ClockElement.Shape shape)
	{
		int count = clockElements.Length;

		for (int ctr = 0 ; ctr < count ; ctr++)
		{
			if (clockElements[ctr].position == position)
			{
				clockElements[ctr].shape = shape;
				break;
			}
		}
	}

	public void SetSpecial ( ClockElement.Position position, ClockElement.Special special)
	{
		int count = clockElements.Length;
		
		for (int ctr = 0 ; ctr < count ; ctr++)
		{
			if (clockElements[ctr].position == position)
			{
				clockElements[ctr].special = special;
				break;
			}
		}
	}

	#endregion
	
}
