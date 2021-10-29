using System;
using System.Collections.Generic;

namespace HT_Lab4_26_30
{
    internal static class Program
    {
        private static void ReadSize(out uint sizeU)
        {
            const string messageInput = "Введите количество элементов: ";
            const string messageSuccess = "Успешно введено количество элементов!";
            const string messageFail = "Ошибка! Введено нецелое число, " +
                                       "или целое, но меньше 0, или строка!";
            Console.Write(messageInput);
            bool isCorrect;
            do
            {
                isCorrect = uint.TryParse(Console.ReadLine(), out sizeU);

                Console.WriteLine(isCorrect
                    ? messageSuccess
                    : messageFail);
            } while (!isCorrect);
        }

        private static void ReadArray(double[] arrayDoubles)
        {
            const string messageInput = "Выбран ручной метод ввода элементов";
            Console.WriteLine(messageInput);
            for (var i = 0; i < arrayDoubles.Length; i++)
            {
                var messageInputElem = $"Введите {i + 1}-й элемент массива: ";
                var messageFailInputElem = $"Ошибка! {i + 1}-й элемент " +
                                           "введен как не число!";
                bool isConvert;
                do
                {
                    Console.Write(messageInputElem);
                    isConvert = double.TryParse(
                        Console.ReadLine(), out arrayDoubles[i]);
                    if (!isConvert)
                        Console.WriteLine(messageFailInputElem);
                } while (!isConvert);
            }
        }

        private static void GenerateArray(IList<double> arrayDoubles)
        {
            const string messageGenerate = "Выбран метод заполнения " +
                                           "случайными числами";
            Console.WriteLine(messageGenerate);
            var generator = new Random();
            for (var i = 0; i < arrayDoubles.Count; i++)
                arrayDoubles[i] = Math.Round(generator.NextDouble(), generator.Next(3))
                         + generator.Next(-100, 101);
        }

        private static void WriteArray(IReadOnlyCollection<double> arrayDoubles)
        {
            if (arrayDoubles.Count > 0)
            {
                foreach (var variable in arrayDoubles)
                    Console.Write($"{variable} ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("<пусто>");
            }
        }

        /// <summary>
        ///     Вычисляет среднее арифметическое последовательности
        ///     <see cref="T:System.Double" /> значений.
        /// </summary>
        private static double Average(IReadOnlyCollection<double> arrayDoubles)
        {
            double sum = 0;
            foreach (var element in arrayDoubles)
                sum += element;
            return Math.Round(sum / arrayDoubles.Count, 14);
        }

        /// <summary>
        ///     Удаляет из последовательности
        ///     <see cref="T:System.Double" />
        ///     значений элемент с указанным индексом.
        /// </summary>
        private static double[] DeleteElement(this IList<double> arrayDoubles, int indexOfElement)
        {
            var tmp = arrayDoubles[indexOfElement];
            for (var j = indexOfElement; j < arrayDoubles.Count - 1; j++)
                arrayDoubles[j] = arrayDoubles[j + 1];
            arrayDoubles[arrayDoubles.Count - 1] = tmp;
            var newArr = new double[arrayDoubles.Count - 1];
            for (var i = 0; i < newArr.Length; i++)
                newArr[i] = arrayDoubles[i];

            return newArr;
        }

        private static double[] DeleteElemsGreaterThanNum(this double[] arrayDoubles, double num)
        {
            for (var i = 0; i < arrayDoubles.Length;)
                if (arrayDoubles[i] > num)
                    arrayDoubles = arrayDoubles.DeleteElement(i);
                else
                    i++;

            return arrayDoubles;
        }

        private static void ChooseMethodToFillArray(double[] arrayDoubles)
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
                        ReadArray(arrayDoubles);
                        break;
                    case "-":
                        GenerateArray(arrayDoubles);
                        break;
                    default:
                        isCorrect = false;
                        break;
                }

                if (!isCorrect)
                    Console.WriteLine(messageIncorrectInput);
            } while (!isCorrect);
        }

        private static double[] ConcatArrays(IReadOnlyList<double> arrayDoubles, IReadOnlyList<double> arrayAdditionalDoubles)
        {
            var concatArr = new double[arrayDoubles.Count + arrayAdditionalDoubles.Count];
            for (var i = 0; i < concatArr.Length; i++)
                concatArr[i] = i < arrayDoubles.Count
                    ? arrayDoubles[i]
                    : arrayAdditionalDoubles[i - arrayDoubles.Count];
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