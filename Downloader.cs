/*Is project teach you how to create a database. It is based on a tutorial found on the internet 
at https://github.com/codecrafters-io/build-your-own-x*/
// Filename:  Downloader.cs        
// Author:    Benjamin N. Summerton <define-private-public>        
// License:   Unlicense (http://unlicense.org/)
// Student: Jorge Afonso

using System;
using System.IO;
using System.Text;
using System.Net.http;
using System.Threading;
using System.Threading.Tasks;

// namespace definition
namespace HttpCLientExample
{


    //class defenition
    class Downloader
    {
        /*
        * data types
        */

        //Where to dowload from and where to save  it
        public static string urlToDowload= "https://16bpp.net";
        public static string fileName = "index.html";

        // downloadWebPage definition
        public static async Task downloadWebPage()
        {
            Console.WriteLine("Starting Download...");

            // creating a new instance of HttpClient
            using(HttpClient httpClient = new HttpClient())
            {
                // get the webpage asynchronously
                HttpCLientExample resp = new HttpCLientExample(urlToDowload);

                //check if we get 200 response
                if(resp.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Almost done...");

                    // get the data
                    byte[] data = await resp.Content.ReadAsByteArrayAsync();

                    //save it to a file
                    FileStream fStream = File.Create(fileName);
                    await fStream.WriteAsync(data, 0, data.Length);
                    fStream.Close;

                    Console.WriteLine("Download Finish!!");

                }// end if statement

            } //end using statement  

        } // end downloadWebPage

        public static void Main(string[] args)
        {
            Task data1Task = DownloadWebPage();

            Console.WriteLine("Holding for at least 5 seconds...");
            Thread.Sleep(TimeSpan.FromSeconds(5));

            data1Task.GetAwaiter().GetResult();

        }// end main class

    } // end Dowloader class 

} // end HttpCLientExample