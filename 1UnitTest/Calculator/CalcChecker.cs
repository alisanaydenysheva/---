using System;

namespace ClassCalculator
{
    public class CalcChecker
    {
        public static double ValidateCalculator(double nums, double num1, string operation)
        {
            if (operation == "+" || operation == "сложение")
            {
                return (nums + num1);
            }
            if (operation == "-" || operation == "вычитание")
            {
                return (nums - num1);

            }
            if (operation == "*" || operation == "умножение")
            {
                return (nums * num1);

            }
            if (operation == "/" || operation == "деление")
            {
                if (num1 == 0)
                {
                    Console.WriteLine("Ошибка!На 0 делить нельзя!");
                }
                else
                {
                    return (nums / num1);
                }
            }
            if (operation == "sqrt" || operation == "корень")
            {
                if (nums > 0)
                {
                    double sqrt = Math.Sqrt(nums);

                    return (sqrt);
                }
                else
                {
                    Console.WriteLine("Ошибка! Нельзя искать квадратный корень отрицательного числа");
                }
            }
            if (operation == "pow" || operation == "степень")
            {
                double pow = Math.Pow(nums, num1);
                return (pow);
            }
            if (operation == "fact" || operation == "факториал")
            {
                for (int i = 1; nums >= i; ++i)
                {
                    num1 = num1 * i;
                }
                return (num1);
            }
            return 0;
        }

        static void Main()
        {
            Console.WriteLine("Какую функцию калькулятора вы хотите сделать? Можно выбрать: сложение, вычитание, умножение, деление, квадратный корень из числа (корень), возведение в степень (степень), факториал");
            string operation = Console.ReadLine();
            Console.WriteLine("Введите 1 число");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите 2 число");
            double b = double.Parse(Console.ReadLine());
            double result = ValidateCalculator(a, b, operation);
            Console.WriteLine("Результат " + result);
        }
    }
}
