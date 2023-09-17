var plugin = {
	LoadLastSession: function()
	{
		//Loader and Saver
		//Load
		window.load_last_session();
	},
	
	SaveSession: function(data)
	{
		console.log("saving: ");
		console.log(UTF8ToString(data));
		window.save_session(UTF8ToString(data));
	},
	
	Log: function()
	{
		console.log("test log");
	},
	
	PostHistory: function(text)
	{
		post_history_ending(UTF8ToString(text));
	},
	
	PostOnWall: function(text)
	{
		post_wall_ending(UTF8ToString(text));
	}
};

mergeInto(LibraryManager.library, plugin);