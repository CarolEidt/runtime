// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

readonly struct LargeStruct
{
    public readonly long l0;
    public readonly long l1;
    public readonly long l2;
    public readonly long l3;
}

readonly struct LargeStruct2
{
    public readonly LargeStruct _largeStruct;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LargeStruct2(LargeStruct largeStruct)
    {
        _largeStruct = largeStruct;
    }
}

public class Runtime_12219
{
    static int Main(string[] args)
    {
        InlinedAssignment();
        InlinedCtor();
        return 100;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static long InlinedAssignment()
    {
        var s = CreateLargeStruct();
        s = GetLargeStruct(s);

        return s.l3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static long InlinedCtor()
    {
        var s = new LargeStruct2(CreateLargeStruct());

        return s._largeStruct.l3;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static LargeStruct GetLargeStruct(LargeStruct l) => l;

    [MethodImpl(MethodImplOptions.NoInlining)]
    static LargeStruct CreateLargeStruct() => new LargeStruct();
}
