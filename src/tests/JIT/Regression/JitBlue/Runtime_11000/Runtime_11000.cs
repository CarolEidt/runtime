// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using System.Runtime.CompilerServices;

struct moo
{
    public void foo() => Console.WriteLine();
}

struct boo
{
    public void foo() => default(moo).foo();
}

public static class Runtime_11000
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Test1()
    {
        default(moo).foo();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Test2()
    {
        default(boo).foo(); // worse codegen
    }

    static int Main()
    {    
        Test1();
        Test2();
        return 100;
    }
}
