$(->
	$('a#sign-out').click(->
		$.progressBar()
		FB.getLoginStatus((response) ->
			if response.status == 'connected'
				FB.logout() 
			$.progressBar('hide')
		)
	)
)