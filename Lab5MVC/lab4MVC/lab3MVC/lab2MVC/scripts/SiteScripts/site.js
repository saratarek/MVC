function ConfirmDelete(id) {
    let res = confirm("Are you sure you want to delete this employee?");
    if (res) {
        $.ajax({
            url: "/Employee/Delete/" + id,
            type: "POST",
            success: function (response) {
                if (response) {
                    let res = $("#" + id);
                    res.remove();
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}
function OnSuccess(employee) {
    $("#form0")[0].reset();
    $("#exampleModal").modal("hide");
}