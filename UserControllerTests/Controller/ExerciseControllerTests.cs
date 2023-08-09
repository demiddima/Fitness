using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.UserControllerTests
{
    [TestClass()]
    public class ExerciseControllerTests
    {

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var controller = new UserController(userName);
            var exController = new ExerciseController(controller.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));
            var start = DateTime.Now;
            var finish = DateTime.Now.AddHours(1);
            //Act
            exController.Add(activity, start, finish);
            //Assert
            Assert.AreEqual(activityName, exController.Activities.First().Name);
        }
    }
}