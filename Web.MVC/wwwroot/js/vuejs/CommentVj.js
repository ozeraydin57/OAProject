﻿var app = new Vue({
    el: '#vueComment',
    data: {
        name: null,
        email: null,
        web: null,
        comment: null,
        response: '',
        disabledButton: false,
        error: null
    },
    methods: {
        sendComment: function (postId) {
            $('.alertSucc').hide();
            $('.alertErr').hide();
            if (this.checkForm()) {

                this.disabledButton = true;
                this.response = "Yorumunuz iletiliyor.."
                $.ajax({
                    method: "post",
                    url: "/PostComment/Create",
                    data: {
                        PostId: postId,
                        Name: this.name,
                        Email: this.email,
                        Web: this.web,
                        Comment: this.comment,
                    },
                    success: (data) => {
                        console.log(data);
                        if (data.success)
                            this.response = data;
                        else
                            this.disabledButton = false;
                        $('.alertSucc').fadeIn();
                        $('.alertErr').hide();
                    }
                });
            }
        },
        checkForm: function () {
            if (this.name && this.email && this.comment) {
                return true;
            }
            this.error = "Lütfen * ile işaretlenmiş alanları doldurunuz!"
            $('.alertErr').fadeIn();
            return false;
        }
    }
})