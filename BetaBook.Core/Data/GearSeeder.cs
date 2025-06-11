using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;

using BetaBook.Core.Entities;

namespace BetaBook.Core.Data;

public static class GearSeeder {
    public static async Task LoadGear(string gearPath) {
        List<Gear> gear = await ParseGear(gearPath);
        
    }

    private static async Task<List<Gear>> ParseGear(string gearPath) {
        using FileStream stream = File.OpenRead(gearPath);
        JsonDocument json = await JsonDocument.ParseAsync(stream);

        List<Gear> gear = [];
        foreach (JsonProperty gearType in json.RootElement.EnumerateObject()) {
            string type = gearType.Name; // active/passive

            foreach (JsonProperty manufSet in gearType.Value.EnumerateObject()) {
                string manufacturer = manufSet.Name;

                foreach (JsonProperty gearDesc in manufSet.Value.EnumerateObject()) {
                    string description = gearDesc.Name;

                    foreach (JsonElement sizeEl in gearDesc.Value.EnumerateArray()) {
                        gear.Add(new Gear() {
                            Type = type,
                            Manufacturer = manufacturer,
                            Description = description,
                            Size = sizeEl.GetString()
                        });
                    }
                }
            }
        }

        return gear;
    }
}
