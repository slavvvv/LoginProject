#LoginForm

This is an automation framework for web application testing. 

##The project is created to demonstrate my current work experience in simple login form. 
It conains 19 tests they can running on cross browser Chrome,Firefox and IE.

LoginFormABV solution contains five projects:
1.ABV.Pages - it conains methods and elements.
2.ABV.Models - it conains Model.
3.LoginFormABV - it conains Factory.
4.ABV.Tests - it conains 19 tests they are divided into Positive, Negative and Crash tests.
5. Utilities - it conains global variables and constans values.

It is use: C#, Nunit, Selenium
The framework: Page Object Model
Design pattern: Factory and Model

##Instalation:
1.Visual Studion 2019
It have to install in ABV.Pages and ABV.Tests the following NuGet packages:
1.DotNetSeleniumExtras
2.Microsoft.NET.Test.Sdk
3.NETStandard.Library
4.NUnit
5.NUnit3TestAdapter
6.Selenium.InternetExplorer.Web
7.Selenium.Support
8.Selenium.WebDriver
9.Selenium.WebDriver.ChromeD
10.Selenium.WebDriver.GeckoDriver

Also you need to check the project references as follow

1.ABV.Factory with ABV.Models
2.ABV.Pages with  ABV.Factory  ABV.Models  Utilities
3.ABV.Tests with  ABV.Factory  ABV.Pages   Utilities

##Tests running instruction:

Tests can run one by one or all in one run.
Change browser in GlobalVariables. It can use  Chrome,Firefox and IE.

public static string BrowserType = "Chrome";

##I hope you like my project and to be useful.
