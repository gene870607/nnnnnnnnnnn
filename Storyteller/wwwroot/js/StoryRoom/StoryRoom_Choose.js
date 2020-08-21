

function YesBeenClick(x) {
    x = !x;
    if (x = true) {
        $('.s-c-btn-yes').eq(0).css({ "box-shadow": "none", "border": "2px inset #CEADC2", "background-color": "#CEADC2" });
        $('.s-c-b-yes-img').eq(0).children('img').css({ "transform": "rotate(-30deg)", "transition-duration": ".3s" });
        $('.s-c-b-yes-text').eq(0).children('h3').css({ "color" : "white" });
    }
    else {
        $('.s-c-btn-yes').eq(0).css({ "box-shadow": "5px 2px 2px rgba(0, 0, 0, 0.25)", "border": "2px solid #CEADC2", "background-color": "white" });
        $('.s-c-b-yes-img').eq(0).children('img').css({ "transform": "none", "transition-duration": "none" });
        $('.s-c-b-yes-text').eq(0).children('h3').css({ "color": "#6ECACA"});
    }
};