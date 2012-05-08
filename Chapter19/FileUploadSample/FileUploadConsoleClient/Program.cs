﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadConsoleClient {

    class Program {

        static void Main(string[] args) {

            const string uploadServiceBaseAddress = "http://localhost:33761/api/upload";

            Console.WriteLine(@"Write the file path. E.g. c:\files\foo.txt");
            var filePath = Console.ReadLine();

            try {

                using (HttpClient httpClient = new HttpClient()) {

                    using (var fileStream = File.Open(filePath, FileMode.Open)) {

                        var fileInfo = new FileInfo(filePath);

                        var content = new MultipartFormDataContent();
                        content.Add(
                            new StreamContent(fileStream), "\"file\"",
                            string.Format("\"{0}\"", fileInfo.Name)
                        );

                        Console.WriteLine("Uploading...");
                        var response =
                            httpClient.PostAsync(uploadServiceBaseAddress, content).Result;

                        response.EnsureSuccessStatusCode();

                        Console.WriteLine(
                            "{0} file inside {1} directory has been uploaded!", fileInfo.Name, fileInfo.DirectoryName
                        );
                        Console.WriteLine("Status Code: {0}", response.StatusCode);
                        Console.WriteLine("Response headers: ");
                        foreach (var header in response.Content.Headers) {
                            Console.WriteLine("{0}: {1}", header.Key, header.Value);
                        }
                    }
                }

            } catch (Exception ex) {

                Console.WriteLine("An error occured while trying to upload the file.");
                Console.WriteLine("Error message: ");
                Console.WriteLine(ex.Message);
            }
        }
    }
}