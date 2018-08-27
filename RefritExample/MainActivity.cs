using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using RefritExample;
using Refit;
using System.Collections.Generic;
using Android.Util;
using Android.Support.V7.Widget;

namespace RefitExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private PokemonService pokemonService;
        private List<Pokemon> pokemons = new List<Pokemon>();
        private RecyclerView pokeRecycler;
        private PokemonAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            pokeRecycler = FindViewById<RecyclerView>(Resource.Id.recycler_poke);
            pokeRecycler.HasFixedSize = true;
            adapter = new PokemonAdapter(pokemons, this);
            pokeRecycler.SetAdapter(adapter);

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings() {
                ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = { new StringEnumConverter() }
            };

            try {
                pokemonService = RestService.For<PokemonService>("https://pokeapi.co");
            }
            catch (Exception e) {
                Log.Error("TAGG", e.StackTrace);
            }

            

            getData();

        }

        private async void getData() {

            try {

                MyResponse response = await pokemonService.getMyResponse();
                pokemons = response.results;

                adapter.setItems(pokemons);

            } catch (Exception e) {
                Toast.MakeText(this, e.StackTrace, ToastLength.Long).Show();
                Log.Error("TAGG", e.StackTrace);
            }


        }

        

        

       
	}
}

