﻿var grid;
dojo.require("dojox.grid.EnhancedGrid");
dojo.require("dojo.data.ItemFileWriteStore");

dojo.ready(function () {
    /*set up data store*/
    var data = {
        identifier: 'Seq',
        items: []
    };
    //var data_list = [
    //    { col1: "normal", col2: false, col3: 'But are not followed by two hexadecimal', col4: 29.91 },
    //    { col1: "important", col2: false, col3: 'Because a % sign always indicates', col4: 9.33 },
    //    { col1: "important", col2: false, col3: 'Signs can be selectively', col4: 19.34 }
    //];
    //var rows = 60;
    //for (var i = 0, l = data_list.length; i < rows; i++) {
    //    data.items.push(dojo.mixin({ id: i + 1 }, data_list[i % l]));
    //}
    var store = new dojo.data.ItemFileWriteStore({ data: [] });

    /*set up layout*/
    var layout = [[
        { name: "Seq", field: "Seq", width: "auto" },
        { name: "UnitKey", field: "UnitKey", width: "auto" },
        { name: "GroupName", field: "GroupName", width: "auto" },
        { name: "LastFactoidDateTime", field: "LastFactoidDateTime", width: "auto" },
        { name: "LastFactoidDateTime_ToolTip", field: "LastFactoidDateTime_ToolTip", width: "auto" }
    ]];

    /*create a new grid:*/
    grid = new dojox.grid.EnhancedGrid({
        id: 'grid',
        store: store,
        structure: layout,
        rowSelector: '20px'
    },
        document.createElement('div'));

    /*append the new grid to the div*/
    dojo.byId("grid").appendChild(grid.domNode);

    /*Call startup() to render the grid*/
    grid.startup();
});
