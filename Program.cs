using System;
using System.Collections.Generic;

namespace HT_Lab4_26_30
{
    internal static class Program
    {
        private static void ReadSize(out uint n)
        {
            const string messageInput = "Введите количество элементов: ";
            const string messageSuccess = "Успешно введено количество элементов!";
            const string messageFail = "Ошибка! Введено нецелое число, " +
                                       "или целое, но меньше 0, или строка!";
            Console.Write(messageInput);
            bool isCorrect;
            do
            {
                isCorrect = uint.TryParse(Console.ReadLine(), out n);

                Console.WriteLine(isCorrect
                    ? messageSuccess
                    : messageFail);
            } while (!isCorrect);
        }

        private static void ReadArray(double[] arr)
        {
            const string messageInput = "Выбран ручной метод ввода элементов";
            Console.WriteLine(messageInput);
            for (var i = 0; i < arr.Length; i++)
            {
                var messageInputElem = $"Введите {i + 1}-й элемент массива: ";
                var messageFailInputElem = $"Ошибка! {i + 1}-й элемент " +
                                           "введен как не число!";
                bool isConvert;
                do
                {
                    Console.Write(messageInputElem);
                    isConvert = double.TryParse(
                        Console.ReadLine(), out arr[i]);
                    if (!isConvert)
                        Console.WriteLine(messageFailInputElem);
                } while (!isConvert);
            }
        }

        private static void GenerateArray(IList<double> arr)
        {
            const string messageGenerate = "Выбран метод заполнения " +
                                           "случайными числами";
            Console.WriteLine(messageGenerate);
            var generator = new Random();
            for (var i = 0; i < arr.Count; i++)
                arr[i] = Math.Round(generator.NextDouble(), generator.Next(3))
                         + generator.Next(-100, 101);
        }

        private static void WriteArray(IEnumerable<double> arr)
        {
            foreach (var variable in arr)
                Console.Write($"{variable} ");
            Console.WriteLine();
        }

        private static double Average(IReadOnlyCollection<double> arr)
        {
            double sum = 0;
            foreach (var element in arr)
                sum += element;
            return Math.Round(sum / arr.Count, 10);
        }

        private static double[] DeleteElement(this IList<double> arr, int indexOfElement)
        {
            var tmp = arr[indexOfElement];
            for (var j = indexOfElement; j < arr.Count - 1; j++)
                arr[j] = arr[j + 1];
            arr[arr.Count - 1] = tmp;
            var newArr = new double[arr.Count - 1];
            for (var i = 0; i < newArr.Length; i++)
                newArr[i] = arr[i];

            return newArr;
        }

        private static double[] DeleteElemsGreaterThanNum(this double[] arr, double num)
        {
            for (var i = 0; i < arr.Length;)
                if (arr[i] > num)
                    arr = arr.DeleteElement(i);
                else
                    i++;

            return arr;
        }

        private static void ChooseMethodToFillArray(double[] arr)
        {
            const string messageChoice = "Вводить элементы с клавиатуры (+) " +
                                         "или заполнить случайными числами (-)? Ваш выбор (+/-): ";
            const string messageIncorrectInput = "Вы ввели неизвестный символ, введите заново";
            bool isCorrect;
            do
            {
                isCorrect = true;
                Console.Write(messageChoice);
                var inputSwitcher = Console.ReadLine();
                switch (inputSwitcher)
                {
                    case "+":
                        ReadArray(arr);
                        break;
                    case "-":
                        GenerateArray(arr);
                        break;
                    default:
                        isCorrect = false;
                        break;
                }

                if (!isCorrect)
                    Console.WriteLine(messageIncorrectInput);
            } while (!isCorrect);
        }

        private static double[] ConcatArrays(IReadOnlyList<double> arr, IReadOnlyList<double> arrAdditional)
        {
            var concatArr = new double[arr.Count + arrAdditional.Count];
            for (var i = 0; i < concatArr.Length; i++)
                concatArr[i] = i < arr.Count
                    ? arr[i]
                    : arrAdditional[i - arr.Count];
            return concatArr;
        }

        private static void Main()
        {
            Console.WriteLine("Ввод массива чисел");
            ReadSize(out var n);
            var arr = new double[n];

            ChooseMethodToFillArray(arr);

            Console.WriteLine("Массив:");
            WriteArray(arr);

            var average = Average(arr);
            arr = arr.DeleteElemsGreaterThanNum(average);
            Console.WriteLine("Массив после удаления из него элементов, больших " +
                              $"среднего арифметического элементов массива ({average}):");
            WriteArray(arr);

            Console.WriteLine("Ввод дополнительных элементов к массиву");
            ReadSize(out var k);
            var arrAdditional = new double[k];
            ChooseMethodToFillArray(arrAdditional);
            Console.WriteLine("Конец ввода дополнительных элементов");

            Console.WriteLine("Дополнительные элементы:");
            WriteArray(arrAdditional);
            arr = ConcatArrays(arr, arrAdditional);
            Console.WriteLine("Массив после добавления в него дополнительных элементов:");
            WriteArray(arr);
        }
    }
}