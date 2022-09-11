using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using CScan.Standard.Static;

namespace Test.Standard.Static;

internal static class StaticScannerTest
{
    private static string Ip { get; } = "";
    internal static void Test()
    {
        // Start <Scan test>

        bool result = TcpScanner.Scan(Ip, 8080, 500);
        Console.WriteLine(result);

        bool result2 = TcpScanner.Scan(IPAddress.Parse(Ip), 443, 500);
        Console.WriteLine(result2);

        bool result3 = TcpScanner.Scan(IPEndPoint.Parse($"{Ip}:443"), 500);
        Console.WriteLine(result3);

        // End <Scan test>

        Console.WriteLine();

        // Start <ScanList test>

        int[] PortsArray = { 8080, 12, 443, 78 };
        List<int> PortsList = new() { 8080, 12, 443, 78 };
        ArrayList PortsArrayList = new() { 8080, 12, 443, 78 };

        Dictionary<int, bool> dict = TcpScanner.ScanList(Ip, PortsArray, 500);

        foreach (var element in dict)
        {
            Console.WriteLine($"{element.Key}: {element.Value}");
        }

        Console.WriteLine();

        Dictionary<int, bool> dict2 = TcpScanner.ScanList(IPAddress.Parse(Ip), PortsArray, 500);

        foreach (var element in dict2)
        {
            Console.WriteLine($"{element.Key}: {element.Value}");
        }

        Console.WriteLine();

        Dictionary<int, bool> dict3 = TcpScanner.ScanList(Ip, PortsList, 500);
        foreach (var element in dict3)
        {
            Console.WriteLine($"{element.Key}: {element.Value}");
        }

        Console.WriteLine();

        Dictionary<int, bool> dict4 = TcpScanner.ScanList(IPAddress.Parse(Ip), PortsList, 500);
        foreach (var element in dict4)
        {
            Console.WriteLine($"{element.Key}: {element.Value}");
        }

        Console.WriteLine();

        Dictionary<int, bool> dict5 = TcpScanner.ScanList(Ip, PortsArrayList, 500);
        foreach (var element in dict5)
        {
            Console.WriteLine($"{element.Key}: {element.Value}");
        }

        Console.WriteLine();

        Dictionary<int, bool> dict6 = TcpScanner.ScanList(IPAddress.Parse(Ip), PortsArrayList, 500);
        foreach (var element in dict6)
        {
            Console.WriteLine($"{element.Key}: {element.Value}");
        }

        // End <ScanList test>
    }
}

