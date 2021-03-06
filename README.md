# BinaryExtensions
![BinaryExtensions](BinaryExtensions.png)

[![NuGet](https://img.shields.io/badge/nuget-latest-blue.svg)](https://www.nuget.org/packages/BinaryExtensions)

Types and extension methods to deal with binary data.

## Features

- read primitives in any endianness using `Read` and `TryRead` extension methods for `BinaryReader` and `byte[]`
- a logged stream that logs read and written regions in a wrapped stream
  - e.g. reverse-engineering a file format and find what's currently been unexplored in the file by your logic

## CHANGELOG

1.1.2 (11/19/2020)
- added BinaryReader.ReadToEnd method
- fixed LogStream.GetRegionsReadIntersect that was returning empty regions for fully read streams
- added tests project
- enforced C# 8.0 version so project can still be used in Unity
- using internal annotations to prevent conflicts, e.g. when using UnityEngine.CoreModule in non-Unity projects
- don't include XML documentation in repository

1.1.1 (10/2/2020)
- publishing release configuration instead

1.1.0 (10/2/2020)
- **breaking changes**
  - not overloading `System.IO` namespace anymore
  - not everything has been back ported yet
  - switching to .NET Standard 2.1
- better NuGet package with sources and symbols
- now using T4 templates for code generation
- version bump to 1.1.0
- new icon

1.0.* (11/18/2018)
- seamless reading of integral types in big-endian or little-endian format, environment endianness being irrelevant
- functions are exposed as extension methods for `BinaryReader` and all integral types
- endian-aware integral types, just declare structs and read them in one go with `ReadStruct<T>`
- a `LoggedBinaryReader` that logs read and unread regions, very useful when deciphering some complex file format
