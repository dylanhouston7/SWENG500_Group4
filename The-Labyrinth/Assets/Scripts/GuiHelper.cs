using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// A class to assist with creating GUI elements
    /// </summary>
    public class GuiHelper
    {
        /// <summary>
        /// Creates a GUIStyle object that can be used for labels
        /// </summary>
        /// <param name="fontSize">The size of the font</param>
        /// <param name="font">The font style</param>
        /// <returns>A GUIStyle that encapsulates font information</returns>
        public static GUIStyle CreateGuiStyle(int fontSize, Font font)
        {
            // TODO: Add more options in this method.
            GUIStyle guiStyle = new GUIStyle(); //create a new variable
            guiStyle.fontSize = fontSize;
            guiStyle.font = font;

            // This doesn't work for some reason.
            //guiStyle.alignment = TextAnchor.UpperCenter;

            return guiStyle;
        }
    }
}
