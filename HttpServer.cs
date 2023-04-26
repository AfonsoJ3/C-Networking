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

    } // end HttpServer

} // end namespace