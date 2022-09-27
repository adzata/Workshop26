namespace Workshop26
{

    public class Calculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;

            List<string> delimiter = new List<string>() { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                var index = numbers.IndexOf(']');
                delimiter.Add(numbers.Substring(3, index - 3));
                numbers = numbers.Remove(0, index+1);
            }
            //"//[*][%]\n1*2%3"
            var numberArrays = numbers.Split(delimiter.ToArray(), StringSplitOptions.None);

            if (numberArrays.Where(x => !String.IsNullOrEmpty(x) && Int32.Parse(x) < 0).Count() > 0)
                throw new ArgumentException("negatives not allowed");

            var result = numberArrays.Where(x => !String.IsNullOrEmpty(x) && Int32.Parse(x) < 1000).Sum(x => Int32.Parse(x));
            return result;
        }


    }

}