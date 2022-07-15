using System;
using System.Collections.Generic;
using System.Text;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.Attributes
{
    /// <summary>
    /// Specifies that the target property will be rendered with no sort controls in the resulting table header.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNotSortableAttribute : Attribute { }

    /// <summary>
    /// Specifies that the target property will be rendered as a hidden colum in the resulting table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnHiddenAttribute : Attribute { }

    /// <summary>
    /// Specifies that the target property will be rendered as an editable column in the resulting table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnEditableAttribute : Attribute 
    {
        public ColumnEditOption Option { get; set; }
        public ColumnEditableAttribute(ColumnEditOption option = ColumnEditOption.Text)
        {
            Option = option;
        }
    }

    /// <summary>
    /// Specifies that the target property will keep track of changes that occur on the rendered row. A javascript event listener will be applied on the row and this property will get marked as true (to signify the row has changed).
    /// The property should be a boolean type, and default to false.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnChangeTrackerAttribute : Attribute { }

    /// <summary>
    /// Specifies the column name/display that will rendered in the table header from the property that this attribute is applied to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnLabelAttribute : Attribute { 
        public string Display { get; set; }
        public ColumnLabelAttribute(string Display)
        {
            this.Display = Display;
        }
    }

    /// <summary>
    /// Specifies that the column rendered from the property that this attribute is applied to will have a minimum width applies.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnMinWidthAttribute : Attribute
    {
        public ColumnMinWidthOption MinWidth { get; set; }
        public ColumnMinWidthAttribute(ColumnMinWidthOption width)
        {
            this.MinWidth = width;
        }
    }
    
    /// <summary>
    /// Specifies that the column is the Primary Key to be used in Conjunction with the ColumnHyperlinkAttribute. Appends the value of the attributed property as a QueryString on the BaseURL applies on a separate property attributed with the ColumnHyperlinkAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnPkAttribute : Attribute { }

    /// <summary>
    /// Specifies that the column's cell data will be rendered as a hyperlink where the defined baseUrl will be used in conjunction with a separate property that is attrbitued with the ColumnPkAttribute. When clicking the rendered cell's text a modal will popup.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnDynamicModalAttribute : Attribute
    {
        /// <summary>
        /// The base URL that will have the primary key of the resource appended to it. The primary key of the resource will be tagged on to a View Model Property with the ColumnPkAttribute.
        /// </summary>
        public string BaseURL { get; set; }

        /// <summary>
        /// The title of the Modal that will be displayed.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The size of the modal.
        /// </summary>
        public ModalSize Size { get; set; }

        /// <summary>
        /// Determines if the modal will close when the user clicks outside of the modal. true = the modal will close, false = the modal will not close.
        /// </summary>
        public bool IsCloseOnClickOff { get; set; }

        /// <summary>
        /// Determines if the modal is vertically scrollable. true = scrollable, false = not scrollable.
        /// </summary>
        public bool IsScrollable { get; set; }

        /// <summary>
        /// Determines if the modal has a footer with buttons for further action. true = footer is present, false = no footer.
        /// </summary>
        public bool IsFooterIncluded { get; set; }

        /// <summary>
        /// The type of button we are working with (determine the color of the button).
        /// </summary>
        public ModalButtonType BtnType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl">The base URL that will have the primary key of the resource appended to it. The primary key of the resource will be tagged on to a View Model Property with the ColumnPkAttribute.</param>
        /// <param name="title">The title of the Modal that will be displayed.</param>
        /// <param name="size">The size of the modal.</param>
        /// <param name="isCloseOnClickOff">Determines if the modal will close when the user clicks outside of the modal. true = the modal will close, false = the modal will not close.</param>
        /// <param name="isScrollable">Determines if the modal is vertically scrollable. true = scrollable, false = not scrollable.</param>
        /// <param name="isFooterIncluded">Determines if the modal has a footer with buttons for further action. true = footer is present, false = no footer.</param>
        /// <param name="buttonType">The type of button we are working with (determine the color of the button).</param>
        public ColumnDynamicModalAttribute(string baseUrl, string title, ModalSize size, bool isCloseOnClickOff = false, bool isScrollable = true, bool isFooterIncluded = true, ModalButtonType buttonType = ModalButtonType.PrimaryBlue)
        {
            BaseURL = baseUrl;
            Title = title;
            Size = size;
            IsCloseOnClickOff = isCloseOnClickOff;
            IsScrollable = isScrollable;
            IsFooterIncluded = isFooterIncluded;
            BtnType = buttonType;
        }
    }

    /// <summary>
    /// Specifies that the column's cell will be rendered as a hyperlink where the defined baseUrl will be used in conjunction with a separate property that is attrbitued with the ColumnPkAttribute. When clicking the rendered cell's text the user is navigated to a new page.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnLinkAttribute : Attribute
    {
        /// <summary>
        /// The base URL that will have the primary key of the resource appended to it. The primary key of the resource will be tagged on to a View Model Property with the ColumnPkAttribute.
        /// </summary>
        public string BaseURL { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// The type of button we are working with (determine the color of the button).
        /// </summary>
        public ModalButtonType BtnType { get; set; }

        /// <summary>
        /// The size of the button we are working with.
        /// </summary>
        public ModalButtonSize BtnSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl">The base URL that will have the primary key of the resource appended to it. The primary key of the resource will be tagged on to a View Model Property with the ColumnPkAttribute.</param>
        /// <param name="text">The text to display as the hyperlink.</param>
        /// <param name="buttonType">The type of button we are working with (determine the color of the button).</param>
        /// <param name="buttonSize"></param>
        public ColumnLinkAttribute(string baseUrl, string text, ModalButtonType buttonType = ModalButtonType.PrimaryBlue, ModalButtonSize buttonSize = ModalButtonSize.Medium)
        {
            BaseURL = baseUrl;
            Text = text;
            BtnType = buttonType;
            BtnSize = buttonSize;
        }
    }
}
