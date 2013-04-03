window.ProjectTemplateApp = window.ProjectTemplateApp || {}
window.ProjectTemplateApp.socialHelpers = window.ProjectTemplateApp.socialHelpers || {};

do (document) ->
	js 
	id = 'facebook-jssdk'
	ref = document.getElementsByTagName('script')[0]
	if !document.getElementById(id) 
		js = document.createElement('script')
		js.id = id
		js.async = true
		js.src = "//connect.facebook.net/en_US/all.js"
		ref.parentNode.insertBefore(js, ref)

SubmitLogin = (userInformation) ->
	$.ajax({
		url: "api/AccountAPI/AuthorizeFbUser"
		type: "POST"
		data: userInformation
		error: -> alert("Error! Please Try Again later!")
		success: (response) -> 
			$.progressBar('hide');
			window.location = response.url
	})

window.ProjectTemplateApp.socialHelpers.InitializeFacebookApi = (appId) ->
	window.fbAsyncInit = -> (FB.init(
			appId: appId,
			status: true, 
			cookie: true, 
			xfbml: true)

	FB.Event.subscribe('auth.login', (response) -> 
			fbUserInformation = 
				Uid: response.authResponse.userID

			FB.api('/me', (userInfo) ->
				$.progressBar();
				fbUserInformation.Email = userInfo.email
				fbUserInformation.FirstName = userInfo.first_name
				fbUserInformation.LastName = userInfo.last_name
				fbUserInformation.FacebookUid = userInfo.id
				SubmitLogin(fbUserInformation)
			)
		))	