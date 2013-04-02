(function() {

  $(function() {
    return $("form#sign-in-form").submit(function(e) {
      var credentials;
      e.preventDefault();
      credentials = $(this).serializeObject();
      return $.post("/api/AccountAPI/PostSignIn", credentials, function(response) {
        var redirectTo;
        if (response.loginStatus) {
          redirectTo = window.ProjectTemplateApp.helpers.getQueryStringParameterByName("ReturnUrl");
          return window.location = redirectTo ? redirectTo : "/Dashboard/Index";
        } else {
          $("div.sign-in-container").attr("class", "sign-in-container alert");
          return $("div.sign-in-container div.sign-in-error-message").show();
        }
      });
    });
  });

}).call(this);
