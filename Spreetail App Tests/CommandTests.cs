using Spreetail_App;

namespace Spreetail_App_Tests
{
    [TestClass]
    public class CommandTests
    {
        private readonly Commands _mvDictionary;

        public CommandTests()
        {
            _mvDictionary = new Commands();
        }
        // ****** ADD ********
        [TestMethod]
        public void Add_New_Key_Success()
        {
            HashSet<string> colorHash = ["blue", "red"];
            var add = _mvDictionary.Add("colors", colorHash);
            Assert.AreEqual(Messages.Added, add);
        }

        [TestMethod]
        public void Add_No_Key_Provided_Err()
        {
            var noKeyRes = _mvDictionary.Add("", new HashSet<string>());
            Assert.AreEqual(Messages.ErrorNoKeyProvided, noKeyRes);
        }

        [TestMethod]
        public void Add_No_Member_Provided_Err()
        {
            var noMemberRes = _mvDictionary.Add("colors", new HashSet<string>());
            Assert.AreEqual(Messages.ErrorNoMemberProvided, noMemberRes);
        }

        [TestMethod]
        public void Add_No_Member_Exists_Err()
        {
            HashSet<string> colorHash1 = ["blue"];
            HashSet<string> colorHash2 = ["blue"];
            _mvDictionary.Add("colors", colorHash1);
            var memberExists = _mvDictionary.Add("colors", colorHash2);
            Assert.AreEqual(Messages.ErrorMemberExists, memberExists);
        }

        [TestMethod]
        public void Add_Multiple_Success()
        {
            HashSet<string> colorHash1 = ["blue", "red"];
            var add = _mvDictionary.Add("colors", colorHash1);
            Assert.AreEqual(Messages.Added, add);

            HashSet<string> colorHash2 = ["green", "yellow"];
            var add2 = _mvDictionary.Add("colors", colorHash2);
            Assert.AreEqual(Messages.Added, add2);
        }

        [TestMethod]
        public void Add_Member_Exists_Err()
        {
            HashSet<string> colorHash1 = ["blue", "red"];
            _mvDictionary.Add("colors", colorHash1);

            HashSet<string> colorHash2 = ["green", "red"];
            var add2 = _mvDictionary.Add("colors", colorHash2);
            Assert.AreEqual(Messages.ErrorMemberExists, add2);
        }

        // ******** KEYS *********
        [TestMethod]
        public void Keys_No_Dictionary_Err()
        {
            var result = _mvDictionary.Keys();
            Assert.AreEqual(Messages.EmptySet, result);
        }

        [TestMethod]
        public void Keys_Success()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);

            HashSet<string> carHash = ["ford"];
            _mvDictionary.Add("car", carHash);

            var result = _mvDictionary.Keys();
            Assert.AreEqual("1) colors" + Environment.NewLine + "2) car", result);

        }

        // ******** MEMBERS *********
        [TestMethod]
        public void Members_No_Key_Provided_Err()
        {
            var result = _mvDictionary.Members("");
            Assert.AreEqual(Messages.ErrorNoKeyProvided, result);
        }

        [TestMethod]
        public void Members_No_Key_Exists_Err()
        {
            var result = _mvDictionary.Members("bad");
            Assert.AreEqual(Messages.ErrorNoKeyExists, result);
        }

        [TestMethod]
        public void Members_Success()
        {
            HashSet<string> colorHash = ["blue", "green"];
            _mvDictionary.Add("colors", colorHash);

            var result = _mvDictionary.Members("colors");
            Assert.AreEqual("1) blue" + Environment.NewLine + "2) green", result);
        }

        // ******** REMOVE *********
        [TestMethod]
        public void Remove_No_Key_Provided_Err()
        {
            var result = _mvDictionary.Remove("", new HashSet<string>());
            Assert.AreEqual(Messages.ErrorNoKeyProvided, result);
        }

        [TestMethod]
        public void Remove_No_Member_Provided_Err()
        {
            var result = _mvDictionary.Remove("colors", new HashSet<string>());
            Assert.AreEqual(Messages.ErrorNoMemberProvided, result);
        }

        [TestMethod]
        public void Remove_No_Key_Exists_Err()
        {
            HashSet<string> colorHash = ["blue"];
            var result = _mvDictionary.Remove("bad", colorHash);
            Assert.AreEqual(Messages.ErrorNoKeyExists, result);
        }

        [TestMethod]
        public void Remove_Too_Many_Members_Err()
        {
            HashSet<string> colorHash = ["blue", "green"];
            _mvDictionary.Add("colors", colorHash);
            var result = _mvDictionary.Remove("colors", colorHash);
            Assert.AreEqual(Messages.ErrorTooManyMembers, result);
        }

        [TestMethod]
        public void Remove_No_Member_Exists_Err()
        {
            HashSet<string> colorHash = ["blue", "green"];
            _mvDictionary.Add("colors", colorHash);
            HashSet<string> removeHash = ["red"];
            var result = _mvDictionary.Remove("colors", removeHash);
            Assert.AreEqual(Messages.ErrorNoMemberExists, result);
        }

        [TestMethod]
        public void Remove_Success()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);
            var result = _mvDictionary.Remove("colors", colorHash);
            Assert.AreEqual(Messages.Removed, result);
        }

        // ******** REMOVE ALL *********
        [TestMethod]
        public void RemoveAll_No_Key_Provided_Err()
        {
            var result = _mvDictionary.RemoveAll("");
            Assert.AreEqual(Messages.ErrorNoKeyProvided, result);
        }

        [TestMethod]
        public void RemoveAll_No_Key_Exists_Err()
        {
            var result = _mvDictionary.RemoveAll("bad");
            Assert.AreEqual(Messages.ErrorNoKeyExists, result);
        }

        [TestMethod]
        public void RemoveAll_Success()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);
            var result = _mvDictionary.RemoveAll("colors");
            Assert.AreEqual(Messages.Removed, result);
        }

        // ******** CLEAR *********
        [TestMethod]
        public void Clear_Success()
        {
            var result = _mvDictionary.Clear();
            Assert.AreEqual(Messages.Cleared, result);
        }

        // ******** KEYEXISTS *********
        [TestMethod]
        public void KeyExists_No_Key_Provided_Err()
        {
            var result = _mvDictionary.KeyExists("");
            Assert.AreEqual(Messages.ErrorNoKeyProvided, result);
        }

        [TestMethod]
        public void KeyExists_False()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);
            var result = _mvDictionary.KeyExists("bad");
            Assert.AreEqual(Messages.False, result);
        }

        [TestMethod]
        public void KeyExists_True()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);
            var result = _mvDictionary.KeyExists("colors");
            Assert.AreEqual(Messages.True, result);
        }

        // ******** MEMBEREXISTS *********
        [TestMethod]
        public void MemberExists_No_Key_Provided_Err()
        {
            var result = _mvDictionary.MemberExists("", new HashSet<string>());
            Assert.AreEqual(Messages.ErrorNoKeyProvided, result);
        }

        [TestMethod]
        public void MemberExists_No_Member_Provided_Err()
        {
            var result = _mvDictionary.MemberExists("bad", new HashSet<string>());
            Assert.AreEqual(Messages.ErrorNoMemberProvided, result);
        }

        [TestMethod]
        public void MemberExists_Too_Many_Members_Err()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);
            HashSet<string> tooManyHash = ["blue", "red"];
            var result = _mvDictionary.MemberExists("colors", tooManyHash);
            Assert.AreEqual(Messages.ErrorTooManyMembers, result);
        }

        [TestMethod]
        public void MemberExists_True()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);
            var result = _mvDictionary.MemberExists("colors", colorHash);
            Assert.AreEqual(Messages.True, result);
        }

        [TestMethod]
        public void MemberExists_False()
        {
            HashSet<string> colorHash = ["blue"];
            _mvDictionary.Add("colors", colorHash);
            HashSet<string> carHash = ["ford"];
            var result = _mvDictionary.MemberExists("colors", carHash);
            Assert.AreEqual(Messages.False, result);
        }

        // ******** ALLMEMBERS *********
        [TestMethod]
        public void AllMembers_Empty_Err()
        {
            var result = _mvDictionary.AllMembers();
            Assert.AreEqual(Messages.EmptySet, result);
        }

        [TestMethod]
        public void AllMembers_Success()
        {
            HashSet<string> colorHash = ["blue", "red"];
            _mvDictionary.Add("colors", colorHash);
            var result = _mvDictionary.AllMembers();
            Assert.AreEqual("1) blue" + Environment.NewLine + "2) red", result, result);
        }

        // ******** ITEMS *********
        [TestMethod]
        public void Items_Err()
        {
            var result = _mvDictionary.Items();
            Assert.AreEqual(Messages.EmptySet, result);
        }

        [TestMethod]
        public void Items_Success()
        {
            HashSet<string> colorHash = ["blue", "red"];
            _mvDictionary.Add("colors", colorHash);
            HashSet<string> carHash = ["ford", "chevy"];
            _mvDictionary.Add("cars", carHash);
            var result = _mvDictionary.Items();
            Assert.AreEqual("1) colors: blue" + Environment.NewLine + "2) colors: red" + Environment.NewLine + "3) cars: ford" + Environment.NewLine + "4) cars: chevy", result);
        }
    }
}