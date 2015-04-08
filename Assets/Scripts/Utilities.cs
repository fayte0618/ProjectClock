using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class Utilities
{
	#region HELPER METHODS
	public static string[] GetEnumContent<T> () where T : struct, IComparable
	{
		return System.Enum.GetNames (typeof(T));
	}

	public static string GetEnumName<T> (T value) where T : struct, IComparable
	{
		return System.Enum.GetName (typeof (T), value);
	}
	#endregion
}
