namespace UserControllerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            // Act
            var controller = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);


        }
    }
}