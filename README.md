# BinaryExtensions
Extension methods for BinaryReader and BinaryWriter.

[![NuGet](https://img.shields.io/badge/nuget-latest-blue.svg)](https://www.nuget.org/packages/BinaryExtensions)

## Features

- Seamless reading of integral types in big-endian or little-endian format, environment endianness being irrelevant
- Functions are exposed as extension methods for `BinaryReader` and all integral types

## Requirements

.NET Framework 4.6.1

## Roadmap

- Equivalent features for `BinaryWriter`
- More bit-level related functions
- Applicable paradigms from [Boost.Endian](http://www.boost.org/doc/libs/1_59_0/libs/endian/doc/index.html)
