var AppScripts = function () {
    return {
        LoadMessages: function () {
            let userId = $('.selected-message').attr("data-userId");
            if (userId == "" || userId == undefined || userId == null) {
                return false;
            }
            $.ajax({
                type: "GET",
                url: "/Messages/LoadMessages",
                data: {
                    userId: userId
                },
                success: function (response) {
                    $("#MessagesContainer").html(response);
                }
            });
        },
        LoadSelectedUserMessages: function ($this) {
            $('.each-message-user').each(function () {
                $(this).removeClass('selected-message');
            });
            $($this).addClass('selected-message');
            AppScripts.LoadMessages();
        },
        SaveMessage: function () {
            let message = $('#txttMessage').val();
            let userId = $('.selected-message').attr("data-userId");
            $.ajax({
                type: "POST",
                url: "/Messages/SaveMessage",
                data: {
                    message: message,
                    toId: userId
                },
                success: function (response) {
                    AppScripts.LoadMessages();
                    $('#txttMessage').val('');
                }
            })
        }
    }
}();