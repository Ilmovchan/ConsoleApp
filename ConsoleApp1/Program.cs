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
        string str = null;

        string str1 = "no";

        str1 ??= "new";

        int[] arr = null;

        Console.WriteLine(arr?.Sum()); 
    }



}

