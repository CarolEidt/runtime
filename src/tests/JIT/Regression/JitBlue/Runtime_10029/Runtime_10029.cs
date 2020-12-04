// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

class Program
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Quaternion Normalize(Quaternion value)
    {
        Vector4 q = Unsafe.As<Quaternion, Vector4>(ref value);
        q = Vector4.Normalize(q);
        return Unsafe.As<Vector4, Quaternion>(ref q);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Quaternion Normalize_New()
    {
        Quaternion start = new Quaternion(8.5f, 9.4f, 1.2f, 1f);

        Quaternion c1 = Normalize(start);
        Quaternion c2 = Normalize(c1);
        Quaternion c3 = Normalize(c2);
        return Normalize(c3);
    }
    static int Main(string[] args)
    {
        Quaternion q = Normalize_New();
        Console.WriteLine(q);
        return 100;
    }
}
