using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ArrayListAdapterPractice
{
	[Activity(Label = "Instructors", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		ListView _instructorListView;
		V7Toolbar _toolbar;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			SetViewReferences();

			SetSupportActionBar(_toolbar);


			SetListViewAdapter();
			_instructorListView.FastScrollEnabled = true;
		}

		void SetViewReferences()
		{
			_instructorListView = FindViewById<ListView>(Resource.Id.InstructorListView);
			_toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
		}

		void SetListViewAdapter()
		{
			var adapter = new InstructorAdapter(this, InstructorData.Instructors);
			_instructorListView.Adapter = adapter;
		}
	}
}


