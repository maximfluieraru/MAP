function BlockUI(elementID) {
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_beginRequest(function () {
        $("#" + elementID).block({ message: '<table align = "center"><tr><td>' + '<img src="../Images/loadingAnim.gif"/></td></tr></table>',
            css: {},
            overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB'
            }
        });
    });
    prm.add_endRequest(function () {
        $("#" + elementID).unblock();
    });
}
$(document).ready(function () {
    BlockUI("dvGrid");
    $.blockUI.defaults.css = {};
});
