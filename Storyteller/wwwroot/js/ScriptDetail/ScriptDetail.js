var a = new Vue({
    el: '#Title_Name',
    data: {
        Title: "劇本詳細內容"
    }
})

var GoBack = document.getElementById('Go_Back');
GoBack.onclick = function () {
    history.back();
}