using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JetBrains.dotMemoryUnit;
using MemoryLeakExample;

namespace MemoryTestExample.Test
{
    [TestClass]
    public class HelloTest
    {

        [TestMethod]
        [DotMemoryUnit(FailIfRunWithoutSupport = true)]
        public void HelloMemoryTest()
        {
            var hbm = new HelloBotManager();
            hbm.AddBot("Mike", 2);
            hbm.RemoveBot("Mike");

            dotMemory.Check(programMemory =>
                {

                    Console.WriteLine($"There are {programMemory.GetObjects(obs=>obs.Type.Is<HelloBot>()).ObjectsCount} HelloBots.");
                    Assert.AreEqual(0,programMemory.GetObjects(obs=>obs.Type.Is<HelloBot>()).ObjectsCount);
                });

        }
    }
}
