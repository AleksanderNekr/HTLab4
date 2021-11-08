using System;
using System.Collections.Generic;

namespace HT_Lab4_26_30
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(MessageMainInputSize);
            ReadSize(out var n);
            var arr = ChooseMethodToFillArray(n);
            Console.WriteLine(MessageMainOutputArray);
            WriteArray(arr);

            if (arr.Length > 0)
            {
                var average = Average(arr);
                DeleteElemsGreaterThanNum(ref arr, average);
                Console.WriteLine(MessageMainOutputArrayAfterDel + average);
                WriteArray(arr);
            }

            Console.WriteLine(MessageMainInputAddArray);
            ReadSize(out var k);
            var arrAdditional = ChooseMethodToFillArray(k);
            Console.WriteLine(MessageMainEndOfInputAddArray);
            Console.WriteLine(MessageMainOutputAddArray);
            WriteArray(arrAdditional);

            arr = ConcatArrays(arr, arrAdditional);
            Console.WriteLine(MessageMainArrayWithAdd);
            WriteArray(arr);

            // TODO: удалять из пустого нельзя, менять что-то тоже, можно дополнять
            // TODO: Выдать сообщение пользователю, о том что массив пустой и вывести меню,
            // TODO: пусть дальше пользователь решает, что делать :)
        }

        #region Функции

        /// <summary>
        ///     Ввод размера последовательности чисел.
        /// </summary>
        private static void ReadSize(out uint sizeU)
        {
            Console.Write(MessageInputCount);
            bool isCorrect;
            do
            {
                isCorrect = uint.TryParse(Console.ReadLine(), out sizeU);

                Console.Write(isCorrect
                    ? MessageSuccessInputCount
                    : MessageFailInputCount);
            } while (!isCorrect);
        }

        /// <summary>
        ///     Консольный ввод массива
        ///     <see cref="T:System.Int32" />
        ///     значений размером sizeArray.
        /// </summary>
        private static int[] ReadArray(uint sizeArray)
        {
            var arrayInts = new int[sizeArray];

            Console.WriteLine(MessageInputConsole);
            for (var i = 0; i < sizeArray; i++)
            {
                bool isConvert;
                do
                {
                    Console.Write(MessageInputElem + i + ": ");
                    isConvert = int.TryParse(
                        Console.ReadLine(), out arrayInts[i]);
                    if (!isConvert)
                        Console.WriteLine(MessageFailInputElem + i);
                } while (!isConvert);
            }

            return arrayInts;
        }

        /// <summary>
        ///     Генерация массива
        ///     <see cref="T:System.Int32" />
        ///     значений размером sizeArray
        ///     с помощью датчика случайных чисел.
        /// </summary>
        private static int[] GenerateArray(uint sizeArray)
        {
            var arrayInts = new int[sizeArray];

            Console.WriteLine(MessageGenerate);
            var generator = new Random();
            for (var i = 0; i < sizeArray; i++)
                arrayInts[i] = generator.Next(-100, 101);

            return arrayInts;
        }

        /// <summary>
        ///     Вывод последовательности
        ///     <see cref="T:System.Int32" />
        ///     значений в консоль с пробельным разделителем элементов.
        /// </summary>
        private static void WriteArray(IReadOnlyCollection<int> arrayInts)
        {
            if (arrayInts.Count > 0)
            {
                foreach (var variable in arrayInts)
                    Console.Write($"{variable} ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(MessageWriteEmptyArray);
            }
        }

        /// <summary>
        ///     Вычисляет среднее арифметическое последовательности
        ///     <see cref="T:System.Int32" /> значений.
        /// </summary>
        private static double Average(IReadOnlyCollection<int> arrayInts)
        {
            var sum = 0.0;
            foreach (var element in arrayInts)
                sum += element;
            return sum / arrayInts.Count;
        }

        /// <summary>
        ///     Удаляет из массива
        ///     <see cref="T:System.Int32" />
        ///     значений элемент с индексом indexOfElement.
        /// </summary>
        private static int[] DeleteElement(this IList<int> arrayInts, int indexOfElement)
        {
            var tmp = arrayInts[indexOfElement];
            for (var j = indexOfElement; j < arrayInts.Count - 1; j++)
                arrayInts[j] = arrayInts[j + 1];
            arrayInts[arrayInts.Count - 1] = tmp;

            var finalArr = new int[arrayInts.Count - 1];
            for (var i = 0; i < finalArr.Length; i++)
                finalArr[i] = arrayInts[i];

            return finalArr;
        }

        /// <summary>
        ///     Удаляет из массива
        ///     <see cref="T:System.Int32" /> значений
        ///     элементы больше указанного.
        /// </summary>
        private static void DeleteElemsGreaterThanNum(ref int[] arrayInts, double num)
        {
            for (var i = 0; i < arrayInts.Length;)
                if (arrayInts[i] > num)
                    arrayInts = arrayInts.DeleteElement(i);
                else
                    i++;
        }

        /// <summary>
        ///     Предоставляет пользователю выбор ручного ввода countElem элементов или их генерации
        ///     с помощью датчика случайных чисел.
        /// </summary>
        private static int[] ChooseMethodToFillArray(uint countElem)
        {
            if (countElem == 0)
                return new int[] { };
            do
            {
                Console.Write(MessageChoice);
                var inputSwitcher = Console.ReadLine();
                switch (inputSwitcher)
                {
                    case "+":
                        return ReadArray(countElem);
                    case "-":
                        return GenerateArray(countElem);
                }

                Console.WriteLine(MessageChoiceIncorrectInput);
            } while (true);
        }

        /// <summary>
        ///     Соединяет 2 последовательности
        ///     <see cref="T:System.Int32" />
        ///     значений в одну конечную.
        /// </summary>
        private static int[] ConcatArrays(IReadOnlyList<int> arrayInts1,
            IReadOnlyList<int> arrayInts2)
        {
            var arrResult = new int[arrayInts1.Count + arrayInts2.Count];
            for (var i = 0; i < arrResult.Length; i++)
                arrResult[i] = i < arrayInts1.Count
                    ? arrayInts1[i]
                    : arrayInts2[i - arrayInts1.Count];
            return arrResult;
        }

        #endregion

        #region Литеральные константы

        private const string MessageGenerate = "Выбран метод заполнения " +
                                               "случайными числами";

        private const string MessageInputConsole = "Выбран ручной метод ввода " +
                                                   "целочисленных элементов";

        private const string MessageInputCount = "Введите количество элементов: ";
        private const string MessageSuccessInputCount = "Успешно введено количество элементов!\n";

        private const string MessageFailInputCount = "Ошибка! Введено нецелое число, " +
                                                     "или целое, но меньше 0, или строка!" +
                                                     "\nВведите количество элементов заново: ";

        private const string MessageInputElem = "Введите элемент массива №";

        private const string MessageFailInputElem = "Ошибка! Введен не как целое число "
                                                    + "элемент №";

        private const string MessageWriteEmptyArray = "(пусто)";

        private const string MessageChoice = "Вводить элементы с клавиатуры (+) " +
                                             "или заполнить случайными числами (-)? Ваш выбор (+/-): ";

        private const string MessageChoiceIncorrectInput = "Вы ввели неизвестный символ, введите заново";

        private const string MessageMainInputSize = "Ввод массива чисел";

        private const string MessageMainArrayWithAdd = "Массив после добавления в него дополнительных элементов:";

        private const string MessageMainOutputAddArray = "Дополнительные элементы:";

        private const string MessageMainEndOfInputAddArray = "Конец ввода дополнительных элементов";

        private const string MessageMainInputAddArray = "Ввод дополнительных элементов к массиву";

        private const string MessageMainOutputArrayAfterDel = "Массив после удаления из него элементов, больших " +
                                                              "среднего арифметического элементов массива = ";

        private const string MessageMainOutputArray = "Массив:";

        #endregion
    }
}