using System.Diagnostics;
using Task1.Helpers;
using Task1.Services;

var text = FileHelper.ReadFile("Documents//Война и мир.txt");

Stopwatch stopwatch = new Stopwatch();

//Single thread execution
stopwatch.Start();
var st = new WordStatistics();
st.GetTextStatisticFile(text, "WordStatSingleThread.txt");
stopwatch.Stop();

Console.WriteLine("[Single thread] Execution time: " + stopwatch.Elapsed.TotalMilliseconds + " ms");

//Parallel execution
stopwatch.Reset();
stopwatch.Start();
var stParallel = new WordStatisticsParallel();
stParallel.GetTextStatisticFile(text, "WordStatMultiThread.txt");
stopwatch.Stop();

Console.WriteLine("[Parallel execution] Execution time: " + stopwatch.Elapsed.TotalMilliseconds + " ms");
Console.ReadLine();