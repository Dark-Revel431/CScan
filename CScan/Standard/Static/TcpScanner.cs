using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace CScan.Standard.Static;

/// <summary>
/// Class that allows you to scan ports using static methods.
/// </summary>
public static class TcpScanner
{
    /// <summary>
    /// Scan a port of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="port">
    /// The port to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for the scan.
    /// </param>
    /// <returns>
    /// Returns true if the port is open, otherwise false.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static bool Scan(string ip, int port, int millisecondsTimeout = -1)
    {
        TcpClient client = new();

        try
        {
            var task = client.ConnectAsync(ip, port);
            task.Wait(millisecondsTimeout);

            bool connected = client.Connected;
            client.Close();

            return connected;
        }
        catch (AggregateException)
        {
            client.Close();

            return false;
        }
        catch (SocketException)
        {
            throw new SocketException();
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException();
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException();
        }
        catch (ObjectDisposedException)
        {
            throw new ObjectDisposedException("client");
        }
    }
    /// <summary>
    /// Scan a port of a specific IP address.
    /// </summary>
    /// <param name="endPoint">
    /// The host IPEndPoint.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for the scan.
    /// </param>
    /// <returns>
    /// Returns true if the port is open, otherwise false.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static bool Scan(IPEndPoint endPoint, int millisecondsTimeout = -1)
    {
        TcpClient client = new();

        try
        {
            var task = client.ConnectAsync(endPoint);
            task.Wait(millisecondsTimeout);

            bool connected = client.Connected;
            client.Close();

            return connected;
        }
        catch (AggregateException)
        {
            client.Close();

            return false;
        }
        catch (SocketException)
        {
            throw new SocketException();
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException();
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException();
        }
        catch (ObjectDisposedException)
        {
            throw new ObjectDisposedException("client");
        }
    }
    /// <summary>
    /// Scan a port of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="port">
    /// The port to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for the scan.
    /// </param>
    /// <returns>
    /// Returns true if the port is open, otherwise false.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static bool Scan(IPAddress ip, int port, int millisecondsTimeout = -1)
    {
        TcpClient client = new();

        try
        {
            var task = client.ConnectAsync(ip, port);
            task.Wait(millisecondsTimeout);

            bool connected = client.Connected;
            client.Close();

            return connected;
        }
        catch (AggregateException)
        {
            client.Close();

            return false;
        }
        catch (SocketException)
        {
            throw new SocketException();
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentNullException();
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException();
        }
        catch (ObjectDisposedException)
        {
            throw new ObjectDisposedException("client");
        }
    }
    /// <summary>
    /// Scan a list of ports of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="ports">
    /// The ports to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for each single scan.
    /// </param>
    /// <returns>
    /// Returns a dictionary that contains the result of the scan.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static Dictionary<int, bool> ScanList(string ip, int[] ports, int millisecondsTimeout = -1)
    {
        Dictionary<int, bool> result = new();

        foreach (int port in ports)
        {
            using TcpClient client = new();
            try
            {
                var task = client.ConnectAsync(ip, port);
                task.Wait(millisecondsTimeout);

                bool connected = client.Connected;
                client.Close();

                result.Add(port, connected);
            }
            catch (AggregateException)
            {
                client.Close();

                result.Add(port, false);
            }
            catch (SocketException)
            {
                throw new SocketException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
            catch (ObjectDisposedException)
            {
                throw new ObjectDisposedException("client");
            }
        }

        return result;
    }
    /// <summary>
    /// Scan a list of ports of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="ports">
    /// The ports to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for each single scan.
    /// </param>
    /// <returns>
    /// Returns a dictionary that contains the result of the scan.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static Dictionary<int, bool> ScanList(IPAddress ip, int[] ports, int millisecondsTimeout = -1)
    {
        Dictionary<int, bool> result = new();

        foreach (int port in ports)
        {
            using TcpClient client = new();
            try
            {
                var task = client.ConnectAsync(ip, port);
                task.Wait(millisecondsTimeout);

                bool connected = client.Connected;
                client.Close();

                result.Add(port, connected);
            }
            catch (AggregateException)
            {
                client.Close();

                result.Add(port, false);
            }
            catch (SocketException)
            {
                throw new SocketException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
            catch (ObjectDisposedException)
            {
                throw new ObjectDisposedException("client");
            }
        }

        return result;
    }
    /// <summary>
    /// Scan a list of ports of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="ports">
    /// The ports to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for each single scan.
    /// </param>
    /// <returns>
    /// Returns a dictionary that contains the result of the scan.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static Dictionary<int, bool> ScanList(string ip, List<int> ports, int millisecondsTimeout = -1)
    {
        Dictionary<int, bool> result = new();

        foreach (int port in ports)
        {
            using TcpClient client = new();
            try
            {
                var task = client.ConnectAsync(ip, port);
                task.Wait(millisecondsTimeout);

                bool connected = client.Connected;
                client.Close();

                result.Add(port, connected);
            }
            catch (AggregateException)
            {
                client.Close();

                result.Add(port, false);
            }
            catch (SocketException)
            {
                throw new SocketException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
            catch (ObjectDisposedException)
            {
                throw new ObjectDisposedException("client");
            }
        }

        return result;
    }
    /// <summary>
    /// Scan a list of ports of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="ports">
    /// The ports to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for each single scan.
    /// </param>
    /// <returns>
    /// Returns a dictionary that contains the result of the scan.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static Dictionary<int, bool> ScanList(IPAddress ip, List<int> ports, int millisecondsTimeout = -1)
    {
        Dictionary<int, bool> result = new();

        foreach (int port in ports)
        {
            using TcpClient client = new();
            try
            {
                var task = client.ConnectAsync(ip, port);
                task.Wait(millisecondsTimeout);

                bool connected = client.Connected;
                client.Close();

                result.Add(port, connected);
            }
            catch (AggregateException)
            {
                client.Close();

                result.Add(port, false);
            }
            catch (SocketException)
            {
                throw new SocketException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
            catch (ObjectDisposedException)
            {
                throw new ObjectDisposedException("client");
            }
        }

        return result;
    }
    /// <summary>
    /// Scan a list of ports of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="ports">
    /// The ports to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for each single scan.
    /// </param>
    /// <returns>
    /// Returns a dictionary that contains the result of the scan.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static Dictionary<int, bool> ScanList(string ip, ArrayList ports, int millisecondsTimeout = -1)
    {
        Dictionary<int, bool> result = new();

        foreach (int port in ports)
        {
            using TcpClient client = new();
            try
            {
                var task = client.ConnectAsync(ip, port);
                task.Wait(millisecondsTimeout);

                bool connected = client.Connected;
                client.Close();

                result.Add(port, connected);
            }
            catch (AggregateException)
            {
                client.Close();

                result.Add(port, false);
            }
            catch (SocketException)
            {
                throw new SocketException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
            catch (ObjectDisposedException)
            {
                throw new ObjectDisposedException("client");
            }
        }

        return result;
    }
    /// <summary>
    /// Scan a list of ports of a specific IP address.
    /// </summary>
    /// <param name="ip">
    /// The host IP address.
    /// </param>
    /// <param name="ports">
    /// The ports to scan.
    /// </param>
    /// <param name="millisecondsTimeout">
    /// The milliseconds timeout for each single scan.
    /// </param>
    /// <returns>
    /// Returns a dictionary that contains the result of the scan.
    /// </returns>
    /// <exception cref="SocketException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ObjectDisposedException"></exception>
    public static Dictionary<int, bool> ScanList(IPAddress ip, ArrayList ports, int millisecondsTimeout = -1)
    {
        Dictionary<int, bool> result = new();

        foreach (int port in ports)
        {
            using TcpClient client = new();
            try
            {
                var task = client.ConnectAsync(ip, port);
                task.Wait(millisecondsTimeout);

                bool connected = client.Connected;
                client.Close();

                result.Add(port, connected);
            }
            catch (AggregateException)
            {
                client.Close();

                result.Add(port, false);
            }
            catch (SocketException)
            {
                throw new SocketException();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
            catch (ObjectDisposedException)
            {
                throw new ObjectDisposedException("client");
            }
        }

        return result;
    }
}