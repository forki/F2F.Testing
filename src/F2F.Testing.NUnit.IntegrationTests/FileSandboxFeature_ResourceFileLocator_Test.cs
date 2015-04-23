﻿using System;
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
	public class FileSandboxFeature_ResourceFileLocator_Test : FileSandboxFeature
	{
		public FileSandboxFeature_ResourceFileLocator_Test()
			: base(new ResourceFileLocator(typeof(FileSandboxFeature_ResourceFileLocator_Test)))
		{
		}

		[TestCase("testdata/TextFile1.txt")]
		public void When_Providing_File__Should_Exist(string fileName)
		{
			// Arrange

			// Act
			var absoluteFile = Sandbox.ProvideFile(fileName);

			// Assert
			File.Exists(absoluteFile).Should().BeTrue();
		}

		[TestCase("testdata/TextFile1.txt", "Hello World!")]
		public void When_Providing_File__Should_Contain_Expected_Content(string fileName, string expectedContent)
		{
			// Arrange

			// Act
			var absoluteFile = Sandbox.ProvideFile(fileName);

			// Assert
			File.ReadAllText(absoluteFile).Should().Be(expectedContent);
		}
	}
}