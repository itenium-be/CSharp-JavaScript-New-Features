# Point releases

Faster releases with TC49-TG2: C#. (Task Group 2)

Different process compared to TC39:  
- Active
- Inactive
- Rejected
- csharp-X: Feature is merged

A new feature can come from Github issue discussions, a Language Design Meeting
or from some other front.  
The "Language Design Team" will also assign a Champion to each feature.


Using them features
===================

## Set it in your csproj file

Instead of targetting a specific `LangVersion`, you can also use `latest`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <LangVersion>7.1</LangVersion>
  </PropertyGroup>
</Project>
```

## Inside Visual Studio

Solution Explorer > Select a Project > Right Click "Properties" (or Alt + Enter)  
Build tab > Advanced... > Pick your "Language version".


## For entire solution

Create a `Directory.build.props` in the root solution folder to set it for every subdirectory.

```xml
<Project>
 <PropertyGroup>
   <LangVersion>7.3</LangVersion>
 </PropertyGroup>
</Project>
```

## CLI parameter

```ps
# List available options
csc -langversion:?

# Use one
csc -langversion:7
```
