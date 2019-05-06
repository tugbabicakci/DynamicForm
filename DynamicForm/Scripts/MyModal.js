@section scripts
{
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
        <script src="~/Scripts/bootstrap.js"></script>
        <script src="~/Scripts/bootstrap.min.js"></script>
        <script>
            var TeamDetailPostBackURL = '/Home/Details';
    $(function () {
                $(".anchorDetail").click(function () {
                    debugger;
                    var $buttonClicked = $(this);
                    var id = $buttonClicked.attr('data-id');
                    var options = { "backdrop": "static", keyboard: true };
                    $.ajax({
                        type: "GET",
                        url: TeamDetailPostBackURL,
                        contentType: "application/json; charset=utf-8",
                        data: { "Id": id },
                        datatype: "json",
                        success: function (data) {
                            debugger;
                            $('#myModalContent').html(data);
                            $('#myModal').modal(options);
                            $('#myModal').modal('show');

                        },
                        error: function () {
                            alert("Dynamic content load failed.");
                        }
                    });
                });
                //$("#closebtn").on('click',function(){  
                //    $('#myModal').modal('hide');    

                $("#closbtn").click(function () {
                    $('#myModal').modal('hide');
                });
            });
            
</script>  
  
}  