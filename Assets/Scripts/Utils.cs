using UnityEngine;
using System.Collections;

public class Utils
{
	public const int defaultDigitCount = 5;
	
	public static bool IsZeroVector(Vector3 v)
	{
		//:'-(
		return (Mathf.Abs(v.sqrMagnitude)<0.00001f);
	}
	
	public static DataType randomElem<DataType>(DataType[] arr)
	{
		return arr[Random.Range(0, arr.Length)];
	}
	
	public static string VecString(Vector3 v, int numDigits = defaultDigitCount)
	{
		return "("
				+ FloatString(v.x, numDigits) + ", "
				+ FloatString(v.y, numDigits) + ", "
				+ FloatString(v.z, numDigits)
				+")";
	}
	
	public static string FloatString(float f, int numDigits = defaultDigitCount)
	{
		string ret = f.ToString("F"+numDigits);
		if(f>=0f) ret = "+" + ret;
		return ret;
	}
}
