using System;
using ColourApi.Controllers;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using ColourApi.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace ColourApi.Test
{
    public class ValuesControllerTest
    {
        private ValuesController testee;
        Mock<ILogger<ValuesController>> logger;
        Mock<ColourContext> context;

        public ValuesControllerTest()
        {
            this.context = new Mock<ColourContext>();
            this.logger = new Mock<ILogger<ValuesController>>();
            this.testee = new ValuesController(this.context.Object, this.logger.Object);    
        }

        [Fact]
        public void GetColorItemsShouldReturnColours()
        {
            var mockSet = new Mock<DbSet<Colour>>();
            mockSet.Setup(x => x.AddRange(new [] { new Colour{ ColourName = "red"}, new Colour{ ColourName = "green"} }));
            var mockContext = new Mock<ColourContext>();
            mockContext.Setup(m => m.ColourItems).Returns(mockSet.Object);

            var result = this.testee.GetColorItems();
        }

        [Fact]
        public void GetColorByNumber1ShouldReturnColourRed()
        {
            var result = this.testee.GetColorItem(1);

            Assert.Equal("red", result.Value.ColourName);
        }
    }
}
