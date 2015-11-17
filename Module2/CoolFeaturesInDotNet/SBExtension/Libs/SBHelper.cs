namespace SBExtension.Libs
{
    using System.Text;
    
    public static class SBHelper
    {
        public static StringBuilder Substring(this StringBuilder text, int index, int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = index; i < length + index; i++)
            {
                if (i < text.Length)
                {
                    sb.Append(text[i]);
                }
                else
                {
                    break;
                }
            }

            return sb;
        }
    }
}
