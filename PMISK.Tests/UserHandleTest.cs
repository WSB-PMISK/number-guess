using System.Runtime.CompilerServices;
using Moq;

namespace PMISK.Tests;

public class UserHandleTest
{
    
    [Fact]
    public void AskTest() {
        var input = "  input  ";
        var expectedResult = "input";

        var mockUserHandle = new Mock<IHandler>();
        mockUserHandle.Setup(line => line.ReadLine()).Returns(input);

        var userHandler = new UserHandler(mockUserHandle.Object);
        
        Assert.Equal(userHandler.Ask("q"), expectedResult);
        mockUserHandle.Verify(mock => mock.ReadLine(), Times.Once);
    }

    [Theory]
    [InlineData(new string[] {"test", "choice"}, "test\nchoice")]
    public void GetChoiceListTest(string[] choices, string expectedResult) {
        var handler = new Handler();
        var userHandler = new UserHandler(handler);
        Assert.Equal(userHandler.GetChoiceList(choices), expectedResult);
    }
}