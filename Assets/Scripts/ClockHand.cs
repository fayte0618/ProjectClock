using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClockHand : MonoBehaviour 
{
	//clockwise is negative, counterclockwise is positive
	public enum Direction
	{
		Clockwise, CounterClockwise, None
	};
	#region PRIVATE PROPERITES
	[SerializeField]
	private Direction _direction = Direction.None;
	[SerializeField]
	private float _speed = 0f;
	#endregion

	#region PRIVATE METHODS

	// Update is called once per frame
	void Update () 
	{
		rect.Rotate (Vector3.forward, _speed * Time.deltaTime, Space.Self); 
	}

	#endregion

	#region PUBLIC PROPERTIES
	public RectTransform rect;

	public Direction direction
	{
		get
		{
			return _direction;
		}
		set
		{
			_direction = value;
			if (_direction == Direction.Clockwise)
			{
				if (_speed > 0) { _speed = -speed; }
			}
			else if (_direction == Direction.CounterClockwise)
			{
				if (_speed < 0) { _speed = Mathf.Abs(_speed); }
			}
		}
	}

	public float speed
	{
		get
		{
			return _speed;
		}
		set
		{
			_speed = value;
			if (_speed > 0) { _direction = Direction.CounterClockwise; }
			else if (_speed < 0) { _direction = Direction.Clockwise; }
			else { _direction = Direction.None; }
		}
	}

	#endregion

	#region PUBLIC METHODS

	#endregion

}
