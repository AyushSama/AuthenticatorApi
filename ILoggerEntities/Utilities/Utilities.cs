using ConfigReader.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ConfigReader
{
    public static class ExtensionMethods
    {
        public static List<string> AddLog(this List<string> Messages, string value, int LogLevel = (int)LogLevel.Method)
        {
            var frame = new StackTrace().GetFrame(1);
            int lineNumbers = frame.GetFileLineNumber();
            var caller = frame.GetMethod();
            string methodName = caller.Name;
            string className = caller.ReflectedType.Name;
            string layerName = caller.Module.Name;
            string paramValues = caller.GetParameters().ToString();
            int postlevel = LogLevel;
            if(Messages.Count>0)
                Messages[Messages.Count - 1] += "$" + DateTime.Now.ToString();
            Messages.Add(value + "$" + DateTime.Now.ToString() + "$" + layerName.Substring(0, layerName.LastIndexOf('.')) + "$" + className + "$" + methodName +"$" + paramValues + "$" + postlevel + "$" + lineNumbers) ;
            return Messages;
        }

        public static List<string> AddLog(this List<string> Messages, string value, string paramValues, int LogLevel = (int)LogLevel.Method)
        {
            var frame =new  StackTrace().GetFrame(1);
            var caller = frame.GetMethod();
            int lineNumbers = frame.GetFileLineNumber();
            string methodName = caller.Name;
            string className = caller.ReflectedType.Name;
            string layerName = caller.Module.Name;
            int postlevel = LogLevel;
            if (Messages.Count > 0)
                Messages[Messages.Count - 1] += "$" + DateTime.Now.ToString();
            Messages.Add(value + "$" + DateTime.Now.ToString() + "$" + layerName.Substring(0, layerName.LastIndexOf('.')) + "$" + className + "$" + methodName + "$" + paramValues + "$" + postlevel + "$" + lineNumbers);
            return Messages;
        }
        public static List<string> AddLog(this List<string> Messages, Exception value, StackFrame frame, int LogLevel = (int)LogLevel.Exception)
        {
            StackTrace trace = new StackTrace(value, true);
            MethodBase methods = frame.GetMethod();
            string classNames = methods.DeclaringType != null ? methods.DeclaringType.FullName : "UnknownClass";
            string methodNames = methods.Name;
            int lineNumbers = frame.GetFileLineNumber();
            string fileNames = frame.GetFileName();
            if (Messages.Count > 0)
                Messages[Messages.Count - 1] += "$" + DateTime.Now.ToString();
            Messages.Add(value.Message + "$" + DateTime.Now.ToString() + "$" + classNames.Substring(0, classNames.LastIndexOf('.')) + "$" + fileNames + "$" + methodNames + "$" + methods.GetParameters().ToString() + "$" + LogLevel + "$" + lineNumbers);
            return Messages;
        }
    }

}

