var a = new Vue({
    el: '#Title_Name',
    data: {
        Title: "選擇一個劇本"
    }
})

//< !--Initialize Swiper-- >
var swiper = new Swiper('#script .swiper-container', {
    effect: 'coverflow',
    grabCursor: true,
    centeredSlides: true,
    slidesPerView: 'auto',
    coverflowEffect: {
        rotate: 50,
        stretch: 0,
        depth: 100,
        modifier: 1,
        slideShadows: true,
    },
    pagination: {
        el: '#script .swiper-pagination'
    },
});

var swiper2 = new Swiper('#top10Player .swiper-container', {
    slidesPerView: 5,
    spaceBetween: 10,
    pagination: {
        el: '#top10Player .swiper-pagination',
        clickable: true,
    },
});

var swiper3 = new Swiper('#top10Creation .swiper-container', {
    slidesPerView: 3,
    spaceBetween: 10,
    pagination: {
        el: '#top10Creation .swiper-pagination',
        clickable: true,
    },
});

var swipers = document.querySelector('.swiper-slide');
swipers.addEventListener('click', function () {
    var ID = this.id;
    var CategoryOrScriptId = ID.trim().split(" ");
    var Category = CategoryOrScriptId[0];
    var Script = CategoryOrScriptId[1];
    $.ajax({
        url: "/Home/ScriptDetail/" + Category + "/" + Script,
        type: "POST",
        data: {
            CategoryID: CategoryOrScriptId[0],
            scriptID: CategoryOrScriptId[1]
        },
        dataType: "text",
        success: function (response) {
            window.location.href = "https://testtestqwe.azurewebsites.net/Home/ScriptDetail/" + Category + "/" + Script;
            //$('body').html(response);
        },
        error: function () {
        }
    })
});

var GoBack = document.getElementById('Go_Back');
GoBack.onclick = function () {
    history.back();
}