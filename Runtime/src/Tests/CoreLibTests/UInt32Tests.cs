﻿using System;
using System.Collections.Generic;
using System.Testing;
using System.Text;

namespace CoreLibTests {
	[TestFixture]
	public class UInt32Tests {
		[Test]
		public void TypePropertiesAreCorrect() {
			Assert.IsTrue((object)(int)0 is uint);
			Assert.IsFalse((object)0.5 is uint);
			Assert.AreEqual(typeof(uint).FullName, "ss.Int32");
			Assert.IsFalse(typeof(uint).IsClass);
		}

		private T GetDefaultValue<T>() {
			return default(T);
		}

		[Test]
		public void DefaultValueIs0() {
			Assert.AreStrictEqual(GetDefaultValue<uint>(), 0);
		}

		[Test]
		public void DefaultConstructorReturnsZero() {
			Assert.AreStrictEqual(new uint(), 0);
		}

		[Test]
		public void CreatingInstanceReturnsZero() {
			Assert.AreStrictEqual(Activator.CreateInstance<uint>(), 0);
		}

		[Test]
		public void ConstantsWork() {
			Assert.AreEqual(uint.MinValue, 0);
			Assert.AreEqual(uint.MaxValue, 4294967295U);
		}

		[Test]
		public void FormatWorks() {
			Assert.AreEqual(((uint)0x123).Format("x"), "123");
		}

		[Test]
		public void LocaleFormatWorks() {
			Assert.AreEqual(((uint)0x123).LocaleFormat("x"), "123");
		}

		[Test]
		public void ParseWithoutRadixWorks() {
			Assert.AreEqual(uint.Parse("234"), 234);
		}

		[Test]
		public void ParseWithRadixWorks() {
			Assert.AreEqual(uint.Parse("234", 16), 0x234);
		}

		[Test]
		public void ToStringWithoutRadixWorks() {
			Assert.AreEqual(((uint)123).ToString(), "123");
		}

		[Test]
		public void ToStringWithRadixWorks() {
			Assert.AreEqual(((uint)123).ToString(10), "123");
			Assert.AreEqual(((uint)0x123).ToString(16), "123");
		}

		[Test]
		public void GetHashCodeWorks() {
			Assert.AreEqual   (((uint)0).GetHashCode(), ((uint)0).GetHashCode());
			Assert.AreEqual   (((uint)1).GetHashCode(), ((uint)1).GetHashCode());
			Assert.AreNotEqual(((uint)0).GetHashCode(), ((uint)1).GetHashCode());
		}

		[Test]
		public void EqualsWorks() {
			Assert.IsTrue (((uint)0).Equals((uint)0));
			Assert.IsFalse(((uint)1).Equals((uint)0));
			Assert.IsFalse(((uint)0).Equals((uint)1));
			Assert.IsTrue (((uint)1).Equals((uint)1));
		}
	}
}
