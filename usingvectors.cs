using Utility;

public class Class1
{
	public Class1()
	{
		var vector = new Vector(6, 4, 3.2);
		++vector.X;
		var vector2 = new Vector(2, 4, 8);
		Console.WriteLine(vector2.X);
		Console.WriteLine(vector.add(vector, vector2));
		// 7 * v2 - v1
		Console.WriteLine(vector.Add(vector.Scale(vector, -1), vector.Scale(vector2, 7)));
		Console.WriteLine(7 * vector2 - vector);
	}
}
