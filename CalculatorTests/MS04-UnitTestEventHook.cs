using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
[TestClass]
public class UnitTestEventHook
{
    public UnitTestEventHook()
    {
        //
        // TODO:  在此加入建構函式的程式碼
        //
    }

    private TestContext testContextInstance;

    /// <summary>
    ///取得或設定提供目前測試回合
    ///的相關資訊與功能的測試內容。
    ///</summary>
    public TestContext TestContext
    {
        get
        {
            return testContextInstance;
        }
        set
        {
            testContextInstance = value;
        }
    }

    #region 其他測試屬性
    [AssemblyInitialize()]
    public static void AssemblyInit(TestContext context)
    {
        Console.WriteLine("AssemblyInit " + context.TestName);
    }

    [AssemblyCleanup()]
    public static void AssemblyCleanup()
    {
        Console.WriteLine("AssemblyCleanup");
    }

    //
    // 您可以使用下列其他屬性撰寫您的測試: 
    //
    // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
    [ClassInitialize()]
    public static void MyClassInitialize(TestContext testContext)
    {
        Console.WriteLine("ClassInitialize" + testContext.TestName);
    }
    //
    // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
    [ClassCleanup()]
    public static void MyClassCleanup()
    {
        Console.WriteLine("ClassCleanup");
    }
    //
    // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼 
    [TestInitialize()]
    public void MyTestInitialize()
    {
        Console.WriteLine("TestInitialize" + this.TestContext.TestName);
    }
    //
    // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
    [TestCleanup()]
    public void MyTestCleanup()
    {
        Console.WriteLine("TestCleanup" + this.TestContext.TestName);
    }
    //
    #endregion


    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine("TestMethod1");
    }

    [TestMethod]
    public void TestMethod2()
    {
        Console.WriteLine("TestMethod2");
    }
}