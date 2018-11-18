# BinaryExtensions
Extension methods for BinaryReader and BinaryWriter.

[![NuGet](https://img.shields.io/badge/nuget-latest-blue.svg)](https://www.nuget.org/packages/BinaryExtensions)

## Features

- seamless reading of integral types in big-endian or little-endian format, environment endianness being irrelevant
- functions are exposed as extension methods for `BinaryReader` and all integral types
- endian-aware integral types, just declare structs and read them in one go with `ReadStruct<T>`
- a `LoggedBinaryReader` that logs read and unread regions, very useful when deciphering some complex file format

## Requirements

At least .NET Framework 4.6.1.
