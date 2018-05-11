function deleteBlog(target) {
    var deleteConfirm = confirm("Are you sure you want to delete?");
    if (!deleteConfirm) {
        return;
    }
    $(target).siblings().eq(1).val(1);
    $(target).parent().submit();
}