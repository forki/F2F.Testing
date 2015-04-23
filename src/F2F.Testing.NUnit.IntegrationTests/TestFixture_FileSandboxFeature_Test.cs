using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using F2F.Sandbox;
using F2F.Testing.NUnit.Sandbox;
using FluentAssertions;
using NUnit.Framework;

namespace F2F.Testing.NUnit.IntegrationTests
{
	[TestFixture]
	public class TestFixture_FileSandboxFeature_Test : TestFixture
	{
		public TestFixture_FileSandboxFeature_Test()
		{
			Register(new FileSandboxFeature(new ResourceFileLocator(typeof(TestFixture_FileSandboxFeature_Test))));
		}

		[Test]
		public void When_Requesting_Sandbox_Fixture__Should_Not_Be_Null()
		{
			// Act
			var sut = Use<FileSandboxFeature>();

			// Assert
			sut.Sandbox.Should().NotBeNull();
		}

		[Test]
		public void When_Providing_File__Then_File_Should_Exist()
		{
			// Arrange
			var sut = Use<FileSandboxFeature>();

			// Act
			var file = sut.Sandbox.ProvideFile("testdata/TextFile1.txt");

			// Assert
			File.Exists(file).Should().BeTrue();
		}
	}
}