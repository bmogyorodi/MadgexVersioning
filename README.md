# MadgexVersioning

This application was made for an Interview for Madgex. The task was to make a console application that using the right input will increment the version number and save it to a file. The version number for this exercise has 4 components, the 3rd is incremented on a new "Feature", the 4th is incremented on a "Bug Fix".

## Versioning Application (console app)
Console application reads current version number from file ProductInfo.cs and allows user to input either "Feature" or "Bug Fix" (case ignored), which will increment the version number accordingly and save it to the ProductInfo.cs file.

## Versioning Testing (unit testing)

Contains unit testing for functions used for the console application. Tests so far cover:
* Unit tests for two kinds of version increments (Feature and Bug Fix)
* Testing File reading functionality
* Testing File Writting functionality
* Testing regex checking on version number (to make sure it's in the correct format)
