using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSGOL; 

namespace CSGOL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GridInitTest()
        {
            Controller controller = new Controller();
            Model model = new Model(controller);
            controller.Model.StartGrid(50);

            Assert.IsNotNull(model.cellGrid);
        }
    }
}
