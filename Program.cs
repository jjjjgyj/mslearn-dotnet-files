using System.IO;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);   

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
    
        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}

record SalesData (double Total);


// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory, "stores");

// var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
// Directory.CreateDirectory(salesTotalDir);     
// var salesFiles = FindFiles(storesDirectory);

// File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);


// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);
//         if (extension == ".json")
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }



// var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

// var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
// File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"\n{data.Total}");

// if (salesData != null)
// {
//     Console.WriteLine(salesData.Total);
// }
// else
// {
//     Console.WriteLine("Sales data is null.");
// }


// if (data != null)
// {
//     File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data.Total.ToString());
// }
// else
// {
//     Console.WriteLine("Data is null.");
// }

// totals.txt
// 22385.32

class SalesTotal
{
  public double Total { get; set; }
}


// totals.txt
// 22385.32
// 22385.32

// string content = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// Console.WriteLine(content);

// Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));

// bool doesDirectoryExist = Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "stores","201","newDir"));
// Console.WriteLine(doesDirectoryExist);

// File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
// bool doesFileExist = File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"));
// Console.WriteLine(doesFileExist);


// var salesFiles = FindFiles("stores");

// Console.WriteLine(Directory.GetCurrentDirectory());
// Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
// Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// Console.WriteLine(Path.Combine("stores","201")); // outputs: stores/201
// Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .json

// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
// FileInfo info = new FileInfo(fileName);
// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         // The file name will contain the full path, so only check the end of it
//         if (file.EndsWith("sales.json"))
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }