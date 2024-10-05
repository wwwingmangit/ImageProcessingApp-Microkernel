# ImageProcessingApp-Microkernel

[This project was initially presented on my LinkedIn, here](https://www.linkedin.com/feed/update/urn:li:activity:7248077512725917699/)

## Overview

ImageProcessingApp-Microkernel is a flexible and extensible image processing application built using the Microkernel Architecture. Developed with C# and .NET Core, the application allows users to upload images and apply various processing plugins such as grayscale filtering, horizontal inversion, and AI automatic text analysis (image to text). The modular design ensures that new functionalities can be seamlessly integrated as plugins without altering the core system, promoting scalability and maintainability.

## Architecture

The application is structured around the Microkernel Architecture, where the Core System serves as the minimal backbone handling essential functionalities like the user interface, plugin management, and workflow orchestration. Specific image processing tasks are encapsulated within Plugins, which adhere to predefined interfaces (IImagePlugin and ITextPlugin). These plugins are dynamically loaded at runtime, enabling the application to extend its capabilities without requiring significant changes to the core.

![MicroKernel Architecture](https://github.com/wwwingmangit/ImageProcessingApp-Microkernel/raw/main/ImagesForREADME/MicroKernelArchitecture.png)

## Core System Components:

* User Interface (UI): Built with ASP.NET Core MVC and styled using Bootstrap, the UI allows users to upload images, select processing plugins, and view results.
* Plugin Loader: A dynamic loader that discovers and integrates external plugins from the Plugins directory at runtime.
* Plugin Interfaces: Defined in a separate class library (PluginInterfaces), these interfaces (IImagePlugin and ITextPlugin) ensure consistency and compatibility across all plugins.

## Plugins:

* Grayscale Filter Plugin: Applies a grayscale filter to uploaded images using the SixLabors.ImageSharp library.
* Horizontal Inversion Plugin: Inverts images horizontally, also leveraging SixLabors.ImageSharp.
* AI Text Analysis Plugin: Calls an OLLAMA server using LLAVA model to extract text description from an image input.

## Pros:

* Extensibility: New features can be added as separate plugins without modifying the core system, allowing for easy scalability.
* Maintainability: The core remains lightweight and focused on essential tasks, simplifying maintenance and reducing complexity.
* Isolation: Plugins operate independently, ensuring that failures or issues in one plugin do not impact the core system or other plugins.
* Flexibility: Users can customize the application's functionality by enabling or disabling specific plugins based on their needs.

## Cons:

* Complex Plugin Management: Implementing dynamic loading and ensuring seamless integration between the core and various plugins can be intricate.
* Performance Overhead: The abstraction layers and dynamic loading mechanisms may introduce slight performance penalties compared to a monolithic design.
* Dependency Handling: Managing dependencies across multiple plugins requires careful coordination to prevent version conflicts and ensure compatibility.
* Testing Challenges: Comprehensive testing is necessary to verify that all plugins interact correctly with the core system and maintain overall system stability.

## Technologies Used

* Programming Language: C#
* Framework: .NET Core 8.0
* Web Framework: ASP.NET Core MVC
* Image Processing Library: SixLabors.ImageSharp
* Styling Framework: Bootstrap 4
* Version Control: GitHub
* External server: OLLAMA using Llava model (7.2B parameters)

## Plugin Development

work in progress...
