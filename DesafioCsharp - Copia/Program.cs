using System;
using System.Linq;
using System.Management.Automation;

using DesafioCsharp.Model;


var dirRoot = "C:\\Users\\disrct\\Desktop\\";
//var delimitador = @"C:\Users\disrct\";

using var ps = PowerShell.Create();
var ls = Directory.EnumerateDirectories(dirRoot, "*", SearchOption.AllDirectories);

foreach (var item in ls)
{
    if(item.EndsWith(@".git"))
    {
        //string[] partes = item.Split(new string[] { delimitador }, StringSplitOptions.None);      
        string resultado = item.Split(@"\.git")[0];
        string address = resultado.Replace(@"\", "/");
        Console.WriteLine(address);

        ps
            .AddCommand("cd")
            .AddArgument(address)
            .Invoke();
        ps.Commands.Clear();

        System.Console.WriteLine("cd");

        ps  
            .AddCommand("git")
            .AddArgument("pull")
            .Invoke();
        ps.Commands.Clear();

        System.Console.WriteLine("git pull ");

        ps
            .AddCommand("git")
            .AddArgument("add .")
            .Invoke();
        ps.Commands.Clear();

        System.Console.WriteLine("git add");

        ps
            .AddCommand("git")
            .AddArgument("commit -m \"teste\"")
            .Invoke();
        ps.Commands.Clear();

        System.Console.WriteLine("git commit");

        ps
            .AddCommand("git")
            .AddArgument("push")
            .Invoke();
        ps.Commands.Clear();

        System.Console.WriteLine("git push");
    }
}





// void AddFiles()
// {
//     var dirRoot = "C:\\Users\\disrct\\Desktop\\";
//     string[] subDiretorios = Directory.GetDirectories(dirRoot);

//     foreach (var item in subDiretorios)
//     {
//         var query =
//             INSERT INTO FilesGit(FileNameS, FilesAddress) VALUES ($"{item}","{item}");
//     }
// }

// subDiretorios.ToList().ForEach(d => {Console.WriteLine(d)});

// var fullPath = Path.Combine(dirRoot, "PASTADOCNPJ");
// fileNames = Directory.GetFiles(fullPath , "*.xml");

// using var ps = PowerShell.Create();

// ps
//     .AddCommand("git")
//     .AddArgument("pull")
//     .AddArgument("https://github.com/trevisharp/pamella");

// var result = ps.Invoke();