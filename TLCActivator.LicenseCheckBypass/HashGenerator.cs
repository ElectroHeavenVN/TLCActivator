using System.Security.Cryptography;
using System.Text;

internal static class HashGenerator
{
    public static string GenerateMD5(string input)
    {
        string text;
        using (MD5 md = MD5.Create())
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            byte[] array = md.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("X2"));
            }
            text = stringBuilder.ToString();
        }
        return text;
    }
}