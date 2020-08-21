function get_openid_access_token() {
    BGO.init({
        token: '3dee242917364a4f8d1bbedc688d4c84_oat',
        official_account_id: '17a99445f5674869bad1849c5c150f72_oa'
    });
    BGO.get_me_openid_access_token('1688E8DB-B8B0-48FE-AC10-3769C35CDE2D', '', callback);
};

var callback = function (data) {
    console.log(data);
    getOpenidUrl = `https://stg-api.beanfun.com/v1/openid/token/verification?token=${data.access_token}`
    var a = new Vue({
        el: '#userInfo',
        data: {
            UserName: data.me_profile.nickname,
            UserImg: data.me_profile.photo
        }
    })
    checkUser(data);
};
var checkUser = function (data) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(this.responseText);
            var res = this.responseText.split(",");
            $('.openid').text(res[4]);
            var GetOpenID = JSON.parse(this.responseText);
            var UserOpenID = `${GetOpenID.open_id}`;
            var SaveUserName = `${data.me_profile.nickname}`;
            var SaveUserImg = `${data.me_profile.photo}`;
            SaveUserData(UserOpenID, SaveUserName, SaveUserImg);
        }
    };
    console.log(getOpenidUrl);
    xhttp.open("GET", getOpenidUrl, true);
    xhttp.send();
}

var SaveUserData = function (UserOpenID, SaveUserName, SaveUserImg) {
    var User = {
        UserId: UserOpenID,
        UserName: SaveUserName,
        UserImg: SaveUserImg
    }

    $.ajax({
        url: '/Home/SaveUserData',
        data: { jdata: JSON.stringify(User) },
        type: 'post',
        success: function () {
            console.log("成功了啦");
        },
        error: function () {
            console.log("失敗了啦");
        }
    })
    return;
}


$(document).ready(function () {
    get_openid_access_token();
});
