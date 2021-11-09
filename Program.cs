using System;
using System.Collections.Generic;
using System.Linq;

namespace HT_Lab4_26_30
{
    internal static class Program
    {
        private static void Main()
        {
            MakeArray(out var arr, out var n);
            MainMenu(arr, n);

            //     Console.WriteLine(MessageMainInputSize);
            //     ReadSize(out var n);
            //     var arr = ChooseMethodToFillArray(n);
            //     Console.WriteLine(MessageMainOutputArray);
            //     WriteArray(arr);
            //
            //     Menu();
            //
            //     if (arr.Length > 0)
            //     {
            //         var average = Average(arr);
            //         DeleteElemsGreaterThanNum(ref arr, average);
            //         Console.WriteLine(MessageMainOutputArrayAfterDel + average);
            //         WriteArray(arr);
            //         Menu();
            //     }
            //
            //     Console.WriteLine(MessageMainInputAddArray);
            //     ReadSize(out var k);
            //     var arrAdditional = ChooseMethodToFillArray(k);
            //     Console.WriteLine(MessageMainEndOfInputAddArray);
            //     Console.WriteLine(MessageMainOutputAddArray);
            //     WriteArray(arrAdditional);
            //     arr = ConcatArrays(arr, arrAdditional);
            //     Console.WriteLine(MessageMainArrayWithAdd);
            //     WriteArray(arr);
            //
            //     Menu();
            //
            //     if (arr.Length <= 0) return;
            //     SwapEvenWithOddIndex(ref arr);
            //     Console.WriteLine(MessageMainArrayAfterSwap);
            //     WriteArray(arr);
            //
            //     Menu();
            //
            //     var findElem = SearchFirstNegat(arr);
            //     Console.WriteLine(MessageMainSearchFirstNeg);
            //     if (findElem > 0)
            //     {
            //         Console.WriteLine(MessageMainDidntFind);
            //     }
            //     else
            //     {
            //         Console.WriteLine(MessageMainResultOfSearch + findElem);
            //         Console.WriteLine(MessageMainPosFindElem + _count);
            //         Console.WriteLine(MessageMainCountOfCompars + _count);
            //     }
            //
            //     Menu();
            //
            //     SortBySimpleInsert(ref arr);
            //     Console.WriteLine(MessageMainSortedArray);
            //     WriteArray(arr);
            //
            //     Menu();
            //
            //     var positOfElem = BinarySearch(arr, findElem);
            //     Console.WriteLine(MessageMainBinarySearch);
            //     if (positOfElem > 0)
            //     {
            //         Console.WriteLine(MessageMainPosFindElem + positOfElem);
            //         Console.WriteLine(MessageMainCountOfCompars + _count);
            //     }
            //     else
            //     {
            //         Console.WriteLine(MessageMainCantFind);
            //     }
            //
            //     Console.WriteLine(MessageMenuExit);
        }

        private static void MakeArray(out int[] arr, out uint n)
        {
            Console.WriteLine("Здравствуйте! Выберите, что нужно сделать (введите номер):" +
                              "\n1) Сформировать массив вручную" +
                              "\n2) Сформировать массив с помощью датчика случайных чисел" +
                              "\n3) Завершить исполнение программы");
            do
            {
                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Выбран ручной метод формирования массива");
                        ReadSize(out n);
                        arr = ReadArray(n);
                        return;
                    case "2":
                        Console.WriteLine("Выбран метод заполнения массива с помощью датчика случайных чисел");
                        ReadSize(out n);
                        arr = GenerateArray(n);
                        return;
                    case "3":
                        Console.WriteLine("Завершение программы...");
                        Environment.Exit(123);
                        break;
                }

                Console.WriteLine("Введен неизвестный символ, введите номер заново");
            } while (true);
        }

        private static void MainMenu(int[] arr, uint n)
        {
            do
            {
                Console.WriteLine("Выберите, что сделать (введите номер):" +
                                  "\n1) Сформировать массив вручную" +
                                  "\n2) Сформировать массив с помощью датчика случайных чисел" +
                                  "\n3) Вывести массив на экран" +
                                  "\n4) Удалить элементы больше среднего арифметического элементов массива" +
                                  "\n5) Добавить K элементов в конец массива вручную" +
                                  "\n6) Добавить K элементов в конец массива, сформированных с помощью " +
                                  "датчика случайных чисел" +
                                  "\n7) Поменять местами элементы с четными и нечетными номерами" +
                                  "\n8) Найти первый отрицательный элемент, подсчитать количество сравнений" +
                                  "\n9) Отсортировать массив методом «Простое включение»" +
                                  "\n10) Поиск методом «Бинарный поиск» найденного в 7 пункте отрицательного элемента," +
                                  " перед этим отсортировав массив, подсчет количества сравнений, " +
                                  "но после поиска вернуть массив в исходное состояние" +
                                  "\n11) Завершить исполнение программы");
                Console.Write("Ваш выбор: ");
                uint k;
                int[] arrAdd;
                int count;
                var firstNeg = 0;
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Выбран ручной метод формирования массива");
                        ReadSize(out n);
                        arr = ReadArray(n);
                        break;
                    case "2":
                        Console.WriteLine("Выбран метод заполнения массива с помощью датчика случайных чисел");
                        ReadSize(out n);
                        arr = GenerateArray(n);
                        break;
                    case "3":
                        Console.WriteLine("Выбран вывод массива");
                        WriteArray(arr);
                        break;
                    case "4":
                        Console.WriteLine(
                            "Выбрано удаление элементов, больших среднего арифметического элементов массива");
                        var average = Average(arr);
                        Console.WriteLine($"Среднее арифметическое = {average}");
                        DeleteElemsGreaterThanNum(ref arr, average);
                        break;
                    case "5":
                        Console.WriteLine("Выбрано добавить К элементов в конец массива вручную");
                        ReadSize(out k);
                        arrAdd = ReadArray(k);
                        Console.Write("Элементы: ");
                        WriteArray(arrAdd);
                        arr = ConcatArrays(arr, arrAdd);
                        break;
                    case "6":
                        Console.WriteLine("Выбрано добавить K элементов в конец массива, сформированных с помощью " +
                                          "датчика случайных чисел");
                        ReadSize(out k);
                        arrAdd = GenerateArray(k);
                        Console.Write("Элементы: ");
                        WriteArray(arrAdd);
                        arr = ConcatArrays(arr, arrAdd);
                        break;
                    case "7":
                        Console.WriteLine("Выбрано поменять местами элементы с четными и нечетными номерами");
                        SwapEvenWithOddIndex(ref arr);
                        break;
                    case "8":
                        Console.WriteLine(
                            "Выбрано найти первый отрицательный элемент, подсчитать количество сравнений");
                        firstNeg = SearchFirstNegat(arr, out count);
                        Console.WriteLine($"Первый отрицательный = {firstNeg}\n" +
                                          $"Позиция найденного элемента = {count}\n" +
                                          $"Количество сравнений = {count}");
                        break;
                    case "9":
                        Console.WriteLine("Выбрано отсортировать массив методом «Простое включение»");
                        SortBySimpleInsert(ref arr);
                        break;
                    case "10":
                        Console.WriteLine("Выбран поиск методом «Бинарный поиск» найденного в 7 пункте" +
                                          " отрицательного элемента," +
                                          " перед этим отсортировать массив, подсчитать количества сравнений, " +
                                          "но после поиска вернуть массив в исходное состояние");
                        var arrTmp = arr;
                        SortBySimpleInsert(ref arr);
                        var pos = BinarySearch(arr, firstNeg, out count);
                        Console.WriteLine($"Позиция найденного элемента = {pos}\n" +
                                          $"Количество сравнений = {count}");
                        arr = arrTmp;
                        break;

                    case "11":
                        Console.WriteLine("Завершение программы...");
                        return;
                }

                Console.WriteLine("Введен неизвестный символ, введите номер заново");
            } while (true);
        }

        #region Функции

        #region Работа с последовательностями

        /// <summary>
        ///     Вычисляет среднее арифметическое последовательности
        ///     <see cref="T:System.Int32" /> значений.
        /// </summary>
        private static double Average(IReadOnlyCollection<int> arrayInts)
        {
            var sum = arrayInts.Aggregate(0.0,
                (current, element) => current + element);
            return sum / arrayInts.Count;
        }

        /// <summary>
        ///     Поиск указанного элемента в последовательности
        ///     <see cref="T:System.Int32" /> значений
        ///     методом «Бинарный поиск», и подсчет количества сравнений.
        /// </summary>
        private static int BinarySearch(IReadOnlyList<int> arrayInts, int findElem, out int count)
        {
            count = 0;
            var leftIndex = 0;
            var rightIndex = arrayInts.Count - 1;
            do
            {
                var pivotIndex = (leftIndex + rightIndex) / 2;
                if (arrayInts[pivotIndex] < findElem)
                    leftIndex = pivotIndex + 1;
                else
                    rightIndex = pivotIndex;

                count++;
            } while (leftIndex != rightIndex);

            count++;
            if (arrayInts[leftIndex] == findElem)
                return leftIndex + 1;

            return -1;
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
                    Console.Write(MessageInputElem + (i + 1) + ": ");
                    isConvert = int.TryParse(
                        Console.ReadLine(), out arrayInts[i]);
                    if (!isConvert)
                        Console.WriteLine(MessageFailInputElem + (i + 1));
                } while (!isConvert);
            }

            return arrayInts;
        }

        /// <summary>
        ///     Сортировка массива <see cref="T:System.Int32" /> значений
        ///     методом «Простое включение».
        /// </summary>
        private static void SortBySimpleInsert(ref int[] arrayInts)
        {
            for (var i = 1; i < arrayInts.Length; i++)
            {
                var tmp = arrayInts[i];
                var j = i - 1;
                for (; j >= 0 && arrayInts[j] > tmp; j--)
                    arrayInts[j + 1] = arrayInts[j];
                arrayInts[j + 1] = tmp;
            }
        }

        /// <summary>
        ///     Поиск первого отрицательного элемента
        ///     в массиве <see cref="T:System.Int32" /> значений
        ///     и подсчет количества сравнений.
        /// </summary>
        private static int SearchFirstNegat(IEnumerable<int> arrayInts, out int count)
        {
            count = 0;
            foreach (var element in arrayInts)
            {
                count++;
                if (element < 0)
                    return element;
            }

            return 1;
        }

        /// <summary>
        ///     Перестановка элементов с четными и нечетными индексами
        ///     в массиве <see cref="T:System.Int32" /> значений .
        /// </summary>
        private static void SwapEvenWithOddIndex(ref int[] arrayInts)
        {
            for (var i = 1; i < arrayInts.Length; i += 2)
            {
                var tmp = arrayInts[i];
                arrayInts[i] = arrayInts[i - 1];
                arrayInts[i - 1] = tmp;
            }
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

        #endregion

        #region Пользоваетльский интерфейс

        #endregion

        #region Ввод размера последовательности

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

        #endregion

        #endregion

        #region Литеральные константы


        private const string MessageGenerate = "Выбран метод заполнения " +
                                               "случайными числами";

        private const string MessageInputConsole = "Выбран ручной метод ввода " +
                                                   "целочисленных элементов";

        private const string MessageInputCount = "Введите количество элементов: ";
        private const string MessageSuccessInputCount = "Успешно введено количество элементов!\n";

        private const string MessageFailInputCount = "Ошибка! Введено нецелое число, " +
                                                     "или целое, но меньше 0, или строка, " +
                                                     "или слишком большое целое!" +
                                                     "\nВведите количество элементов заново: ";

        private const string MessageInputElem = "Введите элемент №";

        private const string MessageFailInputElem = "Ошибка! Введен не как целое число "
                                                    + "элемент №";

        private const string MessageWriteEmptyArray = "(пусто)";

        #endregion
    }
}