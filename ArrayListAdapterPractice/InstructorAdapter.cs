using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ArrayListAdapterPractice
{
	public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
	{
		public InstructorAdapter(Activity context, IList<Instructor> instructorList)
		{
			_context = context;
			_instructorList = instructorList;
			_sectionHeaders = SectionIndexBuilder.BuildSectionHeaders(instructorList);
			_sectionForPosition = SectionIndexBuilder.BuildSectionForPositionMap(instructorList);
			_positionForSection = SectionIndexBuilder.BuildPositionForSectionMap(instructorList);
		}

		public override Instructor this[int position]
		{
			get
			{
				return _instructorList[position];
			}
		}

		public override int Count
		{
			get
			{
				return _instructorList.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		int count = 0;
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			
			var view = convertView;
			if (view == null)
			{
				count++;
				view = _context.LayoutInflater.Inflate(Resource.Layout.InstructorRow, parent, false);
				var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
				var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
				var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

				var vh = new ViewHolder { Photo = photo, Name = name, Specialty = specialty };
				view.Tag = vh;
			}
			var viewHolder = (ViewHolder)view.Tag;
			var instructor = _instructorList[position];	

			viewHolder.Photo.SetImageDrawable(ImageAssetCacher.Get(view.Context, instructor.ImageUrl));

			viewHolder.Name.Text = instructor.Name;
			viewHolder.Specialty.Text = instructor.Specialty;

			return view;
		}

		public int GetPositionForSection(int sectionIndex)
		{
			return _positionForSection[sectionIndex];
		}

		public int GetSectionForPosition(int position)
		{
			return _sectionForPosition[position];
		}

		public Java.Lang.Object[] GetSections()
		{
			return _sectionHeaders;
		}

		private readonly Activity _context;
		private readonly IList<Instructor> _instructorList;
		private readonly Java.Lang.Object[] _sectionHeaders;
		private readonly IDictionary<int, int> _sectionForPosition;
		private readonly IDictionary<int, int> _positionForSection;
	}

}

