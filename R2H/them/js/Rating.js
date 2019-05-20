
        $(document).ready(function () {
            $(".rating-star-block .star").mouseleave(function () {
                $("#" + $(this).parent().attr('id') + " .star").each(function () {
                    $(this).addClass("outline");
                    $(this).removeClass("filled");
                });
            });
        $(".rating-star-block .star").mouseenter(function () {
                        var hoverVal = $(this).attr('rating');
        $(this).prevUntil().addClass("filled");
        $(this).addClass("filled");
        $("#RAT").html(hoverVal);
    });
                    $(".rating-star-block .star").click(function () {
                
                        var v = $(this).attr('rating');
        var newScore = 0;
        var updateP = "#" + $(this).parent().attr('id') + ' .CurrentScore';
        var artID = $("#" + $(this).parent().attr('id') + ' .articleID').val();

        $("#" + $(this).parent().attr('id') + " .star").hide();
                        $("#" + $(this).parent().attr('id') + " .yourScore").html("Your Score is : &nbsp;<b style='color:#ff9900; font-size:15px'>" + v + "</b>");
                        $.ajax({
            type: "POST",
        url: "Default.aspx/SaveRating",
                            data: "{articleID: '" + artID + "',rate: '" + v + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
                            success: function (data) {
            setNewScore(updateP, data.d);
        },
                            error: function (data) {
            alert(data.d);
        }
    });
});
});
                function setNewScore(container, data) {
            $(container).html(data);
        $("#myElem").show('1000').delay(2000).queue(function (n) {
            $(this).hide(); n();
    });
}
          