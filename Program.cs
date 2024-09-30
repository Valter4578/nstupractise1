using System;
using System.Collections.Generic;
using System.Linq;

namespace NortonCommanderImitation
{
    class FileInfo
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDirectory { get; set; }
        public string Type { get; set; }
        public string Permissions { get; set; }

        public FileInfo(string name, long size, DateTime modifiedDate, bool isDirectory, string type, string permissions)
        {
            Name = name;
            Size = size;
            ModifiedDate = modifiedDate;
            IsDirectory = isDirectory;
            Type = type;
            Permissions = permissions;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Задаем размер окна
            Console.SetWindowSize(80, 25);

            // Список файлов
            List<FileInfo> files = new List<FileInfo>()
            {
                new FileInfo("file1.txt", 1024, DateTime.Now, false, "Text", "rw-r--r--"),
                new FileInfo("file2.txt", 2048, DateTime.Now.AddDays(-1), false, "Text", "rw-r--r--"),
                new FileInfo("file3.txt", 4096, DateTime.Now.AddDays(-2), false, "Text", "rw-r--r--"),
                new FileInfo("folder1", 0, DateTime.Now.AddDays(-3), true, "Directory", "rwxr-xr-x"),
                new FileInfo("folder2", 0, DateTime.Now.AddDays(-4), true, "Directory", "rwxr-xr-x"),
                new FileInfo("file4.txt", 8192, DateTime.Now.AddDays(-5), false, "Text", "rw-r--r--"),
                new FileInfo("file5.txt", 16384, DateTime.Now.AddDays(-6), false, "Text", "rw-r--r--"),
                new FileInfo("file6.txt", 32768, DateTime.Now.AddDays(-7), false, "Text", "rw-r--r--"),
                new FileInfo("file7.txt", 65536, DateTime.Now.AddDays(-8), false, "Text", "rw-r--r--"),
                new FileInfo("file8.txt", 131072, DateTime.Now.AddDays(-9), false, "Text", "rw-r--r--"),
                new FileInfo("file9.txt", 262144, DateTime.Now.AddDays(-10), false, "Text", "rw-r--r--"),
                new FileInfo("file10.txt", 524288, DateTime.Now.AddDays(-11), false, "Text", "rw-r--r--"),
                new FileInfo("file11.txt", 1048576, DateTime.Now.AddDays(-12), false, "Text", "rw-r--r--"),
                new FileInfo("file12.txt", 2097152, DateTime.Now.AddDays(-13), false, "Text", "rw-r--r--"),
                new FileInfo("file13.txt", 4194304, DateTime.Now.AddDays(-14), false, "Text", "rw-r--r--"),
                new FileInfo("file14.txt", 8388608, DateTime.Now.AddDays(-15), false, "Text", "rw-r--r--"),
                new FileInfo("file15.txt", 16777216, DateTime.Now.AddDays(-16), false, "Text", "rw-r--r--"),
                new FileInfo("file16.txt", 33554432, DateTime.Now.AddDays(-17), false, "Text", "rw-r--r--"),
                new FileInfo("file17.txt", 67108864, DateTime.Now.AddDays(-18), false, "Text", "rw-r--r--"),
                new FileInfo("file18.txt", 134217728, DateTime.Now.AddDays(-19), false, "Text", "rw-r--r--"),
                new FileInfo("file19.txt", 268435456, DateTime.Now.AddDays(-20), false, "Text", "rw-r--r--"),
                new FileInfo("file20.txt", 536870912, DateTime.Now.AddDays(-21), false, "Text", "rw-r--r--")
            };

            // Сортировка файлов по имени
            files = files.OrderBy(f => f.Name).ToList();

            // Очистка консоли
            Console.Clear();

            // Вывод рамки
            DrawFrame();

            // Вывод списка файлов
            DrawFileList(files);

            // Вывод информации о файле
            DrawFileInfo(files[0]);

            // Вывод команд внизу интерфейса
            DrawCommands();

            // Задержка для визуализации
            Console.ReadKey();
        }

        static void DrawFrame()
        {
            // Верхняя граница
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            for (int i = 1; i < 79; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");

            // Нижняя граница
            Console.SetCursorPosition(0, 23);
            Console.Write("╚");
            for (int i = 1; i < 79; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");

            // Левая граница
            for (int i = 1; i < 23; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
            }

            // Правая граница
            for (int i = 1; i < 23; i++)
            {
                Console.SetCursorPosition(79, i);
                Console.Write("║");
            }

            // Разделитель
            Console.SetCursorPosition(39, 0);
            Console.Write("╦");
            for (int i = 1; i < 23; i++)
            {
                Console.SetCursorPosition(39, i);
                Console.Write("║");
            }
            Console.SetCursorPosition(39, 23);
            Console.Write("╩");
        }

        static void DrawFileList(List<FileInfo> files)
        {
            // Определение максимального количества файлов для отображения
            int maxFiles = 22; // 22 строки для списка файлов

            // Вывод заголовка
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Файлы:");
            Console.ResetColor();

            // Вывод заголовков столбцов
            Console.SetCursorPosition(1, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Имя".PadRight(15));
            Console.SetCursorPosition(18, 2);
            Console.Write("Размер".PadLeft(10));
            Console.SetCursorPosition(30, 2);
            Console.Write("Дата".PadRight(10));
            Console.SetCursorPosition(42, 2);
            Console.Write("Время".PadRight(8));
            Console.SetCursorPosition(52, 2);
            Console.Write("Тип".PadRight(10));
            Console.SetCursorPosition(64, 2);
            Console.Write("Права".PadRight(10));
            Console.ResetColor();

            // Вывод списка файлов
            int fileIndex = 0;
            for (int i = 3; i < 23 && fileIndex < maxFiles && fileIndex < files.Count; i++)
            {
                FileInfo file = files[fileIndex];

                // Отображение имени файла
                string fileName = file.Name;
                if (fileName.Length > 15)
                {
                    fileName = fileName.Substring(0, 12) + "~" + fileName.Substring(fileName.Length - 3);
                }
                Console.SetCursorPosition(1, i);
                Console.ForegroundColor = file.IsDirectory ? ConsoleColor.Blue : ConsoleColor.White;
                Console.Write(fileName.PadRight(15));

                // Отображение размера файла
                Console.SetCursorPosition(18, i);
                Console.Write(file.Size.ToString().PadLeft(10));

                // Пробел между Размером и Датой
                Console.SetCursorPosition(28, i);
                Console.Write(" ");

                // Отображение даты изменения
                Console.SetCursorPosition(30, i);
                Console.Write(file.ModifiedDate.ToShortDateString().PadRight(10));

                // Отображение времени изменения
                Console.SetCursorPosition(42, i);
                Console.Write(file.ModifiedDate.ToShortTimeString().PadRight(8));

                // Отображение типа файла
                Console.SetCursorPosition(52, i);
                Console.Write(file.Type.PadRight(10));

                // Отображение прав доступа
                Console.SetCursorPosition(64, i);
                Console.Write(file.Permissions.PadRight(10));

                fileIndex++;
            }

            // Сброс цвета
            Console.ResetColor();
        }

        static void DrawFileInfo(FileInfo file)
        {
            // Вывод заголовка
            Console.SetCursorPosition(41, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Информация о файле:");
            Console.ResetColor();

            // Вывод имени файла
            Console.SetCursorPosition(41, 3);
            Console.Write("Имя: ");
            Console.ForegroundColor = file.IsDirectory ? ConsoleColor.Blue : ConsoleColor.White;
            Console.Write(file.Name);
            Console.ResetColor();

            // Вывод размера файла
            Console.SetCursorPosition(41, 4);
            Console.Write("Размер: ");
            Console.Write(file.Size.ToString());

            // Вывод даты изменения
            Console.SetCursorPosition(41, 5);
            Console.Write("Дата: ");
            Console.Write(file.ModifiedDate.ToShortDateString());

            // Вывод времени изменения
            Console.SetCursorPosition(41, 6);
            Console.Write("Время: ");
            Console.Write(file.ModifiedDate.ToShortTimeString());

            // Вывод типа файла
            Console.SetCursorPosition(41, 7);
            Console.Write("Тип: ");
            Console.Write(file.Type);

            // Вывод прав доступа
            Console.SetCursorPosition(41, 8);
            Console.Write("Права: ");
            Console.Write(file.Permissions);
        }

        static void DrawCommands()
        {
            // Вывод команд внизу интерфейса
            Console.SetCursorPosition(0, 24);
            Console.Write("F1 Помощь  F2 Вызов  F3 Просмотр  F4 Ред.  F5 Копир.  F6 Перем.  F7 Новая папка  F8 Удал.  F9 Меню  F10 Выход");
        }
    }
}