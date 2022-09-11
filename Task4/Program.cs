using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using FinalTask;
using System.Text.RegularExpressions;

BinaryFormatter formatter = new();
string filepath = @"C:\Users\ekser\Desktop\Students";
DirectoryInfo studentsfolder = new(filepath);

try
{
    if (!studentsfolder.Exists)
        studentsfolder.Create();

    using (FileStream fs = new(@"C:\Users\ekser\Desktop\Students.dat", FileMode.Open))
    {
        Student[] students = (Student[])formatter.Deserialize(fs);
        List<string> groups = new();

        foreach (Student student in students)
        {
            if (!groups.Contains(student.Group))
                groups.Add(student.Group);
        }

        foreach (string group in groups)
        {
            string groupfilepath = Path.Combine(filepath, group) + ".txt";
            FileInfo groupfile = new(groupfilepath);
            foreach (Student student in students)
            {
                if (student.Group == group)
                    using (StreamWriter sw = groupfile.AppendText())
                    {
                        sw.WriteLine($"{student.Name}, {student.DateOfBirth.ToString()}");
                    }
            }
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}