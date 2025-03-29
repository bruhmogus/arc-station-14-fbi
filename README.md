# Arcadis Station 14

Arcadis Station is a minor fork of Einstein Engines, previously a fork of Wizden, based on admin intervention and less of a pure focus on gameplay.

Einstein Engines is a hard fork of [Space Station 14](https://github.com/space-wizards/space-station-14) built around the ideals and design inspirations of the Baystation family of servers from Space Station 13 with a focus on having modular code that anyone can use to make the RP server of their dreams.
Our founding organization is based on a democratic system whereby our mutual contributors and downstreams have a say in what code goes into their own upstream.
If you are a representative of a former downstream of Delta-V, we would like to invite you to contact us for an opportunity to represent your fork in this new upstream.

Space Station 14 is inspired heavily by Space Station 13 and runs on [Robust Toolbox](https://github.com/space-wizards/RobustToolbox), a homegrown engine written in C#.

As a hard fork, any code sourced from a different upstream cannot be merged directly, and must instead be adapted and ported.
All code present in this repository is subject to change as desired by the council of maintainers.

## Links

[Simplestation Website](https://simplestation.org) (This is our server host!) | [Discord](https://discord.gg/edXJXjEMJm) | [Steam(SSMV Launcher)](https://store.steampowered.com/app/2585480/Space_Station_Multiverse/) | [Steam(WizDen Launcher)](https://store.steampowered.com/app/1255460/Space_Station_14/) | [Standalone](https://spacestationmultiverse.com/downloads/)

## Contributing

If you want to contribute just make a PR, we'll probably accept it if the other maintainers say it's chill.

## Building

Refer to [the Space Wizards' guide](https://docs.spacestation14.com/en/general-development/setup/setting-up-a-development-environment.html) on setting up a development environment for general information, but keep in mind that Einstein Engines is not the same and many things may not apply.
We provide some scripts shown below to make the job easier.

### Build dependencies

> - Git
> - .NET SDK 9.0.101


### Windows

> 1. Clone this repository
> 2. Run `git submodule update --init --recursive` in a terminal to download the engine
> 3. Run `Scripts/bat/buildAllDebug.bat` after making any changes to the source
> 4. Run `Scripts/bat/runQuickAll.bat` to launch the client and the server
> 5. Direct connect to localhost in the client and play

### Linux

> 1. Clone this repository
> 2. Run `git submodule update --init --recursive` in a terminal to download the engine
> 3. Run `Scripts/sh/buildAllDebug.sh` after making any changes to the source
> 4. Run `Scripts/sh/runQuickAll.sh` to launch the client and the server
> 5. Direct connect to localhost in the client and play

### MacOS

> I don't know anybody using MacOS to test this, but it's probably roughly the same steps as Linux

## License

Please read the [LEGAL.md](./LEGAL.md) file for information on the licenses of the code and assets in this repository.
