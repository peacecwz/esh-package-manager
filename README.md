# ESH Package Manager

.NET & .NET Core package manager (like a Nuget Package Manager) tool from git sources. It's working like a NPM. You can install git repository as a package referance to projects. Easily install, update, build and more actions

## CLI Support

### Install with Global Tools (.NET Core 2.1 SDK Support)

You can install esh tool globally with .NET Core 2.1 SDK

```
dotnet tool install esh --global
```

#### Commands

ESH Tool supports limited commands. It's preview version

|Name|Parameters|Description|Example|
|--------------|-------------|-------------|-------------------------|
|list| - | List of esh packages | `esh list`
|install| git repository url | Install package from git repository | `esh install https://github.com/peacecwz/package-name` 
|add| git repository url | Add package from local git repository | `esh add ./libs/test.csproj`
|update| [Optional] packageName or git repository url | Update esh package(s) from git repository | `esh update`, `esh update package-name`, `esh update https://github.com/peacecwz/package-name` 
|remove| packageName or git repository url | Remove esh package from project | `esh remove package-name`, `esh remove https://github.com/peacecwz/package-name`
|build| - | Build esh packages in the project | `esh build`
|restore| - | Restore esh packages in the project | `esh restore`

## Visual Studio IDE Support

Coming soon...

## Visual Studio Code 

Coming soon...


## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue

## License

I couldn't decide yet but this project is licensed under the MIT License for now :)

