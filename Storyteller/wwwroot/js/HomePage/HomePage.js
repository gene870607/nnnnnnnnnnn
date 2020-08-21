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

var TitleName = new Vue({
    el: '#Title_Name',
    data: {
        Title: "創作大廳"
    }
});

var swipers = document.querySelectorAll('.sp');
swipers.forEach(item => {
    item.addEventListener('click', function () {
        var UrlId = this.id;
        $.ajax({
            url: "/Home/Category/"+UrlId,
            type: "POST",
            data: { id: this.id },
            dataType: "text",
            success: function (response) {
                window.location.href = "Home/Category/" + UrlId;
            },
            error: function () {
            }
        })
    });
});

var imgs = document.querySelectorAll('#script img');
imgs.forEach(item => {
    item.addEventListener('click', function () {
        var UrlId = this.id;
        $.ajax({
            url: "/Home/Category/" + UrlId,
            type: "POST",
            data: { id: this.id },
            dataType: "text",
            success: function (response) {
                window.location.href = "Home/Category/" + UrlId;
            },
            error: function () {
            }
        })
    });
});

$('#indexFooter .row').on('click', function () {
    $("html").scrollTop(0);
});