using System;
using System.IO;

while (true)
{
    Console.Clear();
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Показать информацию о дисках");
    Console.WriteLine("2. Управление каталогами");
    Console.WriteLine("3. Управление файлами");
    Console.WriteLine("0. Выход");
    Console.Write("Ваш выбор: ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            ShowDriveInfo();
            break;
        case "2":
            ManageDirectories();
            break;
        case "3":
            ManageFiles();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Неверный выбор. Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            break;
    }
}

void ShowDriveInfo()
{
    Console.Clear();
    DriveInfo[] drives = DriveInfo.GetDrives();
    foreach (var drive in drives)
    {
        Console.WriteLine($"Диск: {drive.Name}");
        if (drive.IsReady)
        {
            Console.WriteLine($"  Метка тома: {drive.VolumeLabel}");
            Console.WriteLine($"  Тип файловой системы: {drive.DriveFormat}");
            Console.WriteLine($"  Общий размер: {drive.TotalSize} байт");
            Console.WriteLine($"  Доступное место: {drive.AvailableFreeSpace} байт");
        }
        else
        {
            Console.WriteLine("  Диск не готов.");
        }
    }
    Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
    Console.ReadKey();
}

void ManageDirectories()
{
    Console.Clear();
    Console.WriteLine("Управление каталогами:");
    Console.WriteLine("1. Создать каталог");
    Console.WriteLine("2. Удалить каталог");
    Console.WriteLine("3. Показать содержимое каталога");
    Console.WriteLine("4. Показать свойства каталога");
    Console.WriteLine("0. Назад");
    Console.Write("Ваш выбор: ");
    string choice = Console.ReadLine();
    // Реализуйте соответствующие операции
    switch (choice)
    {
        case "1":
            try
            {
                string path = Console.ReadLine();
                Directory.CreateDirectory(path);
                Console.WriteLine("Каталог успешно создан.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при создании каталога: {e.Message}");
                throw;
            }
            break;
        case "2":
            try
            {
                string path = Console.ReadLine();
                Directory.Delete(path);
                Console.WriteLine("Каталог успешно далён.");


            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при удаление каталога: {e.Message}");
                throw;
            }
            break;
        case "3":
            try
            {
                string path = Console.ReadLine();
                string[] file = Directory.GetFileSystemEntries(path);
                foreach (var VARIABLE in file)
                {
                    Console.WriteLine(VARIABLE);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при отображении содержимого каталога: {e.Message}");
                throw;
            }
            break;
        case "4":
            try
            {
                string path = Console.ReadLine();
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                Console.WriteLine($"Полный путь: {dirInfo.FullName}");
                Console.WriteLine($"Дата создания: {dirInfo.CreationTime}");
                Console.WriteLine($"Последнее изменение: {dirInfo.LastWriteTime}");
                Console.WriteLine($"Атрибуты: {dirInfo.Attributes}");
                long size = 0;
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    size += fileInfo.Length;
                }
                Console.WriteLine($"Размер каталога: {size} байт ({size / 1024.0:F2} КБ, {size / 1048576.0:F2} МБ)");


            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при отображении свойств каталога: {e.Message}");
                throw;
            }
            break;
        case "0":
            return; // Возврат в главное меню
        default:
            Console.WriteLine("Неверный выбор. Нажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            break;
    }
}


void ManageFiles()
{
    Console.Clear();
    Console.WriteLine("Управление файлами:");
    Console.WriteLine("1. Создать файл и записать текст");
    Console.WriteLine("2. Прочитать содержимое файла");
    Console.WriteLine("3. Переименовать файл");
    Console.WriteLine("4. Удалить файл");
    Console.WriteLine("5. Показать свойства файла");
    Console.WriteLine("0. Назад");
    Console.Write("Ваш выбор: ");
    string choice = Console.ReadLine();
    // Реализуйте соответствующие операции
}