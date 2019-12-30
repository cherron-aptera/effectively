namespace effectively.tests.ExtractAndOverride
{
	using NUnit.Framework;
	using effectively.ExtractAndOverride;
	
	[TestFixture]
	public class The_order_service
	{
		[TestFixture]
		public class Given_the_current_user_is_invalid
		{
			[Test]
			public void The_order_cannot_be_placed()
			{
				var service = new OrderService();
				Assert.IsFalse(service.CanPlace(new Order()));
			}
		}

		[TestFixture]
		public class Given_the_current_user_is_valid
		{
			[TestFixture]
			public class and_the_order_amount_is_positive
			{
				[Test]
				public void The_order_can_be_placed()
				{
					var service = new ValidUserOrderService();
					Assert.IsTrue(service.CanPlace(new Order()));
				}
			}

			[TestFixture]
			public class and_the_order_amount_is_negative
			{
				[Test]
				public void The_order_cannot_be_placed()
				{
					var service = new ValidUserOrderService();
					Assert.IsFalse(service.CanPlace(new Order() { Amount = -1 })) ;
				}
			}
		}

		class ValidUserOrderService : OrderService
		{
			protected override UserService GetUserService()
			{
				return new UserService() { IsValidUser = true };
			}
		}
	}
}
