using System;
using System.Collections.Generic;
using System.Data;
//using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace In91TddLab.Tests
{
    /// <summary>
    /// AssertSample 的摘要描述
    /// </summary>
    [TestClass]
    public class AssertSample
    {
        public AssertSample()
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

        //
        // 您可以使用下列其他屬性撰寫您的測試:
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion 其他測試屬性

        [TestMethod]
        public void Test_Order_Equals_by_Assert_Equals()
        {
            var expected = new Order
            {
                Id = 1,
                Price = 10,
            };

            var actual = new Order
            {
                Id = 1,
                Price = 10,
            };

            //this test will pass; when you override Equals(), AreEqual will invoke Order's Equals(), rather than Object's Equals()

            //驗證是否為同一個物件（相同）, 等同於 Assert.IsTrue(Object.RefrenceEquals(expected,actual))
            //測試失敗：比較記憶體位址
            //Assert.AreSame(expected, actual);

            //驗證兩個物件是否相等（相等）, 等同於 Assert.IsTrue(Object.Equals(a,b))
            //測試失敗：也是比較記憶體位址
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Person_Equals_with_ExpectedObjects()
        {
            var expected = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
            };

            var actual = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
            };

            Assert.Inconclusive();
        }

        [TestMethod]
        public void Test_PersonCollection_Equals_with_ExpectedObjects()
        {
            var expected = new List<Person>
			{
				new Person { Id=1, Name="A",Age=10},
				new Person { Id=2, Name="B",Age=20},
				new Person { Id=3, Name="C",Age=30},
			};

            var actual = new List<Person>
			{
				new Person { Id=1, Name="A",Age=10},
				new Person { Id=2, Name="B",Age=20},
				new Person { Id=3, Name="C",Age=30},
			};

            Assert.Inconclusive();
        }

        [TestMethod]
        public void Test_ComposedPerson_Equals_with_ExpectedObjects()
        {
            var expected = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
                Order = new Order { Id = 91, Price = 910 },
            };

            var actual = new Person
            {
                Id = 1,
                Name = "A",
                Age = 10,
                Order = new Order { Id = 91, Price = 910 },
            };

            Assert.Inconclusive();
        }

        [TestMethod]
        public void Test_PartialCompare_Person_Equals_with_ExpectedObjects()
        {
            var expected = new
            {
                Id = 1,
                Age = 10,
                Order = new Order { Id = 91 },
            };

            var actual = new Person
            {
                Id = 1,
                Name = "B",
                Age = 10,
                Order = new Order { Id = 91, Price = 910 },
            };

            Assert.Inconclusive();
        }

        [TestMethod]
        public void Test_DataTable_Equals_with_ExpectedObjects_and_ItemArray()
        {
            var expected = new DataTable();
            expected.Columns.Add("Id");
            expected.Columns.Add("Name");
            expected.Columns.Add("Age");

            expected.Rows.Add(1, "A", 10);
            expected.Rows.Add(2, "B", 20);
            expected.Rows.Add(3, "C", 30);

            var actual = new DataTable();
            actual.Columns.Add("Id");
            actual.Columns.Add("Name");
            actual.Columns.Add("Age");

            actual.Rows.Add(1, "A", 10);
            actual.Rows.Add(2, "B", 20);
            actual.Rows.Add(3, "C", 30);

            Assert.Inconclusive();
        }
    }

    internal class Person //Person didn't override Equals
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }

        public DateTime Birthday { get; set; }

        public Order Order { get; set; }
    }

    internal class Order
    {
        public int Price { get; set; }

        public int Id { get; set; }
    }

    //internal class Order : IEquatable<Order>
    //{
    //	public int Price { get; set; }

    //	public int Id { get; set; }

    //	// remind: when you override Equals(), you should override GetHashCode() too.
    //	public override bool Equals(object obj)
    //	{
    //		var order = obj as Order;
    //		if (order != null)
    //		{
    //			return this.Equals(order);
    //		}

    //		return false;
    //	}
    //	public bool Equals(Order other)
    //	{
    //		//define Equals of Order type between two Order instances
    //		return this.Id == other.Id && this.Price == other.Price;
    //	}
    //}
}