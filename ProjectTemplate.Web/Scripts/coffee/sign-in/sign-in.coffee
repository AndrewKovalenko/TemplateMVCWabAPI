$ -> 
	$("form#sign-in-form").submit  (e) -> 
		e.preventDefault()
		credentials = $(this).serializeObject()

		$.post "/api/AccountAPI/PostSignIn", credentials, (response) ->
			if response.loginStatus
				redirectTo = window.ProjectTemplateApp.helpers.getQueryStringParameterByName("ReturnUrl")
				window.location = if redirectTo then redirectTo else "/Dashboard/Index"
			else
				$("div.sign-in-container").attr("class", "sign-in-container alert")
				$("div.sign-in-container div.sign-in-error-message").show()
				
				