# BinaryExtensions
![BinaryExtensions](BinaryExtensions.png)

[![NuGet](https://img.shields.io/badge/nuget-latest-blue.svg)](https://www.nuget.org/packages/BinaryExtensions)
[![NuGet](https://img.shields.io/badge/nuget-1.0.6896.28656-blue.svg)](https://www.nuget.org/packages/BinaryExtensions/1.0.6896.28656)

Types and extension methods to deal with binary data.

## Features

- read primitives in any endianness using `Read` and `TryRead` extension methods for `BinaryReader` and `byte[]`

## CHANGELOG

10/2/2020
- switching to .NET Standard **(not everything has been back ported, yet)**
- better NuGet package with sources and symbols
- now using T4 templates for code generation
- version bump to 1.0.2
- new icon

11/18/2018
- seamless reading of integral types in big-endian or little-endian format, environment endianness being irrelevant
- functions are exposed as extension methods for `BinaryReader` and all integral types
- endian-aware integral types, just declare structs and read them in one go with `ReadStruct<T>`
- a `LoggedBinaryReader` that logs read and unread regions, very useful when deciphering some complex file format
