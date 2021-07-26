﻿
using System.Windows.Forms;
using HarmonyLib;
using hookmebyharmony;
using System.Reflection;

namespace TestDLL
{
    public class Class1
    {

        public static int TestMethod(string TestParam)
        {
            MessageBox.Show("Yay, C# DLL Injected Successfully!");
            MessageBox.Show(TestParam);
            var harmony = new Harmony("com.example.patch");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            return 0;
        }
    }



    [HarmonyPatch(typeof(Calculator))]
    [HarmonyPatch("Add")]

    class Patch01
    {
        static bool Prefix(ref int __result, int x, int y)
        {
            MessageBox.Show("prefix being executed");
            __result = x + y+99;
            return false; // skip the original
        }
    }

}


