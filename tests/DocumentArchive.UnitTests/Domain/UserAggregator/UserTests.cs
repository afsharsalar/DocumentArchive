using DocumentArchive.Domain.UserAggregator;

using FluentAssertions;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentArchive.UnitTests.Domain.UserAggregator
{
    public class UserTests
    {
        [Fact]
        public void create_should_initialize_correctly()
        {
            //arrange & act
            var user=new User();

            //assert
            user.Should().NotBeNull();
            user.GetType().Should().Be(typeof(User));
        }
    }
}
