using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using System.Text.RegularExpressions;

public static class Toolbox {
    static bool enabled = true;

    public static void Log(string message) {
        if (!enabled) { return; }

        //StackFrame frame = new StackFrame(1);
        //MethodBase method = frame.GetMethod();
        //string tag = method.DeclaringType.ToString();

        //UnityEngine.Debug.Log(tag + ": " + message);
    }

    public static Sprite LoadSprite(string spriteName) {
        Sprite sprite = Resources.Load<Sprite>(spriteName);
        return sprite;
    }

    public static GameObject Create(string resourceName) {
        GameObject newGO = Resources.Load<GameObject>(resourceName);
        if (newGO == null) {
            newGO = Resources.Load<GameObject>("Mock");
        }

        newGO = UnityEngine.Object.Instantiate(newGO);
        newGO.name = resourceName;
        return newGO;
    }

    public static GameObject Create(string resourceName, Vector3 position) {
        GameObject newGO = Create(resourceName);
        newGO.transform.position = position;
        return newGO;
    }

    public static bool NearlyEqual(double a, double b, double epsilon) {
        double absA = Math.Abs(a);
        double absB = Math.Abs(b);
        double diff = Math.Abs(a - b);

        if (a == b) {
            // shortcut, handles infinities
            return true;
        }
        else if (a == 0 || b == 0 || diff < Double.Epsilon) {
            // a or b is zero or both are extremely close to it
            // relative error is less meaningful here
            return diff < epsilon;
        }
        else {
            // use relative error
            return diff / (absA + absB) < epsilon;
        }
    }

    public static bool NearlyEqualZero(double a) {
        return NearlyEqual(a, 0, 0.00001f);
    }

    public static bool IsVectorValid(Vector3 vector) {
        return !float.IsNaN(vector.x) && !float.IsNaN(vector.y) && !float.IsNaN(vector.z);
    }

    private static Regex patternAlphaNumSpecialChar = new Regex("[0-9a-zA-Z._^%$#!~@,-?*'’\"]");
    public static string PadString(string completeString, string currentString) {
        String remainingString = completeString.Substring(currentString.Length);
        String remainingStringScrubbed = patternAlphaNumSpecialChar.Replace(remainingString, "\u00a0");
        return currentString + remainingStringScrubbed;
    }
}
