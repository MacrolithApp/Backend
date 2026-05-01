namespace Shared.Domain.Methods
{
    public static class PrimeNumberGenerator
    {
        private static readonly Random _random = new();

        internal static int GetRandomPrime(int min = 2, int max = 10000)
        {
            if (min < 2) min = 2;

            while (true)
            {
                int candidate = _random.Next(min, max);

                if (IsPrime(candidate))
                    return candidate;
            }
        }

        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int limit = (int)Math.Sqrt(number);
            for (int i = 3; i <= limit; i += 2)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}