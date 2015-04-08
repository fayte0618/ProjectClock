using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (RawImage), typeof (BoxCollider2D))]
public class ClockElement : MonoBehaviour 
{
	public enum Position
	{
		One = 1, Two = 2, Three = 4, Four = 8, Five = 16, Six = 32, Seven = 64, Eight = 128, Nine = 256, Ten = 512, Eleven = 1024, Twelve = 2048, None = 0
	};

	public enum SymbolType
	{
		Shapes, Colour, Special, None
	};

	public enum Shape
	{
		Circle = 0, Line = 1, Cross = 2, Triangle = 3, Square = 4, Pentagon = 5, Hexagon = 6, None = -1
	};

	public enum Colour
	{
		Red, Yellow, Blue, Orange, Purple, Green, Black, None
	};

	public enum Special
	{
		Clockwise, CounterClockwise, Penalty, NormalSpeed, SpeedUp, SpeedDown, Bonus, None
	};
	
	#region PRIVATE PROPERTIES
	[SerializeField]
	private Position _position = Position.None;
	[SerializeField]
	private SymbolType _symbol = SymbolType.None;
	[SerializeField]
	private Shape _shape = Shape.None;
	[SerializeField]
	private Colour _colour = Colour.None;
	[SerializeField]
	private Special _special = Special.None;

	private static Texture2D[] graphics;
	private RawImage symbolGraphic;
	#endregion

	#region PRIVATE METHODS
	
	void Awake()
	{
		LoadComponents ();
		LoadGraphics ();
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (OnTrigger != null) { OnTrigger (this); }
	}
	
	private void LoadGraphics ()
	{
		if (graphics == null) { graphics = Resources.LoadAll<Texture2D> (ResourceLocation.CLOCK_ELEMENTS_GRAPHICS); }
	}
	
	private void LoadComponents ()
	{ 
		if (symbolGraphic == null) { symbolGraphic = GetComponent<RawImage>(); }
	}
	
	private Texture2D GetGraphic (string name)
	{
		//just to make sure it has content
		LoadGraphics ();
		
		int count = graphics.Length;
		
		for (int ctr = 0 ; ctr < count ; ctr++)
		{
			if (graphics[ctr].name.Equals(name, System.StringComparison.Ordinal))
			{
				return graphics[ctr];
			}
		}
		
		return null;
	}
	
	#endregion

	#region PUBLIC PROPERTIES
	public Position position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public SymbolType symbol
	{
		get
		{
			return _symbol;
		}
		set
		{
			_symbol = value;
		}
	}

	public Shape shape
	{
		get
		{
			return _shape;
		}
		set
		{
			_shape = value;
			SetShapeGraphic(value);
		}
	}

	public Colour colour
	{
		get
		{
			return _colour;
		}
		set
		{
			_colour = value;
			SetColorGraphic(value);
		}
	}

	public Special special
	{
		get
		{
			return _special;
		}
		set
		{
			_special = value;
			SetSpecialGraphic(value);
		}
	}
	#endregion

	#region PUBLIC EVENTS
	public delegate void TriggerListener(ClockElement element);
	public static event TriggerListener OnTrigger;
	#endregion

	#region PUBLIC METHODS

	public void SetShapeGraphic (Shape shape)
	{
		if (_symbol != SymbolType.Shapes) { Debug.Log("please set symbol to shape"); return; }
		symbolGraphic.texture = GetGraphic (Utilities.GetEnumName<Shape>(shape));
	}

	public void SetColorGraphic(Colour colour)
	{
		if (_symbol != SymbolType.Colour) { return; }
	}

	public void SetSpecialGraphic(Special special)
	{
		if (_symbol != SymbolType.Special) { return; }
	}

	#endregion

}
