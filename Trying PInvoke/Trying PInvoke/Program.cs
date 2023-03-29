using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Trying_PInvoke
{
    internal class Program
    {
        public class ClassyClass
        {
            public override string ToString()
            {
                return $"{this.id}\n{this.phone}";
            }
            public string phone { get; set; }
            public int id { get; set; }
        }
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        static async Task Main(string[] args)
        {
            ClassyClass result;
            using (HttpClient client = new HttpClient())
            {
                Uri endpoint = new Uri("https://jsonplaceholder.typicode.com/users/1");
                result = await client.GetFromJsonAsync<ClassyClass>(endpoint);
            }
            MessageBox(IntPtr.Zero, result.ToString(), "Results", 0);
            StreamWriter sr = new StreamWriter(""); //enter the file path for the .txt file
            sr.Write(result.ToString());
            sr.Close();
            Console.ReadKey();
        }
    }
}