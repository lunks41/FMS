
/// ### Auto Complete DropDown ###///
function BindAutoCompleteComboBoxData(e, t, o, a) {

    $.ajax({
        url: e,
        async: !1,
        type: "GET",
        cache: !1,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (e) {

            e = JSON.parse(e), null !== e && e.length > 0 ? ($("#" + t).kendoAutoComplete({
                dataTextField: o,
                dataValueField: a,
                placeholder: "Select..",
                filter: "contains",
                dataSource: e,
                select: function (e) {
                    if (e.dataItem) {
                        var o = this.dataItem(e.item.index());
                        void 0 !== o && null !== o && OnSelectDropdown(o, t)
                    }
                    else {

                    }
                },
                change: function (e) {
                    if (e.dataItem) {
                        var o = this.dataItem(e.item);

                        void 0 !== o && null !== o ? OnSelectDropdown(o, t) : ($("#" + t).data("kendoAutoComplete").text(""), $("#" + t).data("kendoAutoComplete").value(""))
                    } else { }
                }
            }), SelectedDropdown(t), AutoWithBindAutoCompleteComboBox(t)) : ($("#" + t).kendoAutoComplete({
                dataSource: [],
                placeholder: "Select..",
                filter: "contains"
            }), $("#" + t).data("kendoAutoComplete").text(""))
        },
        
    })
}

function AutoWithBindAutoCompleteComboBox(e) {

    var t = $("#" + e).data("kendoAutoComplete"),
        o = t.list.width();
    o > 100 && t.list.width("auto")
}
/// ### Auto Complete DropDown ###///
/// ### Combo Box DropDown ###///

function BindComboBox(e, t, o, a) {

    $.ajax({
        url: e,
        async: !1,
        type: "GET",
        cache: !1,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (e) {

            e = JSON.parse(e), null !== e && e.length > 0 ? ($("#" + t).kendoComboBox({
                dataTextField: o,
                dataValueField: a,
                placeholder: "Select..",
                filter: "contains",
                //suggest: !0,
                //autoBind: !1,
                //serverPaging: !0,
                //serverFiltering: !0,
                dataSource: e,
                select: function (e) {

                    if (e.dataItem) {
                        var o = this.dataItem(e.item.index());
                        void 0 !== o && null !== o && OnSelectDropdown(o, t)
                    }
                    else { }

                },
                change: function (e) {

                    if (e.dataItem) {
                        var o = this.dataItem(e.item);
                        void 0 !== o && null !== o ? OnSelectDropdown(o, t) : ($("#" + t).data("kendoComboBox").text(""), $("#" + t).data("kendoComboBox").value(""))
                    }
                    else { }
                }
            }), SelectedDropdown(t), AutoWithBindComboBox(t)) : ($("#" + t).kendoComboBox({
                dataSource: [],
                placeholder: "Select..",
                filter: "contains"
            }), $("#" + t).data("kendoComboBox").text(""), $("#" + t).data("kendoComboBox").value(''))
        },
        
    })
}

function AutoWithBindComboBox(e) {

    var t = $("#" + e).data("kendoComboBox"),
        o = t.list.width();
    o > 100 && t.list.width("auto")
}
/// ### Combo Box DropDown ###///
/// ### Multi Select DropDown and Multi Column Dropwn ###///
function BindMultiSelectComboBox(e, t, o, a) {

    $.ajax({
        url: e,
        async: !1,
        type: "GET",
        cache: !1,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (e) {

            e = JSON.parse(e), null !== e && e.length > 0 ? ($("#" + t).kendoMultiSelect({
                dataTextField: o,
                dataValueField: a,
                placeholder: "Multi Select..",
                filter: "contains",
                dataSource: e,
                select: function (e) {

                    if (e.dataItem) {
                        var o = this.dataItem(e.item.index());
                        void 0 !== o && null !== o && OnSelectDropdown(o, t)
                    }
                    else { }

                },
                change: function (e) {

                    if (e.dataItem) {
                        var o = this.dataItem(e.item);
                        void 0 !== o && null !== o ? OnSelectDropdown(o, t) : ($("#" + t).data("kendoMultiSelect").text(""), $("#" + t).data("kendoMultiSelect").value(""))
                    }
                    else { }
                }
            }), SelectedDropdown(t), AutoWithBindMultiColumnComboBox(t)) : ($("#" + t).kendoMultiSelect({
                dataSource: [],
                placeholder: "Multi Select..",
                filter: "contains"
            }), $("#" + t).data("kendoMultiSelect").text(""), $("#" + t).data("kendoMultiSelect").value(''))
        },
        
    })
}

function BindMultiColumnComboBox(e, t, o, a, Columns_properties, filterFields) {

    $.ajax({
        url: e,
        async: !1,
        type: "GET",
        cache: !1,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (e) {

            e = JSON.parse(e), null !== e && e.length > 0 ? ($("#" + t).kendoMultiColumnComboBox({
                dataTextField: o,
                dataValueField: a,
                placeholder: "Select..",
                filter: "contains",
                dataSource: e,
                columns: Columns_properties,
                footerTemplate: 'Total #: instance.dataSource.total() # items found',
                filterFields: filterFields,
                autoWidth: true,
                select: function (e) {
                    if (e.dataItem) {
                        var o = this.dataItem(e.item.index());
                        void 0 !== o && null !== o && OnSelectDropdown(o, t)
                    }
                    else {
                    }
                },
                change: function (e) {
                    if (e.dataItem) {
                        var o = this.dataItem(e.item);
                        void 0 !== o && null !== o ? OnSelectDropdown(o, t) : ($("#" + t).data("kendoMultiColumnComboBox").text(""), $("#" + t).data("kendoMultiColumnComboBox").value(""))
                    }
                    else {
                    }

                }
            }), SelectedDropdown(t)) : ($("#" + t).kendoMultiColumnComboBox({
                dataSource: [],
                placeholder: "Select..",
                filter: "contains"
            }), $("#" + t).data("kendoMultiColumnComboBox").text(""))
        },
        
    })
}

function AutoWithBindMultiColumnComboBox(e) {

    var t = $("#" + e).data("kendoMultiColumnComboBox"),
        o = t.list.width();
    o > 50 && t.list.width("auto")
}

/// ### Multi Select DropDown and Multi Column Dropwn ###///
/// ### Dropdown ###///

function BindDropdown(e, t, o, a) {
    $.ajax({
        url: e,
        async: !1,
        type: "GET",
        cache: !1,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (e) {

            //Harshad Added On 20 JAn 2024 Some Drop have array values and some JSON Format
            if (typeof e === "object") {
                e = e; //return Array [ return Json((ObjBindSuperObjects), JsonRequestBehavior.AllowGet);]
            } else {
                e = JSON.parse(e); // return JSON to array convert [return Json((ObjBindSuperObjects), JsonRequestBehavior.AllowGet);  Action Method]
            }

            null !== e && e.length > 0 ? ($("#" + t).kendoDropDownList({
                dataTextField: o,
                dataValueField: a,
                optionLabel: "Select",
                filter: "contains",
                dataSource: e,
                select: function (e) {

                    if (e.dataItem) {

                        //var o = this.dataItem(e.item.index());
                        var o = e.dataItem;
                        void 0 !== o && null !== o && OnSelectDropdown(o, t)
                    } else {

                    }
                },
                change: function (e) {

                    if (e.dataItem) {

                        //var o = this.dataItem(e.item);
                        var o = e.dataItem;
                        void 0 !== o && null !== o && OnSelectDropdown(o, t)
                    } else {

                    }
                }
            }), SelectedDropdown(t)) : ($("#" + t).kendoDropDownList({
                dataSource: [],
                optionLabel: "Select",
                filter: "contains"
            }), $("#" + t).data("kendoDropDownList").text(""))
        },
        
    })
}

/// ### Dropdown ###///

function CommonAjaxRequest(e, t, o) {

     $.ajax({
        url: e,
        type: o,
        cache: !1,
        contentType: "application/json; charset=utf-8",
        data: t,
        dataType: "html",
        success: function (e) {

            setTimeout(function () {
                
            }, 500), $("#Content").html(e), $("html, body").animate({
                scrollTop: 0
            }, "slow"), void 0 !== $("#login-form").html() && null !== $("#login-form").html() ? $("#divReplacement").html(e) : void 0 !== $("#error-form").html() && null !== $("#error-form").html() && $("#divReplacement").html(e)
        },
        
    })
}
function CreateRecordNew(Url, Params, o, a) {
    
    $.ajax({
        type: "POST",
        url: Url,
        data: Params,
        dataType: "json",
        async: true,
        success: function (n) {
            
            n = JSON.parse(n), setTimeout(function () {
            }, 500), "" !== n && null !== n && null !== n.ERROR_MESSAGE && "" !== n.ERROR_MESSAGE ? (setTimeout(function () {
            }, 500), setTimeout(function () {
                n.RESULT > 0 ? (toastr.success(n.ERROR_MESSAGE), 1 === o ? (RedirectActionToList(n), a()) : 2 === o ? RedirectActionToEdit(n) : DefaultSelection()) : toastr.error(n.ERROR_MESSAGE)
            }, 1e3)) : $("#lbl_Message").text("Error occurred in Url=" + e + ", Param" + t)
        },
        
    })
}
function UpdateRecordNew(e, t, o) {
     $.ajax({
        type: "POST",
        url: e,
        data: t,
        dataType: "json",
        success: function (a) {

            a = JSON.parse(a), setTimeout(function () {
                
            }, 500), "" !== a && null !== a && null !== a.ERROR_MESSAGE && "" !== a.ERROR_MESSAGE ? (setTimeout(function () {
                
            }, 500), setTimeout(function () {
                a.RESULT > 0 ? (toastr.success(a.ERROR_MESSAGE), 1 === o ? RedirectActionToList(a) : 2 === o ? RedirectActionToEdit(a) : DefaultSelection()) : toastr.error(a.ERROR_MESSAGE)
            }, 1e3)) : $("#lbl_Message").text("Error occurred in Url=" + e + ", Param" + t)
        },
        
    })
}
function CreateRecord(e, t, o) {
     $.ajax({
        type: "POST",
        url: e,
        data: t,
        dataType: "json",
        success: function (a) {
            a = JSON.parse(a), setTimeout(function () {
                
            }, 500), "" !== a && null !== a ? (null !== a.ERROR_MESSAGE && "" !== a.ERROR_MESSAGE ? (setTimeout(function () {
                
            }, 500), a.RESULT > 0 ? toastr.success(a.ERROR_MESSAGE) : toastr.error(a.ERROR_MESSAGE)) : $("#lbl_Message").text("Error occurred in Url=" + e + ", Param" + t), setTimeout(function () {
                a.RESULT > 0 && (o ? RedirectAction(a) : DefaultSelection())
            }, 1e3)) : $("#lbl_Message").text("Error occurred in Url=" + e + ", Param" + t)
        },
        
    })
}
function UpdateRecord(e, t, o) {
     $.ajax({
        type: "POST",
        url: e,
        data: t,
        dataType: "json",
        success: function (a) {
            a = JSON.parse(a), setTimeout(function () {
                
            }, 500), "" !== a && null !== a ? (null !== a.ERROR_MESSAGE && "" !== a.ERROR_MESSAGE ? $("#lbl_Message").text(a.ERROR_MESSAGE) : $("#lbl_Message").text("Error occurred in Url=" + e + "Param" + t), setTimeout(function () {
                a.RESULT > 0 && (o ? RedirectAction(a) : DefaultSelection())
            }, 1e3)) : $("#lbl_Message").text("Error occurred in Url=" + e + "Param" + t)
        },
        
    })
}
function DeleteRecord(e, t, o) {
     $.ajax({
        url: e,
        type: "POST",
        cache: !1,
        data: t,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (a) {
            a = JSON.parse(a), setTimeout(function () {
                
            }, 1e3), "" !== a && null !== a ? (null !== a.ERROR_MESSAGE && "" !== a.ERROR_MESSAGE ? $("#lbl_DeletePopupMessage").text(a.ERROR_MESSAGE) : $("#lbl_DeletePopupMessage").text("DeleteFailed"), a.RESULT > 0 && (setTimeout(function () {
                ClosePopup("Popup_Delete")
            }, 1e3), o ? LoadTabsGrid() : DeleteRedirect())) : $("#lbl_Message").text("Error occurred in Url=" + e + "Param" + t)
        },
        
    })
}

//*************** GRIDS BLOCK BEGIN ***************
function FillUpdatedGrid(Url, Params, GridName, PageSize, Columns_properties, Aggregate, DataFunction, ScreenName, DataAdd) {
    
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    var time = today.getHours() + ':' + today.getMinutes() + ':' + today.getSeconds();
    var CurrentDateTime = date + ' ' + time;

    var ColsProp = JSON.stringify(Columns_properties).split('"').join("&quot;");

    var templates = DataFunction[0].template;

    var toolbar = DataFunction[0].toolbar ? false : ["excel", "pdf", "search"];

    var save = DataFunction[0].save;
    var dataBound = DataFunction[0].dataBound;
    var GridTemplate = DataFunction[0].GridColumnTemplate;
    var save_function = save == true ? eval('OnGridCellChanges_' + GridName) : false;
    var dataBound_function = dataBound == true ? (GridName == 'Active' || GridName == 'Inactive' ? eval('onDataBoundExtension_' + GridName) : eval('onDataBoundExtension_' + GridName)) : false;
    var GridHeight = DataFunction[0].GridHeight == true ? '500px' : false;

    if (Url == '') {
        GridLayout(DataAdd, toolbar, GridTemplate, save_function, dataBound_function, Columns_properties, ScreenName, GridName, PageSize, CurrentDateTime, Aggregate, GridHeight);
    }
    else {
        
        $.ajax({
            type: "POST",
            url: Url,
            data: Params,
            dataType: "json",
            async: true,
            success: function (e) {

                GridLayout(e, toolbar, GridTemplate, save_function, dataBound_function, Columns_properties, ScreenName, GridName, PageSize, CurrentDateTime, Aggregate, GridHeight);
            },
            
        }), KendoGridToolTip(GridName)
    }
}

function GridLayout(e, toolbar, GridTemplate, save_function, dataBound_function, Columns_properties, ScreenName, GridName, PageSize, CurrentDateTime, Aggregate, GridHeight) {

    if (e = JSON.parse(e), void 0 !== Columns_properties && "" !== Columns_properties && (hidecolumns = Columns_properties), $("#grid_" + GridName).html(""), null !== e && e.length > 0) {

        //Adding Header Name With Total QTY
        if ($("#li_" + GridName).html()) {
            var Grid_Title = $("#li_" + GridName).html();
            Grid_Title.indexOf(" (") > 0 && (Grid_Title = Grid_Title.substring(0, Grid_Title.indexOf(" ("))), $("#li_" + GridName).html(Grid_Title + " (" + e.length + ")"), null !== e && e.length > 0
        }

        GenerateGridModelColumnsProperties(e[0], GridName, Columns_properties, Aggregate, GridTemplate);

        dataSource = new kendo.data.DataSource({
            type: "text",
            data: e,
            schema: {
                model: model
            },
            aggregate: Aggregate,
            pageSize: PageSize == '' ? 500 : PageSize
            /*group: gridGroup*/

        });

        $("#grid_" + GridName).kendoGrid({
            height: GridHeight,
            dataSource: dataSource,
            toolbar: toolbar,
            excel: {
                fileName: GridName + " (" + CurrentDateTime + ") " + ".xlsx",
                filterable: true,
                allPages: true
            },
            pdf: {
                allPages: true,
                avoidLinks: true,
                paperSize: "A2",
                margin: { top: "2cm", left: "1cm", right: "1cm", bottom: "1cm" },
                landscape: true,
                repeatHeaders: true,
                template: $("#page-template").html(),
                scale: 0.7,
                fileName: GridName + " (" + CurrentDateTime + ") " + ".PDF"
            },
            scrollable: true,
            columns: columnsOptions,
            dataBound: dataBound_function,
            pageable: {
                refresh: true,
                pageSizes: true,
                buttonCount: 5,
                pageSizes: ["All", 10, 20, 50, 100, 500],
            },
            editable: true,
            sortable: true,
            selectable: true,
            resizable: true,
            reorderable: true,
            columnMenu: true,
            save: save_function
        });
    } else $("#grid_" + GridName).html(
        `<div class="alert alert-danger">
                    <strong>Data not available!</strong>
                  </div>`
    )
}

function GenerateGridModelColumnsProperties(e, GridName, Columns_properties, Aggregate, GridTemplate) {

    columnsOptions = [], model = {}, modelfields = null, model.id = "ID";
    var o = {};
    modelfields = new Array;
    aggregateArray = [];

    if (GridTemplate) {

        (GridName == 'Active' || GridName == 'Inactive') ? GridColumnTemplate(e, GridName) : eval("GridColumnTemplate_" + GridName + "(e, GridName)");
    }

    for (let a of Columns_properties) {

        modelfields.push(a.columnName);

        if (a.dataType == "date") {

            o[a.columnName] = { type: "date", editable: a.iseditable };
            columnsOptions.push({

                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                type: "date",
                width: a.width,
                editor: a.editor,
                hidden: a.isHidden,
                locked: a.islocked,
                format: "{0:dd MMM yyyy}",  //"{0:d}",
                parseFormats: "{0:dd MMM yyyy}", //"{0:d}",
                filterable: {
                    ui: function (e) {
                        e.kendoDatePicker({
                            format: "dd MMM yyyy"
                        });
                    },
                    extra: false
                }
            })
        }
        else if (a.dataType == "dateongrid") {

            o[a.columnName] = { type: "date", editable: a.iseditable };
            columnsOptions.push({

                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                type: "date",
                width: a.width,
                template: a.template,
                editor: a.editor,
                hidden: a.isHidden,
                locked: a.islocked,
                format: "{0:dd MMM yyyy}",
                parseFormats: "{0:dd MMM yyyy}"
            })
        }
        else if (a.dataType == "datetime") {

            o[a.columnName] = { type: "date", editable: a.iseditable };

            columnsOptions.push({
                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                type: "date",
                width: a.width,
                editor: a.editor,
                hidden: a.isHidden,
                locked: a.islocked,
                format: "{0:dd MMM yyyy H:mm}",  //"{0:d}",
                parseFormats: "{0:dd MMM yyyy H:mm}", //"{0:d}",
                filterable: {
                    ui: function (e) {
                        e.kendoDatePicker({
                            format: "dd MMM yyyy"
                        });
                    },
                    extra: false
                }
            })
        }
        else if (a.dataType == "amount") {

            o[a.columnName] = {
                type: "number", editable: a.iseditable, /*validation: validation*/
            };
            var isAggregate = false;
            var aggregate = "";

            for (let x in Aggregate) {

                if (Aggregate[x].field == a.columnName) {
                    isAggregate = true;
                    aggregate = Aggregate[x].aggregate;
                    break;
                }
            }

            if (isAggregate) {

                columnsOptions.push({
                    field: a.columnName,
                    title: (a.title != undefined) ? a.title : a.columnName,
                    type: "number",
                    format: "{0:n2}",
                    /*template: "#=("+a.columnName+" < 0 ? '-$' : '') +"+ Math.abs(a.columnName)+" #",*/
                    aggregates: [aggregate],
                    footerTemplate: "#=kendo.toString(" + aggregate + ", \"" + "{0:n2}" + "\")#", //n2
                    footerAttributes: {
                        "class": "aggregate_footertemplate_td",
                        "style": "text-align: right;font-size: 15px",
                    },
                    attributes: {
                        style: "text-align: right;"
                    },
                    width: a.width,
                    editor: a.editor,
                    hidden: a.isHidden,
                    locked: a.islocked,
                    filterable: {
                        cell: {
                            operator: "contains",
                            extra: !1
                        },
                        ui: function (e) {
                            e.kendoAutoComplete({
                                dataSource: e
                            });
                        }
                    }
                })
            }
            else {
                columnsOptions.push({
                    field: a.columnName,
                    title: (a.title != undefined) ? a.title : a.columnName,
                    type: "number",
                    format: "{0:n2}",
                    /*template: "#=(" + a.columnName + " < 0 ? '-$' : '') +" + Math.abs(a.columnName) + " #",*/
                    attributes: {
                        style: "text-align: right;"
                    },
                    width: a.width,
                    editor: a.editor,
                    hidden: a.isHidden,
                    locked: a.islocked,
                    filterable: {
                        cell: {
                            operator: "contains",
                            extra: !1
                        },
                        ui: function (e) {
                            e.kendoAutoComplete({
                                dataSource: e
                            });
                        }
                    }
                })
            }

        }
        else if (a.dataType == "ex_Rate") {

            o[a.columnName] = { type: "number", editable: a.iseditable };
            columnsOptions.push({
                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                type: "number",
                format: "{0:n2}",
                attributes: {
                    style: "text-align: right;"
                },
                width: a.width,
                editor: a.editor,
                hidden: a.isHidden,
                locked: a.islocked,
                filterable: {
                    cell: {
                        operator: "contains",
                        extra: !1
                    },
                    ui: function (e) {
                        e.kendoAutoComplete({
                            dataSource: e
                        });
                    }
                }
            })
        }
        else if (a.dataType == "checkbox") {

            o[a.columnName] = { type: "boolean", editable: a.iseditable };

            columnsOptions.push({
                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                template: a.template,
                type: "string",
                width: a.width,
                editor: a.editor,
                hidden: a.isHidden,
                locked: a.islocked,
                filterable: {
                    cell: {
                        operator: "contains",
                        extra: !1
                    },
                    ui: function (e) {
                        e.kendoAutoComplete({
                            dataSource: e
                        });
                    }
                }
            })
        }
        else if (a.datatype == "editable") {

            o[a.columnname] = { type: "number", editable: a.iseditable, validation: { required: true } }; // Value should be change as a number in column cell https://docs.telerik.com/kendo-ui/api/javascript/ui/grid/configuration/columns.editoroptions,
            https://dojo.telerik.com/OhaVAKor/12

            columnsoptions.push({
                field: a.columnname,
                title: (a.title != undefined) ? a.title : a.columnname,
                type: "number",
                format: "{0:n2}",
                attributes: {
                    style: "text-align: right;"
                },
                editor: function (cont, options) {
                    $("<span>" + options.model.a.columnname + "</span>").appendTo(cont);
                },
                width: a.width,
                editor: a.editor,
                hidden: a.ishidden,
                locked: a.islocked,
                filterable: {
                    cell: {
                        operator: "contains",
                        extra: !1
                    },
                    ui: function (e) {
                        e.kendoautocomplete({
                            datasource: e
                        });
                    }
                }
            })
        }
        else if (a.dataType == "bool") {

            o[a.columnName] = { type: "boolean", editable: a.iseditable };

            columnsOptions.push({
                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                type: "string",
                width: a.width,
                editor: a.editor,
                hidden: a.isHidden,
                locked: a.islocked,
                filterable: {
                    cell: {
                        operator: "contains",
                        extra: !1
                    },
                    ui: function (e) {
                        e.kendoAutoComplete({
                            dataSource: e
                        });
                    }
                }
            })
        }
        else if (a.dataType == "stringlink") {

            o[a.columnName] = { type: "string", editable: a.iseditable };
            columnsOptions.push({
                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                type: "string",
                template: a.template,
                width: a.width,
                hidden: a.isHidden,
                locked: a.islocked,
                filterable: {
                    cell: {
                        operator: "contains",
                        extra: !1
                    },
                    ui: function (e) {
                        e.kendoAutoComplete({
                            dataSource: e
                        });
                    }
                }
            })
        }
        else {
            o[a.columnName] = { type: "string", editable: a.iseditable };
            columnsOptions.push({
                field: a.columnName,
                title: (a.title != undefined) ? a.title : a.columnName,
                type: "string",
                width: a.width,
                //editable: a.iseditable,
                editor: a.editor,
                hidden: a.isHidden,
                locked: a.islocked,
                filterable: {
                    cell: {
                        operator: "contains",
                        extra: !1
                    },
                    ui: function (e) {

                        e.kendoAutoComplete({
                            dataSource: e
                        });
                    }
                }
            })
        }
    }
    model.fields = o
}

function KendoGridToolTip(e) {
    $("#grid_" + e).kendoTooltip({
        show: function (e) {
            this.content.text().length > 10 && this.content.parent().css("visibility", "visible")
        },
        hide: function (e) {
            this.content.parent().css("visibility", "hidden")
        },
        filter: "td[role=gridcell]",
        content: function (e) {
            var t = e.target;
            if ("" !== t.text()) var o = t.text();
            return o
        },
        position: "bottom"
    }).data("kendoTooltip")
}