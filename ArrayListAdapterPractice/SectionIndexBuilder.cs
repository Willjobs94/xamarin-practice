using System;
using System.Collections.Generic;
using Java.Lang;

namespace ArrayListAdapterPractice
{
	public static class SectionIndexBuilder 
	{

		public static IDictionary<int, int> BuildPositionForSectionMap(IList<Instructor> data)
		{
			var positionMap = new Dictionary<int, int>();
			var letters = new List<char>();
			var section = -1;
			for (int i = 0; i < data.Count; i++)
			{
				if (!letters.Contains(data[i].Name[0]))
				{
					letters.Add(data[i].Name[0]);
					section++;
					positionMap.Add(section, i);
				}
			}

			return positionMap;
		}

		public static IDictionary<int, int> BuildSectionForPositionMap(IList<Instructor> data)
		{
			var setionMap = new Dictionary<int, int>();
			var letters = new List<char>();
			var section = -1;
			for (int i = 0; i < data.Count; i++)
			{
				var letter = data[i].Name[0];
				if (!letters.Contains(letter))
				{
					letters.Add(letter);
					section++;
				}

				setionMap.Add(i, section);
			}

			return setionMap;
		}

		public static Java.Lang.Object[] BuildSectionHeaders(IList<Instructor> data)
		{
			var letters = new List<char>();
			var sortedLetters = new SortedSet<char>();
			foreach (var instructor in data)
			{
				if (!sortedLetters.Contains(instructor.Name[0]))
				{
					letters.Add(instructor.Name[0]);
					sortedLetters.Add(instructor.Name[0]);
				}
			}

			var javaArray = new Java.Lang.Object[letters.Count];
			for (int i = 0; i < letters.Count; i++)
			{
				javaArray[i] = letters[i];
			}

			return javaArray;
		}

	}
}

