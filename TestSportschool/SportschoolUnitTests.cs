using sportschool.Data;
using sportschool.Models;

namespace TestSportschool;

[TestClass]
public class SportschoolUnitTests
{
    public class TestCursusBound
    {
        public int userId;
        public string cursusName;
        public TestCursusBound(int userId, string cursusName)
        {
            this.userId = userId;
            this.cursusName = cursusName;
        }
    }
    [TestMethod]
    public void ApiReturnsListOfUsers()
    {
        var actualUsers = DataSportschool.users;
        Assert.IsNotNull(actualUsers);
        Assert.AreSame(DataSportschool.users, actualUsers);
    }
    [TestMethod]
    public void ApiDoesntRecognizeUser()
    {
        int fakeUserId = 4;
        var user = DataSportschool.users.FirstOrDefault(u => u.Id == fakeUserId);
        Assert.IsNull(user, "User doesn't exists");
    }
    [TestMethod]
    public void ApiReturnsUser()
    {
        int realUserId = 0;
        var user = DataSportschool.users.FirstOrDefault(u => u.Id == realUserId);
        Assert.AreEqual(user, DataSportschool.users.First());
    }
    [TestMethod]
    public void UserSchrijftInVoorCursus()
    {
        TestCursusBound testCursusBound = new TestCursusBound(1, "Pilates");
        var user = DataSportschool.users.FirstOrDefault(u => u.Id == testCursusBound.userId);
        var gevondenCursus = DataSportschool.cursussen.FirstOrDefault(c => c.Name == testCursusBound.cursusName);
        gevondenCursus.Users.Add(user);
        Assert.AreEqual(user, gevondenCursus.Users.Last());
    }
}
