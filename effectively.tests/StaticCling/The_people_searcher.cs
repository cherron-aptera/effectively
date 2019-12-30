namespace effectively.tests.StaticCling
{
	using effectively.StaticCling;
	using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
	public class The_people_searcher
	{

		[TestFixture]
		public class when_querying
		{
			[Test]
			public void can_query()
			{
				Database.Instance = new TestableDatabase();
				var ps = new PeopleSearcher();
				ps.Search("Clint Herron");
			}

			[Test]
			public void logs_the_sql()
			{
				TestableLogger tl = new TestableLogger();
				Logger.Instance = tl;
				Database.Instance = new TestableDatabase();
				var ps = new PeopleSearcher();

				Assert.AreEqual(0, tl.LogMessages.Count);
				ps.Search("Clint Herron");
				Assert.AreEqual(1, tl.LogMessages.Count);
				Assert.AreEqual("select * from Person where Name like '%Clint Herron%'", tl.LogMessages[0]);
			}
		}
	}

	internal class TestableLogger : Logger
	{
		public List<string> LogMessages = new List<string>();

		public override void LogInternal(string message)
		{
			LogMessages.Add(message);
		}
	}

	internal class TestableDatabase : Database
	{
		protected override IEnumerable<T> DoQueryInternal<T>(string sql)
		{
			return null;
		}
	}
}
