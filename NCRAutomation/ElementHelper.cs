using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace NCRAutomation
{
    public class ElementHelper
    {
        public static void ClickButton(AutomationElement element)
        {
            InvokePattern invokePattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;

            invokePattern.Invoke();
        }

        public static AutomationElement FindElementByControlType(AutomationElement parentElement, ControlType type)
        {
            PropertyCondition typeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, type);

            return parentElement.FindFirst(TreeScope.Children, typeCondition);
        }

        public static AutomationElement FindElementById(AutomationElement parentElement, string automationID, ControlType type)
        {
            PropertyCondition typeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, type);

            PropertyCondition IDCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, automationID);

            AndCondition andCondition = new AndCondition(typeCondition, IDCondition);

            return parentElement.FindFirst(TreeScope.Children, andCondition);
        }

        public static AutomationElement FindElementById(AutomationElement parentElement, string automationID)
        {
            PropertyCondition IDCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, automationID);

            return parentElement.FindFirst(TreeScope.Children, IDCondition);
        }

        public static AutomationElement FindWindowByName(AutomationElement rootElement, string name, ControlType type)
        {
            PropertyCondition nameCondition = new PropertyCondition(AutomationElement.NameProperty, name);

            PropertyCondition typeCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, type);

            AndCondition andCondition = new AndCondition(nameCondition, typeCondition);

            return  rootElement.FindFirst(TreeScope.Children, andCondition);
        }

        public static string GetText(AutomationElement element)
        {
            string content = string.Empty;

            TextPattern txtPattern = element.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (txtPattern != null)
            {
                content = txtPattern.DocumentRange.GetText(-1);
            }

            return content;
        }
        
        public static void SetValue(AutomationElement element, string newValue)
        {
            ValuePattern valuePattern = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;

            valuePattern.SetValue(newValue);
        }

        public static bool waitForElement(Func<AutomationElement> element, int secondsToWait = 200)
        {
            //SpinWait.SpinUntil(() => element.), 10000);
            var timeout = new TimeSpan(0, 0, secondsToWait);
            var sw = new Stopwatch();
            bool found = false;

            sw.Start();
            while (!found && sw.ElapsedMilliseconds < timeout.TotalMilliseconds)
            {
                element();
                if (element!=null)
                {
                    found = true;
                }
                else
                {
                    Thread.Sleep(500);
                }
            }
            if (!found)
            {
                throw new Exception("Following element wasn't exist on time");
            }
            return true;
        }
    }
}
