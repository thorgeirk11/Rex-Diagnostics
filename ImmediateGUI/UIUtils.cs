﻿using System;
using System.Collections.Generic;
using Rex.Utilities;
using Rex.Utilities.Helpers;
using UnityEditor;
using UnityEngine;

namespace Rex.Window
{
    public static class UIUtils
    {
        public static string SyntaxHighlingting(IEnumerable<Syntax> syntax)
        {
            if (EditorGUIUtility.isProSkin)
                return Utils.SyntaxHighlingting(syntax, Utils.SyntaxHighlightColors);
            else
                return Utils.SyntaxHighlingting(syntax, Utils.SyntaxHighlightProColors);
        }

        internal static string SyntaxHighlingting(MemberDetails details, string search)
        {
            if (EditorGUIUtility.isProSkin)
                return Utils.SyntaxHighlingting(details, Utils.SyntaxHighlightColors, search);
            else
                return Utils.SyntaxHighlingting(details, Utils.SyntaxHighlightProColors, search);
        }


        public static void BackColor(Color color, Action controlsToPaint)
        {
            var prevColor = GUI.backgroundColor;
            GUI.backgroundColor = color;

            controlsToPaint();

            GUI.backgroundColor = prevColor;
        }

        public static void TextColor(Color color, Action controlsToPaint)
        {
            var prevColor = GUI.color;
            GUI.color = color;

            controlsToPaint();

            GUI.color = prevColor;
        }

        /// <summary>
        /// EditorToggle with clickable text to open and close.
        /// </summary>
        /// <param name="expanded">Should be open or cloesed</param>
        /// <param name="content">Content of the toggle.</param>
        /// <returns></returns>
        public static bool Toggle(bool expanded, GUIContent content)
        {
            var name = "__" + content.text + "_Toggle";
            GUI.SetNextControlName(name);
            // Display foldout
            EditorGUILayout.Foldout(expanded, content);
            if (GUI.GetNameOfFocusedControl() == name)
            {
                GUI.FocusControl(null);
                return !expanded;
            }
            return expanded;
        }

    }
}
