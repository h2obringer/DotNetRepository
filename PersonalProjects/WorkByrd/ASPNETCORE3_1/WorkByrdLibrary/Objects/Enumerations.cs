using System.ComponentModel;

namespace WorkByrdLibrary.Objects
{
    /// <summary>
    /// These types outline the different types of user roles that will be assigned to users in our system.
    /// </summary>
    public enum RoleType
    {
        NA = 0,
        [Description("SystemAdmin")]
        SystemAdmin = 1,
        [Description("CompanyAdmin")]
        CompanyAdmin = 2,
        [Description("CompanyManager")]
        CompanyManager = 3,
        [Description("CompanySales")]
        CompanySales = 4,
        [Description("CompanyEmployee")]
        CompanyEmployee = 5
    }

    /// <summary>
    /// These types outline the different custom paid subscription policies available throughout the application.
    /// </summary>
    public enum SubscriptionType
    {
        NA = 0,
        [Description("Apprentice")]
        Apprentice = 1,
        [Description("Craftsman")]
        Craftsman = 2,
        [Description("MasterCraftsman")]
        MasterCraftsman = 3
    }
    
    /// <summary>
    /// Is the current request from the Web API or the MVC site?
    /// </summary>
    public enum EntryPoint
    {
        Unknown = 0,
        Core = 1,
        API = 2,
        MVC = 3
    }

    /// <summary>
    /// To be used by the custom logging system to identify the type of log being entered (see WorkByrdDbLogger.cs)
    /// </summary>
    public enum LogLevel
    {
        Info = 0,
        Warning = 1,
        Error = 2,
        Critical = 3
    }

    /// <summary>
    /// Used by the UserAccessLogger to log program access history of users.
    /// </summary>
    public enum UserAccessAction
    {
        [Description("Login")]
        Login = 0,
        [Description("Login Two-Factor Authentication 1 of 2")]
        Login2fa1 = 1,
        [Description("Login Two-Factor Authentication 2 of 2")]
        Login2fa2 = 2,
        [Description("Logout")]
        Logout = 3,
        [Description("Invalid Login Attempt")]
        InvalidLoginAttempt = 4,
        [Description("Locked Out")]
        LockedOut = 5
    }

    /// <summary>
    /// Used by History/Audit Entities in the ApplicationDbContext
    /// </summary>
    public enum HistoryAuditAction
    {
        Insert = 0,
        Update = 1,
        Delete = 2
    }

    #region "HTML Datatables"
    /// <summary>
    /// Correlates directly to the MDBootstrap (mdbootstrap/dist/js/addons/datatables.min.js) pagination type to use on a Datatable. 
    /// </summary>
    public enum TablePaginationOption
    {
        None = 0,
        Simple = 1, //'Previous' and 'Next' buttons only
        Numbers = 2, //Page number buttons only
        SimpleNumbers = 3, //'Previous' and 'Next' buttons, plus page numbers
        Full = 4, //'First', 'Previous', 'Next' and 'Last' buttons
        FullNumbers = 5, //'First', 'Previous', 'Next' and 'Last' buttons, plus page numbers
        FirstLastNumbers = 6 //'First' and 'Last' buttons, plus page numbers
    }

    /// <summary>
    /// Determines how many entries will be shown per page when the table is paginated.
    /// </summary>
    public enum TableDefaultPageSizeOption
    {
        Ten = 0,
        TwentyFive = 1,
        Fifty = 2,
        OneHundred = 3
    }

    /// <summary>
    /// Determines if a property will be editable or not
    /// </summary>
    public enum ColumnEditOption
    {
        None = 0, //column will be rendered as text and cannot be edited.
        Text = 1, //column will be rendered as text and can be edited.
        Checkbox = 2 //column will be rendered as a checkbox and can be edited.
    }

    /// <summary>
    /// Defines minimum column widths that can be applied on an individual column.
    /// </summary>
    public enum ColumnMinWidthOption
    {
        None = 0, //no min column width specified
        Small = 1, //mdb.css .th-sm (min column width of 6rem)
        Large = 2 //mdb.css .th-lg (min column width of 9rem)
    }

    /// <summary>
    /// Provides options to determine universal column widths on a table.
    /// </summary>
    public enum TableColumnWidthOption
    {
        None = 0, //no table width option specified. No special width controls will be emplaced. Column level width options will be applied if present.
        Fixed = 1, //table column widths will be fixed and all be the same.
        Auto = 2 //table column widths will adjust to fit the size of the largest element in its column
    }
    #endregion

    #region "HTML Modals"
    public enum ModalSize
    {
        Small = 1, //bootstrap.css .modal-sm (300px max width)
        Medium = 2, //bootstrap.css (no class this is the default - 500px max width)
        Large = 3, //bootstrap.css .modal-lg (800px max width)
        XLarge = 4 //bootstrap.css .modal-xl (1140px max width)
    }

    /// <summary>
    /// Determines how a modal button will be rendered (color). 
    /// </summary>
    public enum ModalButtonType
    {
        [Description("btn-primary")]
        PrimaryBlue = 0, //bootstrap.css .btn-primary
        [Description("btn-secondary")]
        SecondaryGray = 1, //bootstrap.css .btn-secondary
        [Description("btn-success")]
        SuccessGreen = 2, //bootstrap.css .btn-success
        [Description("btn-danger")]
        DangerRed = 3, //bootstrap.css .btn-danger
        [Description("btn-warning")]
        WarningYellow = 4, //bootstrap.css .btn-warning
        [Description("btn-info")]
        InfoTurquoise = 5, //bootstrap.css .btn-info
        [Description("btn-light")]
        Light = 6, //bootstrap.css .btn-light
        [Description("btn-dark")]
        Dark = 7, //bootstrap.css .btn-dark
        [Description("btn-link")]
        Link = 8, //bootstrap.css .btn-link
        [Description("btn-outline-primary")]
        PrimaryOutlineBlue = 9, //bootstrap.css .btn-outline-primary
        [Description("btn-outline-secondary")]
        SecondaryOutlineGray = 10, //bootstrap.css .btn-outline-secondary
        [Description("btn-outline-success")]
        SuccessOutlineGreen = 11, //bootstrap.css .btn-outline-success
        [Description("btn-outline-danger")]
        DangerOutlineRed = 12, //bootstrap.css .btn-outline-danger
        [Description("btn-outline-warning")]
        WarningOutlineYellow = 13, //bootstrap.css .btn-outline-warning
        [Description("btn-outline-info")]
        InfoOutlineTurquoise = 14, //bootstrap.css .btn-outline-info
        [Description("btn-outline-light")]
        LightOutline = 15, //bootstrap.css .btn-outline-light
        [Description("btn-outline-dark")]
        DarkOutline = 16 //bootstrap.css .btn-outline-dark
    }

    public enum ModalButtonSize
    {
        [Description("btn-sm")]
        Small = 0, //bootstrap.css .btn-sm
        [Description("")]
        Medium = 1, // N/A
        [Description("btn-lg")]
        Large = 2, //bootstrap.css .btn-lg
        [Description("btn-block")]
        BlockLevel = 3 //bootstrap.css .btn-block
    }
    

    #endregion
}
