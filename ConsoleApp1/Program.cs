using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO.Pipes;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Buffers;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Net;
using System.Diagnostics;
using System.Globalization;

class Program
{

    static void Main()
    {

        Math.Sum<int>(5,3,5,6,1,2);

    }
}

class Math
{
    public static T Sum<T>(params T[] parameters)
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(double))
        {
            return default;
        }
        else throw Exception(null);
    }
}

