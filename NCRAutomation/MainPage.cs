using System.Windows.Automation;

namespace NCRAutomation
{
    public class MainPage:BasePage
    {
        public AutomationElement OkButton() => ElementHelper.FindElementById(mainWindow, "btnOk", ControlType.Button);
        
        public void clickOnOkBtn()
        {
            ElementHelper.waitForElement(OkButton);
            ElementHelper.ClickButton(OkButton());
        }
        public AutomationElement TextTxtbox() => ElementHelper.FindElementById(mainWindow, "txtbox");

        public void SetValueOnTxtbox(string txt)
        {
            ElementHelper.waitForElement(TextTxtbox);
            ElementHelper.SetValue(TextTxtbox(), txt);
        }
        public AutomationElement AlertLabel() => ElementHelper.FindElementById(mainWindow, "lblAlert");

        public string getAlertFromLabel()
        {
            ElementHelper.waitForElement(AlertLabel);
            return AlertLabel().GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
        }

        public AutomationElement MessageBox() => ElementHelper.FindElementByControlType(mainWindow, ControlType.Window);

        public string MessageBoxContent()
        {
            AutomationElement MessageBoxContent = ElementHelper.FindElementByControlType(MessageBox(), ControlType.Text);
            return MessageBoxContent.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
        }

    }
}
