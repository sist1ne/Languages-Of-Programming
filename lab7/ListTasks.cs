using lab7;
using System;

namespace lab7
{
    public class Lists
    {
        public static void AddListAfterElem(List<string> information, string? elem)
        {
            int idElem = information.IndexOf(elem);
            if (idElem != -1)
            {
                List<string> list = new List<string>(information);
                information.InsertRange(idElem + 1, list);
                Console.WriteLine("Список изменен.\n");
            }
            else Console.WriteLine("Указанного элемента нет в списке.\n");
        }

        public static void AddFrontAndBack(LinkedList<string> information, string? elem)
        {
            information.AddFirst(elem);
            information.AddLast(elem);
            Console.WriteLine("Элемент добавлен.\n");
        }
    }
}