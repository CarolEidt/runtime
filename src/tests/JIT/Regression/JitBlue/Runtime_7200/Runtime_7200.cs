// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.CompilerServices;

struct TestStruct
{
    public float Value;
    //public int Value;
}
class TestClass
{
    public TestStruct Field;
    public TestStruct Property { get; set; }
}
class Program
{

    static int Main(string[] args)
    {
        TestClass testClass = new TestClass();
        TestFieldSetters(testClass, new TestStruct() { Value = 5 });
        TestPropSetters(testClass, new TestStruct() { Value = 3 });
        TestFieldGetters(testClass);
        TestPropGetters(testClass);
        return 100;
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void TestFieldSetters(TestClass testClass, TestStruct testStruct)
    {
        testClass.Field = testStruct;
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void TestPropSetters(TestClass testClass, TestStruct testStruct)
    {
        testClass.Property = testStruct;
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void TestFieldGetters(TestClass testClass)
    {
        Print(testClass.Field);
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void TestPropGetters(TestClass testClass)
    {
        Print(testClass.Property);
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Print(TestStruct testStruct)
    {
        Console.WriteLine(testStruct.Value);
    }
}
