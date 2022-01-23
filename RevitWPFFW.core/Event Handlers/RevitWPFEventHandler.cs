using Autodesk.Revit.UI;
using System;
using System.Reflection;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// This is an example of of wrapping a method with an ExternalEventHandler using a string argument.
    /// Any type of argument can be passed to the RevitEventWrapper, and therefore be used in the execution
    /// of a method which has to take place within a "Valid Revit API Context".
    /// Developed by Petr Mitev
    /// https://github.com/mitevpi/revit-wpf-template
    /// </summary>
    public class RevitWPFEventHandler : RevitEventWrapper<string>
    {
        /// <summary>
        /// The Execute override void must be present in all methods wrapped by the RevitEventWrapper.
        /// Execution takes string argument with defines method to be called
        /// Method currently does not allow for property arguments to be passed
        /// To be developed
        /// </summary>
        public override void Execute(UIApplication uiApp, string args)
        {
            //Get arguments from string
            WPFEventCommandArgs eventArgs = new WPFEventCommandArgs(args);

            //Locate type and method
            Type type = eventArgs.EventClass;
            MethodInfo method = eventArgs.Method;

            //Instantiate the class
            object classInstance = Activator.CreateInstance(type, null);

            //Invoke the called method
            method.Invoke(classInstance, null);

        }

    }
}
