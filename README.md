# .NET AOT and Python

A sample demonstrating how to use .NET 8.0 AOT to generate a native dll which can be called from Python.

## Background & Motivations

With a transition towards "intelligent apps", data, analytics and AI workloads, Python is becoming the de facto language data engineering, data science and AI engineering. 

Many organisations have 20+ years of investment in .NET, and are looking to leverage their existing .NET IP investments, and employees skills in future data and AI workloads.

[Modular](https://www.modular.com) have raised over $130m (and generated significant buzz) to develop the [Mojo Language](https://www.modular.com/max/mojo) as a high performance alternative to Python, offering 68,000x performance improvement, which will offer an order of magnitude reduction in the cost of building AI models (code = compute = energy = cost). Mojo provides many features missing from Python; multi-threading, SIMD, Hardware Intrinsics etc... features which .NET has had for many years.

Organisations are slow moving when it comes to making data platform bets; adopting a new platform is a major investment, and a major organisational transformation programme, and the ROI of these endeavours are often measured on a decade long timescale. A modern cloud native analytics platform is a foundational building block for any AI strategy.

## Run demo

**To run on Windows**, in a terminal, run `build.ps1`. You will need to have the .NET 8.0 SDK installed, the "Desktop development with C++" workload installed in Visual Studio, and a Python distribution available on your PATH. The build script will create a `win-x64` library.

**To run on Linux**, open the devcontainer in VS Code and run `build.ps1`. The build script will create a `linux-x64` library.

## Experiments

This proof of concept contains a series of experiments to see what is possible:

- [x] Can we call a .NET AOT compiled dll from Python? (use [ctypes](https://docs.python.org/3/library/ctypes.html))
- [x] Can we pass in integer, perform a operation and return an integer?
- [x] Can we pass in a string, and call a .NET library ([Spectre.Console](https://github.com/spectreconsole/spectre.console))
- [ ] Can we do file operations?
- [ ] Can we pass in an array?
- [ ] Can we pass in a pandas dataframe?
- [ ] Can we package in a `.whl` file?
- [ ] Can we deploy the `.whl` file to Azure Synapse Analytics and run?
- [ ] Can we deploy the `.whl` file to Microsoft Fabric and run?