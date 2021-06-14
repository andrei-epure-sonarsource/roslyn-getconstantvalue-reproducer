# roslyn-getconstantvalue-reproducer
Reproducer project for a bug in the Roslyn SemanticModel.GetConstantValue() API.

How to reproduce:
- on a Windows machine, you need to have the .NET compiler platform SDK workload installed and be able to run a VSIX project (experimental VS instance)
- open the `Reproducer.sln` solution and run it
- in the newly spawned experimental VS instance, open the `Sample/Sample.sln` solution, and open the `Program.cs` file.

Notice the "Repro" Roslyn warnings in the Error List window are the same with the ones in the comments.
