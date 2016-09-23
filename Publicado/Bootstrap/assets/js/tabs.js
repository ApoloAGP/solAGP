$(function () {
//####### Tabs
$('#tabs2, #tabs, #tabs3').tabs();

// Dynamic tabs
var tabTitle = $("#tab_title"),
    tabContent = $("#tab_content"),
    tabTemplate = "<li><a href='#{href}'>#{label}</a> <span class='ui-icon ui-icon-close'>Remove Tab</span></li>",
    tabCounter = 2;

var tabs = $("#tabs2").tabs();
});