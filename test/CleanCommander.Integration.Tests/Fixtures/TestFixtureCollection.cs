using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanCommander.Integration.Tests.Fixtures
{
    [CollectionDefinition("TestingCollection")]
    public class TestFixtureCollection : ICollectionFixture<TestingFixture>
    {
    }
}