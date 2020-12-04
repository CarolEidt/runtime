// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public unsafe class Runtime_11992
{
    public void* p;

    public struct MyStruct
    {
        public byte a, b;
        public MyStruct(byte x, byte y)
        {
            a = x;
            b = y;
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void WriteShort(short x)
    {
        *(short*)p = x;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void WriteUShort(ushort x)
    {
        *(ushort*)p = x;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void WriteChar(char x)
    {
        *(char*)p = x;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void WriteShort_TakeRefAndDeref(short x)
    {
        *(short*)p = *&x;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void WriteStruct_Direct(MyStruct x)
    {
        *(MyStruct*)p = x;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void WriteStruct_ByShort(MyStruct x)
    {
        *(short*)p = *(short*)&x;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void WriteStruct_ByUShort(MyStruct x)
    {
        *(ushort*)p = *(ushort*)&x;
    }

    static int Main()
    {
        int i = 1;
        Runtime_11992 r = new Runtime_11992();
        r.p = &i;
        MyStruct s = new MyStruct(2, 3);
        r.WriteShort(4);
        r.WriteUShort(5);
        r.WriteChar('a');
        r.WriteShort_TakeRefAndDeref(6);
        r.WriteStruct_Direct(s);
        r.WriteStruct_ByShort(s);
        r.WriteStruct_ByUShort(s);
        return 100;
    }
}
