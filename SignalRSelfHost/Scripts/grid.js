var grid;
require([
    "dojox/grid/DataGrid",
    "dojo/store/Memory",
    "dojo/data/ObjectStore",
    "dojo/domReady!"],
    function (DataGrid, Memory, ObjectStore) {
        /* create store here ... */
        var dataStore = new ObjectStore({ objectStore: new Memory({ data: [] }) });
        grid = new DataGrid({
            id: 'Seq',
            store: dataStore,
        }, "grid");

    });