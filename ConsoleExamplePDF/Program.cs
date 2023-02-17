// See https://aka.ms/new-console-template for more information
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;

Console.WriteLine("Hello, World!");

var rs = new LocalReporting()
    .UseBinary(JsReportBinary.GetBinary())
    .AsUtility()
    .Create();

var report = await rs.RenderAsync(new RenderRequest
{
    Template = new Template
    {
        Recipe = Recipe.ChromePdf,
        Engine = Engine.None,
        Content = "<style> h1 { color : red } </style> <h1> Hello world </h1>"
    }
});

using ( var fs = File.Create("Out.pdf"))
{
    report.Content.CopyTo(fs);
}