class MyFunctions
{
    public static void AddToEnd<T>(ref T[] input, T value)
    {
        T[] origin = new T[input.Length + 1];
        for (int i = 0; i < input.Length; i++) origin[i] = input[i];
        origin[origin.Length - 1] = value;
        input = origin;
    }
}

