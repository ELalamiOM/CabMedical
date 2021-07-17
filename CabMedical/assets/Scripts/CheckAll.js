$(function () {
    $("#chkAll").click(function () {
        //Determine the reference CheckBox in Header row.
        var chkAll = this;

        //Fetch all row CheckBoxes in the Table.
        var chkRows = $("#html_table").find(".chkRow");

        //Execute loop over the CheckBoxes and check and uncheck based on
        //checked status of Header row CheckBox.
        chkRows.each(function () {
            $(this)[0].checked = chkAll.checked;
            //if (!$(this).is(":checked")) {
            //    var td = $("td", $(this).closest("tr"));
            //    td.css({ "background-color": "#FFF" });
            //} else {
            //    var td = $("td", $(this).closest("tr"));
            //    td.css({ "background-color": "#ddd" });
            //}
        });
    });
    $(document).on('click', '.chkRow', function() {
        //Determine the reference CheckBox in Header row.
        var chkAll = $("#chkAll");

        //By default set to Checked.
        chkAll.attr("checked", "checked");

        //Fetch all row CheckBoxes in the Table.
        var chkRows = $("#html_table").find(".chkRow");

        //Execute loop over the CheckBoxes and if even one CheckBox
        //is unchecked then Uncheck the Header CheckBox.
        chkRows.each(function () {
            if (!$(this).is(":checked")) {
                chkAll.removeAttr("checked", "checked");
                return;
            }
        });
        //if (!$(this).is(":checked")) {
        //    var td = $("td", $(this).closest("tr"));
        //    td.css({ "background-color": "#FFF" });
        //} else {
        //    var td = $("td", $(this).closest("tr"));
        //    td.css({ "background-color": "#ddd" });
        //}
    });
    $('#del').on('click', function (e) {
        if ($("tbody").find(".chkRow:checked").length == 0) {
            swal("Attention", "Veuillez cochez les ligne à supprimer", "warning");
        }
        else {
            $("#m_modal_1").modal("show");
        }
    });

    $('#EnCours').on('click', function (e) {
        if ($("tbody").find(".chkRow:checked").length == 0) {
            swal("Attention", "Veuillez cochez au mois une ligne", "warning");
        }
        else {
            $("#m_modal_EnCours").modal("show");
        }
    });

    $('#Annulee').on('click', function (e) {
        if ($("tbody").find(".chkRow:checked").length == 0) {
            swal("Attention", "Veuillez cochez au mois une ligne", "warning");
        }
        else {
            $("#m_modal_Annulee").modal("show");
        }
    });

    $('#Realisee').on('click', function (e) {
        if ($("tbody").find(".chkRow:checked").length == 0) {
            swal("Attention", "Veuillez cochez au mois une ligne", "warning");
        }
        else {
            $("#m_modal_Realisee").modal("show");
        }
    });


    //$('#EnCours,#Annulee,#Realisee').on('click', function (e) {
    //    if ($("tbody").find(".chkRow:checked").length == 0) {
    //        swal("Attention", "Veuillez cochez au mois une ligne", "warning");
    //    } else {
    //        if (e.target.id == 'EnCours') {
    //            $("#m_modal_EnCours").modal("show");
    //        }
    //        else if (e.target.id == 'Annulee') {
    //            $("#m_modal_Annulee").modal("show");
    //        }
    //        else if (e.target.id == 'Realisee') {
    //            $("#m_modal_Realisee").modal("show");
    //        }
            
    //    }
    //});

});