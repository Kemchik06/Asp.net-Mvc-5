using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // ����������� (arrange)
            //Mock<IGameRepository> mock = new Mock<IGameRepository>();
            //mock.Setup(m => m.Games).Returns(new List<Game>
            //{
            //    new Game { GameId = 1, Name = "����1"},
            //    new Game { GameId = 2, Name = "����2"},
            //    new Game { GameId = 3, Name = "����3"},
            //    new Game { GameId = 4, Name = "����4"},
            //    new Game { GameId = 5, Name = "����5"}
            //});
            //GameController controller = new GameController(mock.Object);
            //controller.pageSize = 3;

            //// �������� (act)
            //IEnumerable<Game> result = (IEnumerable<Game>)controller.List(2).Model;

            //// ����������� (assert)
            //List<Game> games = result.ToList();
            //Assert.IsTrue(games.Count == 2);
            //Assert.AreEqual(games[0].Name, "����4");
            //Assert.AreEqual(games[1].Name, "����5");
        }
    }
    }
}
