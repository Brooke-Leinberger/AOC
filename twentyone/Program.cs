using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Text.Json;


namespace TwentyOne
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] testInput, realInput;

            var function = Day4.part2;
            testInput = FileCsv("../../../test.txt");
            realInput = WebCsv("https://adventofcode.com/2021/day/4/input");
            
            Console.WriteLine("Test: " + function(testInput));
            Console.WriteLine("Real: " + function(realInput));
        }

        
        
        
        private class AuthToken
        {
            public string session { get; set; }
        }


        private static string[] WebCsv(string url, char delimiter = '\n', string cookiePath = "../../../cookies.json")
        {
            AuthToken token = JsonSerializer.Deserialize<AuthToken>(File.ReadAllText(cookiePath));
            string cookie = "session="+ token.session;
            
            WebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Cookie, cookie);
            
            string content;
            using(var reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                content = reader.ReadToEnd();
            }
            
            return content.Split(delimiter);
        }

        private static string[] FileCsv(string path, char delimiter = '\n')
        {
            return File.ReadAllText(path).Split(delimiter);
        }
    }
}