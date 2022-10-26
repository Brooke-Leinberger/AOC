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
            //Console.WriteLine("Result: " + Day1.execute(WebCsv(Console.ReadLine())));
            string[] input = WebCsv("https://adventofcode.com/2021/day/1/input");
            Console.WriteLine(Day1.part2(input));
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

        public static string[] ConsoleCsv(uint num = 0, char delimiter = '\n')
        {
            string lastLine;
            List<string> lines = new List<string>();

            for (int i = 0; i < num || num == 0; i++)
            {
                if(delimiter == '\n')
                   lastLine = Console.ReadLine();
                
                else
                {
                    char ch;
                    lastLine = "";
                    while ((ch = (char)Console.Read()) != delimiter)
                    {
                        lastLine += ch;
                    }
                }
                
                if (lastLine == "end" || lastLine == "")
                    break;

                lines.Append(lastLine);
            }

            return lines.ToArray();
        }
    }
}