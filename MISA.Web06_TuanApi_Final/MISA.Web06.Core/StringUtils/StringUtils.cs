namespace MISA.SME.Core.Helpers
{
    public class StringUtils
    {
        /// <summary>
        /// Tìm kiếm chuỗi số hợp lệ cuối cùng trong chuỗi đầu vào
        /// </summary>
        /// <param name="numberStr"></param>
        /// <returns> Chuỗi số hợp lệ. Eg: 12abc123 => 123</returns>
        public static string? findLastValidNum(string numberStr)
        {
            var lastNumber = "";
            for (int i = numberStr.Length - 1; i >= 0; i--)
            {
                if (Char.IsNumber(numberStr[i]))
                {
                    lastNumber = numberStr[i] + lastNumber;
                }
                else if (lastNumber.Length != 0)
                {
                    break;
                }
            }
            if (lastNumber == "")
            {
                return null;
            }
            return lastNumber;
        }

        /// <summary>
        /// Thay thế lần xuất hiện cuối cùng của chuỗi muốn thay thế
        /// </summary>
        /// <param name="Source">chuỗi đầu vào</param>
        /// <param name="Find">chuỗi muốn thay thế</param>
        /// <param name="Replace">chuỗi thay thế</param>
        /// <returns>chuỗi đầu vào sau khi đã được thay thế</returns>
        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }
    }
}