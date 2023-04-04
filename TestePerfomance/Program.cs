using BenchmarkDotNet.Running;
using TestePerfomance;
using TestePerfomance.Helpers;

Console.WriteLine("Aperte qualquer tecla para iniciar os Testes de Perfomance");

Console.ReadLine();

var resultadoJson =
   BenchmarkRunner.Run<JsonHelper>();

var resultadoCriptografia =
   BenchmarkRunner.Run<CriptografiaHelper>();

var resultadoService =
   BenchmarkRunner.Run<ServiceDemo>();
