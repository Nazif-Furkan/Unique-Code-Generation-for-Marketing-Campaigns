
var codes = CodeHelper.GenerateCodes();

for (int i = 1; i <= codes.Count; i++)
{
    string? code = codes[i - 1];
    Console.Write(i + "->\t");
    Console.Write(code);

    Console.WriteLine("---->CheckCodeResult: " + CodeHelper.CheckCode(code));
}

Console.Read();