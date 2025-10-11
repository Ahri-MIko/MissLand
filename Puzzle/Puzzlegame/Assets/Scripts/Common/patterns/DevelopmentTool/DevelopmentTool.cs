using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopmentTool
{
    public static void WTF(string message)
    {
        Debug.LogFormat($"WTF:<color=#ff0000> --->   {message}   <--- </color>");
    }

    public static void Print(string message,string source)
    {
        Debug.Log(source +":"+ message);
    }
}