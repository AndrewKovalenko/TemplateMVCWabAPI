(function() {

  $(function() {
    return $('a#sign-out').click(function() {
      $.progressBar();
      return FB.getLoginStatus(function(response) {
        if (response.status === 'connected') {
          FB.logout();
        }
        return $.progressBar('hide');
      });
    });
  });

}).call(this);
