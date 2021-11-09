using System;
using System.Collections.Generic;
using System.Linq;

namespace HT_Lab4_26_30
{
    internal static class Program
    {
        private static void Main()
        {
            ShowMainMenu();
            Console.WriteLine(MessageMainInputSize);
            ReadSize(out var n);
            var arr = ChooseMethodToFillArray(n);
            Console.WriteLine(MessageMainOutputArray);
            WriteArray(arr);

            Menu();

            if (arr.Length > 0)
            {
                var average = Average(arr);
                DeleteElemsGreaterThanNum(ref arr, average);
                Console.WriteLine(MessageMainOutputArrayAfterDel + average);
                WriteArray(arr);
                Menu();
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

            Menu();

            if (arr.Length <= 0) return;
            SwapEvenWithOddIndex(ref arr);
            Console.WriteLine(MessageMainArrayAfterSwap);
            WriteArray(arr);

            Menu();

            var findElem = SearchFirstNegat(arr);
            Console.WriteLine(MessageMainSearchFirstNeg);
            if (findElem > 0)
            {
                Console.WriteLine(MessageMainDidntFind);
            }
            else
            {
                Console.WriteLine(MessageMainResultOfSearch + findElem);
                Console.WriteLine(MessageMainPosFindElem + _count);
                Console.WriteLine(MessageMainCountOfCompars + _count);
            }

            Menu();

            SortBySimpleInsert(ref arr);
            Console.WriteLine(MessageMainSortedArray);
            WriteArray(arr);

            Menu();

            var positOfElem = BinarySearch(arr, findElem);
            Console.WriteLine(MessageMainBinarySearch);
            if (positOfElem > 0)
            {
                Console.WriteLine(MessageMainPosFindElem + positOfElem);
                Console.WriteLine(MessageMainCountOfCompars + _count);
            }
            else
            {
                Console.WriteLine(MessageMainCantFind);
            }

            Console.WriteLine(MessageMenuExit);
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Здравствуйте! Выберите, что нужно сделать (введите номер):" +
                              "\n1) Сформировать массив вручную" +
                              "\n2) Сформировать массив с помощью датчика случайных чисел");
            Console.Write("Ваш выбор: ");
            var choice = Console.ReadLine();
            switch (choice)
            {

            }
            Console.WriteLine("Выберите, что сделать (введите номер):" +
                              "\n1) Сформировать массив вручную" +
                              "\n2) Сформировать массив с помощью датчика случайных чисел" +
                              "\n3) Вывести массив на экран" +
                              "\n4) Удалить элементы больше среднего арифметического элементов массива" +
                              "\n5) Добавить K элементов в конец массива" +
                              "\n6) Поменять местами элементы с четными и нечетными номерами" +
                              "\n7) Найти первый отрицательный элемент, подсчитать количество сравнений" +
                              "\n8) Отсортировать массив методом «Простое включение»" +
                              "\n9) Поиск методом «Бинарный поиск» найденного в 7 пункте отрицательного элемента," +
                              " перед этим отсортировав массив, подсчет количества сравнений, " +
                              "но после поиска вернуть массив в исходное состояние");
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
        private static int BinarySearch(IReadOnlyList<int> arrayInts, int findElem)
        {
            _count = 0;
            var leftIndex = 0;
            var rightIndex = arrayInts.Count - 1;
            do
            {
                var pivotIndex = (leftIndex + rightIndex) / 2;
                if (arrayInts[pivotIndex] < findElem)
                    leftIndex = pivotIndex + 1;
                else
                    rightIndex = pivotIndex;

                _count++;
            } while (leftIndex != rightIndex);

            _count++;
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
        private static int SearchFirstNegat(IEnumerable<int> arrayInts)
        {
            _count = 0;
            foreach (var element in arrayInts)
            {
                _count++;
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
        ///     Вывод меню с выбором продолжения выполнения программы или ее завершения.
        /// </summary>
        private static void Menu()
        {
            do
            {
                Console.Write(MessageMenu);
                var choiceSign = Console.ReadLine();
                switch (choiceSign)
                {
                    case "+":
                        Console.WriteLine(MessageMenuCont);
                        return;
                    case "-":
                        Console.WriteLine(MessageMenuExit);
                        Environment.Exit(123);
                        return;
                }

                Console.WriteLine(MessageChoiceIncorrectInput);
            } while (true);
        }

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

        private const string MessageMainBinarySearch = "Поиск найденного ранее элемента методом \"Двоичный поиск\"";

        private const string MessageMainArrayAfterSwap = "Массив после перестановки элементов с" +
                                                         " четными и нечетными номерами:";

        private const string MessageMainDidntFind = "Элемент не найден";

        private const string MessageMainPosFindElem = "Позиция найденного элемента: ";

        private const string MessageMainCountOfCompars = "Количество сравнений: ";

        private const string MessageMainResultOfSearch = "Результат поиска первого отрицательного элемента: ";

        private const string MessageMainSearchFirstNeg = "Поиск первого отрицательного элемента";

        private const string MessageMainSortedArray = "Массив после сортировки методом \"Простое включение\":";

        private const string MessageMainCantFind = "Элемент для поиска в отсортированном массиве не определен";
        private const string MessageMenuExit = "Программа завершается...";

        private const string MessageMenuCont = "Программа продолжается...\n";

        private const string MessageMenu = "Продолжить выполнение программы (+) " +
                                           "или завершить (-)? Ваш выбор [+/-]: ";

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