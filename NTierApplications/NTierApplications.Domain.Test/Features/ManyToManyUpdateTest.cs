using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NTierApplications.Domain.Test.Features
{
	[TestClass]
	public class ManyToManyUpdateTest
	{
		[TestMethod]
		public void AddRemoveItems()
		{
			// Arrange
			IList<int> newList = new List<int>() { 1, 2, 3 };
			IList<int> currentList = new List<int>() {1, 3, 4, 5};
			IList<int> finalList = currentList;

			// Act
			var addedList = newList.Except(currentList).ToList();
			var deletedList = currentList.Except(newList).ToList();

			addedList.ForEach(x => finalList.Add(x));
			deletedList.ForEach(x => finalList.Remove(x));

			// Assert
			Assert.AreEqual(1, addedList.Count());
			Assert.AreEqual(2, deletedList.Count());
			Assert.AreEqual(3, finalList.Count());
		}
	}
}
