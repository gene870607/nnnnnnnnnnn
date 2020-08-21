var like = false;

function ChangeColor(icon) {
    like = !like;

    if (like == true) {
        $('.red-heart').css("color", "orangered");
    }
    else {
        $('.red-heart').css("color", "#B2B2B2");
    }
};