/// <reference path="types-gtanetwork/index.d.ts" />
var menuPool = null;
API.onServerEventTrigger.connect(function (name, args) {
    if (name == "create_menu") {
        menuPool = API.getMenuPool();
        var callbackId = args[0];
        var title = args[1];
        var subtitle = args[2];
        var noExit = args[3];
        var itemsLenght = args[4];
        var menu = null;
        if (title != null)
            menu = API.createMenu(title, subtitle, 20, 20, 2);
        else
            menu = API.createMenu(subtitle, 20, 20, 2);
        for (var i = 0; i < itemsLenght; i++) {
            var item = args[5 + i];
            var subtitle = args[5 + i + itemsLenght];
            if (subtitle == null)
                item = API.createMenuItem(item, "");
            else
                item = API.createMenuItem(item, subtitle);
            menu.AddItem(item);
        }
        menu.Visible = true;
        menuPool.Add(menu);
    }
    else if (name == "destroy_menu") {
        menuPool = null;
    }
});
API.onUpdate.connect(function () {
    if (menuPool != null) {
        menuPool.ProcessMenus();
    }
});
