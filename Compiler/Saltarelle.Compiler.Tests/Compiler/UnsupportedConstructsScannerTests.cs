﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Saltarelle.Compiler.Tests.Compiler {
	[TestFixture]
	public class UnsupportedConstructsScannerTests : CompilerTestBase {
		private void AssertCorrect(string code, string feature) {
			var er = new MockErrorReporter();
			Compile(new[] { code }, errorReporter: er, allowUnsupportedConstructs: false);
			Assert.That(er.AllMessages.Count, Is.EqualTo(1));
			Assert.That(er.AllMessages[0].Code, Is.EqualTo(7998));
			Assert.That(er.AllMessages[0].Args[0], Is.EqualTo(feature));
		}

		[Test]
		public void YieldReturnIsReportedAsUnsupported() {
			AssertCorrect(@"
using System.Collections.Generic;
class C {
	public IEnumerable<object> M() {
		yield return null;
	}
}
", "yield return");
		}

		[Test]
		public void YieldBreakIsReportedAsUnsupported() {
			AssertCorrect(@"
using System.Collections.Generic;
class C {
	public IEnumerable<object> M() {
		yield break;
	}
}
", "yield break");
		}

		[Test]
		public void AwaitIsReportedAsUnsupported() {
			AssertCorrect(@"
using System.Threading;
class C {
	public Task<int> F() { return null; }

	public async Task<double> M() {
		int i = await F();
		return (double)i;
	}
}
", "await");
		}

		[Test]
		public void StructIsReportedAsUnsupported() {
			AssertCorrect(@"
struct S {
}
", "user-defined value type (struct)");
		}
	}
}
