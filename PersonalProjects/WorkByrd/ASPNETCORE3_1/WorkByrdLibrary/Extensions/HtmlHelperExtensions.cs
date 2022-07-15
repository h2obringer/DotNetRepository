using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WorkByrdLibrary.Attributes;
using WorkByrdLibrary.Utils;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WorkByrdLibrary.Extensions;
using System.Text.RegularExpressions;
using WorkByrdLibrary.Objects;

namespace WorkByrdLibrary.Extensions
{
    public static partial class HtmlHelperExtensions
    {
        /// <summary>
        /// Creates a robust HTML Table element that should cover a lot of basic needs. All columns are sortable unless explicitly declared as Non-Sortable (source class property attributed with a ColumnNotSortableAttribute).
        /// All table data is non-edittable unless explicitly declared as editable (source class property attributed with a ColumnEditableAttribute).
        /// Any rows that were edited by the user can be tracked by attributing a source class property as the tracking column with ColumnChangeTrackerAttribute. This property must be of type bool and it will only take affect if a postURL is provided and at least one property on the "source" parameter
        /// has a ColumnEditableOption and that option is Not ColumnEditableOption.None. Otherwise there is no use in tracking any changes because the table is not editable in any way.
        /// </summary>
        /// <typeparam name="T">A View Model Class whose properties are decorated as needed from WorkByrdLibrary.Attributes.HtmlTableAttributes.</typeparam>
        /// <param name="source">The list we are generating a table for.</param>
        /// <param name="baseControlID">The base id attribute to mark generated HTML elements with.</param>
        /// <param name="postURL">If provided, the table can be posted if at least one one property on the "source" parameter type has a ColumnEditableOption and that option is not ColumnEditableOption.None. (TODO - add to this, add conditions based on if any input tags are included or not...)</param>
        /// <param name="pageOption">Determines how the table pagination will be displayed. Defaults to TablePaginationOption.FullNumbers if not provided.</param>
        /// <param name="defaultPageSizeOption">Determines the default page size of the table. 10, 25, 50, or 100.</param>
        /// <param name="isSearchable">Determines if the table is searchable or not.</param>
        /// <param name="isHorizontalScrollable">Determines if the table is scrollable via the width of the table not. Defaults to scrollable (true).</param>
        /// <param name="verticalScrollHeight">If provided, determines the height of the table and allows vertical scrolling. Defaults to 0 meaning the table is not vertically scrollable. Values less than 200 will also not be vertically scrollable.</param>
        /// <param name="isTextWrap">Determines whether or not text in columns will wrap or not. Defaults to let text wrap (true).</param>
        /// <param name="tableColumnWidths">If provided, overrides Minimum widths set on individual columns and provides a uniform column width behavior for the whole table. Defaults to TableColumnWidthOption.None.</param>
        /// <param name="successjs">Will not be used unless postURL is provided. Allows the execution of custom js upon a successful post for the table. Minimum default behavior is applied if not provided. 
        ///     The provided javascript should have the form: "function(data) { }" where "data" must be the name of the function parameter.</param>
        /// <param name="errorjs">Will not be used unless postURL is provided. Allows the execution of custom js upon an expected error response from the post request of the table. Minimum default behavior is applied if not provided.
        ///     The provided javascript should have the form: "function(data) { }"  where "data" must be the name of the function parameter.</param>
        /// <param name="catchjs">Will not be used unless postURL is provided. Allows the execution of custom js upon an unexpected error response from the post request of the table. Minimum default behavior is applied if not provided.
        ///     The provided javascript should have the form: "function(err) { }" where "err" must be the name of the function parameter.</param>
        /// <returns>An HTML Table utilizing mdbootstrap DataTable functionality.</returns>
        public static IHtmlContent WorkByrdDataTable<T>(this IHtmlHelper htmlHelper,
            IList<T> source,
            string baseControlID,
            string postURL = "",
            TablePaginationOption pageOption = TablePaginationOption.FullNumbers,
            TableDefaultPageSizeOption defaultPageSizeOption = TableDefaultPageSizeOption.Ten,
            bool isSearchable = true,
            bool isHorizontalScrollable = true,
            int verticalScrollHeight = 300,
            bool isTextWrap = true,
            TableColumnWidthOption tableColumnWidths = TableColumnWidthOption.None,
            string successjs = "",
            string errorjs = "",
            string catchjs = "")
        {
            //***************PERFORM INITIAL SANITY CHECKS********************
            if (source.Count == 0)
            {
                return new HtmlString("<p>There are currently no items to be displayed.</p>");
            }
            if (string.IsNullOrWhiteSpace(baseControlID))
            {
                throw new ArgumentNullException("A controlID value was not provided");
            }
            PropertyInfo[] propertyInfo = source[0].GetType().GetProperties();
            if (propertyInfo.Length == 0)
            {
                throw new ArgumentException("The source class must have properties");
            }
            if (!string.IsNullOrWhiteSpace(successjs))
            {
                if (!Regex.IsMatch(successjs, @"\s*function\s*\(data\)\s*{.*}")) throw new ArgumentException("The \"successjs\" javascript function is not valid.");
            }
            if (!string.IsNullOrWhiteSpace(errorjs))
            {
                if (!Regex.IsMatch(errorjs, @"\s*function\s*\(data\)\s*{.*}")) throw new ArgumentException("The \"errorjs\" javascript function is not valid.");
            }
            if (!string.IsNullOrWhiteSpace(catchjs))
            {
                if (!Regex.IsMatch(catchjs, @"\s*function\s*\(err\)\s*{.*}")) throw new ArgumentException("The \"catchjs\" javascript function is not valid.");
            }
            //***************END INITIAL SANITY CHECKS********************


            StringBuilder builder = new StringBuilder();
            int? changeTrackingIndex = null; //holds the index of the column that will be rendered as a hidden checkbox that will be set to true via a row's js event listener
            int? primaryKeyIndex = null; //holds the index of the column that will be used as the primary key in an HTTP GET Request for a specified row used with dynamic modals. 
            List<int> nonSortIndexes = new List<int>(); //holds the indexes of non-sortable columns
            string[] modalControlIdCols = new string[propertyInfo.Length]; //holds the unique HTML id for each dynamic modal element rendered in the table. Recalculated for each row.
            string[] modalEventIdCols = new string[propertyInfo.Length]; //holds the unique HTML id for each element that triggers a modal popup in the table. Recalculated for each row.
            
            //is text in the table allowed to wrap?
            if (!isTextWrap)
            {
                builder.AppendLine("<div class=\"text-nowrap\">"); //table-responsive 
            }
            else
            {
                builder.AppendLine("<div class=\"\">"); //table-responsive
            }

            bool isEditable = false; //keeps track of whether or not the table is editable. If there is at least one editable column then the table is editable.
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (!DataUtils.IsSimple(propertyInfo[i].PropertyType))
                {
                    throw new NotSupportedException("Use of Complex Type Properties in View Model Classes is not supported for HTML table generation.");
                }

                ColumnEditableAttribute editable = (ColumnEditableAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnEditableAttribute));
                if (editable == null) editable = new ColumnEditableAttribute(ColumnEditOption.None);
                if (editable.Option != ColumnEditOption.None)
                {
                    isEditable = true;
                }

                ColumnPkAttribute pk = (ColumnPkAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnPkAttribute));
                if (pk != null)
                {
                    if (primaryKeyIndex != null) throw new InvalidOperationException("Only one column can be marked as a primary key on a View Model Class for HTML table generation.");
                    primaryKeyIndex = i;
                }
            }

            bool isPostable = isEditable && !string.IsNullOrWhiteSpace(postURL);

            if (isPostable)
            {
                builder.AppendLine($"<form id=\"form{baseControlID}\" method=\"post\" action=\"{postURL}\">");
            }

            builder.AppendLine($"<table id=\"tbl{baseControlID}\" class=\"table table-striped table-bordered ");
            switch (tableColumnWidths)
            {
                case TableColumnWidthOption.Fixed:
                    builder.AppendLine("table-fixed ");
                    break;
                case TableColumnWidthOption.Auto:
                    builder.AppendLine("w-auto ");
                    break;
                default:
                    break;
            }
            builder.AppendLine("\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");


            //***************START TABLE HEADER********************
            builder.AppendLine("<thead>");
            builder.AppendLine("<tr>");
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                ColumnChangeTrackerAttribute trackable = (ColumnChangeTrackerAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnChangeTrackerAttribute));
                ColumnNotSortableAttribute nosort = (ColumnNotSortableAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnNotSortableAttribute));
                ColumnHiddenAttribute hidden = (ColumnHiddenAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnHiddenAttribute));
                ColumnLabelAttribute label = (ColumnLabelAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnLabelAttribute));
                ColumnMinWidthAttribute width = (ColumnMinWidthAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnMinWidthAttribute));

                if (trackable != null && isPostable)
                {
                    if (changeTrackingIndex != null) throw new InvalidOperationException("Only one tracking column can be applied to a View Model Class for HTML table generation.");
                    changeTrackingIndex = i;
                }

                if (nosort != null) nonSortIndexes.Add(i);

                if (hidden != null)
                {
                    builder.AppendLine("<th class=\"hidden\">");
                }
                else
                {
                    if (width == null) width = new ColumnMinWidthAttribute(ColumnMinWidthOption.Small);
                    switch (width.MinWidth)
                    {
                        case ColumnMinWidthOption.None:
                            builder.AppendLine("<th>");
                            break;
                        case ColumnMinWidthOption.Small:
                            builder.AppendLine("<th class=\"th-sm\">");
                            break;
                        case ColumnMinWidthOption.Large:
                            builder.AppendLine("<th class=\"th-lg\">");
                            break;
                    }
                }

                if (label == null || string.IsNullOrWhiteSpace(label.Display))
                {
                    builder.AppendLine($"{propertyInfo[i].Name}");
                }
                else
                {
                    builder.AppendLine($"{label.Display}");
                }
                builder.AppendLine("</th>");
            }

            builder.AppendLine("</tr>");
            builder.AppendLine("</thead>");
            //***************END TABLE HEADER********************


            //***************START TABLE BODY********************
            builder.AppendLine("<tbody>");
            for (int i = 0; i < source.Count; i++)
            {
                PropertyInfo[] rowProps = source[i].GetType().GetProperties();
                builder.AppendLine("<tr>");
                for (int j = 0; j < rowProps.Length; j++)
                {
                    //set the form item's name and id in a way that ASP.NET Core model binder can bind the posted data to the model on the HttpPost method.
                    string formItemName = $"[{i}].{rowProps[j].Name}";
                    string formItemID = $"z{i}__{rowProps[j].Name}";

                    ColumnEditableAttribute editable = (ColumnEditableAttribute)rowProps[j].GetCustomAttribute(typeof(ColumnEditableAttribute));
                    ColumnHiddenAttribute hidden = (ColumnHiddenAttribute)rowProps[j].GetCustomAttribute(typeof(ColumnHiddenAttribute));
                    ColumnDynamicModalAttribute dynamicModal = (ColumnDynamicModalAttribute)rowProps[j].GetCustomAttribute(typeof(ColumnDynamicModalAttribute));
                    ColumnLinkAttribute link = (ColumnLinkAttribute)rowProps[j].GetCustomAttribute(typeof(ColumnLinkAttribute));
                    bool isCheckboxDisabled = false;

                    //an attribute cannot be both a dynamic modal and a link
                    if (!string.IsNullOrWhiteSpace(modalControlIdCols[j]) && link != null) throw new InvalidOperationException("Properties on View Model Classes that are attributed with a ColumnDynamicModalAttribute cannot also be attributed with a ColumnLinkAttribute for HTML table generation.");

                    //if a column is set as a dynamic modal with the BaseURL and Primary Key columns set then keep track of the unique HTML id that will be assigned to the modal and the button that will trigger the modal
                    if (dynamicModal != null && !string.IsNullOrWhiteSpace(dynamicModal.BaseURL) && primaryKeyIndex != null)
                    {
                        modalControlIdCols[j] = "modal_" + baseControlID + "_row" + i + "_col" + j;
                        modalEventIdCols[j] = "modal_trigger" + baseControlID + "_row" + i + "_col" + j;
                    }

                    if (editable == null)
                    {
                        if (DataUtils.IsBoolean(rowProps[j].PropertyType, source[i]))
                        {
                            editable = new ColumnEditableAttribute(ColumnEditOption.Checkbox); //all boolean properties will be checkboxes
                            if (changeTrackingIndex == null || changeTrackingIndex != j || !isPostable) //if a column is attributed with the ColumnChangeTrackerAttribute it cannot be disabled. If the table is not postable then it SHOULD be disabled.
                            {
                                isCheckboxDisabled = true;
                            }
                        }
                        else
                        {
                            editable = new ColumnEditableAttribute(ColumnEditOption.None);
                        }
                    }

                    //A single column cannot be both editable and be a dynamic modal button or a link
                    if (editable.Option != ColumnEditOption.None  && !isCheckboxDisabled && (!string.IsNullOrWhiteSpace(modalControlIdCols[j]) || link != null)) throw new InvalidOperationException("Properties on View Model Classes that are attributed with a ColumnDynamicModalAttribute cannot also be attributed with a ColumnEditableAttribute for HTML table generation.");

                    switch (editable.Option)
                    {
                        case ColumnEditOption.Checkbox:
                            if (hidden != null)
                            {
                                builder.AppendLine("<td class=\"hidden\">");
                                if (DataUtils.IsBoolean(rowProps[j].PropertyType, rowProps[j].GetValue(source[i], null)) && (bool)rowProps[j].GetValue(source[i], null) == true)
                                {
                                    builder.AppendLine($"checked<input id=\"{formItemID}\" type=\"checkbox\" name=\"{formItemName}\" checked value=\"true\" />");
                                }
                                else
                                {
                                    builder.AppendLine($"<input id=\"{formItemID}\" type=\"checkbox\" name=\"{formItemName}\" value=\"true\" />");
                                }
                            }
                            else
                            {
                                builder.AppendLine("<td class=\"td-checkbox\">");
                                if (DataUtils.IsBoolean(rowProps[j].PropertyType, rowProps[j].GetValue(source[i], null)) && (bool)rowProps[j].GetValue(source[i], null) == true)
                                {
                                    //the checked text will be hidden from view and is there to allow the column to be sortable
                                    builder.AppendLine($"checked<input id=\"{formItemID}\" type=\"checkbox\" name=\"{formItemName}\" checked value=\"true\"");
                                }
                                else
                                {
                                    builder.AppendLine($"<input id=\"{formItemID}\" type=\"checkbox\" name=\"{formItemName}\" value=\"true\"");
                                }

                                if (isCheckboxDisabled)
                                {
                                    builder.AppendLine(" disabled />");
                                }
                                else
                                {
                                    builder.AppendLine(" />");
                                }
                            }
                            break;
                        case ColumnEditOption.Text:
                            if (hidden != null)
                            {
                                builder.AppendLine("<td class=\"hidden\">");
                                builder.AppendLine($"<input id=\"{formItemID}\" type=\"hidden\" name=\"{formItemName}\" value=\"{rowProps[j].GetValue(source[i], null)}\" />");
                            }
                            else
                            {
                                builder.AppendLine("<td contenteditable=\"true\">");
                                builder.AppendLine($"{rowProps[j].GetValue(source[i], null)}<input id=\"{formItemID}\" type=\"hidden\" name=\"{formItemName}\" value=\"{rowProps[j].GetValue(source[i], null)}\" />");
                            }

                            break;
                        default: //ColumnEditOption.None
                            builder.AppendLine("<td>");
                            if (!string.IsNullOrWhiteSpace(modalControlIdCols[j]))
                            {
                                string pk = DataUtils.GetString(rowProps[(int)primaryKeyIndex].GetValue(source[i], null));
                                string modallink = dynamicModal.BaseURL + "/" + pk; //TODO - probably needs to be reworked...   
                                builder.AppendLine($"{htmlHelper.WorkByrdDynamicModalButton(modallink, (string)rowProps[j].GetValue(source[i], null), modalEventIdCols[j], modalControlIdCols[j], dynamicModal.BtnType).CompileToString()}");
                            }
                            else if (link != null)
                            {
                                string pk = DataUtils.GetString(rowProps[(int)primaryKeyIndex].GetValue(source[i], null));
                                string url = link.BaseURL + "/" + pk; //TODO - probably needs to be reworked...   
                                builder.AppendLine($"<a class=\"btn {link.BtnType.GetDescription()} {link.BtnSize.GetDescription()}\" href=\"{url}\">{link.Text}</a>");
                            }
                            else
                            {
                                builder.AppendLine($"{rowProps[j].GetValue(source[i], null)}");
                            }
                            break;
                    }
                    builder.AppendLine("</td>");
                }
                builder.AppendLine("</tr>");
            }
            builder.AppendLine("</tbody>");
            //***************END TABLE BODY********************


            builder.AppendLine("</table>");
            //if the table is postable to the server
            if (isPostable)
            {
                //then render a submit button
                builder.AppendLine("<div>");
                builder.AppendLine($"   <input id=\"btn{baseControlID}Save\" type=\"submit\" class=\"btn btn-primary\" value=\"Save\" /> ");
                
                builder.AppendLine(htmlHelper.AntiForgeryToken().CompileToString());
                //add a progress spinner
                builder.AppendLine($"   <span><div id=\"tbl-progress-{baseControlID}\" class=\"circle-loader\" style=\"display:none;\"></div></span>");
                builder.AppendLine("</div>");
                builder.AppendLine("</form>");
            }

            //TODO - the placement and increment on this is incorrect. Fix this. Incorrect loop.
            for (int i = 0; i < modalControlIdCols.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(modalControlIdCols[i]))
                {
                    //render the modals that 
                    ColumnDynamicModalAttribute dynamicModal = (ColumnDynamicModalAttribute)propertyInfo[i].GetCustomAttribute(typeof(ColumnDynamicModalAttribute));
                    ModalButtonAttribute[] buttons = (ModalButtonAttribute[])propertyInfo[i].GetCustomAttributes(typeof(ModalButtonAttribute));
                    builder.AppendLine($"{WorkByrdDynamicModal(htmlHelper, modalControlIdCols[i], dynamicModal.Title, modalEventIdCols[i], dynamicModal.IsFooterIncluded, dynamicModal.IsScrollable, dynamicModal.IsCloseOnClickOff, dynamicModal.Size, buttons).CompileToString()}");
                }
            }


            builder.AppendLine("</div>");


            //***************START JAVASCRIPT********************
            builder.AppendLine("<script>");
            builder.AppendLine("    var $table;");
            builder.AppendLine("    $(document).ready(function() {");
            //establish the different table initialization options
            builder.AppendLine($"       $table = $(\"#tbl{baseControlID}\").DataTable({{");
            
            //determine how the paging will be rendered for the table
            switch (pageOption)
            {
                case TablePaginationOption.None:
                    builder.AppendLine("    \"paging\": false,");
                    break;
                case TablePaginationOption.Simple:
                    builder.AppendLine("    \"paging\": true,");
                    builder.AppendLine("    \"pagingType\": \"simple\",");
                    break;
                case TablePaginationOption.Numbers:
                    builder.AppendLine("    \"paging\": true,");
                    builder.AppendLine("    \"pagingType\": \"numbers\",");
                    break;
                case TablePaginationOption.SimpleNumbers:
                    builder.AppendLine("    \"paging\": true,");
                    builder.AppendLine("    \"pagingType\": \"simple_numbers\",");
                    break;
                case TablePaginationOption.Full:
                    builder.AppendLine("    \"paging\": true,");
                    builder.AppendLine("    \"pagingType\": \"full\",");
                    break;
                case TablePaginationOption.FullNumbers:
                    builder.AppendLine("    \"paging\": true,");
                    builder.AppendLine("    \"pagingType\": \"full_numbers\",");
                    break;
                case TablePaginationOption.FirstLastNumbers:
                    builder.AppendLine("    \"paging\": true,");
                    builder.AppendLine("    \"pagingType\": \"first_last_numbers\",");
                    break;
            }

            //will the table be horizontally scrollable?
            if (isHorizontalScrollable) //TODO - test this later, haven't seen this working yet...
            {
                builder.AppendLine("        \"scrollX\": true,");
            }
            //establish the minimum table height and if vertical scrolling will occur on taller tables
            if (verticalScrollHeight >= 200)
            {
                builder.AppendLine($"       \"scrollY\": \"{verticalScrollHeight}\",");
                //builder.AppendLine("      \"scrollCollapse\": true,");
            }

            //determine column sort behavior, if none of the columns are sortable this it is disabled on the entire table.
            if (nonSortIndexes.Count == propertyInfo.Length)
            {
                builder.AppendLine("        \"sort\": false,");
            }
            else //otherwise it is enabled on the table but we will disable it on columns that are not sortable...
            {
                builder.AppendLine("        \"sort\": true,");
                //now check if there are any individual non-sorting columns we need to account for...
                if (nonSortIndexes.Count > 0)
                {
                    StringBuilder targets = new StringBuilder();
                    foreach (int col in nonSortIndexes) {
                        targets.AppendLine($"{col}, ");
                    }
                    targets.Remove(targets.Length - 2, 2); //remove the trailing ", "

                    builder.AppendLine("    \"columnDefs\": [{");
                    builder.AppendLine("        \"orderable\": false,");
                    builder.AppendLine($"       \"targets\": [{targets.ToString()}]");
                    builder.AppendLine("    }],");
                }
            }

            //will the table be searchable?
            if (isSearchable)
            {
                builder.AppendLine("        \"searching\": true");
            }
            else
            {
                builder.AppendLine("        \"searching\": false");
            }
            builder.AppendLine("        });");
            builder.AppendLine("        $(\".dataTables_length\").addClass(\"bs - select\");");

            if (pageOption != TablePaginationOption.None)
            {
                //if the table has a default page size initial the appropriate size as being selected in the dropdown
                builder.AppendLine($"   $(\"#tbl{baseControlID}_length label select\").find(\"option\").eq({(int)defaultPageSizeOption}).prop(\"selected\", true)");
                if (defaultPageSizeOption != TableDefaultPageSizeOption.Ten)
                    builder.AppendLine($"$(\"#tbl{baseControlID}_length label select\").trigger(\"change\");"); //table already defaults at 10
            }

            builder.AppendLine("    });");

            if (changeTrackingIndex != null)
            {
                //if there is a column set to track if a change has occurred on a row in the table, set the row's on-change event to set the row's hidden checkbox to true
                builder.AppendLine($"$(\"#tbl{baseControlID} tbody tr\").on(\"change\", function() {{");
                builder.AppendLine($"   $(this).find(\"td\").eq({changeTrackingIndex}).find(\"input\").prop(\"checked\", true);");
                builder.AppendLine("});");
            }

            //if the table is editable...
            if (isEditable)
            {
                //set an on-change event listener on each table cell to track the value before the change and the value after the change. 
                builder.AppendLine($"$(\"#tbl{baseControlID} tbody tr td\").on(\"focus\", function() {{");
                builder.AppendLine("    const $this = $(this);");
                builder.AppendLine("    $this.data(\"before\", $this.html());");
                builder.AppendLine("}).on(\"blur cut keyup delete copy paste input\", function() {");
                builder.AppendLine("    const $this = $(this);");
                //on perform on-change detection if the table cell is editable
                builder.AppendLine("    if($this.hasClass(\"td-checkbox\") || $this.prop(\"contenteditable\") == \"true\") {");
                builder.AppendLine("        if ($this.data(\"before\") !== $this.html()) {");
                builder.AppendLine("            var $input = $this.find(\"input\");"); 
                //if we are dealing with text changes
                builder.AppendLine("            if($input.prop(\"type\") == \"text\" || $input.prop(\"type\") == \"hidden\") {");
                //set the hidden form input element to the value of the text that was changed so that the change can be sent to the server when posting the form
                builder.AppendLine("                $input.val($this.text());");
                //if we are dealing with a checkbox change
                builder.AppendLine("            } else if($input.prop(\"type\") == \"checkbox\") {");
                //set the hidden text field in front of the checkbox so that the column can be sorted if the column is sortable
                builder.AppendLine("                if($input.prop(\"checked\") == true) {");
                builder.AppendLine("                    $this.text(\"checked\");");
                builder.AppendLine("                } else {");
                builder.AppendLine("                    $this.text(\"\");");
                builder.AppendLine("                }");
                builder.AppendLine("                $this.append($input);");
                builder.AppendLine("            }");
                //highlight cells that have changes to an appropriate shade of green depending on even or odd row count.
                builder.AppendLine("            if($this.parent().hasClass(\"odd\")) {");
                builder.AppendLine("                $this.prop(\"style\", \"background-color: #ccffcc;\")");
                builder.AppendLine("            } else {");
                builder.AppendLine("                $this.prop(\"style\", \"background-color: #e6ffe6;\")");
                builder.AppendLine("            }");
                //ensure we trigger the row's on-change event
                builder.AppendLine("            $this.parent().trigger(\"change\");");
                builder.AppendLine("        }");
                builder.AppendLine("    }");
                builder.AppendLine("});");
            }

            if (isPostable)
            {
                builder.AppendLine($"$(\"#form{baseControlID}\").submit( function (e) {{");
                builder.AppendLine("    e.preventDefault();");
                builder.AppendLine($"   $(\"#btn{baseControlID}Save\").prop(\"disabled\", true);");
                builder.AppendLine($"   $(\"#tbl-progress-{baseControlID}\").show();");

                builder.AppendLine("     var formData = new FormData();");
                //put all table input values into the form that we will post... posting our data, especially if it has been sorted, does not work otherwise...
                builder.AppendLine("    var $rows = $table.rows().nodes();");
                builder.AppendLine("    for(var i=0; i<$rows.length; i++) {");
                builder.AppendLine("        var $cols = $($rows[i]).children().find(\"input\");");
                builder.AppendLine("        for(var j=0; j<$cols.length; j++) {");
                builder.AppendLine("            if($cols[j].type != \"checkbox\" || ($cols[j].type == \"checkbox\" && $cols[j].checked == true)) {");
                builder.AppendLine("                formData.append($cols[j].name, $cols[j].value);");
                builder.AppendLine("            }");
                builder.AppendLine("        }");
                builder.AppendLine("    }");

                builder.AppendLine("    wbGetSecureJSON(");
                builder.AppendLine($"       \"{postURL}\",");
                builder.AppendLine("        formData");
                builder.AppendLine("    ).then(function(data){");
                builder.AppendLine("        if(data.Success != null) {");
                if (!string.IsNullOrWhiteSpace(successjs))
                {
                    builder.AppendLine($"       ({successjs}(data));"); //self-invoking js function...
                }
                else
                {
                    builder.AppendLine($"       $(\"#tbl-progress-{baseControlID}\").hide();");
                    builder.AppendLine($"       $(\"#btn{baseControlID}Save\").prop(\"disabled\", false);");
                }
                builder.AppendLine("        } else if (data.Error != null) {");
                if (!string.IsNullOrWhiteSpace(errorjs))
                {
                    builder.AppendLine($"       ({errorjs}(data));"); //self-invoking js function...
                }
                else
                {
                    builder.AppendLine($"       $(\"#tbl-progress-{baseControlID}\").hide();");
                    builder.AppendLine($"       $(\"#btn{baseControlID}Save\").prop(\"disabled\", false);");
                }
                builder.AppendLine("        }");
                builder.AppendLine("    }).catch(function(err) {");
                if (!string.IsNullOrWhiteSpace(catchjs))
                {
                    builder.AppendLine($"   ({baseControlID}(err));"); //self-invoking js function...
                }
                else
                {
                    builder.AppendLine($"   $(\"#tbl-progress-{baseControlID}\").hide();");
                    builder.AppendLine($"   $(\"#btn{0}Save\").prop(\"disabled\", false);");
                    builder.AppendLine("        console.error(err);");
                }
                builder.AppendLine("    });");
                builder.AppendLine("});");
            }

            builder.AppendLine("</script>");
            //***************END JAVASCRIPT********************


            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// Renders a modal with dynamic content.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="modalControlID">The HTML id assigned to the modal parent container.</param>
        /// <param name="title">The title to display in the header of the modal.</param>
        /// <param name="eventListenerControlID">The HTML id assigned to the button that triggers this modal. </param>
        /// <param name="content">The static content to display inside the modal.</param>
        /// <param name="includeFooter">Determines if a footer containing additional buttons will be displayed on the modal or not. true = footer, false = no footer.</param>
        /// <param name="isModalScrollable">Determines if the modal is vertically scrollable. true = scrollable, false = not scollable.</param>
        /// <param name="isCloseOnClickOff">Determines if the modal will close when the user clicks outside of the modal or not. true = close when clicking outside of modal, false = no close.</param>
        /// <param name="modalSize">The size of the modal.</param>
        /// <param name="buttons">The list of buttons to display in the footer.</param>
        /// <param name="isOverrideDefaultButton">Determines if the buttons list will be in addition to the default close button or exclude the default close button. true = exclude default close button, false = default close button is included.</param>
        /// <returns></returns>
        public static IHtmlContent WorkByrdDynamicModal(this IHtmlHelper htmlHelper, string modalControlID, string title, string eventListenerControlID, bool includeFooter = true, bool isModalScrollable = true, bool isCloseOnClickOff = false, ModalSize modalSize = ModalSize.Medium, ModalButtonAttribute[] buttons = null, bool isOverrideDefaultButton = false, int stackCount = 0, string parentButtonClassHandleChain = "")
        {
            if (string.IsNullOrWhiteSpace(modalControlID)) throw new ArgumentNullException("controlID cannot be empty when creating a dynamic HTML Modal.");
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException("title cannot be empty when creating a dynamic HTML Modal.");
            if (string.IsNullOrWhiteSpace(eventListenerControlID)) throw new ArgumentNullException("eventListenerControlID cannot be empty when creating a dynamic HTML Modal.");

            string modalBodyControlID = "body_" + modalControlID;

            StringBuilder builder = new StringBuilder();

            string childOfClass = "parent-in-chain";
            if (!string.IsNullOrWhiteSpace(parentButtonClassHandleChain))
            {
                childOfClass = $"childOf-{parentButtonClassHandleChain}";
            }

            builder.AppendLine($"<div id=\"{modalControlID}\" class=\"modal fade modal-stack{stackCount} modal-{childOfClass}\" tabindex=\"-1\" role=\"dialog\">");

            string modalSizeClass = "";
            switch (modalSize)
            {
                case ModalSize.Small:
                    modalSizeClass = "modal-sm";
                    break;
                case ModalSize.Medium:
                    break;
                case ModalSize.Large:
                    modalSizeClass = "modal-lg";
                    break;
                case ModalSize.XLarge:
                    modalSizeClass = "modal-xl";
                    break;
            }
            string scrollClass = "";
            if (isModalScrollable) scrollClass = "modal-dialog-scrollable";
            
            builder.AppendLine($"   <div class=\"modal-dialog modal-dialog-stack{stackCount} {modalSizeClass} {scrollClass}\" role=\"document\">");
            builder.AppendLine($"       <div class=\"modal-content modal-content-stack{stackCount}\">");
            builder.AppendLine($"           <div class=\"modal-header modal-header-stack{stackCount}\">");
            builder.AppendLine($"               <h4 class=\"modal-title modal-title-stack{stackCount}\">{title}</h4>");
            builder.AppendLine($"                <button id=\"{modalControlID}_btn{buttons.Length+1}\" type=\"button\" class=\"close class-handle-Close-stack{stackCount} {childOfClass}\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden\"true\">&times;</span></button>");
            builder.AppendLine("            </div>");
            builder.AppendLine($"           <div id=\"{modalBodyControlID}\" class=\"modal-body modal-body-stack{stackCount}\">");
            //TO BE FILLED IN VIA AN AJAX REQUEST - see the script element below for more details
            builder.AppendLine("            </div>");
            if (includeFooter)
            {
                builder.AppendLine($"       <div class=\"modal-footer modal-footer-stack{stackCount}\">");

                if (buttons != null && buttons.Length > 0)
                {
                    //the javscript actions to be performed for each button will be defined on the Partial View grabbed via AJAX REQUEST below.
                    for (int i = 0; i < buttons.Length; i++) 
                    {        
                        string buttonId = $"{modalControlID}_btn{i}";

                        if (!string.IsNullOrWhiteSpace(buttons[i].WarningPrompt))
                        {
                            string subModalControlId = $"{modalControlID}_sub{i}";
                            builder.AppendLine($"   {htmlHelper.WorkByrdStaticModalButton(buttons[i].Text, buttonId, subModalControlId, buttons[i].BtnType, ModalButtonSize.Medium, stackCount, parentButtonClassHandleChain).CompileToString()}");
                            List<ModalButtonAttribute> subButtons = new List<ModalButtonAttribute>();
                            subButtons.Add(new ModalButtonAttribute("OK", ModalButtonType.SuccessGreen, ModalButtonSize.Medium));
                            //TODO - possibly change how we are generating this because it gets generated in the StaticModalButton function...
                            string newParentChain = $"class-handle-{buttons[i].Text.Replace(" ", "")}-stack{stackCount}-{childOfClass}";
                            builder.AppendLine($"   {htmlHelper.WorkByrdStaticModal(subModalControlId, "Warning", buttonId, buttons[i].WarningPrompt, true, false, false, ModalSize.Small, subButtons.ToArray(), false, stackCount + 1, newParentChain).CompileToString()}");
                        }
                        else
                        {
                            builder.AppendLine($"   <button id=\"{buttonId}\" type=\"button\" class=\"btn {buttons[i].BtnType.GetDescription()} {buttons[i].Size.GetDescription()} class-handle-{buttons[i].Text.Replace(" ", "")}-stack{stackCount} {childOfClass}\">{buttons[i].Text}</button>");
                        }
                    }
                }

                if (!isOverrideDefaultButton)
                {
                    builder.AppendLine($"           <button id=\"{modalControlID}_btn{buttons.Length}\" type=\"button\" class=\"btn {ModalButtonType.SecondaryGray.GetDescription()} {ModalButtonSize.Medium.GetDescription()} class-handle-Close-stack{stackCount} {childOfClass}\" data-dismiss=\"modal\">Close</button>");
                }
                builder.AppendLine("        </div>");
            }
            builder.AppendLine("        </div>");
            builder.AppendLine("    </div>");
            builder.AppendLine("</div>");

            builder.AppendLine("<script>");
            builder.AppendLine("    $(document).ready(function() {");
            //when the modal's button is clicked
            builder.AppendLine($"       $(\"#{eventListenerControlID}\").click(function(e){{");
            builder.AppendLine("            debugger;");
            //do not navigate to the anchor elements href URL
            builder.AppendLine("            e.preventDefault();");
            //grab it for later reference instead...
            builder.AppendLine("            var url = $(this).prop(\"href\");");
            builder.AppendLine($"           var $modalBody = $(\"#{modalBodyControlID}\");");
            //set the body of the modal to a progress spinner
            builder.AppendLine($"           $modalBody.html('<span><div id=\"modal-progress-{modalControlID}\" class=\"circle-loader\" ></div></span>')"); //clear the previous modal contents and show a progress spinner

            string clickOffOption = ""; //if left blank, the modal will close when the user clicks outside of the modal.
            if (!isCloseOnClickOff) clickOffOption = "{backdrop: 'static'}"; //the modal will not close when the user clicks outside of the modal...
            
            //display the modal
            builder.AppendLine($"           $(\"#{modalControlID}\").modal({clickOffOption});");

            //fetch the dynamic body of the modal using the provided anchor href
            builder.AppendLine("            fetch(url, {method: 'GET'}).then(function(response){");
            builder.AppendLine("                debugger;");
            builder.AppendLine("                return response.text();");
            builder.AppendLine("            }).then(function(html){");
            builder.AppendLine("                debugger;");
            builder.AppendLine("                $modalBody.html(html);");
            builder.AppendLine("            }).catch(function(err) {");
            builder.AppendLine("                debugger;");
            builder.AppendLine("                $modalBody.html(\"err\")");
            builder.AppendLine("                console.error(err);");
            builder.AppendLine("            });");
            builder.AppendLine("        });");
            builder.AppendLine("    });");
            builder.AppendLine("</script>");

            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// Renders a button that triggers a model with dynamic content.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="url">The url that will be used to fetch the content of the modal's body.</param>
        /// <param name="buttonText">The text on display on the button.</param>
        /// <param name="buttonControlID">The HTML id to assign to the button element.</param>
        /// <param name="targetControlID">The HTML id assigned to the modal that this button targets.</param>
        /// <param name="buttonType">The type of button to render (decides what color the button will be).</param>
        /// <param name="buttonSize">The size of the button.</param>
        /// <param name="stackCount">In conditions where modals are stacked this identifies what level in the stack this button appears on and will allow access to the element by a class selector with the format "class-handle-stack-count-{stackCount}"</param>
        /// <param name="stackButtonCount">Allows for applying additional class identifiers on the button to allow for better access to the elemeny through class selectors and will have a format of "class-handle-{stackButtonCount}.</param>
        /// <returns></returns>
        public static IHtmlContent WorkByrdDynamicModalButton(this IHtmlHelper htmlHelper, string url, string buttonText, string buttonControlID, string targetControlID, ModalButtonType buttonType = ModalButtonType.PrimaryBlue, ModalButtonSize buttonSize = ModalButtonSize.Medium, int stackCount = 0, string parentButtonClassHandleChain = "")
        {
            string childOfClass = "parent-in-chain";
            if (!string.IsNullOrWhiteSpace(parentButtonClassHandleChain))
            {
                childOfClass = $"childOf-{parentButtonClassHandleChain}";
            }

            return new HtmlString($"<a id=\"{buttonControlID}\" class=\"btn {buttonType.GetDescription()} {buttonSize.GetDescription()} class-handle-{buttonText.Replace(" ", "")}-stack{stackCount} {childOfClass}\" href=\"{url}\" data-toggle=\"modal\" data-target=\"#{targetControlID}\">{buttonText}</a>");
        }

        /// <summary>
        /// Renders a button that triggers a modal with static content. 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="buttonText">The text on display on the button.</param>
        /// <param name="buttonControlID">The HTML id to assign to the button element.</param>
        /// <param name="targetControlID">The HTML id assigned to the modal that this button targets.</param>
        /// <param name="buttonType">The type of button to render (decides what color the button will be).</param>
        /// <param name="buttonSize">The size of the button.</param>
        /// <param name="stackCount">In conditions where modals are stacked this identifies what level in the stack this button appears on and will allow access to the element by a class selector with the format "class-handle-stack-count-{stackCount}"</param>
        /// <param name="stackButtonCount">Allows for applying additional class identifiers on the button to allow for better access to the element through class selectors and will have a format of "class-handle-{stackButtonCount}.</param>
        /// <returns></returns>
        public static IHtmlContent WorkByrdStaticModalButton(this IHtmlHelper htmlHelper, string buttonText, string buttonControlID, string targetControlID, ModalButtonType buttonType = ModalButtonType.PrimaryBlue, ModalButtonSize buttonSize = ModalButtonSize.Medium, int stackCount = 0, string parentButtonClassHandleChain = "")
        {
            string childOfClass = "parent-in-chain";
            if (!string.IsNullOrWhiteSpace(parentButtonClassHandleChain))
            {
                childOfClass = $"childOf-{parentButtonClassHandleChain}";
            }

            return new HtmlString($"<button id=\"{buttonControlID}\" class=\"btn {buttonType.GetDescription()} {buttonSize.GetDescription()} class-handle-{buttonText.Replace(" ", "")}-stack{stackCount} {childOfClass}\" data-toggle=\"modal\" data-target=\"#{targetControlID}\">{buttonText}</button>");
        }
        
        /// <summary>
        /// Renders a modal with static content.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="modalControlID">The HTML id assigned to the modal parent container.</param>
        /// <param name="title">The title to display in the header of the modal.</param>
        /// <param name="eventListenerControlID">The HTML id assigned to the button that triggers this modal. </param>
        /// <param name="content">The static content to display inside the modal.</param>
        /// <param name="includeFooter">Determines if a footer containing additional buttons will be displayed on the modal or not. true = footer, false = no footer.</param>
        /// <param name="isModalScrollable">Determines if the modal is vertically scrollable. true = scrollable, false = not scollable.</param>
        /// <param name="isCloseOnClickOff">Determines if the modal will close when the user clicks outside of the modal or not. true = close when clicking outside of modal, false = no close.</param>
        /// <param name="modalSize">The size of the modal.</param>
        /// <param name="buttons">The list of buttons to display in the footer.</param>
        /// <param name="isOverrideDefaultButton">Determines if the buttons list will be in addition to the default close button or exclude the default close button. true = exclude default close button, false = default close button is included.</param>
        /// <returns></returns>
        public static IHtmlContent WorkByrdStaticModal(this IHtmlHelper htmlHelper, string modalControlID, string title, string eventListenerControlID, string content, bool includeFooter = true, bool isModalScrollable = true, bool isCloseOnClickOff = false, ModalSize modalSize = ModalSize.Medium, ModalButtonAttribute[] buttons = null, bool isOverrideDefaultButton = false, int stackCount = 0, string parentButtonClassHandleChain = "")
        { 
            if (string.IsNullOrWhiteSpace(modalControlID)) throw new ArgumentNullException("controlID cannot be empty when creating a static HTML Modal.");
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException("title cannot be empty when creating a static HTML Modal.");
            if (string.IsNullOrWhiteSpace(eventListenerControlID)) throw new ArgumentNullException("eventListenerControlID cannot be empty when creating a static HTML Modal.");

            string modalBodyControlID = "body_" + modalControlID;

            StringBuilder builder = new StringBuilder();

            string childOfClass = "parent-in-chain";
            if (!string.IsNullOrWhiteSpace(parentButtonClassHandleChain))
            {
                childOfClass = $"childOf-{parentButtonClassHandleChain}";
            }

            builder.AppendLine($"<div id=\"{modalControlID}\" class=\"modal fade modal-stack{stackCount} modal-{childOfClass}\" tabindex=\"-1\" role=\"dialog\">");

            string modalSizeClass = "";
            switch (modalSize)
            {
                case ModalSize.Small:
                    modalSizeClass = "modal-sm";
                    break;
                case ModalSize.Medium:
                    break;
                case ModalSize.Large:
                    modalSizeClass = "modal-lg";
                    break;
                case ModalSize.XLarge:
                    modalSizeClass = "modal-xl";
                    break;
            }
            string scrollClass = "";
            if (isModalScrollable) scrollClass = "modal-dialog-scrollable";

            builder.AppendLine($"   <div class=\"modal-dialog modal-dialog-stack{stackCount} {modalSizeClass} {scrollClass}\" role=\"document\">");
            builder.AppendLine($"       <div class=\"modal-content modal-content-stack{stackCount}\">");
            builder.AppendLine($"           <div class=\"modal-header modal-header-stack{stackCount}\">");
            builder.AppendLine($"               <h4 class=\"modal-title modal-title-stack{stackCount}\">{title}</h4>");
            builder.AppendLine($"                <button id=\"{modalControlID}_btn{buttons.Length + 1}\" type=\"button\" class=\"close class-handle-Close-stack{stackCount} {childOfClass}\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden\"true\">&times;</span></button>");
            builder.AppendLine("            </div>");
            builder.AppendLine($"           <div id=\"{modalBodyControlID}\" class=\"modal-body modal-body-stack{stackCount}\">");
            builder.AppendLine($"               {content}");
            builder.AppendLine("            </div>");
            if (includeFooter)
            {
                builder.AppendLine($"       <div class=\"modal-footer modal-footer-stack{stackCount}\">");

                if (buttons != null && buttons.Length > 0)
                {
                    for (int i=0; i<buttons.Length; i++)
                    {
                        string buttonId = $"{modalControlID}_btn{i}";

                        if (!string.IsNullOrWhiteSpace(buttons[i].WarningPrompt))
                        {
                            string subModalControlId = $"{modalControlID}_sub{i}";
                            builder.AppendLine($"   {htmlHelper.WorkByrdStaticModalButton(buttons[i].Text, buttonId, subModalControlId, buttons[i].BtnType,ModalButtonSize.Medium, stackCount, parentButtonClassHandleChain).CompileToString()}");
                            List<ModalButtonAttribute> subButtons = new List<ModalButtonAttribute>();
                            subButtons.Add(new ModalButtonAttribute("OK", ModalButtonType.SuccessGreen, ModalButtonSize.Medium));
                            //TODO - possibly change how we are generating this because it gets generated in the StaticModalButton function...
                            string newParentChain = $"class-handle-{buttons[i].Text.Replace(" ", "")}-stack{stackCount}-{childOfClass}";
                            builder.AppendLine($"   {htmlHelper.WorkByrdStaticModal(subModalControlId, "Warning", buttonId, buttons[i].WarningPrompt, true, false, false, ModalSize.Small, subButtons.ToArray(), false, stackCount + 1, newParentChain).CompileToString()}");
                        }
                        else
                        {
                            builder.AppendLine($"<button id=\"{buttonId}\" type=\"button\" class=\"btn {buttons[i].BtnType.GetDescription()} {buttons[i].Size.GetDescription()} class-handle-{buttons[i].Text.Replace(" ", "")}-stack{stackCount} {childOfClass}\">{buttons[i].Text}</button>");
                        }
                    }
                }
                if (!isOverrideDefaultButton)
                {
                    builder.AppendLine($"           <button id=\"{modalControlID}_btn{buttons.Length}\" type=\"button\" class=\"btn {ModalButtonType.SecondaryGray.GetDescription()} {ModalButtonSize.Medium.GetDescription()} class-handle-Close-stack{stackCount} {childOfClass}\" data-dismiss=\"modal\">Close</button>");
                }
                builder.AppendLine("        </div>");
            }
            builder.AppendLine("        </div>");
            builder.AppendLine("    </div>");
            builder.AppendLine("</div>");

            builder.AppendLine("<script>");
            builder.AppendLine("    $(document).ready(function() {");
            //when the modal's button is clicked
            builder.AppendLine($"       $(\"#{eventListenerControlID}\").click(function(e){{");
            builder.AppendLine("            debugger;");
            //do not navigate to the anchor elements href URL
            builder.AppendLine("            e.preventDefault();");
            string clickOffOption = ""; //if left blank, the modal will close when the user clicks outside of the modal.
            if (!isCloseOnClickOff) clickOffOption = "{backdrop: 'static'}"; //the modal will not close when the user clicks outside of the modal...

            //display the modal
            builder.AppendLine($"           $(\"#{modalControlID}\").modal({clickOffOption});");
            builder.AppendLine("        });");
            builder.AppendLine("    });");
            builder.AppendLine("</script>");

            return new HtmlString(builder.ToString());
        }
    }
}
