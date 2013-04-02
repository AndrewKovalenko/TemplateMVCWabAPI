(function() {
  var SubmitLogin;

  window.ProjectTemplateApp = window.ProjectTemplateApp || {};

  window.ProjectTemplateApp.socialHelpers = window.ProjectTemplateApp.socialHelpers || {};

  (function(document) {
    js;

    var id, js, ref;
    id = 'facebook-jssdk';
    ref = document.getElementsByTagName('script')[0];
    if (!document.getElementById(id)) {
      js = document.createElement('script');
      js.id = id;
      js.async = true;
      js.src = "//connect.facebook.net/en_US/all.js";
      return ref.parentNode.insertBefore(js, ref);
    }
  })(document);

  SubmitLogin = function(userInformation) {
    return $.ajax({
      url: "api/AccountAPI/AuthorizeFbUser",
      type: "POST",
      data: userInformation,
      error: function() {
        return alert("Error! Please Try Again later!");
      },
      success: function(response) {
        $.progressBar('hide');
        return window.location = response.url;
      }
    });
  };

  window.ProjectTemplateApp.socialHelpers.InitializeFacebookApi = function(appId) {
    return window.fbAsyncInit = function() {
      FB.init({
        appId: appId,
        status: true,
        cookie: true,
        xfbml: true
      });
      return FB.Event.subscribe('auth.login', function(response) {
        var fbUserInformation;
        fbUserInformation = {
          Uid: response.authResponse.userID
        };
        return FB.api('/me', function(userInfo) {
          $.progressBar();
          fbUserInformation.Email = userInfo.email;
          fbUserInformation.FirstName = userInfo.first_name;
          fbUserInformation.LastName = userInfo.last_name;
          return SubmitLogin(fbUserInformation);
        });
      });
    };
  };

}).call(this);
