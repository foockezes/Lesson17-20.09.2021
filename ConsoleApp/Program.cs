using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] IntArr = { 1, 2, 3, 4, 5, 6, 7, 8 };

            Console.WriteLine($"Удаленный елемент массива: {Arrays<int>.Pop(ref IntArr)}");
            Console.WriteLine($"обновленная длина массива: {Arrays<int>.Push(ref IntArr, 6)}");
            Console.WriteLine($"Удаленный елемент массива: {Arrays<int>.Shift(ref IntArr)}");
            Console.WriteLine($"обновленная длина массива: {Arrays<int>.UnShift(ref IntArr, 6)}");
            Console.WriteLine($"{Arrays<int>.Slice(IntArr, 2, 5)}");

        }
    }
    static class Arrays<TClass>
    {
        public static T Pop<T>(ref T[] array)
        {
            if (array.Length == 0) return default;
            T[] NewArray = new T[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
                NewArray[i] = array[i];
            T del = array[array.Length - 1];
            array = NewArray;
            return del;
        }
        public static int Push<T>(ref T[] array, T element)
        {
            if (array.Length == 0) return 0;
            T[] NewArray = new T[array.Length + 1];
            NewArray[array.Length] = element;
            for (int i = 0; i < array.Length; i++)
                NewArray[i] = array[i];
            array = NewArray;
            return array.Length;
        }
        public static T Shift<T>(ref T[] array)
        {
            if (array.Length == 0) return default;
            T[] NewArray = new T[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                NewArray[i] = array[i + 1];
            }
            T del = array[0];
            array = NewArray;
            return del;
        }
        public static int UnShift<T>(ref T[] array, T element)
        {
            if (array.Length == 0) return 0;
            T[] NewArray = new T[array.Length + 1];
            NewArray[0] = element;
            for (int i = 0; i < array.Length; i++)
            {
                NewArray[i + 1] = array[i];
            }
            array = NewArray;
            return array.Length;
        }
        public static T[] Slice<T>(T[] array, int Bindex = 0, int Eindex = 0)
        {
            if (Bindex < 0 && Eindex < 0)
            {
                Console.WriteLine("начальный и конечный индекс меньше 0 : возврать пустого массива");
                T[] NewArray = new T[0];
                return NewArray;
            }
            else if (Bindex > (array.Length - 1))
            {
                Console.WriteLine("Началный индекс больше длины массива:возврать пустого массива");
                T[] NewArray = new T[0];
                return NewArray;
            }
            else if (Bindex < 0)
            {
                Console.WriteLine($"начальный индекс отрицательный: Вызов slice({Bindex}) извлечёт {Bindex * -1} последних элемента последовательности.");
                T[] NewArray = new T[(Bindex * -1)];
                Bindex = Bindex * -1;
                for (int i = 0; i < NewArray.Length; i++, Bindex--)
                {
                    NewArray[i] = array[array.Length - Bindex];
                }
                return NewArray;
            }
            else if (Eindex < 0)
            {
                Console.WriteLine($"конечный индекс отрицательный: новый массив с индекса {Bindex} до {array.Length - (Eindex * -1)}");
                T[] NewArray = new T[(array.Length) - Bindex - (Eindex * -1)];
                for (int i = 0; i < NewArray.Length; i++, Bindex++)
                {
                    NewArray[i] = array[Bindex];
                }
                return NewArray;
            }
            else if (Bindex > Eindex)
            {
                Console.WriteLine("Началный индекс больше конечного");
                T[] NewArray = new T[0];
                return NewArray;
            }
            else if (Bindex >= 0 && Eindex >= 0 && Bindex < (array.Length - 1))
            {
                Console.WriteLine($"вернет новый массив с индекса {Bindex} до {Eindex}");
                T[] NewArray = new T[(Eindex + 1) - Bindex];
                for (int i = 0; i < NewArray.Length; i++, Bindex++)
                {
                    NewArray[i] = array[Bindex];
                }
                array = NewArray;
            }
            return array;
        }
    }
}
