using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Module8.Practice
{
    public static class Task1to3Class
    {
        public static int CleanDir(string dirpath)
        {
            if (Directory.Exists(dirpath))
            {
                DirectoryInfo dir = new(dirpath);
                int FileCount = 0;
                try
                {
                    DirectoryInfo[] subdirs = dir.GetDirectories();
                    FileInfo[] files = dir.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        if ((DateTime.Now - file.LastAccessTime) > TimeSpan.FromMinutes(30))
                        {
                            file.Delete();
                            FileCount++;
                        }
                    }

                    foreach (DirectoryInfo subdir in subdirs)
                    {
                        if ((DateTime.Now - subdir.LastAccessTime) > TimeSpan.FromMinutes(30))
                        {
                            FileCount += CountFiles(subdir.FullName);
                            subdir.Delete(true);
                        }
                        else
                        {
                            FileCount += CleanDir(subdir.FullName);
                        }
                    }
                    return FileCount;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return FileCount;
                }
            }
            else
            {
                Console.WriteLine($"Не существует директории по указанному пути {dirpath}");
                return 0;
            }
        }

        public static long CountSize(string dirpath)
        {
            if (Directory.Exists(dirpath))
            {
                try
                {
                    DirectoryInfo dir = new(dirpath);
                    long size = 0;

                    foreach (FileInfo file in dir.GetFiles())
                    {
                        size += file.Length;
                    }

                    foreach (DirectoryInfo directory in dir.GetDirectories())
                    {
                        size += CountSize(directory.FullName);
                    }

                    return size;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
            else
            {
                Console.WriteLine($"Не существует директории по указанному пути {dirpath}");
                return 0;
            }
        }

        public static void CountAndClean(string dirpath)
        {
            if (Directory.Exists(dirpath))
            {
                try
                {
                    long initSize = CountSize(dirpath);
                    int initFiles = CountFiles(dirpath);

                    Console.WriteLine($"Исходный размер папки: {initSize} байт");
                    Console.WriteLine($"Исходное кол-во файлов: {initFiles}");

                    int deletedfiles = CleanDir(dirpath);
                    long newSize = CountSize(dirpath);
                    int newFiles = CountFiles(dirpath);

                    Console.WriteLine($"Текущий размер папки: {newSize} байт");
                    Console.WriteLine($"Текущее кол-во файлов: {newFiles}");
                    Console.WriteLine($"Освобождено места: {initSize - newSize} байт");
                    Console.WriteLine($"Удалено файлов: {deletedfiles}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine($"Не существует директории по указанному пути {dirpath}");
            }
            
        }

        public static int CountFiles(string dirpath)
        {
            if (Directory.Exists(dirpath))
            {
                int filecount = 0;
                try
                {
                    DirectoryInfo dir = new(dirpath);

                    foreach (FileInfo file in dir.GetFiles())
                    {
                        filecount++;
                    }

                    foreach (DirectoryInfo directory in dir.GetDirectories())
                    {
                        filecount += CountFiles(directory.FullName);
                    }

                    return filecount;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return filecount;
                }
            }
            else
            {
                Console.WriteLine($"Не существует директории по указанному пути {dirpath}");
                return 0;
            }
        }
    }
}
