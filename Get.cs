using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Stream
{
    class Get
    {
		static int getCodesCount(string path)
		{
			int count = 0;
			string[] filenames=Directory.GetFiles(path);
			string[] directories=Directory.GetDirectories(path);
            string strLine;
			foreach(string fname in filenames)
			{
				if(fname.EndsWith(".java")||fname.EndsWith(".jsp")||fname.EndsWith(".xml")||fname.EndsWith(".properties")
					||fname.EndsWith(".css"))
				{
                    Console.WriteLine(fname);
			        try
			        {
				        FileStream aFile = new FileStream(fname,FileMode.Open);
			            StreamReader sr = new StreamReader(aFile);
			            strLine = sr.ReadLine();
				        while(strLine != null)
				        {
					        //Console.WriteLine(strLine);
					        strLine=sr.ReadLine();
					        count++;
				        }
				        sr.Close();
			        }
			        catch (IOException ex)
                    {
				        Console.WriteLine(ex.ToString());
			        }
				}
			}
            foreach(string dname in directories)
			{
				Console.WriteLine(dname);
				count += getCodesCount(dname);
			}
			return count;
		}

        static void Main()
        {
			string path = "D:\\test";
			Console.WriteLine(path);
			int count = 0;
			count=getCodesCount(path);

			
			Console.WriteLine("count:"+count);
            //Console.WriteLine("c#:hello world!");
			
        }
    }
}