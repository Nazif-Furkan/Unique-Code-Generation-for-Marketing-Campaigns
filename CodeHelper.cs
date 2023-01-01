using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CodeHelper
{
    const string CHARSET = "ACDEFGHKLMNPRTXYZ234579";
    static int charLength = CHARSET.Length;
    static List<int[]> createdCodes = new List<int[]>();
    public static List<string> GenerateCodes()
    {
        createdCodes.Clear();
        var retval = new List<string>();

        for (int i = 0; i < 1000; i++)
        {
            var code = new int[8];

            var rand = new Random();

            for (int j = 0; j < 4; j++)
            {
                code[j] = rand.Next(0, CHARSET.Length);
            }

            var createdCode = caclulateLastFourCode(code);

            if (createdCodes.Any(i => i.SequenceEqual(createdCode)))
            {
                i--;
                continue;
            }

            createdCodes.Add(createdCode);
            retval.Add(convertCodeToString(createdCode));
        }


        return retval;
    }

    static string convertCodeToString(int[] array)
    {
        var sb = new StringBuilder();
        foreach (var item in array)
        {
            sb.Append(CHARSET[item]);
        }

        return sb.ToString();
    }

    public static bool CheckCode(string code)
    {
        var charLength = CHARSET.Length;

        int[] charValues = code.Select(c => (int)CHARSET.IndexOf(c)).ToArray();

        var checkChars = caclulateLastFourCode(charValues);

        for (int i = 0; i < 8; i++)
        {
            if (charValues[i] != checkChars[i])
                return false;
        }

        return true;
    }

    public static int[] caclulateLastFourCode(int[] code)
    {
        var retcode = new int[8];

        retcode[0] = code[0];
        retcode[1] = code[1];
        retcode[2] = code[2];
        retcode[3] = code[3];

        retcode[4] = ((int)(((int)Math.Pow((retcode[0] << 1), 2)) * ((int)Math.Pow((retcode[1] << 2), 3)) + ((int)Math.Pow((retcode[2] << 4), 2)))) % charLength;
        retcode[5] = ((int)(((int)Math.Pow((retcode[1] << 1), 2)) * ((int)Math.Pow((retcode[2] << 2), 3)) + ((int)Math.Pow((retcode[3] << 4), 2)))) % charLength;
        retcode[6] = ((int)(((int)Math.Pow((retcode[2] << 1), 2)) * ((int)Math.Pow((retcode[3] << 2), 3)) + ((int)Math.Pow((retcode[5] << 4), 2)))) % charLength;
        retcode[7] = ((int)(((int)Math.Pow((retcode[6] << 1), 2)) * ((int)Math.Pow((retcode[5] << 2), 3)) + ((int)Math.Pow((retcode[3] << 3), 2)))) % charLength;

        return retcode;
    }
}

