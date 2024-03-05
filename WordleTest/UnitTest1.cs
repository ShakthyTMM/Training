using WordleGame;
namespace WordleTest {
   [TestClass]
   public class UnitTest1 {
      /// <summary>Tests the wordle implementation</summary>
      [TestMethod]
      public void WordleTest () {
         mW.SelectWord ();
         mW.SecretWord = "CHAIN";
         foreach (var tries in mInputs) {
            foreach (var word in tries) {
               foreach (var ch in word)
                  mW.UpdateGameState ((ConsoleKey)ch);
               mW.UpdateGameState (ConsoleKey.Enter);
            }
            mW.IsTest = true;
            mW.DisplayBoard ();
         }
         Assert.IsTrue (mW.CheckTextFilesEqual ("c:/etc/wordletest.txt", "TestData/wordleref.txt"));
      }

      Wordle mW = new ();
      List<string[]> mInputs = new () { new string[] { "APPLE", "LEARN", "TRAIN", "CHAIR", "PEARL", "CHAIN" },
                                     new string[] { "APPLE", "CHAIR", "PEARL", "CHAIN" },
                                     new string[] { "CHAIR", "PEARL", "CHAIN" } };
   }
}