window.ProjectTemplateApp = window.ProjectTemplateApp || {}

window.ProjectTemplateApp.helpers = do ->
	helpersContainer = {}
	helpersContainer.getQueryStringParameterByName = (name) ->
			name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
			regexS = "[\\?&]" + name + "=([^&#]*)";
			regex = new RegExp(regexS);
			results = regex.exec(window.location.search);
			if(results == null)
				return "";
			else
			return decodeURIComponent(results[1].replace(/\+/g, " "));
	helpersContainer