# xamarin-rest-template
This is a Xamarin template and .NET API project following best practices. This guide will outline how to use this code and remane major parts to make it your own.

### Best Practices
It has been written to ensure the following principles:

* Separation of concerns - each class should perform 1 task and 1 task only
* Testability - ensure that the code can be unit tested
* Maintainability - be able to make future changes without conern for big impact. Separation of concerns and testability assist with this
* Loose coupling - organize classes into interfaces allowing dependency injection to remove dependencies
* Code sharing - using xamarin.forms will share as much code as possible

### Renaming to make your own
Follow these steps to change the default name *xTemplate* to your own projects name (assuming you're using Visual Studio):

1. from the Solution Explorer right click and rename the solution
1. from the Solution Explorer right click and rename each project
1. for each project go to the project options / properties and change the default namespace, save
1. run a find and replace, replacing *xTemplate* with the new name
1. from the Solution Explorer for the Android and iOS projects remove the reference to the shared code project (was *xTemplate.Mobile* before rename) and then add it back
1. clean and build the solution
1. rename the root folder

### Git Branch Naming
I am using the following naming conventions for branches:

* __master__: production branch
* hotfix/branch-desc: branch created from __master__ to quickly fix an issue in production
* rel/branch-desc: branch created from a feature branch to be prepared for merge to __master__
* __develop__: development branch
* feat/branch-desc: branch created from __develop__ to add a new feature
* bug/branch-desc: branch created from __develop__ to fix a bug

### Code Explanation

##### Behaviors
Behaviors let you add functionality to user interface controls without having to subclass them. Instead of code behind, the functionality is implemented in a behavior class and attached to the control as if it was part of the control itself.
In this case these behaviors are being used when the menu items are tapped since this is the only way to catch the event.

##### Bootstrap
This is used for Inversion of Control (IoC) via the Nuget package Autofac.
https://autofac.org/

##### Constants
Classes containing application settings that remain constant for the build

##### Controls
Here we'll create custom renderer. For example we'll have a bindable property to turn a regular text entry box into one with rounded corners. This also requires the actual renderer to be defined in the Android and iOS project (see the Renderers folder)