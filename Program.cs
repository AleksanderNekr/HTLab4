using System;
using System.Collections.Generic;

namespace HT_Lab4_26_30
{
    internal static class Program
    {
        /// <summary>
        ///     Ввод размера последовательности чисел.
        /// </summary>
        private static void ReadSize(out uint sizeU)
        {
            const string messageInput = "Введите количество элементов: ";
            const string messageSuccess = "Успешно введено количество элементов!\n";
            const string messageFail = "Ошибка! Введено нецелое число, " +
                                       "или целое, но меньше 0, или строка!" +
                                       "\nВведите количество элементов заново: ";
            Console.Write(messageInput);
            bool isCorrect;
            do
            {
                isCorrect = uint.TryParse(Console.ReadLine(), out sizeU);

                Console.Write(isCorrect
                    ? messageSuccess
                    : messageFail);
            } while (!isCorrect);
        }

        /// <summary>
        ///     Консольный ввод массива
        ///     <see cref="T:System.Double" />
        ///     значений размером sizeArray.
        /// </summary>
        private static double[] ReadArray(uint sizeArray)
        {
            var arrayDoubles = new double[sizeArray];

            const string messageInput = "Выбран ручной метод ввода элементов";
            Console.WriteLine(messageInput);
            for (var i = 0; i < sizeArray; i++)
            {
                var messageInputElem = $"Введите {i + 1}-й элемент массива: ";
                var messageFailInputElem = $"Ошибка! {i + 1}-й элемент " +
                                           "введен не как число!";
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

            return arrayDoubles;
        }

        /// <summary>
        ///     Генерация массива
        ///     <see cref="T:System.Double" />
        ///     значений размером sizeArray
        ///     с помощью датчика случайных чисел.
        /// </summary>
        private static double[] GenerateArray(uint sizeArray)
        {
            var arrayDoubles = new double[sizeArray];

            const string messageGenerate = "Выбран метод заполнения " +
                                           "случайными числами";
            Console.WriteLine(messageGenerate);
            var generator = new Random();
            for (var i = 0; i < sizeArray; i++)
                arrayDoubles[i] = Math.Round(generator.NextDouble(), generator.Next(3))
                                  + generator.Next(-100, 101);

            return arrayDoubles;
        }

        /// <summary>
        ///     Вывод последовательности
        ///     <see cref="T:System.Double" />
        ///     значений в консоль с пробельным разделителем элементов.
        /// </summary>
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
            return sum / arrayDoubles.Count;
        }

        /// <summary>
        ///     Удаляет из массива
        ///     <see cref="T:System.Double" />
        ///     значений элемент с индексом indexOfElement.
        /// </summary>
        private static double[] DeleteElement(this IList<double> arrayDoubles, int indexOfElement)
        {
            var tmp = arrayDoubles[indexOfElement];
            for (var j = indexOfElement; j < arrayDoubles.Count - 1; j++)
                arrayDoubles[j] = arrayDoubles[j + 1];
            arrayDoubles[arrayDoubles.Count - 1] = tmp;

            var finalArr = new double[arrayDoubles.Count - 1];
            for (var i = 0; i < finalArr.Length; i++)
                finalArr[i] = arrayDoubles[i];

            return finalArr;
        }

        /// <summary>
        ///     Удаляет из массива
        ///     <see cref="T:System.Double" /> значений
        ///     элементы больше указанного.
        /// </summary>
        private static void DeleteElemsGreaterThanNum(ref double[] arrayDoubles, double num)
        {
            for (var i = 0; i < arrayDoubles.Length;)
                if (arrayDoubles[i] > num)
                    arrayDoubles = arrayDoubles.DeleteElement(i);
                else
                    i++;
        }

        /// <summary>
        ///     Предоставляет пользователю выбор ручного ввода countElem элементов или их генерации
        ///     с помощью датчика случайных чисел.
        /// </summary>
        private static double[] ChooseMethodToFillArray(uint countElem)
        {
            const string messageChoice = "Вводить элементы с клавиатуры (+) " +
                                         "или заполнить случайными числами (-)? Ваш выбор (+/-): ";
            const string messageIncorrectInput = "Вы ввели неизвестный символ, введите заново";
            do
            {
                Console.Write(messageChoice);
                var inputSwitcher = Console.ReadLine();
                switch (inputSwitcher)
                {
                    case "+":
                        return ReadArray(countElem);
                    case "-":
                        return GenerateArray(countElem);
                }

                Console.WriteLine(messageIncorrectInput);
            } while (true);
        }

        /// <summary>
        ///     Соединяет 2 последовательности
        ///     <see cref="T:System.Double" />
        ///     значений в одну конечную.
        /// </summary>
        private static double[] ConcatArrays(IReadOnlyList<double> arrayDoubles1,
            IReadOnlyList<double> arrayDoubles2)
        {
            var arrResult = new double[arrayDoubles1.Count + arrayDoubles2.Count];
            for (var i = 0; i < arrResult.Length; i++)
                arrResult[i] = i < arrayDoubles1.Count
                    ? arrayDoubles1[i]
                    : arrayDoubles2[i - arrayDoubles1.Count];
            return arrResult;
        }

        private static void Main()
        {
            Console.WriteLine("Ввод массива чисел");
            ReadSize(out var n);
            var arr = ChooseMethodToFillArray(n);
            Console.WriteLine("Массив:");
            WriteArray(arr);

            var average = Average(arr);
            DeleteElemsGreaterThanNum(ref arr, average);
            Console.WriteLine("Массив после удаления из него элементов, больших " +
                              $"среднего арифметического элементов массива ({average}):");
            WriteArray(arr);

            Console.WriteLine("Ввод дополнительных элементов к массиву");
            ReadSize(out var k);
            var arrAdditional = ChooseMethodToFillArray(k);
            Console.WriteLine("Конец ввода дополнительных элементов");
            Console.WriteLine("Дополнительные элементы:");
            WriteArray(arrAdditional);

            arr = ConcatArrays(arr, arrAdditional);
            Console.WriteLine("Массив после добавления в него дополнительных элементов:");
            WriteArray(arr);

            // TODO: удалять из пустого нельзя, менять что-то тоже, можно дополнять
            // TODO: Выдать сообщение пользователю, о том что массив пустой и вывести меню,
            // TODO: пусть дальше пользователь решает, что делать :)
        }
    }
}