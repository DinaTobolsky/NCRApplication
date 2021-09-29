using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Automation;

namespace NCRAutomation
{
    [TestClass]
    public class UnitTest1
    {
        MainPage mainPage;
        [TestMethod]
        public void TxtboxEmptyTest()
        {
            mainPage = new MainPage();
            mainPage.clickOnOkBtn();
            Assert.IsTrue(mainPage.getAlertFromLabel().Equals("you have to type letters."));
        }

        [TestMethod]
        public void TextTooLongTest()
        {
            mainPage = new MainPage();
            mainPage.SetValueOnTxtbox("asdfgmkmvtk1111111111111vstvsrt");
            mainPage.clickOnOkBtn();
            Assert.IsTrue(mainPage.getAlertFromLabel().Equals("Text too long."));
        }

        [TestMethod]
        public void TextContainsNotNumericTavTest()
        {
            mainPage = new MainPage();
            mainPage.SetValueOnTxtbox("asdfg$#&*t");
            mainPage.clickOnOkBtn();
            Assert.IsTrue(mainPage.getAlertFromLabel().ToString().Equals("You can type only letter or digits."));
        }

        [TestMethod]
        public void TextContainsNotNumericTavAndLongTxtTest()
        {
            mainPage = new MainPage();
            mainPage.SetValueOnTxtbox("asdfg$222222222222555555555#&*t");
            mainPage.clickOnOkBtn();
            Assert.IsTrue(mainPage.getAlertFromLabel().Equals("Text too long.You can type only letter or digits."));
        }

        [TestMethod]
        public void MessageBoxOpenTest()
        {
            mainPage = new MainPage();
            mainPage.SetValueOnTxtbox("dgdrhedh");
            mainPage.clickOnOkBtn();
            Assert.IsTrue(ElementHelper.waitForElement(mainPage.MessageBox));
        }

        [TestMethod]
        public void MessageBoxContentTest()
        {
            mainPage = new MainPage();
            string message = "dgdrhedh";
            mainPage.SetValueOnTxtbox(message);
            mainPage.clickOnOkBtn();
            Assert.IsTrue(mainPage.MessageBoxContent().Equals(message));
        }

        [TestMethod]
        public void IsWindowAppearsTest()
        {
            AutomationElement win = null;
            AutomationElement ae = AutomationElement.RootElement;
            //PropertyCondition prop = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);
            PropertyCondition propName = new PropertyCondition(AutomationElement.NameProperty, "mainWin");
            //AndCondition andCondition = new AndCondition(prop, propName);
            win = ae.FindFirst(TreeScope.Descendants, propName);
            Assert.IsNull(win);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if(BasePage.process!=null)
                BasePage.process.Kill();
        }
    }
}
