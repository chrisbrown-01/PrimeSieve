# SignalR-PrimeSieve

Simple project for experimenting with SignalR communication between seperate .NET projects.

A console application calculates prime numbers using the Sieve of Eratosthenes method. It then uses SignalR to stream each prime to an ASP.NET Core Razor page for displaying.

The web app contains the SignalR hub and displays the prime number results in real time as they are received.

Findings: 
- Executing the SignalR `connection.InvokeAsync` command for each prime severely slows down the console app (unsurprisingly). It would be wiser to stream the results in batches/arrays.
