using Microsoft.Maui.Controls;

using BetaBook.Core.Data;
using BetaBook.Core.Entities;
using BetaBook.UI.Pages;

namespace BetaBook.UI;

public partial class App : Application {
	private readonly DbManager _db;
	private readonly IDbConfigProvider _dbConfig;

	public App(DbManager db, IDbConfigProvider dbConfig) {
		InitializeComponent();
		Routing.RegisterRoute("home", typeof(MainPage));
		Routing.RegisterRoute("beta", typeof(BetaPage));

		_db = db;
		_dbConfig = dbConfig;

		MainPage = new AppShell();
	}

	protected override async void OnStart() {
		base.OnStart();

		// Seed gear tables when app loads if no gear exists yet
		var gear = await _db.FindAllAsync<Gear>();
		if (!gear.Any()) {
			await GearSeeder.LoadGear(_db, _dbConfig.GetGearDataPath());
		}
	}
}
