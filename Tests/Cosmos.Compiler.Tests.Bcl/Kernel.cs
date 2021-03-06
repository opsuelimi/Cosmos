﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Debug.Kernel;
using Cosmos.TestRunner;
using Sys = Cosmos.System;

namespace Cosmos.Compiler.Tests.Bcl
{
    using Cosmos.Compiler.Tests.Bcl.System;

    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Starting BCL tests now please wait...");
        }

        protected override void Run()
        {
            try
            {
                mDebugger.Send("Run");

                CSharp.WhileLoopTests.Execute();

                //ObjectTests.Execute(); Stack corruption on method Clone()
                StringTest.Execute();
                ByteTest.Execute();
                SByteTest.Execute();
                Int16Test.Execute();
                UInt16Test.Execute();
                Int32Test.Execute();
                UInt32Test.Execute();
                Int64Test.Execute();
                UInt64Test.Execute();
                CharTest.Execute();
                BooleanTest.Execute();
                SingleTest.Execute();
                DoubleTest.Execute();
                BitConverterTest.Execute();
                UnsafeCodeTest.Execute();
                DelegatesTest.Execute();

#if false
                DecimalTest.Execute();
                System.Collections.Generic.ListTest.Execute();
                System.Collections.Generic.QueueTest.Execute();
                System.UInt64Test.Execute();
#endif
                TestController.Completed();
            }
            catch (Exception e)
            {
                mDebugger.Send("Exception occurred: " + e.Message);
                mDebugger.Send(e.Message);
                Console.WriteLine("Exception occurred");
                Console.WriteLine(e.Message);
                TestController.Failed();
            }
        }
    }
}
