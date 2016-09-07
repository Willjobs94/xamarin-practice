using System.Collections.Generic;
using Android.Content;
using Android.Graphics.Drawables;

namespace ArrayListAdapterPractice
{
	public static class ImageAssetCacher
	{

		private static readonly IDictionary<string, Drawable> _cache = new Dictionary<string, Drawable>();

		public static Drawable Get(Context context, string imageUrl)
		{
			if (!_cache.ContainsKey(imageUrl))
			{
				var photoStream = context.Assets.Open(imageUrl);
				var drawable = Drawable.CreateFromStream(photoStream, null);
				_cache.Add(imageUrl, drawable);
			}

			return _cache[imageUrl];
		}
	}
}

