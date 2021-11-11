using System;
using System.Collections.Generic;

namespace HT_Lab4_26_30
{
    internal static class Program
    {
        private static void Main()
        {
            FirstMenu(out var arr, out _);
            MainMenu(arr, out _);
        }

        // TODO: нормальную реакцию функций на пустой массив

        #region Функции

        #region Основные функции

        /// <summary>
        ///     Начальное меню.
        /// </summary>
        private static void FirstMenu(out int[] arr, out uint n)
        {
            Console.WriteLine("Здравствуйте! Выберите, что нужно сделать (введите номер):" +
                              "\n1) Сформировать массив вручную" +
                              "\n2) Сформировать массив с помощью датчика случайных чисел" +
                              "\n3) Завершить исполнение программы");
            do
            {
                Console.Write("\nВаш выбор: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nВыбран ручной метод формирования массива\n");
                        ReadSize(out n);
                        arr = ReadArray(n);
                        return;
                    case "2":
                        Console.WriteLine("\nВыбран метод заполнения массива с помощью датчика случайных чисел\n");
                        ReadSize(out n);
                        arr = GenerateArray(n);
                        return;
                    case "3":
                        Console.WriteLine("\nЗавершение программы...\n");
                        Environment.Exit(123);
                        break;
                }

                Console.WriteLine("\nВведен неизвестный символ, введите номер операции заново\n");
            } while (true);
        }

        private static void MainMenu(int[] arr, out uint n)
        {
            var firstNeg = 0;
            do
            {
                Console.Write("\nДля продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.WriteLine();

                Console.WriteLine("\nВыберите, что сделать (введите номер):" +
                                  "\n1) Сформировать новый массив вручную" +
                                  "\n2) Сформировать новый массив с помощью датчика случайных чисел" +
                                  "\n3) Вывести массив на экран" +
                                  "\n4) Удалить элементы больше среднего арифметического элементов массива" +
                                  "\n5) Добавить K элементов в конец массива вручную" +
                                  "\n6) Добавить K элементов в конец массива, сформированных с помощью " +
                                  "датчика случайных чисел" +
                                  "\n7) Поменять местами элементы с четными и нечетными номерами" +
                                  "\n8) Найти первый отрицательный элемент, подсчитать количество сравнений" +
                                  "\n9) Отсортировать массив методом «Простое включение»" +
                                  "\n10) Поиск методом «Бинарный поиск» найденного в 8 пункте отрицательного элемента," +
                                  " подсчет количества сравнений" +
                                  "\n11) Завершить исполнение программы");
                Console.Write("\nВаш выбор: ");
                var choice = Console.ReadLine();
                uint k;
                int[] arrAdd;
                int count;
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nВыбран ручной метод формирования массива\n");
                        ReadSize(out n);
                        arr = ReadArray(n);
                        break;
                    case "2":
                        Console.WriteLine("\nВыбран метод заполнения массива с помощью датчика случайных чисел\n");
                        ReadSize(out n);
                        arr = GenerateArray(n);
                        break;
                    case "3":
                        Console.WriteLine("\nВыбран вывод массива\n");
                        WriteArray(arr);
                        break;
                    case "4":
                        var average = Average(arr);
                        Console.WriteLine("\nВыбрано удаление элементов, больших" +
                                          $" среднего арифметического элементов массива = {average}");

                        if (arr.Length > 0)
                            DeleteGreaterThanNum(ref arr, average);
                        else
                            Console.WriteLine("\nНельзя выполнить, так как массив пустой!\n");
                        break;
                    case "5":
                        Console.WriteLine("\nВыбрано добавить К элементов в конец массива вручную\n");
                        ReadSize(out k);
                        arrAdd = ReadArray(k);
                        if (k > 0)
                        {
                            Console.Write("\nЭлементы: ");
                            WriteArray(arrAdd);
                        }
                        else
                        {
                            Console.WriteLine("\nДополнительных элементов нет!\n");
                        }

                        arr = Concat(arr, arrAdd);
                        break;
                    case "6":
                        Console.WriteLine("\nВыбрано добавить K элементов в конец массива, сформированных с помощью " +
                                          "датчика случайных чисел\n");
                        ReadSize(out k);
                        arrAdd = GenerateArray(k);
                        if (k > 0)
                        {
                            Console.Write("Элементы: ");
                            WriteArray(arrAdd);
                        }
                        else
                        {
                            Console.WriteLine("\nДополнительных элементов нет!\n");
                        }

                        arr = Concat(arr, arrAdd);
                        break;
                    case "7":
                        Console.WriteLine("\nВыбрано поменять местами элементы с четными и нечетными номерами\n");
                        if (arr.Length > 0)
                        {
                            SwapEvenOddIndex(ref arr);
                        }
                        else
                        {
                            Console.WriteLine("\nНельзя выполнить, так как массив пустой!\n");
                        }

                        break;
                    case "8":
                        Console.WriteLine("\nВыбрано найти первый отрицательный элемент," +
                                          " подсчитать количество сравнений\n");
                        if (arr.Length > 0)
                        {
                            firstNeg = SearchFirstNegat(arr, out count);
                            if (firstNeg == 1)
                                Console.WriteLine("Последовательность не содержит отрицательных элементов!\n");
                            else
                                Console.WriteLine($"Первый отрицательный = {firstNeg}\n" +
                                                  $"Количество сравнений = {count}\n");
                        }
                        else
                        {
                            Console.WriteLine("\nНельзя выполнить, так как массив пустой!\n");
                        }


                        break;
                    case "9":
                        Console.WriteLine("\nВыбрано отсортировать массив методом «Простое включение»\n");
                        if (arr.Length > 0)
                        {
                            Sort(ref arr);
                        }
                        else
                        {
                            Console.WriteLine("\nНельзя выполнить, так как массив пустой!\n");
                        }

                        break;
                    case "10":
                        Console.WriteLine("\nВыбран поиск методом «Бинарный поиск» найденного в 8 пункте" +
                                          " отрицательного элемента, подсчитать количество сравнений\n");
                        if (firstNeg >= 0 || arr.Length == 0)
                        {
                            Console.WriteLine("\nСначала нужно найти этот элемент!\n");
                        }
                        else
                        {
                            var pos = BinarySearch(arr, firstNeg, out count);
                            switch (pos)
                            {
                                case >= 0:
                                    Console.WriteLine($"\nИскомый элемент = {firstNeg}\n" +
                                                      $"Позиция найденного элемента = {pos}\n" +
                                                      $"Количество сравнений = {count}\n");
                                    break;
                                case -2:
                                    Console.WriteLine("\nЭлемент не найден\n");
                                    break;
                            }
                        }

                        break;
                    case "11":
                        Console.WriteLine("\nЗавершение программы...\n");
                        n = 0;
                        return;
                    default:
                        Console.WriteLine("\nВведен неизвестный символ!" +
                                          " Продолжение выполнения...\n");
                        break;
                }
            } while (true);
        }

        /// <summary>
        ///     Консольный ввод массива
        ///     <see cref="T:System.Int32" />
        ///     значений размером sizeArray.
        /// </summary>
        private static int[] ReadArray(uint sizeArray)
        {
            var arrayInts = new int[sizeArray];
            for (var i = 0; i < sizeArray; i++)
            {
                bool isConvert;
                do
                {
                    Console.Write($"Введите элемент №{i + 1}: ");
                    isConvert = int.TryParse(
                        Console.ReadLine(), out arrayInts[i]);
                    if (!isConvert)
                        Console.WriteLine($"Ошибка! Введен не как целое число элемент №{i + 1}");
                } while (!isConvert);
            }

            Console.WriteLine("Массив успешно сформирован");
            if (sizeArray == 0)
                Console.WriteLine("Массив не содержит элементов");
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

            var generator = new Random();
            for (var i = 0; i < sizeArray; i++)
                arrayInts[i] = generator.Next(-100, 101);

            Console.WriteLine("Массив успешно сформирован");
            if (sizeArray == 0)
                Console.WriteLine("Массив не содержит элементов");
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
                Console.WriteLine("Массив не содержит элементов");
            }
        }

        /// <summary>
        ///     Удаляет из массива
        ///     <see cref="T:System.Int32" /> значений
        ///     элементы больше указанного.
        /// </summary>
        private static void DeleteGreaterThanNum(ref int[] arrayInts, double num)
        {
            for (var i = 0; i < arrayInts.Length;)
                if (arrayInts[i] > num)
                    arrayInts = arrayInts.Delete(i);
                else
                    i++;
        }

        /// <summary>
        ///     Перестановка элементов с четными и нечетными индексами
        ///     в массиве <see cref="T:System.Int32" /> значений .
        /// </summary>
        private static void SwapEvenOddIndex(ref int[] arrayInts)
        {
            for (var i = 1; i < arrayInts.Length; i += 2)
            {
                var tmp = arrayInts[i];
                arrayInts[i] = arrayInts[i - 1];
                arrayInts[i - 1] = tmp;
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
        ///     Сортировка массива <see cref="T:System.Int32" /> значений
        ///     методом «Простое включение».
        /// </summary>
        private static void Sort(ref int[] arrayInts)
        {
            for (var i = 1; i < arrayInts.Length; i++)
            {
                var tmp = arrayInts[i];
                var j = i - 1;
                for (; j >= 0 && arrayInts[j] > tmp; j--)
                    arrayInts[j + 1] = arrayInts[j];
                arrayInts[j + 1] = tmp;
            }

            Console.WriteLine("Массив успешно отсортирован");
        }

        /// <summary>
        ///     Поиск нимера указанного элемента в последовательности
        ///     <see cref="T:System.Int32" /> значений
        ///     методом «Бинарный поиск», и подсчет количества сравнений.
        /// </summary>
        private static int BinarySearch(IReadOnlyList<int> arrayInts, int findElem, out int count)
        {
            count = 0;
            if (IsSorted(arrayInts))
            {
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
                } while (leftIndex < rightIndex);


                if (leftIndex != rightIndex) return -2;
                count++;
                if (arrayInts[leftIndex] == findElem)
                    return leftIndex + 1;

                // Элемент не найден
                return -2;
            }

            // Массив не отсортирован
            Console.WriteLine("Сначала нужно отсортировать массив!");
            return int.MinValue;
        }

        #endregion

        #region Дополнительные функции

        /// <summary>
        ///     Ввод размера последовательности чисел.
        /// </summary>
        private static void ReadSize(out uint sizeU)
        {
            Console.Write("Введите количество элементов: ");
            bool isCorrect;
            do
            {
                isCorrect = uint.TryParse(Console.ReadLine(), out sizeU);

                Console.Write(isCorrect
                    ? "Успешно введено количество элементов!\n"
                    : "Ошибка! Введено нецелое число, " +
                      "или целое, но меньше 0, или строка, " +
                      "или слишком большое целое!" +
                      "\nВведите количество элементов заново: ");
            } while (!isCorrect);
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
        private static int[] Delete(this IList<int> arrayInts, int indexOfElement)
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
        ///     Соединяет 2 последовательности
        ///     <see cref="T:System.Int32" />
        ///     значений в одну конечную.
        /// </summary>
        private static int[] Concat(IReadOnlyList<int> arrayInts1,
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
        ///     Проверяет, сортирована ли последовательность
        ///     <see cref="T:System.Int32" /> значений.
        /// </summary>
        private static bool IsSorted(IReadOnlyList<int> arr)
        {
            for (var i = 1; i < arr.Count;)
                if (arr[i - 1] <= arr[i])
                    i++;
                else
                    return false;

            return true;
        }

        #endregion

        #endregion
    }
}