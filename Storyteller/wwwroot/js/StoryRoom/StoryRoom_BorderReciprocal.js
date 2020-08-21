
$(document).ready(function () {
    setTimeout(function () {
        $('.line-topRight').eq(0).css({ "width": "40%", "border-top-color": "white", "transition": "width 2s ease-out" });
        $('.line-topLeft').eq(0).css({ "width": "40%", "border-top-color": "white", "transition": "width 2s ease-out" });
        $('.line-rightdown').eq(0).css({ "height": "100%", "border-right-color": "white", "transition": "height 2s ease-out 2.1s, border-right-color 1s" });
        $('.line-leftdown').eq(0).css({ "height": "100%", "border-left-color": "white", "transition": "height 2s ease-out 2.1s, border-left-color 1s" });
        $('.line-bottomright').eq(0).css({ "width": "50%", "border-bottom-color": "white", "transition": "width 2s ease-out 4.1s, border-bottom-color 1s" });
        $('.line-bottomleft').eq(0).css({ "width": "60%", "border-bottom-color": "white", "transition": "width 2s ease-out 4.1s, border-bottom-color 1s" });
    }, 2000);
});