using System;
using System.IO;

namespace Document
{
    class Program

    {

        static void Main(string[] args)

        {
            string fileContent;
            string fileName;
            string name;
            string txtCatch = "";
            int count;
            string tryAgain = "yes";
            Exception failure = null;
            StreamWriter thisFile = null;

            while (tryAgain == "yes")

            {

                Console.WriteLine("Document");
                Console.WriteLine("What Is The Name Of The File?");
                name = Console.ReadLine();

                for (int counter = 1; counter <= 4; counter++)

                {

                    txtCatch = txtCatch + name[name.Length - counter];

                }

                if (txtCatch == "txt.")

                {

                    fileName = name;

                }

                else

                {

                    fileName = name + ".txt";

                }

                Console.WriteLine("What Is InCluded In The Text File? Press ENTER When Done.");
                fileContent = Console.ReadLine();
                count = fileContent.Length;

                try

                {

                    thisFile = File.CreateText(fileName);
                    thisFile.WriteLine(fileContent);

                }

                catch (IOException e)

                {

                    failure = e;

                    Console.WriteLine("{0}", failure);

                    Console.WriteLine("type 'yes' If You Want To Try Again.");
                    tryAgain = Console.ReadLine();

                }

                finally

                {
                    if (thisFile != null)

                    {

                        thisFile.Close();
                        if (failure == null)

                        {

                            Console.WriteLine("{0} Was Successfully Saved. The Document Contains {1} Characters.", fileName, count);
                            tryAgain = "no";
                            Console.ReadLine();

                        }

                        failure = null;

                    }
                }
            }
        }
    }
}