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
        Stopwatch sw = new Stopwatch();
        MyStruct a = new MyStruct();

        sw.Start();
        for (int i = 0; i < int.MaxValue; i++)
        {
            Foo(a);
        }
        sw.Stop();
        Console.WriteLine($"Foo: {sw.ElapsedMilliseconds}");

        sw.Restart();
        for (int i = 0; i < int.MaxValue; i++)
        {
            Bar(a);
        }
        sw.Stop();
        Console.WriteLine($"Bar: {sw.ElapsedMilliseconds}");

        sw.Restart();
        for (int i = 0; i < int.MaxValue; i++)
        {
            Ref(ref a);
        }
        sw.Stop();
        Console.WriteLine($"Ref: {sw.ElapsedMilliseconds}");
    }

    struct MyStruct
    {
        decimal a;
        decimal b;
        decimal c;
        decimal d;
        decimal e;
        decimal f;
        decimal g;
        decimal h;
        decimal i;
        decimal j;
        decimal k;
        decimal l;
    }

    static void Foo(MyStruct value)
    {

    }

    static void Bar(in MyStruct value)
    {

    }

    static void Ref(ref MyStruct value)
    {

    }

}

