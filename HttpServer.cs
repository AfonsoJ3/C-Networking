/*Is project teach you how to create a database. It is based on a tutorial found on the internet 
at https://github.com/codecrafters-io/build-your-own-x*/
// Filename:  Downloader.cs        
// Author:    Benjamin N. Summerton <define-private-public>        
// License:   Unlicense (http://unlicense.org/)
// Student: Jorge Afonso

using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

// namespace defenition 
namespace HttpCLientExample
{
    // class defenition 
    class HttpServer
    {
        /*
        * data type
        */

        public static HttpListing listener; 
        public static string url = "http://localhost:8000/";
        public static int pageViews = 0;
        public static int requestCount = 0;
        
        // Reads the html file
        public static string pageData = File.ReadAllText("pageData.html");

    } // end HttpServer

    public static async Task HandleIncomingConnections()
    {
        //flag 
       bool runServer = true;

        // check if the user hasn't 'shutdown' url
        if(runServer)
        {
            // hear from a connection
            HttListenerContext ctx = await listener.GetContextAsunc();

            // Separate the resquest and respond object
            HttpListenerRequest request = ctx.Request;
            HttpListenerResponse response = ctx.response;

            //print out some info about the requet
            Console.WriteLine($"Request #: {++requestCount}.\n{request.url.toString()}." +
                            $"\n{request.HttpMethod}.\n{request.UserHostName}.\n{request.UserAgent}.\n");

            //if the  user 'shutdown' the server
            if((request.HttpMethod == "POST")&&(request.url.AbsolutePath == "/shutdown"))
            {
                Console.WriteLine("Shutdown request");
                //updade the flag variable
                runServer = false;
            }// end if stament

            if (request.url.AbsolutePath != "/favicon.ico")
            {
                pagesViews += 1;
            }// end if stament 

            // Write the response info
            string disableSubmit = !runServer ? "disabled" : "";
            byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews, disableSubmit));
            resp.ContentType = "text/html";
            resp.ContentEncoding = Encoding.UTF8;
            resp.ContentLength64 = data.LongLength;

            // Write out to the response stream (asynchronously), then close it
            await resp.OutputStream.WriteAsync(data, 0, data.Length);
            resp.Close();

        }// if stament

    } // end HandleIncomingConnections

    public static void Main(string[] args)
    {
        // Create a Http server and start listening for incoming connections
        listener = new HttpListener();
        listener.Prefixes.Add(url);
        listener.Start();
        Console.WriteLine("Listening for connections on {0}", url);

        // Handle requests
        Task listenTask = HandleIncomingConnections();
        listenTask.GetAwaiter().GetResult();

        // Close the listener
        listener.Close();
    }

} // end namespace