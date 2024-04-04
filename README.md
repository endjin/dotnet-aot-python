# .NET AOT and Python

A sample demonstrating how to use .NET 8.0 AOT to generate a native dll which can be called from Python.

## Background & Motivations

With a transition towards "intelligent apps", data, analytics and AI workloads, Python is becoming the de facto language data engineering, data science and AI engineering.

Many organisations have 20+ years of investment in .NET, and are looking to leverage their existing .NET IP investments, and employees skills in future data and AI workloads.

[Modular](https://www.modular.com) have [raised over $130m](https://techcrunch.com/2023/08/24/modular-raises-100m-for-ai-dev-tools/) (and generated significant buzz) to develop the [Mojo Language](https://www.modular.com/max/mojo) as a high performance alternative to Python, offering 68,000x performance improvement, which will offer an order of magnitude reduction in the cost of building AI models (code = compute = energy = cost = carbon). Mojo provides many features missing from Python; multi-threading, SIMD, Hardware Intrinsics etc... features which .NET has had for many years.

Organisations are slow-moving when it comes to making data platform bets; adopting a new platform is a major investment, and a major organisational transformation programme, and the ROI of these endeavours are often measured on a decade long timescale. A modern cloud native analytics platform is a foundational building block for any AI strategy. .NET doesn't feature in the biggest produce investment outside of AI - Microsoft Fabric, or in Azure Synapse Analytics, Databricks, or Snowflake.

As part of data modernisation programmes, organisations are also evaluating which languages they should invest in for computational modelling workloads. [C++, Rust, Go, Python, R, Julia, and .NET are often being benchmarked](https://github.com/milliman/julia_research_2023). Even though .NET is one of the fastest platforms, it is often discounted as because it is not perceived as a language for high performance compute, mathematical modelling, data engineering, data science and AI engineering (like Python or Julia). These same organisations have significant investments in .NET related to data formats, data validation and processing logic, business & domain logic, and algorithms.

.NET has been embraced by the gaming industry for [cross-platform](https://docs.unity3d.com/Manual/overview-of-dot-net-in-unity.html) performance and [ease of development](https://docs.godotengine.org/en/stable/contributing/development/compiling/compiling_with_dotnet.html). Neuroscience has embraced .NET for [intuitive visual](https://www.sainsburywellcome.org/web/blog/making-research-accessible-intuitive-visual-programming-language), [reactive](https://bonsai-rx.org/), real-time data processing, analytics and hardware control, and [machine learning](https://www.sainsburywellcome.org/web/blog/collaborating-toward-next-telescope-experimental-neuroscience).

What marketing / DevRel / code samples / new language and platform features are required to change this perception for computational modelling, data engineering, data science and AI engineering?

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

## Thoughts

There are a number of other efforts to enable .NET and Python interoperability:

- [IronPython](https://ironpython.net/) - focused on DLR & managed execution
- [Python.NET](https://pythonnet.github.io/) - focused on CPython

But both require the .NET runtime to be installed in the execution environment. These are not viable options for managed Spark Cluster environments, such as Azure Synapse Analytics, or Microsoft Fabric, where the cluster images are managed by the cloud provider, and LTS versions of .NET and Bring Your Own Runtime customisations (i.e. the model offered by GitHub Actions / Azure Pipelines) are not supported.

The ability to call .NET AOT from Python depends on the `UnmanagedCallersOnlyAttribute` Class, which comes with a number of [restrictions](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.unmanagedcallersonlyattribute?view=net-8.0#remarks).

If the ability to use .NET from Python is seen as something worthy of investment, improving the interop experience would be a great place to start. How can interop be improved? Can we use Source Generators to create idiomatic interop wrappers over .NET libraries (i.e. automatically convert from PascalCase to snake_case)? Could this source generated interop layer make calling a .NET library method from Python as simple as calling a Python method from Python - not having to marshal C type or use pointers to memory structures, or be limited to [blittable](https://learn.microsoft.com/en-us/dotnet/framework/interop/blittable-and-non-blittable-types) types? Rust uses macros ([bindgen](https://github.com/rust-lang/rust-bindgen) and [cbindgen](https://github.com/mozilla/cbindgen)). Could [DNNE](https://github.com/AaronRobinsonMSFT/DNNE) be an option for .NET?