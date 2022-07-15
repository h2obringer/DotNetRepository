using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.Attributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ModalButtonAttribute : Attribute {
        /// <summary>
        /// The text displayed on the button
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The type of button we are working with (determine the color of the button).
        /// </summary>
        public ModalButtonType BtnType { get; set; }
        
        /// <summary>
        /// The size of the button.
        /// </summary>
        public ModalButtonSize Size { get; set; }
        
        /// <summary>
        /// A warning prompt to display to the user. If set (not null or whitespace), the button will trigger a nested modal with 2 predetermined buttons: "OK" and "Close".
        /// </summary>
        public string WarningPrompt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">The text displayed on the button.</param>
        /// <param name="btnType">The type of button we are working with (determine the color of the button).</param>
        /// <param name="size">The size of the button</param>
        /// <param name="warningPrompt">A warning prompt to display to the user. If set (not null or whitespace), the button will trigger a nested modal with 2 predetermined buttons: "OK" and "Close".</param>
        public ModalButtonAttribute(string text, ModalButtonType btnType, ModalButtonSize size = ModalButtonSize.Medium, string warningPrompt = "")
        {
            Text = text;
            BtnType = btnType;
            Size = size;
            WarningPrompt = warningPrompt;
        }
    }
}
