using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using RefitExample;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using RefritExample;
using Refit;
using System.Collections.Generic;
using Android.Util;

namespace RefitExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private PokemonService pokemonService;
        private List<Pokemon> pokemons = new List<Pokemon>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

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

                foreach (Pokemon pokemon in pokemons)
                {
                    Toast.MakeText(this, "Pokemon Name: " + pokemon.name, ToastLength.Short).Show();
                    Log.Debug("TAGG", pokemon.name);
                }


            } catch (Exception e) {
                Toast.MakeText(this, e.StackTrace, ToastLength.Long).Show();
                Log.Error("TAGG", e.StackTrace);
            }


        }

        

        

       
	}
}

