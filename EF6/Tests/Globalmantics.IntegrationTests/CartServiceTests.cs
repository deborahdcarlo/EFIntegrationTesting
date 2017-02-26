﻿using FluentAssertions;
using Globalmantics.DAL;
using Globalmantics.Logic;
using NUnit.Framework;
using System.Linq;

namespace Globalmantics.IntegrationTests
{
    [TestFixture]
    public class CartServiceTests
    {
        [Test]
        public void CartIsInitiallyEmpty()
        {
            var context = new GlobalmanticsContext();
            var userService = new UserService(context);
            var cartService = new CartService(context);

            var user = userService.GetUserByEmail("test@globalmantics.com");
            context.SaveChanges();

            var cart = cartService.GetCartForUser(user);
            context.SaveChanges();

            cart.CartItems.Count().Should().Be(0);
        }
    }
}