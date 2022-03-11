using System.IO;
using System.Diagnostics;

namespace PersonalAppLibrary
{
    class DBModel
    {
        private static string path = Directory.GetCurrentDirectory().ToString() + @"\Categories";
        public static void LaunchFile(int fileIndex, string category)
        {
            string[] files = File.ReadAllLines(path + @"\" + category + ".bar");
            Process.Start(files[fileIndex]);
        }
        public static void ToFileDirectory(int fileIndex, string category)
        {
            string[] files = File.ReadAllLines(path + @"\" + category + ".bar");
            string[] CuttedPath = files[fileIndex].Split('\\');
            string catalog = "";
            for (int i = 0; i < CuttedPath.Length - 1; i++)
            {
                catalog += CuttedPath[i] + "\\";
            }
            Process.Start("explorer", catalog);
        }
        public static string[] GetCategories()
        {
            if (Directory.Exists(path))
            {
                if (Directory.GetFiles(path, "*.bar").Length > 0)
                {
                    string[] categories = new string[Directory.GetFiles(path, "*.bar").Length];
                    int num = 0;
                    foreach (string catPath in Directory.GetFiles(path, "*.bar"))
                    {
                        string[] splittedCatPath = catPath.Split('\\');
                        categories[num] = splittedCatPath[splittedCatPath.Length - 1].Split('.')[0];
                        num++;
                    }
                    return categories;
                }
                else return null;
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory().ToString() + @"\Categories");
                return null;
            }
        }

        public static void AddToCategory(string filepath, string category)
        {
            if (File.Exists(path + @"\" + category + ".bar"))
            {
                if (File.ReadAllLines(path + @"\" + category + ".bar").Length >= 1)
                {
                    File.AppendAllText(path + @"\" + category + ".bar", "\n" + filepath);
                }
                else
                {
                    File.WriteAllText(path + @"\" + category + ".bar", filepath);
                }
            }
        }
        public static void RemoveFromCategory(int fileIndex, string category)
        {
            if (File.Exists(path + @"\" + category + ".bar"))
            {
                if (File.ReadAllLines(path + @"\" + category + ".bar").Length != 1)
                {
                    string[] files = File.ReadAllLines(path + @"\" + category + ".bar");
                    bool firstInput = true;
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (i != fileIndex)
                        {
                            if (firstInput)
                            {
                                File.WriteAllText(path + @"\" + category + ".bar", files[i]);
                                firstInput = !firstInput;
                            }
                            else
                            {
                                File.AppendAllText(path + @"\" + category + ".bar", "\n" + files[i]);
                            }
                        }
                    }
                }
                else
                {
                    File.WriteAllText(path + @"\" + category + ".bar", "");
                }
            }
        }

        public static string[] GetCategoryFiles(string category)
        {

            if (File.Exists(path + @"\" + category + ".bar"))
            {
                string[] files = File.ReadAllLines(path + @"\" + category + ".bar");
                int num = 0;
                foreach (string file in files)
                {
                    string[] splittedCatPath = file.Split('\\');
                    files[num] = splittedCatPath[splittedCatPath.Length - 1];
                    num++;
                }
                return files;
            }
            else return null;
        }

        public static void RemoveCategory(string category)
        {
            if (File.Exists(path + @"\" + category + ".bar"))
            {
                File.Delete(path + @"\" + category + ".bar");
            }
        }
    }
}
